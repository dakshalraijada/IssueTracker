using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core
{
    public class Project
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [Required]
        public string Name { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<IssueStatus> IssueStatuses { get; set; }
    }
}
