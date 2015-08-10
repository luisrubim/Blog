﻿using Api.Common.Interface;
using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic.Interface
{
    public interface IComentarioBL : IBusinessLogic<Comentario>
    {
        List<Comentario> GetByPost(Guid id);
        void InserirComentario(Guid idPost, Guid idUsuario, string Mensagem);
    }
}
