using KeesingTechnologies.Assignment.Common.Exceptions;
using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Data.Base;
using KeesingTechnologies.Assignment.Service;
using KeesingTechnologies.Assignment.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.UnitTest.Domain
{
    [TestClass]
    public class DocumentServiceUnitTest
    {
        IDocumentService sut;
        IUnitOfWork unitofWork;

        [TestInitialize()]
        public void Initialize()
        {
            unitofWork = new Data.InMemoryConcret.AssignmentDataContext();
            sut = new DocumentService(unitofWork);
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        public void Document_Empty_UserName_Will_Fail()
        {
            // arrange 
            Document docLastWeek = new Document {
                ScanDate = DateTime.Now.AddDays(-8),
                UserName = "test"
            };
            Document docThisweek = new Document
            {
                ScanDate = DateTime.Now.AddDays(-1),
                UserName = "test1"
            };

            sut.Add(docLastWeek);
            sut.Add(docThisweek);

            // Action 
            var result = sut.GetDocumentList(DateTime.Now.AddDays(-2), DateTime.Now);

            // assertation
            Assert.AreEqual(1, result.Count);
        }
    }
}
