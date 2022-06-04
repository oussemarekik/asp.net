﻿namespace WebApplication3.Models
{
    public class School
    {
        public int SchoolID { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAdress { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Group> Group { get; set; }

    }
}
