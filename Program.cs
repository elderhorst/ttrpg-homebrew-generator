using Homebrew;

Console.WriteLine("Begining to parse files...");

Parser parser = new Parser();

parser.ParseSpellList("Elder Homebrew - Spell List.tsv");
parser.ParseSpells("Elder Homebrew - Spells.tsv");
parser.ParseMagicItems("Elder Homebrew - Magic Items.tsv");

Console.WriteLine("Completed parsing files...");
Console.WriteLine("Generating document...");

Generator generator = new Generator();

generator.AddMarkdown("Elder Introduction.md");
generator.AddSpellList(parser.SpellList);
generator.AddSpells(parser.Spells);
generator.AddMagicItems(parser.MagicItems);

Console.WriteLine("Saving document...");

generator.SaveOutput("output.txt");

Console.WriteLine("Process completed.");
