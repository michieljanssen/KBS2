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
                cijferlist.Add(new VakCijfer("UML", 3, 5.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
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
            public void returns19_whenallgradesarepositive()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 6.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 6.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gehaaldeEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returns0_whenallgradesarenegative()
            {
                int expected = 0;
                int actual = 18;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 3.5));
                cijferlist.Add(new VakCijfer("UML", 3, 1.5));
                cijferlist.Add(new VakCijfer("UML", 1, 2.5));
                cijferlist.Add(new VakCijfer("UML", 5, 5.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gehaaldeEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returns11_for4positivegrades()
            {
                int expected = 11;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 5.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gehaaldeEC();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class gemisteECTest
        {
            [TestMethod()]
            public void returns19_forallgradesnegative()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 2.5));
                cijferlist.Add(new VakCijfer("UML", 3, 3.5));
                cijferlist.Add(new VakCijfer("UML", 1, 3.5));
                cijferlist.Add(new VakCijfer("UML", 5, 5.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gemisteEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returns0_forallgradespositive()
            {
                int expected = 0;
                int actual = 19;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 7.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 8.4));
                cijferlist.Add(new VakCijfer("UML", 6, 9.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gemisteEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void return8_for2gradesnegative()
            {
                int expected = 8;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 5.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gemisteEC();
                Assert.AreEqual(expected, actual);

            }
        }

        [TestClass()]
        public class totaalECTest
        {

            [TestMethod()]
            public void returns19_forallgradesnegative()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 2.5));
                cijferlist.Add(new VakCijfer("UML", 3, 3.5));
                cijferlist.Add(new VakCijfer("UML", 1, 3.5));
                cijferlist.Add(new VakCijfer("UML", 5, 5.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.gemisteEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void returns19_forallgradespositive()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 7.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 8.4));
                cijferlist.Add(new VakCijfer("UML", 6, 9.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.totaalEC();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void return19_for2gradesnegative()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 5.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                actual = a.totaalEC();
                Assert.AreEqual(expected, actual);

            }
            [TestMethod()]
            public void return19_forfailedpluspos()
            {
                int expected = 19;
                int actual = 0;
                List<VakCijfer> cijferlist = new List<VakCijfer>();
                cijferlist.Add(new VakCijfer("UML", 2, 4.5));
                cijferlist.Add(new VakCijfer("UML", 2, 6.5));
                cijferlist.Add(new VakCijfer("UML", 3, 5.5));
                cijferlist.Add(new VakCijfer("UML", 1, 6.5));
                cijferlist.Add(new VakCijfer("UML", 5, 7.4));
                cijferlist.Add(new VakCijfer("UML", 6, 1.2));
                Student a = new Student("Alfa Bet", "S1075802", cijferlist);
                expected = a.totaalEC();
                actual = a.gehaaldeEC() + a.gemisteEC();
                Assert.AreEqual(expected, actual);

            }
        }
    }
}