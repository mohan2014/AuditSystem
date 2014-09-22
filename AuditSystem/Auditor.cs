using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AuditSystem
{

   
    public class ConsoleAuditor : IAuditor
    {

        // compares any type of object and returns only the property name of changed values
        public IList<string> CompareObject(object obj1, object obj2)
        {
            // get property types
            Type type1 = obj1.GetType();
            Type type2 = obj2.GetType();

            // get all properties
            PropertyInfo[] type1Properties = type1.GetProperties();
            PropertyInfo[] type2Properties = type2.GetProperties();

            var diffList = new List<string>();

            // loop through  properties 
            for (int i = 0; i < type1Properties.Length; i++)
            {
                var val1 = type1Properties[i].GetValue(obj1, null);
                var val2 = type2Properties[i].GetValue(obj2, null);

                if (val1 == null ^ val2 == null)
                {
                    diffList.Add(type1Properties[i].Name);
                }

                if (val1 != null && val2 != null)
                {
                    if (!type1Properties[i].GetValue(obj1, null).Equals(type2Properties[i].GetValue(obj2, null)))
                    {
                        if (type1Properties[i].IsDefined(typeof(DisplayNameAttribute), true))
                        {
                            var displayNameAttribute = type1Properties[i].GetCustomAttributes(typeof(DisplayNameAttribute), true)[0] as DisplayNameAttribute;
                            if (displayNameAttribute != null)
                                diffList.Add(displayNameAttribute.DisplayName);
                        }
                        else
                        {
                            diffList.Add(type1Properties[i].Name);
                        }
                    }
                }
            }

            return diffList;
        }
    }
}
