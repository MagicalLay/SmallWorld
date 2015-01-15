using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;
using Jeu;

namespace UnitTests
/// <summary>
/// Tests sur les algo du wrapper, petite carte seulement
/// </summary>
{
    [TestClass]
    public class UnitTestWrapper
    {
        [TestMethod]
        public unsafe void TestInitialCoord()
        {
            WrapperAlgo algo = new WrapperAlgo();
            StrategySmall sts = new StrategySmall();

            Map m1 = sts.instantiate();
            int* map1 = m1.toInt();
            int* coord1 = algo.WrapperInitialCoord(map1,m1.Size);
            Assert.IsInstanceOfType(coord1[0], typeof(int));
            Assert.IsInstanceOfType(coord1[1], typeof(int));
            Assert.IsInstanceOfType(coord1[2], typeof(int));
            Assert.IsInstanceOfType(coord1[3], typeof(int));
        }
    }
}
