using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;
using Jeu;

namespace UnitTests
{

    [TestClass]
    public class UnitTestWrapper
    {
        [TestMethod]
        public unsafe void TestInitialCoord()
        {
            WrapperAlgo algo = new WrapperAlgo();

            StrategySmall sts = new StrategySmall();
            StrategyMedium stm = new StrategyMedium();
            StrategyLarge stl = new StrategyLarge();

            Map m1 = sts.instantiate();
            int* map1 = m1.toInt();
            int* coord1 = algo.WrapperInitialCoord(map1,m1.Size);
            Assert.IsInstanceOfType(coord1[0], typeof(int));
            Assert.IsInstanceOfType(coord1[1], typeof(int));
            Assert.IsInstanceOfType(coord1[2], typeof(int));
            Assert.IsInstanceOfType(coord1[3], typeof(int));

            Map m2 = stm.instantiate();
            int* map2 = m2.toInt();
            int* coord2 = algo.WrapperInitialCoord(map2,m2.Size);
            Assert.IsInstanceOfType(coord2[0], typeof(int));
            Assert.IsInstanceOfType(coord2[1], typeof(int));
            Assert.IsInstanceOfType(coord2[2], typeof(int));
            Assert.IsInstanceOfType(coord2[3], typeof(int));

            Map m3 = stl.instantiate();
            int* map3 = m3.toInt();
            int* coord3 = algo.WrapperInitialCoord(map3,m3.Size);
            Assert.IsInstanceOfType(coord3[0], typeof(int));
            Assert.IsInstanceOfType(coord3[1], typeof(int));
            Assert.IsInstanceOfType(coord3[2], typeof(int));
            Assert.IsInstanceOfType(coord3[3], typeof(int));
        }
    }
}
