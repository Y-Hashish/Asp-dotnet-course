namespace Partial_Views.Models
{
    public class List
    {
        public string ListTitle { get; set; } = "";
        public List<string> ListItems{ get; set; } = new List<string>();
    }
}
