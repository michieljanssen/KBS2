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
        public class VakCijferTest
        {
            [TestMethod()]
            public void WillCreataANewVakCijfer()
            {
                VakCijfer assert = new VakCijfer("UML", 2, new List<ToetsCijfer>());
                if (assert.VakNaam == null || assert.EC == null || assert.Cijfers == null)
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.AreEqual(1, 1);
                }
            }
        }

        [TestClass()]
        public class isVoldoendeTest
        {
            [TestMethod()]
            public void ReturnsFalse_WhenCijferSmallerthan5p5()
            {
                Boolean expected = false;
                VakCijfer v = new VakCijfer("UML", 2, new List<ToetsCijfer>());
                Boolean actual = v.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void ReturnsTrue_WhenCijferEqualto5p5()
            {
                Boolean expected = true;
                VakCijfer v = new VakCijfer("UML", 2, new List<ToetsCijfer>());
                Boolean actual = v.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void ReturnsTrue_WhenCijferLargerthan5p5()
            {
                Boolean expected = true;
                VakCijfer v = new VakCijfer("UML", 2, new List<ToetsCijfer>());
                Boolean actual = v.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}