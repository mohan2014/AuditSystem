using System;

namespace AuditSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare an interface instance.
            var Auditor = new ConsoleAuditor();

            //Declare instance of the employee class and set the variables with values
            var obj1 = new Employee { Id = 5, FirstName = "David", LastName = "Brown", DateOfBirth = new DateTime(1980, 01, 31) };
            var obj2 = new Employee { Id = 6, FirstName = "John", LastName = "Brown", DateOfBirth = new DateTime(1980, 01, 30) };

            //Call the member method and pass two objects to compare
            var diffList = Auditor.CompareObject(obj1, obj2);

            foreach (var prop in diffList)
            {
                Console.WriteLine(prop);
            }
            Console.ReadKey();
        }
    }
}