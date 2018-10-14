namespace AspNetCore.Domain
{
    using Newtonsoft.Json;

    public class TeacherSubject
    {
        public int TeacherSubjectId { get; set; }

        public int TeacherId { get; set; }

        public int SubjectId { get; set; }

        [JsonIgnore]
        public virtual Teacher Teacher { get; set; }

        [JsonIgnore]
        public virtual Subject Subject { get; set; }
    }
}
