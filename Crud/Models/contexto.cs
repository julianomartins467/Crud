using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Crud.Models
{
    public class contexto: DbContext
    {
        public DbSet<aluno> Alunos { get; set; }
    }
}