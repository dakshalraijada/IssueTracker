using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core
{
    public class IssueComment
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public virtual Issue Issue { get; set; }
        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
        [Required]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
