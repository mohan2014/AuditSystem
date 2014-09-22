using System;
using System.ComponentModel;

namespace AuditSystem
{
    public class Employee
    {
        //Declare properties and atrributes
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public int Id { get; set; }

        // Overide equal method for user defined types
        public override bool Equals(object obj)
        {
            var instance = obj as Employee;

            if (instance == null) return false;

            return FirstName == instance.FirstName && LastName == instance.LastName && DateOfBirth == instance.DateOfBirth && Id == instance.Id;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ DateOfBirth.GetHashCode() ^ Id.GetHashCode();
        }
    }
}