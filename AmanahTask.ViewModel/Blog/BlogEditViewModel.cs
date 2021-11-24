using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
