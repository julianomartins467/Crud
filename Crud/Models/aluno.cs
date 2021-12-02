using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class aluno

    {   [Key]
        public int codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

    }
}