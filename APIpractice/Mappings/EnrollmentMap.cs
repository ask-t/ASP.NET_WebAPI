using APIpractice.Model;
using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace APIpractice.Mappings
{
    public class EnrollmentMap : ClassMap<Enrollment>
    {
        public EnrollmentMap()
        {
            Id(x => x.ENROLLMENT_ID);
            Map(x => x.STUDENT_ID);
            Map(x => x.COURSE_ID);
            Map(x => x.ENROLLMENT_DATE);
        }
    }
}
