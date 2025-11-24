namespace Views.Models
{
    public class Person
    {
        public string? name { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public Gender gender { get; set; }
    }
    public enum Gender
    {
        male,female,other
    }
}
