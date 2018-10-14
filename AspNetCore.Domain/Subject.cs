namespace AspNetCore.Domain
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Subject
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public int TeacherId { get; set; }

        [JsonIgnore]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
