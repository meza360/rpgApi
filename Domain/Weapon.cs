using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Damage  { get; set; }
        public ICollection<Character>? Characters { get; set; }
    }
}