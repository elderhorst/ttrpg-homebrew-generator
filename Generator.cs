using System.Text;

namespace Homebrew
{
	public class Generator
	{
		StringBuilder builder;
		
		public Generator()
		{
			builder = new StringBuilder();
		}
		
		public void SaveOutput(string path)
		{
			File.WriteAllText(path, builder.ToString());
		}
		
		public void AddSpells(List<Spell> spells)
		{
			builder.AppendLine("## Spells");
			builder.AppendLine();
			
			for (int i = 0; i < spells.Count; i++)
			{
				AddSpell(spells[i]);
			}
			
			builder.AppendLine("\\page");
		}
		
		private void AddSpell(Spell spell)
		{
			builder.AppendLine($"#### {spell.Name}");
			builder.AppendLine($"*{Utility.FormatNumber(spell.Level)}-level {spell.School.ToLower()}" + ((spell.Ritual) ? " (ritual)" : string.Empty) + "*");
			builder.AppendLine();
			builder.AppendLine($"**Casting Time:** :: {spell.CastingTime}");
			builder.AppendLine($"**Range:** :: {spell.Range}");
			builder.AppendLine($"**Components:** :: {spell.Components}");
			builder.AppendLine($"**Duration:** :: {spell.Duration}" + ((spell.Concentration) ? ", concentration" : string.Empty));
			builder.AppendLine();
			
			for (int i = 0; i < spell.Description.Length; i++)
			{
				string text = spell.Description[i];
				
				if (text.Contains("At Higher Levels:"))
				{
					text = text.Replace("At Higher Levels:", "**At Higher Levels:**");
				}
				
				builder.AppendLine(text);
				builder.AppendLine();
			}
		}
		
		public void AddSpellList(SpellList spellList)
		{
			builder.AppendLine("## Spell List");
			builder.AppendLine();
			builder.AppendLine("{{spellList,wide");
			
			foreach (string key in spellList.Spells.Keys)
			{
				AddKeySpells(spellList, key);
			}
			
			builder.AppendLine("}}");
			builder.AppendLine("\\page");
		}
		
		private void AddKeySpells(SpellList spellList, string key)
		{
			builder.AppendLine($"### {key}");
			
			List<string>[] spells = spellList.Spells[key];
			
			for (int i = 0; i < spells.Length; i++)
			{
				if (spells[i].Count == 0)
				{
					continue;
				}
				
				builder.AppendLine("##### " + ((i == 0) ? "Cantrips" : $"{Utility.FormatNumber(i)} Level"));
				
				for (int k = 0; k < spells[i].Count; k++)
				{
					builder.AppendLine($"- {spells[i][k]}");
				}
			}
			
			builder.AppendLine();
		}
	}
}