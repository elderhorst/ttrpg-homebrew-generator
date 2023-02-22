﻿using Homebrew;

Console.WriteLine("Begining to parse files...");

Parser parser = new Parser();

parser.ParseSpellList("Elder Homebrew - Spell List.tsv");
parser.ParseSpells("Elder Homebrew - Spells.tsv");

Console.WriteLine("Completed parsing files...");
Console.WriteLine("Generating document...");

Generator generator = new Generator();

generator.AddSpellList(parser.SpellList);
generator.AddSpells(parser.Spells);

Console.WriteLine("Saving document...");

generator.SaveOutput("output.txt");

Console.WriteLine("Process completed.");
