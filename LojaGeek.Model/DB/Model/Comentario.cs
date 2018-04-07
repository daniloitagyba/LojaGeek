﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGeek.Model.DB.Model
{
    public class Comentario
    {
        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Coment { get; set; }
        public virtual Produto Produto { get; set; }
    }

    public class ComentarioMap : ClassMapping<Comentario>
    {
        public ComentarioMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Coment);

            ManyToOne(x => x.Produto, m => {
                m.Column("ProdutoId");
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });
        }
    }
}
