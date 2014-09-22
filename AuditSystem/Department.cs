namespace AuditSystem
{
    public class Department
    {
        public string Name { get; set; }
        public string Address { get; set; }

        // overide equal method for user defined types
        public override bool Equals(object obj)
        {
            var instance = obj as Department;

            if (instance == null) return false;

            return Name == instance.Name && Address == instance.Address;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Address.GetHashCode();
        }
    }
}
