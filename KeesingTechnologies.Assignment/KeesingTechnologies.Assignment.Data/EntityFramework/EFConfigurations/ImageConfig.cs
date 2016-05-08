using KeesingTechnologies.Assignment.Core.Document;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Data.EntityFramework.EFConfigurations
{
    public class ImageConfig : EntityTypeConfiguration<Image>
    {
        public ImageConfig()
        {
            this.Property(p => p.Url).IsRequired();
            this.Property(p => p.PageNumber).IsRequired();
            this.HasRequired(p => p.Document).WithMany(d => d.Images);
        }
    }
}
