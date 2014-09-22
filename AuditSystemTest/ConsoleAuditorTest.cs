using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuditSystem;  // call namespace to test
using System.Collections.Generic;

namespace AuditSystemTest
{
    [TestClass()]
    public class ConsoleAuditorTest
    {
        /// <summary>
        ///A test for CompareObject
        ///</summary>
        [TestMethod()]
        public void CompareObjectTest()
        {
            var target = new ConsoleAuditor();
            object obj1 = new Employee { Id = 5, FirstName = "David", LastName = "Brown", DateOfBirth = new DateTime (1980,01,31)};
            object obj2 = new Employee { Id = 7, FirstName = "Tim", LastName = "Brown", DateOfBirth = new DateTime(1980, 01, 30) };

            IList<string> expected = new List<string> { "First Name", "Id" };
            IList<string> actual = target.CompareObject(obj1, obj2);

            const int expectedCount = 2;
            int actualCount = actual.Count;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expected.Contains("Id"), actual.Contains("Id"));
            Assert.AreEqual(expected.Contains("First Name"), actual.Contains("First Name"));
            Assert.IsFalse(expected.Contains("Last Name"), "Last Name is same in both objects");
        }
    }
}
