
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AmanahTask.Models
{
    [Table("Blog")]

    public class Blog : BaseModel
    {

        public string Title { get; set; }
        public string Body { get; set; }


    }
}
