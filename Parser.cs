namespace Homebrew
{
	public class Parser
	{
		public SpellList SpellList = new SpellList();
		public List<Spell> Spells {get; private set;}
		public List<MagicItem> MagicItems {get; private set;}
		
		public Parser()
		{
			Spells = new List<Spell>();
			MagicItems = new List<MagicItem>();
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
				Console.WriteLine($"Line cannot be formatted, length is '{data.Length}'.");
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
		
		public void ParseSpellList(string filePath)
		{
			string[] lines = GetFileContents(filePath);
			string[,] data = FormatSpellListData(lines);
			
			for (int i = 0; i < data.GetLength(0); i++)
			{
				ParseSpellListColumn(data, i);
			}
		}
		
		private string[,] FormatSpellListData(string[] lines)
		{
			int width = 9;
			
			string[,] data = new string[width, lines.Length];
			
			for (int i = 0; i < data.GetLength(1); i++)
			{
				string[] lineData = lines[i].Split('\t');
				
				if (lineData.Length != width)
				{
					Console.WriteLine($"Could not parse line '{i}' of spell list file.");
					continue;
				}
				
				for (int k = 0; k < data.GetLength(0); k++)
				{
					data[k, i] = lineData[k];
				}
			}
			
			return data;
		}
		
		private void ParseSpellListColumn(string[,] data, int column)
		{
			string key = data[column, 0];
			int level = 0;
			
			for (int i = 2; i < data.GetLength(1); i++)
			{
				string value = data[column, i];
				int newLevel;
				
				if (string.IsNullOrWhiteSpace(value))
				{
					continue;
				}
				
				if (int.TryParse(value, out newLevel))
				{
					level = newLevel;
				}
				else
				{
					SpellList.AddSpell(key, level, value);
				}
			}
		}
		
		public void ParseMagicItems(string filePath)
		{
			string[] lines = GetFileContents(filePath);
			
			for (int i = 1; i < lines.Length; i++)
			{
				MagicItem? magicItem = ParseMagicItem(lines[i]);
				
				if (magicItem != null)
				{
					MagicItems.Add(magicItem);
				}
			}
		}
		
		private MagicItem? ParseMagicItem(string line)
		{
			string[] data = line.Split('\t');
			
			if (data.Length < 4)
			{
				Console.WriteLine($"Line cannot be formatted, length is '{data.Length}'.");
				return null;
			}
			
			List<string> description = new List<string>();
			for (int i = 4; i < data.Length; i++)
			{
				if (!string.IsNullOrWhiteSpace(data[i]))
				{
					description.Add(data[i]);
				}
			}
			
			return new MagicItem
			{
				Name = data[0],
				Rarity = data[1],
				Type = data[2],
				Attunement = data[3].Equals("y"),
				Description = description.ToArray(),
			};
		}
	}
}