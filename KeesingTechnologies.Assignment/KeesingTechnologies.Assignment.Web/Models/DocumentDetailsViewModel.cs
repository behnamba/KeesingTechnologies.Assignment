using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeesingTechnologies.Assignment.Web.Models
{
    public class DocumentDetailsViewModel
    {
        public DocumentDetailsViewModel()
        {
            Urls = new List<string>();
        }
        public string UserName { get; set; }

        public DateTime ScanDate { get; set; }

        public List<string> Urls { get; set; }
    }
}