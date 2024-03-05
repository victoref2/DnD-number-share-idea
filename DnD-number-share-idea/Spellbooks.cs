using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_number_share_idea
{
    public class SpellService
    {
        public static class GlobalSpellbook
        {
            public static List<Spell> Spells = new List<Spell>();

            public static Spell FindSpellById(int id)
            {
                return Spells.FirstOrDefault(spell => spell.Id == id);
            }
        }
        public static List<Spell> GetPlayerSpells(Player player)
        {
            return player.SpellIds.Select(id => GlobalSpellbook.FindSpellById(id))
                                  .Where(spell => spell != null).ToList();
        }

        public static void AddSpellToPlayer(Player player, int spellId)
        {
            if (GlobalSpellbook.Spells.Any(spell => spell.Id == spellId) && !player.SpellIds.Contains(spellId))
            {
                player.SpellIds.Add(spellId);
                // Optionally, notify about the change
            }
        }
    }

    public class Spell : INotifyPropertyChanged
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Range { get; set; }
        public string Damage { get; set; }
        public string Components { get; set; }
        public string Description { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
