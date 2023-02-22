
/**************************************************************
 *  Filename:    UsersController.cs
 *  Copyright:   .
 *
 *  Description: UsersController ClassFile.
 *
 *  @author:     Dongliang Yi
 *  @version     2021/11/8 17:30:53  @Reviser  Initial Version
 **************************************************************/
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NPlatform.Domains.IService.Sys;
using NPlatform.Dto.Sys;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NPlatform.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : BaseController
    {
        public ILogger<UsersController> Loger { get; set; }
        public IUserService UserSvc { get; set; }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<INPResult>GetList([FromQuery] QueryExp whereExp)
        {
            return await UserSvc.GetListAsync(whereExp);
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<INPResult> GetPage([FromQuery] QueryPageExp whereExp )
        {
            Console.WriteLine("UsersController：线程Id:【{0}】，是否后台线程:【{1}】，是否使用线程池:【{2}】，当前时间:【{3}】",
                Environment.CurrentManagedThreadId.ToString(),
                Thread.CurrentThread.IsBackground,
                Thread.CurrentThread.IsThreadPoolThread,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:fff"));
            var users= await UserSvc.GetPageAsync(whereExp);
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<INPResult> Get(string id)
        {
            var rst= await UserSvc.GetAsync(id);
            StatusCode(409, "");
            return rst;
        }
        // POST api/<UsersController>
        [HttpPost]
        public Task<INPResult> Post([FromBody] UserDto user)
        {
            return UserSvc.PostAsync(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
