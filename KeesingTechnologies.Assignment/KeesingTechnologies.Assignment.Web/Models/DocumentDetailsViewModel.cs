using KeesingTechnologies.Assignment.Core.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeesingTechnologies.Assignment.Web.Models
{
    public class DocumentDetailsViewModel
    {
        public DocumentDetailsViewModel()
        {
            Images = new List<ImageViewModel>();
        }

        [Required]
        public string UserName { get; set; }

        public DateTime ScanDate { get; set; }

        public List<ImageViewModel> Images { get; set; }

        public Document ToDocument()
        {
            Document document = new Document
            {
                UserName = UserName,
                ScanDate = DateTime.Now,
            };

            foreach (var item in Images)
            {
                document.AddImage(new Image {
                    PageNumber = item.PageNumber,
                    Url = item.Url
                });
            }

            return document;
        }
    }
}