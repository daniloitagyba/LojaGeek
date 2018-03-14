﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaGeek.Model.DB.Model
{
    public class Cliente
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }

        public static List<Cliente> Clientes = new List<Cliente>();

        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Sobrenome { get; set; }
        public virtual int Cpf { get; set; }
        public virtual String Email { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Sobrenome);
            Property(x => x.Cpf);
            Property(x => x.Email);
            //HasMany(x => x.Enderecos);
        }
    }
}