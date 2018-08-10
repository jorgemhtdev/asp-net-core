namespace Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Teacher
    {
        public Teacher()
        {
            Subjects = new List<Subject>();
        }
        public int TeacherId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [Range(18, 100)]
        public int Age { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
