using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Autodesk.Revit.DB;
using SampleTool.Helper;
using Autodesk.Revit.UI;
using System.Diagnostics;

namespace SampleTool.Tests.UnitTests
{
    [TestFixture]
    public class HasParameter_Tests
    {
        [SetUp]
        public void Setup()
        {
            // setup pre-test environment
        }

        [TearDown]
        public void Cleanup()
        {
            // cleanup
        }

        [Test]
        public void ShouldNotHaveParameter_Test()
        {
            Document document = Helpers.GeneralHelper.ActiveUIDocument.Document;
            IParameterHelper parameterHelper = new ParameterHelper(document);
            Assert.That(parameterHelper.HasParameter("SomeParameterThatNormallyDoesnotExist"), Iz.False);
        }

        [Test]
        public void ShouldHaveParameter_Test()
        {
            Document document = Helpers.GeneralHelper.ActiveUIDocument.Document;
            IParameterHelper parameterHelper = new ParameterHelper(document);
            Assert.That(parameterHelper.HasParameter("Project Name"), Iz.True);
        }

        [Test]
        public void Test_Test()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            string adFn = ad.FriendlyName;
            int appDomainId = ad.Id;
            Debug.WriteLine("Test AppDomain: " + adFn + " " + appDomainId);
            Debug.WriteLine("GeneralHelper.TestProperty: " + Helpers.GeneralHelper.TestProperty);
            UIDocument uiDoc = Helpers.GeneralHelper.ActiveUIDocument;
            Assert.IsNull(uiDoc);
            //Document document = Helpers.GeneralHelper.ActiveUIDocument.Document;
            //IParameterHelper parameterHelper = new ParameterHelper(document);
            //Assert.That(parameterHelper.HasParameter("Project Name"), Iz.True);
        }
    }
}
