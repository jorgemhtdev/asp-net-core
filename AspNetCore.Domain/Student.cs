namespace AspNetCore.Domain
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }

        [JsonIgnore]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
