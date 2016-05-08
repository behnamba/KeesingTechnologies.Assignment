using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Data.Base;
using KeesingTechnologies.Assignment.Service.Base;
using KeesingTechnologies.Assignment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Service
{
    public class DocumentService : AssignmentService<Document>, IDocumentService
    {
        public DocumentService(IUnitOfWork unitofWork) : base(unitofWork)
        {
        }

        public List<Document> GetDocumentList(DateTime start, DateTime end)
        {
            return Get(p => p.ScanDate > start && p.ScanDate < end);
        }
    }
}
