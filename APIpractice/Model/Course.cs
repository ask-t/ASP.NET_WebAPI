using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace APIpractice.Model
{
    public class Course
    {
        public virtual string COURSE_ID { get; set; }
        public virtual string COURSE_NAME { get;set; }
        public virtual string COURSE_CODE { get; set; }
        public virtual string COURSE_DESC { get; set; }
        public virtual string COURSE_SECTION { get; set; }
        public virtual int CREDIT { get; set; }
    }
}
