using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using JSLibrary.Data;

namespace JSLibrary_Test
{
    [TestFixture]
    public class SortableListTest
    {
        stuff s0, s1, s2, s3, s4;
        SortableList<stuff> sl;
        [SetUp]
        public void Initialization()        
        {        
            sl = new SortableList<stuff>();            
        }

        [Test]
        public void Add_CorrectOrder_Success()
        {
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(1));
            sl.Add(s2 = new stuff(2));
            sl.Add(s3 = new stuff(3));
            sl.Add(s4 = new stuff(4));

            Assert.AreEqual(5, sl.Count);

            Assert.AreEqual(s0, sl[0].First());
            Assert.AreEqual(s1, sl[1].First());
            Assert.AreEqual(s2, sl[2].First());
            Assert.AreEqual(s3, sl[3].First());
            Assert.AreEqual(s4, sl[4].First());
        }

        [Test]
        public void Add_WrongOrder_Success()
        {
            sl.Add(s2 = new stuff(2));
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(1));
            sl.Add(s4 = new stuff(4));
            sl.Add(s3 = new stuff(3));

            Assert.AreEqual(5, sl.Count);

            Assert.AreEqual(s0, sl[0].First());
            Assert.AreEqual(s1, sl[1].First());
            Assert.AreEqual(s2, sl[2].First());
            Assert.AreEqual(s3, sl[3].First());
            Assert.AreEqual(s4, sl[4].First());
        }

        [Test]
        public void Add_DuplicateSortValue_Success()
        {
            sl.Add(s2 = new stuff(2));
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(1));
            sl.Add(s3 = new stuff(2));

            Assert.AreEqual(4, sl.Count);

            Assert.AreEqual(s0, sl[0].First());
            Assert.AreEqual(s1, sl[1].First());
            Assert.AreEqual(s2, sl[2].First());
            Assert.AreEqual(s3, sl[2].Last());
        }

        [Test]
        public void Remove_NoDuplicate_Success()
        {
            sl.Add(s2 = new stuff(2));
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(1));
            sl.Add(s4 = new stuff(4));
            sl.Add(s3 = new stuff(3));

            sl.Remove(s3);

            Assert.AreEqual(4, sl.Count);

            Assert.AreEqual(s0, sl[0].First());
            Assert.AreEqual(s1, sl[1].First());
            Assert.AreEqual(s2, sl[2].First());
            Assert.AreEqual(s4, sl[3].First());
        }

        [Test]
        public void Remove_DuplicateExists_Success()
        {
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(0));
            sl.Add(s2 = new stuff(1));
            sl.Add(s3 = new stuff(2));
            sl.Add(s4 = new stuff(3));
            Assert.AreEqual(5, sl.Count);
            Assert.AreEqual(2, sl[0].Count);

            sl.Remove(s1);

            Assert.AreEqual(4, sl.Count);

            Assert.AreEqual(s0, sl[0].First());
            Assert.AreEqual(1, sl[0].Count);
            Assert.AreEqual(s2, sl[1].First());
            Assert.AreEqual(s3, sl[2].First());
            Assert.AreEqual(s4, sl[3].First());
        }


        [Test]
        public void Enumeration_BothDuplicatesAndNoDuplicates_Success()
        {
            sl.Add(s0 = new stuff(0));
            sl.Add(s1 = new stuff(0));
            sl.Add(s2 = new stuff(1));
            sl.Add(s3 = new stuff(2));
            sl.Add(s4 = new stuff(3));
            int i = 0;

            foreach (stuff s in sl)
            {
                if (i == 0)
                    Assert.IsTrue(s.val == s0.val || s.val == s1.val);
                else if (i == 1)
                    Assert.IsTrue(s.val == s0.val || s.val == s1.val);
                else if (i == 2)
                    Assert.AreEqual(s, s2);
                else if (i == 3)
                    Assert.AreEqual(s, s3);
                else if (i == 4)
                    Assert.AreEqual(s, s4);

                i++;
            }

            Assert.AreEqual(5, i);
        }

        private class stuff : IComparable
        {
            public stuff(int i)
            {
                val = i;
            }
            public int val;
            int IComparable.CompareTo(object obj)
            {
                if (((stuff)obj).val < val)
                    return -1;
                else if (((stuff)obj).val > val)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
