using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2;
using KBS2.model;
using KBS2.model.cijfer;


namespace KBS2.model.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestClass()]
        public class StudentTestconstructors
        {
            [TestMethod()]
            public void WillCreataNewStudent_WhenAllParametersareMet()
            {
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                if (a.ID == null || a.Naam == null || a.Cijfers == null)
                {
                    Assert.Fail();
                }
                Assert.AreEqual(1, 1);
            }
        }

        [TestClass()]
        public class gehaaldeECTest
        {
            [TestMethod()]
            public void TODO()
            {
                Assert.Fail();
            }
        }

        [TestClass()]
        public class gemisteECTest
        {
            [TestMethod()]
            public void TODO()
            {
                Assert.Fail();
            }
        }

        [TestClass()]
        public class totaalECTest
        {
            [TestMethod()]
            public void TODO()
            {
                Assert.Fail();
            }
        }
    }
}