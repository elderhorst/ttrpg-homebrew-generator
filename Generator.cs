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
			builder.AppendLine("### Spells");
			builder.AppendLine();
			
			for (int i = 0; i < spells.Count; i++)
			{
				AddSpell(spells[i]);
			}
		}
		
		private void AddSpell(Spell spell)
		{
			builder.AppendLine($"#### {spell.Name}");
			builder.AppendLine($"*{spell.Level}rd-level {spell.School.ToLower()}");
			builder.AppendLine();
			builder.AppendLine($"**Casting Time:** :: {spell.CastingTime}");
			builder.AppendLine($"**Range:** :: {spell.Range}");
			builder.AppendLine($"**Components:** :: {spell.Components}");
			builder.AppendLine($"**Duration:** :: {spell.Duration}");
			builder.AppendLine();
			
			for (int i = 0; i < spell.Description.Length; i++)
			{
				builder.AppendLine(spell.Description[i]);
				builder.AppendLine();
			}
		}
	}
}