using System.ComponentModel.DataAnnotations;

namespace AmanahTask.ViewModels
{
    public class BlogEditViewModel
    {
        public long ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
