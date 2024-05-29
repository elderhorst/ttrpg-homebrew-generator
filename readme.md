# TTRPG Homebrew Generator

This project takes sets of data, in the form os tsv and markdown files, and creates a formatted markdown document that can then be imported into an external document renderer, such as Homebrewery. (https://homebrewery.naturalcrit.com/)

This way, the written content can be edited in any text editor of choice, while being saved and stored in a location that works best for the user. The generator was built specifically for DnD 5th Edition content.

## Features

- Read spells, spell lists, and magic items from TSV files and format them.
- Read existing markdown files to be used in the generated markdown document.
- When building the final document the user can choose what order the read data will be printed in the generated markdown document.

### Future Plans

- Subclasses
- Feats
- Heritages

## File Formatting

The following sections have an example of the expected format for the TSV files.

**Note:** Unfortunately, tabs do not render with a consistent amount of whitespace in markdown files.

### Spells

To have multiple paragraphs in the description of the spell, each block of text should be in it's own column. The parser will read the "Description" column and read every remaining column in that row as a part of that rows description.

```
Name	Spell Level	School	Ritual	Concentration	Casting Time	Range	Components	Duration	Source	Description
Magic Image	1	Evocation	y	n	1 action	30 feet	S, M (a crystal)	1 hour	Book Name	This spell makes a magic image appear.
```

### Spell Lists

After loading the file, the parser goes column by column filling out the spell list for each class. It starts with cantrips, ignores blank cells, and when it reads a spell level number, assigns the following spells to that level.

```
Druid	Wizard
Cantrip	Cantrip
Elemental Light	Icebolt
Sprout	Mage Lamp
	
1	1
Rainfall	Summon Entity
Read Runes
Rock Armor	
```

### Magic Items

To have multiple paragraphs in the description of the spell, each block of text should be in it's own column. The parser will read the "Description" column and read every remaining column in that row as a part of that rows description.

```
Name	Rarity	Type	Attunement	Description	
Amulet of Illusion	rare	wonderous item	n	This amulet lets the wearer make minor illusions appear around themselves.	Item adapted from Some Book Name Here.
```

## Notes and Considerations

The generator will add page breaks between different sections (i.e. there will be a page break between the Spell List and Spell pages). However, within each section page breaks will still need to be manually added after the fact. This is because, at the time of this writing, most markdown formatters that the output of this generator will be used with cannot automatically detect when a page break is required.