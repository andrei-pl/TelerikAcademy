namespace StudentSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTimeOffset? TimeSent
        {
            get
            {
                return timeSent.HasValue ? new DateTimeOffset(timeSent.Value, TimeSpan.FromHours(0)) : (DateTimeOffset?)null;
            }
            set
            {
                timeSent = value.HasValue ? value.Value.UtcDateTime : (DateTime?)null;
            }
        }

        [ForeignKey("Student")]
        public int StudentIdentification { get; set; }

        public virtual Student Student { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }
        
        [NotMapped]
        private Nullable<DateTime> timeSent;
    }
}
