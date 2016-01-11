using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2.model.cijfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBS2.model.cijfer.Tests
{
    [TestClass()]
    public class VakCijferTests
    {
        [TestClass()]
        public class constructortest
        {
            [TestMethod()]
            public void Constructor()
            {
                ToetsCijfer cijfer1 = new ToetsCijfer("01", "o1", "praktijk", 9.4, "11-05-1995");
                ToetsCijfer cijfer2 = new ToetsCijfer("01", "o1", "Theorie", 3.8, "11-05-1995");
                ToetsCijfer cijfer3 = new ToetsCijfer("01", "o1", "multiple-choice", 5.5, "11-05-1995");
                List<ToetsCijfer> cijfers = new List<ToetsCijfer> { cijfer1, cijfer2, cijfer3 };
                VakCijfer test = new VakCijfer("C#", 4, cijfers);
                if (test != null)
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.Fail();
                }
            }

        }

        [TestClass()]
        public class ECsBehaaldTest
        {
            [TestMethod()]
            public void rtrnFalseWheNotAllGradesArePassable()
            {
                bool expected = false;
                ToetsCijfer cijfer1 = new ToetsCijfer("01", "o1", "praktijk", 9.4, "11-05-1995");
                ToetsCijfer cijfer2 = new ToetsCijfer("01", "o1", "Theorie", 3.8, "11-05-1995");
                ToetsCijfer cijfer3 = new ToetsCijfer("01", "o1", "multiple-choice", 5.5, "11-05-1995");
                List<ToetsCijfer> cijfers = new List<ToetsCijfer> { cijfer1, cijfer2, cijfer3 };
                VakCijfer test = new VakCijfer("C#", 4, cijfers);
                bool actual = test.ECsBehaald();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void rtnrTrueWhenAllGradesArePassable()
            {
                bool expected = true;
                ToetsCijfer cijfer1 = new ToetsCijfer("01", "o1", "praktijk", 9.4, "11-05-1995");
                ToetsCijfer cijfer2 = new ToetsCijfer("01", "o1", "Theorie", 6.8, "11-05-1995");
                ToetsCijfer cijfer3 = new ToetsCijfer("01", "o1", "multiple-choice", 5.5, "11-05-1995");
                List<ToetsCijfer> cijfers = new List<ToetsCijfer> { cijfer1, cijfer2, cijfer3 };
                VakCijfer test = new VakCijfer("C#", 4, cijfers);
                bool actual = test.ECsBehaald();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class gemiddeldeTest
        {
            [TestMethod()]
            public void rtrnfourpointfivegrade()
            {
                double expected = 4.5;
                ToetsCijfer cijfer1 = new ToetsCijfer("01", "o1", "praktijk", 4, "11-05-1995");
                ToetsCijfer cijfer2 = new ToetsCijfer("01", "o1", "Theorie", 6.8, "11-05-1995");
                ToetsCijfer cijfer3 = new ToetsCijfer("01", "o1", "multiple-choice", 2.7, "11-05-1995");
                List<ToetsCijfer> cijfers = new List<ToetsCijfer> { cijfer1, cijfer2, cijfer3 };
                VakCijfer test = new VakCijfer("C#", 4, cijfers);
                double actual = test.gemiddelde();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class besteToetsenTest
        {
            [TestMethod()]
            public void rtrnTwoGradesFromTwoTestsFromOneClass()
            {
                int expected = 2;
                ToetsCijfer cijfer1 = new ToetsCijfer("01", "o1", "praktijk", 9.4, "11-05-1995");
                ToetsCijfer cijfer2 = new ToetsCijfer("01", "o1", "praktijk", 3.8, "11-05-1995");
                ToetsCijfer cijfer3 = new ToetsCijfer("01", "o1", "multiple-choice", 5.5, "11-05-1995");
                List<ToetsCijfer> cijfers = new List<ToetsCijfer> { cijfer1, cijfer2, cijfer3 };
                VakCijfer test = new VakCijfer("C#", 4, cijfers);
                int actual = test.besteToetsen().Count();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}