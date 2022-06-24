using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? RpgClass { get; set; }
        public User? User { get; set; }
        public ICollection<Weapon>? Weapons { get; set; }
    }
}