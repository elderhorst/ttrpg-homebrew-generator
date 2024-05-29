using Homebrew;

Console.WriteLine("Begining to parse files...");

Parser parser = new Parser();

parser.ParseSpellList("local/data/Spell List.tsv");
parser.ParseSpells("local/data/Spells.tsv");
parser.AddClassesToSpells();
parser.ParseMagicItems("local/data/Magic Items.tsv");

Console.WriteLine("Completed parsing files...");
Console.WriteLine("Generating document...");

Generator generator = new Generator();

generator.AddMarkdown("local/pregenerated/Introduction.md");
generator.AddSpellList(parser.SpellList);
generator.AddSpells(parser.Spells);
generator.AddMagicItems(parser.MagicItems);
generator.AddMarkdown("local/pregenerated/Heritages.md");

Console.WriteLine("Saving document...");

generator.SaveOutput("local/output/output.txt");

Console.WriteLine("Process completed.");
