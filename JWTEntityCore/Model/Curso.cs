using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTEntityCore.Model
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Turno { get; set; }
    }
}
