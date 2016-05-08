using KeesingTechnologies.Assignment.Common.Exceptions;
using KeesingTechnologies.Assignment.Core.Document;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.UnitTest.Domain
{
    [TestClass]
    public class ProductUnitTest
    {
        public ProductUnitTest()
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
