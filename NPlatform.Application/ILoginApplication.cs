using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using NPlatform.DTO.VO.Login;
using System.Security.Claims;

namespace NPlatform.Application
{
    public interface ILoginApplication
    {
        IClientStore ClientStore { get; set; }
        IIdentityServerInteractionService Interaction { get; set; }
        IAuthenticationSchemeProvider SchemeProvider { get; set; }

        Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(ClaimsPrincipal user, HttpContext httpContext, string logoutId);
        Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model, HttpContext context);
        Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl, HttpContext httpContext);
        Task<LogoutViewModel> BuildLogoutViewModelAsync(ClaimsPrincipal user, string logoutId);
        string GetApplicationShortName();
    }
}