using KeesingTechnologies.Assignment.Core.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Service.Interfaces
{
    public interface IDocumentService : Base.IAssignmentService<Document>
    {
        List<Document> GetDocumentList(DateTime start, DateTime end);
    }
}
