namespace Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Subject
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [JsonIgnore]
        public Teacher Teacher { get; set; }
    }
}
