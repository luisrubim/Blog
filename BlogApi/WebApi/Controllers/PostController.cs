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
    public class PostController : ApiController
    {
        public IHttpActionResult GetById(Guid id)
        {
            try
            {
                return Ok(BusinessLogicFactory<IPostBL>.Instance.GetById(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult GetAll()
        {
            try
            {
                List<Post> lista = BusinessLogicFactory<IPostBL>.Instance.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult GetLast(int count)
        {
            try
            {                
                List<Post> lista = BusinessLogicFactory<IPostBL>.Instance.GetAll();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }
        public IHttpActionResult Get(int index,int count)
        {
            try
            {
                return Ok(BusinessLogicFactory<IPostBL>.Instance.GetAll());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        public IHttpActionResult Save(Post entity)
        {
            try
            {
                if (entity == null)
                {
                    ModelState.AddModelError("Erro", "Objeto não enviado");
                    return BadRequest(ModelState);
                }
                else
                {
                    BusinessLogicFactory<IPostBL>.Instance.Insert(entity);
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", HelperErro.GeraMensagemErro(ex));
                return BadRequest(ModelState);
            }
        }

    }
}