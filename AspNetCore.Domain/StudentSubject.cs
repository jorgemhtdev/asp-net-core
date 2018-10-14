namespace AspNetCore.Domain
{
    using Newtonsoft.Json;

    public class StudentSubject
    {
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        [JsonIgnore]
        public virtual Student Student { get; set; }

        [JsonIgnore]
        public virtual Subject Subject { get; set; }
    }
}
