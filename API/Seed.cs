using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace API
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<User> userManager){
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User{DisplayName = "meza360", UserName = "Giovani", Email="meza@gmail.com", Characters = new List<Character> {new Character{Name = "Legolas",RpgClass = "Archer"}}},
                    new User{DisplayName = "barrueto111", UserName = "Barrueto", Email="barrueto@gmail.com",Characters = new List<Character> {new Character{Name = "Anibal",RpgClass = "Dwarf"}}},
                    new User{DisplayName = "ingeniero", UserName = "Ingeniero", Email="ing@gmail.com",Characters = new List<Character> {new Character{Name = "Raven",RpgClass = "Mage"}}}
                };

                foreach (User user in users)
                {
                    await userManager.CreateAsync(user,"test");
                }
            }   

            if (!context.Characters.Any())
            {
                
                var characters = new List<Character>
                {
                    new Character{Name = "Legolas",RpgClass = "Archer",Weapons = new List<Weapon>{new Weapon{Name="Sword",Damage=100},new Weapon{Name="Arch",Damage=50}}},
                    new Character{Name = "Anibal",RpgClass = "Dwarf", Weapons= new List<Weapon> {new Weapon{Name="Bow",Damage=20},new Weapon{Name="Nunchaku",Damage=10}}},
                    new Character{Name = "Raven",RpgClass = "Mage", Weapons = new List<Weapon> {new Weapon{Name="Blade",Damage=110},new Weapon{Name="Knife",Damage=35}}},
                    new Character{Name = "Superman",RpgClass = "Superhero", Weapons = new List<Weapon> {new Weapon{Name="Nunchaku",Damage=10},new Weapon{Name="Blade",Damage=110}}},
                    new Character{Name = "Batman",RpgClass = "Superhero", Weapons = new List<Weapon> {new Weapon{Name="Nunchaku",Damage=10},new Weapon{Name="Blade",Damage=110}}}
                };
                
                foreach (Character ch in characters)
                {
                    context.Characters.Add(ch);
                    await context.SaveChangesAsync();
                }
            }

            if (!(context.Weapons.Any()))
            {
                var weapons = new List<Weapon>
                {
                    new Weapon{Name="Sword",Damage=100},
                    new Weapon{Name="Arch",Damage=50},
                    new Weapon{Name="Bow",Damage=20},
                    new Weapon{Name="Nunchaku",Damage=10},
                    new Weapon{Name="Blade",Damage=110},
                    new Weapon{Name="Knife",Damage=35}
                 
                };
                
                foreach (Weapon weap in weapons)
                {
                    context.Weapons.Add(weap);
                    await context.SaveChangesAsync();
                }
            }
            
            
            
        }
    }
}