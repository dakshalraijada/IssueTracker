using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core
{
    public class Issue
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int TypeId { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual IssueStatus Status { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<IssueComment> Comments { get; set; }
        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
    }
}
