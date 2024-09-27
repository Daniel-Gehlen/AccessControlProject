namespace AccessControlAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class Service
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class Restriction
    {
        public int Id { get; set; }
        public required string CategoryS { get; set; }
        public required string CategoryP { get; set; }
        public string Rule => $"Some {CategoryS} are not allowed in {CategoryP}.";
    }

    // Predefined Lists
    public static class PredefinedData
    {
        public static List<string> PeopleCategories = new List<string>
        {
            "Employee",
            "Visitor",
            "Contractor",
            "Administrator",
            "Security"
        };

        public static List<string> AreaCategories = new List<string>
        {
            "Restricted Area",
            "Meeting Room",
            "Parking Lot",
            "Recreation Area",
            "Data Center"
        };

        public static List<string> Services = new List<string>
        {
            "Security Service",
            "Maintenance Service",
            "Cleaning Service",
            "IT Support",
            "Reception Service"
        };
    }
}
