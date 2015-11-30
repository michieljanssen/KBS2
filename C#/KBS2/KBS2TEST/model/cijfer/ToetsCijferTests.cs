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
    public class ToetsCijferTests
    {
        [TestClass()]
        public class isVoldoendeTest
        {
            [TestMethod()]
            public void returnstrue_whengradebiggerthan5p5()
            {
                bool expected = true;
                bool actual = false;
                ToetsCijfer testcijfer = new ToetsCijfer("S1075802", "Hugo Timmerman", 8.8, "11 mei");
                actual = testcijfer.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returnstrue_whengradeis5p5()
            {

                bool expected = true;
                bool actual = false;
                ToetsCijfer testcijfer = new ToetsCijfer("S1075802", "Hugo Timmerman", 5.5, "11 mei");
                actual = testcijfer.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returnsfalse_whengradeislowerthan5p5()
            {
                bool expected = false;
                bool actual = true;
                ToetsCijfer testcijfer = new ToetsCijfer("S1075802", "Hugo Timmerman", 3.5, "11 mei");
                actual = testcijfer.isVoldoende();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}