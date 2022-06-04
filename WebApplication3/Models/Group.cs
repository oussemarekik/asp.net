namespace WebApplication3.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public int SchoolID { get; set; }
        public School School { get; set; }
    }
}
