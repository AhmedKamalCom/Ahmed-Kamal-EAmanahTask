using System.ComponentModel.DataAnnotations.Schema;

namespace AmanahTask.Models
{
    [Table("Blog")]
    public class Blog : BaseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
