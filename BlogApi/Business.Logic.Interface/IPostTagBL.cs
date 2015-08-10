using Api.Common.Interface;
using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic.Interface
{
    public interface IPostTagBL : IBusinessLogic<PostTag>
    {
        List<PostTag> GetByPost(Guid idPost);
    }
}
