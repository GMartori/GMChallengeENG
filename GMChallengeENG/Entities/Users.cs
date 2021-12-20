using System;
using System.ComponentModel.DataAnnotations;

namespace GMChallengeENG.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
