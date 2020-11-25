using Localization_Provider_App.Controllers;
using Localization_Provider_App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Localization_Provider_App.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestGetFIOKTranslation()
        {
            var transalatedValueMock = new Mock<ITranslation>();
           
            List<TranslationModel> mockTranslation = new List<TranslationModel>();
            mockTranslation.Add(new TranslationModel { TranslationType = TranslationType.FI, OKButtonText = "FI_OK", CancelButtonText = "FI_Cancel" });
            mockTranslation.Add(new TranslationModel { TranslationType = TranslationType.EN, OKButtonText = "OK", CancelButtonText = "Cancel" });

            
            var mockContext = new Mock<ITranslation>();

            mockContext.Setup(m => m.GetTranslatedValue("FI"));


            //Act
            HomeController controller = new HomeController(mockContext.Object);

            //To do
        }
        [TestMethod]
        public void TestGetFICancelTranslation()
        {

        }
        [TestMethod]
        public void TestGetENOKTranslation()
        {

        }
        [TestMethod]
        public void TestGetENCancelTranslation()
        {

        }
    }
