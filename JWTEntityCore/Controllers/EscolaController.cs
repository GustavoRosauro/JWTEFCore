using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTEntityCore.Data;
using JWTEntityCore.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JWTEntityCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private EscolaDbContext db;
        public EscolaController(DbContextOptions<EscolaDbContext> options)
        {
            db = new EscolaDbContext(options);
        }
        [HttpPost("[action]")]
        [Authorize(Roles = "administrador")]
        public async Task<ActionResult> InserirRegistro(object o)
        {            
            try
            {
                string validator = o.ToString().ToLower();
                if (validator.Contains("email"))
                {
                    Aluno a = JsonConvert.DeserializeObject<Aluno>(o.ToString());
                    db.Alunos.Add(a);
                }
                else if (validator.Contains("especialidade"))
                {
                    Professor p = JsonConvert.DeserializeObject<Professor>(o.ToString());
                    db.Professores.Add(p);
                }
                else if (validator.Contains("turno"))
                {
                    Curso c = JsonConvert.DeserializeObject<Curso>(o.ToString());
                    db.Cursos.Add(c);
                }
                else if (validator.Contains("idprofessor"))
                {
                    AlunoProfessorCurso apc = JsonConvert.DeserializeObject<AlunoProfessorCurso>(o.ToString());
                    db.AlunosCursosProfessores.Add(apc);
                }
                else
                {
                    throw new Exception("Objeto não estava em um formato correto");
                }
                await db.SaveChangesAsync();
                return Ok("Inserido com suceso!");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<object> Get()
        {
            return from i in db.AlunosCursosProfessores
                        select new
                        {
                            Aluno = i.Aluno.Nome,
                            Professor = i.Professor.Nome,
                            Curso = i.Curso.Descricao,
                            Turno = i.Curso.Turno
                        };
        }
        
    }
}