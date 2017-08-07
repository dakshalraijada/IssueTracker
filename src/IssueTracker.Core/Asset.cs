using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IssueTracker.Core
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FileName { get; set; }

        public int FileSize { get; set; }
        [Required]
        [MaxLength(50)]
        public string ContentType { get; set; }

        public byte[] Attachment { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int? IssueId { get; set; }
        public virtual Issue Issue { get; set; }

        [DefaultValue("GETDATE()")]
        public DateTime CreatedDate
        {
            get { return CreatedDate == default(DateTime) ? DateTime.Now : CreatedDate; }
            set { CreatedDate = value; }
        }
    }
}
