using KeesingTechnologies.Assignment.Common.Exceptions;
using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Data.Base;
using KeesingTechnologies.Assignment.Service;
using KeesingTechnologies.Assignment.Service.Interfaces;
using KeesingTechnologies.Assignment.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KeesingTechnologies.Assignment.UnitTest.Domain
{
    [TestClass]
    public class DocumentControllerUnitTest
    {
        IDocumentService documentService;
        IUnitOfWork unitofWork;

        DocumentController sut;

        [TestInitialize()]
        public void Initialize()
        {
            Web.Helper.Bootstraper.InitialDependencyMappings();
            unitofWork = new Data.InMemoryConcret.AssignmentDataContext();
            documentService = new DocumentService(unitofWork);

            sut = new Web.Controllers.DocumentController();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void New_Document_Faile_If_Input_Model_MVC_Validation_Failed()
        {
            // arrange 
            sut.ModelState.AddModelError("fakeError", "fakeError");

            // action
            sut.Post(null);
        }
    }
}
