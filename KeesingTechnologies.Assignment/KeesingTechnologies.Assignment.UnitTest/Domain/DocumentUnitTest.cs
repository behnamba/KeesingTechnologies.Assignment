using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeesingTechnologies.Assignment.Core.Document;
using KeesingTechnologies.Assignment.Common.Exceptions;

namespace KeesingTechnologies.Assignment.UnitTest.Domain
{
    [TestClass]
    public class DocumentUnitTest
    {
        public DocumentUnitTest()
        {
        }

        Document sut;

        [TestInitialize()]
        public void Initialize()
        {
            sut = new Document();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void Document_Empty_UserName_Will_Fail()
        {
            // Action 
            sut.UserName = "";
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void Document_Duplicated_UserName_Will_Fail()
        {
            // Action 
            sut.UserName = "";
        }
    }
}
