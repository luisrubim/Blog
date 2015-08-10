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
    public class UsuarioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Logar(string email, string senha)
        {
            try
            {
                return Ok(BusinessLogicFactory<IUsuarioBL>.Instance.Logar(email, senha));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", HelperErro.GeraMensagemErro(ex));
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erro", ex.Message);
                return BadRequest(ModelState);
            }
        }

        public IHttpActionResult Save(Usuario entity)
        {
            try
            {
                if (entity == null)
                {
                    ModelState.AddModelError("Erro", "Objeto não enviado");
                    return BadRequest(ModelState);
                }
                else if (entity.Id != Guid.Empty)
                    BusinessLogicFactory<IUsuarioBL>.Instance.Update(entity);
                else
                {
                    entity.Id = Guid.NewGuid();
                    BusinessLogicFactory<IUsuarioBL>.Instance.Insert(entity);
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