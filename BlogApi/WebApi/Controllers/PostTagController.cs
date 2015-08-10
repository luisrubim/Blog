using Api.Common.Factory;
using Api.Helper;
using Business.Entitie;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class PostTagController : ApiController
    {
        public IHttpActionResult GetByPost(Guid id)
        {
            try
            {
                return Ok(BusinessLogicFactory<IPostTagBL>.Instance.GetByPost(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

    }
}