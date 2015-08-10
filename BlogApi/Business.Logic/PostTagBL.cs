using Api.Common.BaseClass;
using Api.Common.Factory;
using Business.Entitie;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Logic
{
    public class PostTagBL : BusinessLogicBase<PostTag>, IPostTagBL
    {
        public List<PostTag> GetByPost(Guid idPost)
        {
            return db.PostTag
                .Include("Tag")
                .Where(x => x.IdPost == idPost)
                .ToList();
        }
    }
}
