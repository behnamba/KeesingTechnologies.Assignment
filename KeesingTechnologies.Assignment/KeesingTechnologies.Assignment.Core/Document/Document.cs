using KeesingTechnologies.Assignment.Common.DDD;
using KeesingTechnologies.Assignment.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Core.Document
{
    public class Document : EntityBase, IAggregateRoot
    {
        public Document()
        {
            Images = new List<Image>();
        }

        string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new RequiredException("Username is requierd");
                }
                _UserName = value;
            }
        }

        public DateTime ScanDate { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public void AddImage(Image image)
        {
            if (Images.Where(p => p.PageNumber == image.PageNumber).Count() > 0)
            {
                throw new DuplicatevalueException("Image page number can't be duplicated");
            }

            Images.Add(image);
        }

        public void Remove(Image image)
        {
            Images.ToList().RemoveAll(p => p.Id == image.Id);
        }

        protected override void Validate()
        {
        }
    }
}
