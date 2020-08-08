using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JWTEntityCore.Model
{
    public class AlunoProfessorCurso
    {
        [Key]
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int IdProfessor { get; set; }
        public virtual Professor Professor { get; set; }
        public int IdCurso { get; set; }
        public Curso Curso { get; set; }
    }
}
