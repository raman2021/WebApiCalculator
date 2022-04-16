using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        BlazorDemoEntities _db = new BlazorDemoEntities();

        [HttpGet]
        [Route("UserLogin")]
        public IHttpActionResult LoginUser(string EmailId, string Password)
        {
            Registration LoginData = new Registration();
            if (!string.IsNullOrEmpty(EmailId) && !string.IsNullOrEmpty(Password))
            {
                 LoginData = (from u in _db.Registrations
                                where u.Email.ToUpper() == EmailId.ToUpper() && u.Password == Password
                                select u).FirstOrDefault();
            }
            return Ok(new { Status = 0, Data = LoginData });
        }

        [HttpPost]
        [Route("UserRegistration")]
        public IHttpActionResult UserRegistration(string JsonRegister)
        {
            Registration Obj = JsonConvert.DeserializeObject<Registration>(JsonRegister);

            bool response = false;
            if (Obj != null)
            {
                Registration Data = new Registration();
                Data.Id = Obj.Id;
                Data.FirstName = Obj.FirstName;
                Data.LastName = Obj.LastName;
                Data.Email = Obj.Email;
                Data.Password = Obj.Password;
                _db.Registrations.Add(Data);
                _db.SaveChanges();
                response = true;

            }
            return Ok(new { Status = 0, Data = response });
        }
    }
}