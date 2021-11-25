using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmanahTask.Models
{
    public class BaseModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual long ID { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
