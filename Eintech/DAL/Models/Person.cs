using System;

namespace Eintech.DAL.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
