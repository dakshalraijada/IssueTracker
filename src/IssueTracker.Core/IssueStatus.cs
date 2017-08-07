using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core
{
    public class IssueStatus
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
    }
}
