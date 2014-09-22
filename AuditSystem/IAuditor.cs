using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditSystem
{
    // Interface
    public interface IAuditor
    {

        IList<string> CompareObject(object obj1, object obj2);

    }
}
