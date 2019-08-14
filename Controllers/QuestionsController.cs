using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace acme_backend.Controllers
{
    [Produces("application/json")]
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        readonly ProjectContext context;

        public QuestionsController(ProjectContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Models.Question> Get()
        {
            return context.Questions;
        }
        [HttpGet("{projectId}")]
        public IEnumerable<Models.Question> Get([FromRoute] int projectId)
        {
            return context.Questions.Where(q => q.ProjectId == projectId);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Question question)
        {
            var project = context.Project.SingleOrDefault(q => q.ID == question.ProjectId);

            if (project == null)
                return NotFound();
            context.Questions.Add(question);
            await context.SaveChangesAsync();
            return Ok(question);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Question question)
        {
            if (id != question.ID)
                return BadRequest();

            context.Entry(question).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Ok(question);
        }
    }
}
