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
    public class ImageUnitTest
    {
        public ImageUnitTest()
        {
        }

        Image sut;

        [TestInitialize()]
        public void Initialize()
        {
            sut = new Image();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            sut = null;
        }

        [TestMethod]
        [ExpectedException(typeof(RequiredException))]
        public void Image_Empty_Url_Will_Fail()
        {
            // action
            sut.Url = "";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFormatException))]
        public void Image_Invalid_Url_Will_Fail()
        {
            // action
            sut.Url = "test";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidValueException))]
        public void Image_Negetive_Or_Zero_Page_Will_Fail()
        {
            // action
            sut.PageNumber = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicatevalueException))]
        public void Image_Duplicated_ImageNumber_Will_Fail()
        {
            // arrange
            Document dc = new Document();
            dc.AddImage(new Image { PageNumber = 1 });

            // action
            dc.AddImage(new Image { PageNumber = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicatevalueException))]
        public void Remove_One_Image_From_List()
        {
            // arrange
            Document dc = new Document();
            var img1 = new Image { PageNumber = 1 };
            var img2 = new Image { PageNumber = 2 };
            dc.AddImage(img1);
            dc.AddImage(img1);

            // action
            dc.Remove(img2);

            // assertation
            Assert.AreEqual(1, dc.Images.Count);
        }
    }
}
