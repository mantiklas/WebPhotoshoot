using ASPNetFramework_Angular7_EF.Business.Core;
using ASPNetFramework_Angular7_EF.Business.Dtos;
using ASPNetFramework_Angular7_EF.Business.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPNetFramework_Angular7_EF.Controllers
{
    [RoutePrefix("api/item")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemController : ApiController
    {
        private readonly IEmailSender _emailSender;

        public ItemController(IEmailSender emailSender)
        {
            this._emailSender = emailSender;
        }

        [HttpPost]
        [Route("sendemail")]
        public IHttpActionResult SendEmail(EmailDto ed)
        {
            try
            {
                this._emailSender.Send(ed);
                return Ok();
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }
    }
}
