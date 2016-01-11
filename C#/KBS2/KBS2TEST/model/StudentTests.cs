using Microsoft.VisualStudio.TestTools.UnitTesting;
using KBS2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KBS2.model.cijfer;

namespace KBS2.model.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestClass()]
        public class StudentTest
        {
            
            [TestMethod()]
            public void Constructor()
            {
                ToetsCijfer t1 = new ToetsCijfer("01", "nm1", "mult", 2.4, "11-05-2015");
                ToetsCijfer t2 = new ToetsCijfer("01", "nm1", "mult", 4.2, "11-05-2015");
                ToetsCijfer t3 = new ToetsCijfer("01", "nm1", "theo", 8.0, "11-07-2015");
                VakCijfer Vc1 = new VakCijfer("C#", 2, new List<ToetsCijfer> { t1, t2, t3 });
                ToetsCijfer aa = new ToetsCijfer("01", "nm1", "prak", 3.8, "11-05-2015");
                ToetsCijfer ab = new ToetsCijfer("01", "nm1", "theo", 8.3, "11-05-2015");
                ToetsCijfer ac = new ToetsCijfer("01", "nm1", "theo", 5.0, "11-07-2015");
                ToetsCijfer ad = new ToetsCijfer("01", "nm1", "mult", 5.9, "11-07-2015");
                VakCijfer Vc2 = new VakCijfer("UML", 4, new List<ToetsCijfer> { aa,ab,ac,ad });
                ToetsCijfer ba = new ToetsCijfer("01", "nm1", "prak", 6.2, "11-05-2015");
                ToetsCijfer bb = new ToetsCijfer("01", "nm1", "theo", 8.3, "11-05-2015");
                ToetsCijfer bc = new ToetsCijfer("01", "nm1", "mult", 5.0, "11-07-2015");
                ToetsCijfer bd = new ToetsCijfer("01", "nm1", "mult", 5.9, "11-07-2015");
                VakCijfer Vc3 = new VakCijfer("DB", 4, new List<ToetsCijfer> { ba,bb,bc,bd });
                Student teststudent = new Student("nm1", "01", new List<VakCijfer> { Vc1, Vc2 ,Vc3});
                if(teststudent == null)
                {
                    Assert.Fail();
                } else { Assert.IsTrue(true); }
            }
        }

        [TestClass()]
        public class getVakCijferTest
        {
            ToetsCijfer t1 = new ToetsCijfer("01", "nm1", "mult", 2.4, "11-05-2015");
            ToetsCijfer t2 = new ToetsCijfer("01", "nm1", "mult", 4.2, "11-05-2015");
            ToetsCijfer t3 = new ToetsCijfer("01", "nm1", "theo", 8.0, "11-07-2015");
            ToetsCijfer aa = new ToetsCijfer("01", "nm1", "prak", 3.8, "11-05-2015");
            ToetsCijfer ab = new ToetsCijfer("01", "nm1", "theo", 8.3, "11-05-2015");
            ToetsCijfer ac = new ToetsCijfer("01", "nm1", "theo", 5.0, "11-07-2015");
            ToetsCijfer ad = new ToetsCijfer("01", "nm1", "mult", 5.9, "11-07-2015");
            ToetsCijfer ba = new ToetsCijfer("01", "nm1", "prak", 6.2, "11-05-2015");
            ToetsCijfer bb = new ToetsCijfer("01", "nm1", "theo", 8.3, "11-05-2015");
            ToetsCijfer bc = new ToetsCijfer("01", "nm1", "mult", 5.0, "11-07-2015");
            ToetsCijfer bd = new ToetsCijfer("01", "nm1", "mult", 5.9, "11-07-2015");
            [TestMethod()]
            public void rtrnfourUMLgrades()
            {
                int expected = 4;
                VakCijfer Vc1 = new VakCijfer("C#", 2, new List<ToetsCijfer> { t1, t2, t3 });
                VakCijfer Vc2 = new VakCijfer("UML", 4, new List<ToetsCijfer> { aa, ab, ac, ad });
                VakCijfer Vc3 = new VakCijfer("DB", 4, new List<ToetsCijfer> { ba, bb, bc, bd });
                Student teststudent = new Student("nm1", "01", new List<VakCijfer> { Vc1, Vc2, Vc3 });
                int actual = teststudent.getVakCijfer("UML").Cijfers.Count();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void rtrnthreeCsharpgrades()
            {
                int expected = 3;
                VakCijfer Vc1 = new VakCijfer("C#", 2, new List<ToetsCijfer> { t1, t2, t3 });
                VakCijfer Vc2 = new VakCijfer("UML", 4, new List<ToetsCijfer> { aa, ab, ac, ad });
                VakCijfer Vc3 = new VakCijfer("DB", 4, new List<ToetsCijfer> { ba, bb, bc, bd });
                Student teststudent = new Student("nm1", "01", new List<VakCijfer> { Vc1, Vc2, Vc3 });
                int actual = teststudent.getVakCijfer("C#").Cijfers.Count();
                Assert.AreEqual(expected, actual);
            }
            [TestMethod()]
            public void rtrnfourDBgrades()
            {
                int expected = 4;
                VakCijfer Vc1 = new VakCijfer("C#", 2, new List<ToetsCijfer> { t1, t2, t3 });
                VakCijfer Vc2 = new VakCijfer("UML", 4, new List<ToetsCijfer> { aa, ab, ac, ad });
                VakCijfer Vc3 = new VakCijfer("DB", 4, new List<ToetsCijfer> { ba, bb, bc, bd });
                Student teststudent = new Student("nm1", "01", new List<VakCijfer> { Vc1, Vc2, Vc3 });
                int actual = teststudent.getVakCijfer("DB").Cijfers.Count();
                Assert.AreEqual(expected, actual);
            }
        }

        [TestClass()]
        public class gehaaldeECTest
        {
            [TestMethod()]
            public void a()
            {
                Assert.Fail();
            }
        }

        [TestClass()]
        public class gemisteECTest
        {
            [TestMethod()]
            public void a()
            {
                Assert.Fail();
            }
        }

        [TestClass()]
        public class totaalECTest
        {
            [TestMethod()]
            public void a()
            {
                Assert.Fail();
            }
        }
    }
}