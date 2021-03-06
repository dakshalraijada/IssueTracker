﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Core
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string SubDomain { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<CompanyUser> Users { get; set; }
    }
}
