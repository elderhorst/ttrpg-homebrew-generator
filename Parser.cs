namespace Homebrew
{
	public class Parser
	{
		public List<Spell> Spells {get; private set;}
		
		public Parser()
		{
			Spells = new List<Spell>();
		}
		
		private string[] GetFileContents(string filePath)
		{
			if (File.Exists(filePath))
			{
				List<string> lines = new List<string>();
				
				using (StreamReader reader = File.OpenText(filePath))
				{
					string? line;
					while ((line = reader.ReadLine()) != null)
					{
						lines.Add(line);
					}
				}
				
				return lines.ToArray();
			}
			else
			{
				Console.WriteLine($"File at '{filePath}' does not exist!");
				return new string[0];
			}
		}
		
		public void ParseSpells(string filePath)
		{
			string[] lines = GetFileContents(filePath);
			
			for (int i = 1; i < lines.Length; i++)
			{
				Spell? spell = ParseSpell(lines[i]);
				
				if (spell != null)
				{
					Spells.Add(spell);
				}
			}
		}
		
		private Spell? ParseSpell(string line)
		{
			string[] data = line.Split('\t');
			
			if (data.Length < 10)
			{
				Console.WriteLine("Line cannot be formatted.");
				return null;
			}
			
			List<string> description = new List<string>();
			for (int i = 10; i < data.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(data[i]))
				{
					description.Add(data[i]);
				}
			}
			
			return new Spell
			{
				Name = data[0],
				Level = data[1],
				School = data[2],
				Ritual = data[3].Equals("y"),
				Concentration = data[4].Equals("n"),
				CastingTime = data[5],
				Range = data[6],
				Components = data[7],
				Duration = data[8],
				Source = data[9],
				Description = description.ToArray(),
			};
		}
	}
}