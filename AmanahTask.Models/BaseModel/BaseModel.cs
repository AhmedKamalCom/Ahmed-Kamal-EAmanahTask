using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmanahTask.Models
{
    public class BaseModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual long ID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
