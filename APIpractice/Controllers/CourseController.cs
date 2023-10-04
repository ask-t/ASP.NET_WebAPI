using Microsoft.AspNetCore.Mvc;
using APIpractice.Model;
using APIpractice.Helpers;
using NHibernate;
using System.Configuration;

namespace APIpractice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var courses = session.Query<Course>().ToList();
                return Ok(courses);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(int id)
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var course = session.Get<Course>(id);
                if(course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
        }

        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course newCouse)
        {
            if (newCouse == null)
            {
                return BadRequest();
            }

            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newCouse);
                    transaction.Commit();
                }
                return CreatedAtAction(nameof(CreateCourse), newCouse);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course updateCourse)
        {
            using (NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var course = session.Get<Course>(id);
                if(course == null)
                {
                    return NotFound();
                }
                if(updateCourse.COURSE_CODE != null)
                {
                    course.COURSE_CODE = updateCourse.COURSE_CODE;
                }
                if (updateCourse.COURSE_ID != null)
                {
                    course.COURSE_ID = updateCourse.COURSE_ID;
                }
                if (updateCourse.COURSE_NAME != null)
                {
                    course.COURSE_NAME = updateCourse.COURSE_NAME;
                }

                if (updateCourse.COURSE_CODE != null)
                {
                    course.COURSE_CODE = updateCourse.COURSE_CODE;
                }
                if (updateCourse.COURSE_DESC != null)
                {
                    course.COURSE_DESC = updateCourse.COURSE_DESC;
                }
                if (updateCourse.CREDIT != null)
                {
                    course.CREDIT = updateCourse.CREDIT;
                }


                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(course);
                    transaction.Commit();
                }
                return Ok(course);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            using(NHibernate.ISession session = NHibernateHelper.SessionFactory.OpenSession())
            {
                var course = session.Get<Course>(id);
                if(course == null)
                {
                    return NotFound();
                }
                using(NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(course);
                    transaction.Commit();
                }
                return Ok(course);
            }
        }

    }
}
