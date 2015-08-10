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
    public class PostBL : BusinessLogicBase<Post>, IPostBL
    {
        public override List<Post> GetAll()
        {
            return db.Post
                .Include("Usuario")
                .OrderByDescending(x=>x.Data)
                .ToList();
        }

        public override Post GetById(Guid id)
        {
            return db.Post
                .Include("Usuario")
                .FirstOrDefault(x => x.Id == id);
        }

        public override void Insert(Post item)
        {
            //Exemplo Transation
            //Exemplo tratando a regra
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
            {

                Post postInsert = new Post();
                postInsert.Id = Guid.NewGuid();
                postInsert.Data = item.Data;
                postInsert.IdUsuario = item.IdUsuario;
                postInsert.Titulo = item.Titulo;
                postInsert.Corpo = item.Corpo;

                base.Insert(postInsert);

                foreach(PostTag pt in item.PostTags)
                {
                    Tag tag = BusinessLogicFactory<ITagBL>.Instance.GetByName(pt.Tag.Nome);
                    PostTag postTag = new PostTag();

                    postTag.Id = Guid.NewGuid();
                    postTag.IdPost = postInsert.Id;

                    if(tag == null)
                    {
                        tag = new Tag { Id = Guid.NewGuid(), Nome = pt.Tag.Nome };
                        postTag.IdTag = tag.Id;
                        BusinessLogicFactory<ITagBL>.Instance.Insert(tag);
                    }
                    else
                        postTag.IdTag = tag.Id;                        

                    BusinessLogicFactory<IPostTagBL>.Instance.Insert(postTag);
                }

                ts.Complete();
            }          
        }
    }
}
