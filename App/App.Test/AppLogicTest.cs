using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Logic;

namespace App.Test
{
    [TestClass]
    public class AppLogicTest
    {
        private BaseLogic baseLogic;

        public AppLogicTest()
        {
            baseLogic = new BaseLogic();
        }
        [TestMethod]
        public void LogicReferenceDataGet()
        {
            var rtn = baseLogic.GetReferenceData(1);
            Assert.IsTrue(rtn.ResultStatus.IsSuccess==true);
        }
    }
}
