using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace UnitTests
{

    [TestClass]
    public class UnitTestWrapper
    {

        [TestMethod]
        public void TestWrapper()
        {
            WrapperAlgo algo = new WrapperAlgo();
            int a = algo.computeFoo();
            Assert.AreEqual(a, 1);
        }
    }
}
