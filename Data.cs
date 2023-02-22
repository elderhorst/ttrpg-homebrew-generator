namespace Homebrew
{
	public class Spell
	{
		public string Name;
		public string Level;
		public string School;
		public bool Ritual;
		public bool Concentration;
		public string CastingTime;
		public string Range;
		public string Components;
		public string Duration;
		public string Source;
		public string[] Description;
	}
	
	public class SpellList
	{
		public Dictionary<string, List<string>[]> Spells {get; private set;}
		
		public SpellList()
		{
			Spells = new Dictionary<string, List<string>[]>();
			
			InitClass("Artificer");
			InitClass("Bard");
			InitClass("Cleric");
			InitClass("Druid");
			InitClass("Paladin");
			InitClass("Ranger");
			InitClass("Sorcerer");
			InitClass("Warlock");
			InitClass("Wizard");
		}
		
		private void InitClass(string name)
		{
			Spells.Add(name, new List<string>[10]);
			
			for (int i = 0; i < Spells[name].Length; i++)
			{
				Spells[name][i] = new List<string>();
			}
		}
		
		public void AddSpell(string key, int level, string spell)
		{
			if (!Spells.ContainsKey(key))
			{
				Console.WriteLine($"The key '{key}' does not exist!");
				return;
			}
			
			if (level < 0 || level >= Spells[key].Length)
			{
				Console.WriteLine($"The provided level '{level}' is invalid!");
				return;
			}
			
			Spells[key][level].Add(spell);
		}
	}
}