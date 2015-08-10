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
    public class ComentarioController : ApiController
    {
        public IHttpActionResult GetByPost(Guid guid)
        {
            try
            {
                return Ok(BusinessLogicFactory<IComentarioBL>.Instance.GetByPost(guid));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [Authorize]
        public IHttpActionResult Save(Comentario entity)
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
                    entity.Id = Guid.NewGuid();
                    BusinessLogicFactory<IComentarioBL>.Instance.Insert(entity);
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
