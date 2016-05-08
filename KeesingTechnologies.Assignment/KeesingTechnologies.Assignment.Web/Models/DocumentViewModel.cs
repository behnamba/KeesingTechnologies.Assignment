using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeesingTechnologies.Assignment.Web.Models
{
    public class DocumentViewModel
    {
        public DocumentViewModel()
        {
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime ScanDate { get; set; }

        public int ImageCount { get; set; }
    }
}
