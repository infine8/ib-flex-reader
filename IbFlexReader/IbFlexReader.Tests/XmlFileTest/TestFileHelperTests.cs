﻿
using System;
using System.Linq;
using NUnit.Framework;

namespace IbFlexReader.Tests.TestXml
{
    public class TestFileHelperTests
    {

        private TestFileHelper _tfh;

        [SetUp]
        public void InitTests()
        {
            _tfh = new TestFileHelper();
        }


        [Test]
        public void GetSlnPathTest()
        {
            // Arrange
            bool check = false;
            string exp = @"ib-flex-reader\IbFlexReader";

            // Act
            var path = _tfh.GetSlnPath().Replace("/", "\\");
            if (path.Contains(exp))
            {
                check = true;}

            // Assert
            Assert.IsTrue(check, $"exp: {exp}, current: {path}");

        }


        [Test]
        public void GetTestFilePathTest()
        {
            // Arrange
            string exp = @"\ib-flex-reader\IbFlexReader\IbFlexReader.Tests\bin\Release\XmlFileTest\TestFiles";
            bool check = false;

            // Act
            var path = _tfh.GetTestFilePath().Replace("/", "\\");


            // Assert
            if (path.Contains(exp))
            {
                check = true;
            }
            
            
            Assert.True(check, $"exp: {exp}, current: {path}");

        }

        [Test]
        public void GetTestFilesTest()
        {
            // Arrange
            int xmlsInPath = 2;

            //Act
            var xfiles = _tfh.GetXmlFiles().Count;

            //Assert
           Assert.AreEqual(xmlsInPath, xfiles);

        }

        [Test]
        public void ConvertXmlStringTest()
        {
            // Arrange
            var xmlStart = @"<FlexQueryResponse queryName=";
            bool cont = false;

            //Act
            var stringCol = _tfh.ConvertXmlToString(_tfh.GetXmlFiles());

            //Assert
            for (int i = 0; i < stringCol.Count ;i++)
            {
                if (stringCol[i].Contains(xmlStart))
                {
                    cont = true;
                    Assert.IsTrue(cont);
                }
            }
           

           
        }
    }
}