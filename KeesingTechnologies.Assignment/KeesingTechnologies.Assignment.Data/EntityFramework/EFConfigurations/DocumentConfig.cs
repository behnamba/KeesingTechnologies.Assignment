using KeesingTechnologies.Assignment.Core.Document;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Data.EntityFramework.EFConfigurations
{
    public class DocumentConfig : EntityTypeConfiguration<Document>
    {
        public DocumentConfig()
        {
            this.Property(p => p.ScanDate).IsRequired();
            this.Property(p => p.UserName).IsRequired().HasMaxLength(50);
        }
    }
}
