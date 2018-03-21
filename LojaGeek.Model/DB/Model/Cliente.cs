using LojaGeek.Model.DB.Model.Validation;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LojaGeek.Model.DB.Model
{
    public class Cliente
    {
        public Cliente()
        {
            var culture = new CultureInfo("pt-BR");
            var v1 = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek).ToString().Substring(0, 3);
            var v2 = DateTime.Now.Month.ToString();
            var dia = DateTime.Now.Day;
            var hora = DateTime.Now.Hour;
            var v3 = (dia + hora).ToString();

            Senha = v1+v2+v3;
        }

        public static List<Cliente> Clientes = new List<Cliente>();

        public virtual Guid Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome")]
        public virtual String Nome { get; set; }
        [Required(ErrorMessage = "Informe o Sobrenome")]
        public virtual String Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o CPF")]
        [Cpf]
        public virtual int Cpf { get; set; }
        [Required(ErrorMessage = "Informe o E-mail")]
        [EmailAddress]
        public virtual String Email { get; set; }
        public virtual String Senha { get; set; }
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
            Property(x => x.Senha);
        }
    }
}
