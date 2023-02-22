using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using NPlatform.Middleware;
using System.Configuration;
using NPlatform.Infrastructure.Config;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Autofac;
// builder
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutofac();
builder.Host.UseServiceProviderFactory(new Autofac.Extensions.DependencyInjection.AutofacServiceProviderFactory());

#region ����ע��
// 1.�滻controller�������
// 2.ע�� API.DLL ��ע�� controller��
// controller �ھͿ���ʹ������ע���ˡ�
builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

var serviceConfig = builder.Configuration.GetServiceConfig();
string serviceName = serviceConfig.ServiceName;
builder.Services.AddHealthChecks().AddCheck<NHealthChecks>(serviceName); ;
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc($"{serviceConfig.ServiceName}_{serviceConfig.ServiceVersion}", new OpenApiInfo { Title = serviceConfig.ServiceName, Version = serviceConfig.ServiceVersion });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("local", policy =>
    {
        string origins = "http://127.0.0.1,http://localhost:3000";
        policy.AllowAnyOrigin();
        //  .AllowAnyHeader()
        // .AllowAnyMethod()
        //.AllowCredentials();
    });
});

// �����־Provider
builder.Logging.AddLog4Net();

#endregion

builder.Configuration.GetRequiredSection("");

builder.Host.Configure(builder.Configuration);

#region ��������
var app=builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/" + $"{serviceConfig.ServiceName}_{serviceConfig.ServiceVersion}" + "/swagger.json", serviceConfig.ServiceName));
}
app.Lifetime.ConfigConsul(builder.Configuration);


app.UseHealthChecks("/healthChecks");
app.UseHttpsRedirection();
app.UseStaticFiles();

//  app.UseCnblogsHttpsRedirection();
app.UseRouting();

app.UseCors("local");//�����������Ҫ���ϱ����Ӧ
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion