using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeesingTechnologies.Assignment.Web.Models
{
    public class ImageViewModel
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public int PageNumber { get; set; }
    }   
}