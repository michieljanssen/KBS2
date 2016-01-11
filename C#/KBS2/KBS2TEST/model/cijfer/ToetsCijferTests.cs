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
        public class Constructor
        {
            [TestMethod()]
            public void correctconstructor()
            {
                ToetsCijfer testcijfer = new ToetsCijfer("1", "nm1", "multiplechoice", 4.5, "11-05-2005");
                if (testcijfer == null)
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.IsTrue(true);
                }

            }
        }
        [TestClass()]
        public class isVoldoende
        {
            [TestMethod()]
            public void false_Ongradelessthan5p5()
            {
                bool expected = false;
                ToetsCijfer testcijfer = new ToetsCijfer("1", "nm1", "multiplechoice", 4.5, "11-05-2005");
                bool actual = testcijfer.ECsBehaald();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void true_ongradeis5p5()
            {
                bool expected = true;
                ToetsCijfer testcijfer = new ToetsCijfer("1", "nm1", "multiplechoice", 5.5, "11-05-2005");
                bool actual = testcijfer.ECsBehaald();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void true_ongradelargerthan5p5()
            {
                bool expected = true;
                ToetsCijfer testcijfer = new ToetsCijfer("1", "nm1", "multiplechoice", 8, "11-05-2005");
                bool actual = testcijfer.ECsBehaald();
                Assert.AreEqual(expected, actual);
            }
        }
    }
}