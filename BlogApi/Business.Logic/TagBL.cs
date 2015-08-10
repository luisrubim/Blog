using Api.Common.BaseClass;
using Business.Entitie;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic
{
    public class TagBL : BusinessLogicBase<Tag>, ITagBL
    {
        public Tag GetByName(string name)
        {
            return db.Tag
                .FirstOrDefault(x => x.Nome.Equals(name));
        }
    }
}
