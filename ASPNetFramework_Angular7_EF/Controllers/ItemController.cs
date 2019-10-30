using ASPNetFramework_Angular7_EF.Business.Core;
using ASPNetFramework_Angular7_EF.Business.Dtos;
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
        private readonly IItemBusiness _itemBusiness;

        public ItemController(IItemBusiness itemBusiness )
        {
            this._itemBusiness = itemBusiness;
        }
        [Route("getall")]
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            try
            {
                var items =  this._itemBusiness.GetAllItems();
                return Ok(items);
            }

            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }

        [HttpPost]
        [Route("deleteitem")]
        public IHttpActionResult DeleteItem(ToBeDeletedItem item)
        {
            try
            {
                this._itemBusiness.DeleteItem(item.Id);
                return Ok();
            }

            catch (Exception exception)
            {
                return Content(HttpStatusCode.BadRequest, exception);
            }
        }
    }
}
