using APIpractice.Helpers;
using APIpractice.Model;
using Microsoft.AspNetCore.Mvc;
using NHibernate;


namespace APIpractice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StudentController : Controller
    {


        [HttpGet]
        public IActionResult GetAllStudents()
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var students = session.Query<Student>().ToList();
                return Ok(students);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var student = session.Get<Student>(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest();
            }

            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newStudent);
                    transaction.Commit();
                }
                return CreatedAtAction(nameof(GetStudent), new { id = newStudent.Id }, newStudent);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var student = session.Get<Student>(id);
                if (student == null)
                {
                    return NotFound();
                }

                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(student);
                    transaction.Commit();
                }

                return Ok(student);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var student = session.Get<Student>(id);
                if (student == null)
                {
                    return NotFound();
                }

                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(student);
                    transaction.Commit();
                }
                return NoContent(); // 204 No Content response
            }
        }

    }
}
