namespace AspNetCore.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Teacher
    {
        public int TeacherId { get; set; }

        [StringLength(30, ErrorMessage = "You must indicate the name of the teacher")]
        [Required(ErrorMessage = "The name of the teacher is obligatory")]
        public string Name { get; set; }

        // DataType attribute actually doesn't perform validation on field.
        // MVC validate Age when applying binding from post data to model
        [Range(18, 100, ErrorMessage = "You must have an age between 18 and 100")]
        [Required(ErrorMessage = "You must indicate the age")]
        public int? Age { get; set; } // In order to make your Required attribute works you need to make field nullable

        public string Photo { get; set; }

        public List<Subject> Subjects { get; set; }
    }
}
