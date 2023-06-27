using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CastleDecksContext : DbContext
    {
        public CastleDecksContext(DbContextOptions<CastleDecksContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            // N:N
            builder.Entity<Item_and_Monster>()
                .HasKey(itemMonster => new
                {
                    itemMonster.ItemId,
                    itemMonster.MonstersId
                });

            builder.Entity<Item_and_Monster>()
                .HasOne(itemMonster => itemMonster.Monsters)
                .WithMany(monsters => monsters.DropItems_Monster)
                .HasForeignKey(itemMonster => itemMonster.MonstersId);

            builder.Entity<Monsters>()
                .HasOne(monster => monster.Category_Monster)
                .WithMany(category => category.Monsters_Category)
                .HasForeignKey(monster => monster.CategoryId);

            builder.Entity<Item_and_Monster>()
                .HasOne(itemMonster => itemMonster.Item)
                .WithMany(item => item.ItemsMonsters)
                .HasForeignKey(itemMonster => itemMonster.ItemId);

            // 1:N
            builder.Entity<Weapons>()
                .HasOne(weapons => weapons.TypeWeapon_Weapon)
                .WithMany(type => type.Weapons_TypeWeapon)
                .HasForeignKey(weapons => weapons.TypeWeaponId);

            // 1:1
           //builder.Entity<Familiar>()
             //   .HasOne(familiar => familiar.Spell_Familiar)
           //     .WithOne(spell => spell.Familiar_Spell)
         //       .HasForeignKey(familiar => familiar.SpellId);
        }

        public DbSet<Weapons> Weapons { get; set; }
        public DbSet<TypeWeapon> TypesWeapons { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Monsters> Monsters { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Item_and_Monster> ItemMonster { get; set; }
        public DbSet<Familiar> Familiars { get; set; }
        public DbSet<Spell> Spells { get; set; }
    }
}
