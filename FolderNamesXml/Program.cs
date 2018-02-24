using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

[Serializable, XmlRoot("folder")]
public class Folder
{
	[XmlAttribute("name")]
	public string Name { get; set; }

	[XmlElement("folder")]
	public List<Folder> SubFolders { get; set; }

	public bool StartsWith(string startingString)
	{
		return Name.StartsWith(startingString);
	}

	public bool StartsWith(char startingChar)
	{
		return StartsWith(startingChar.ToString());
	}
}

public class Folders
{
	public static IEnumerable<string> FolderNames(string xml, char startingLetter)
	{
		var xmlSerializer = new XmlSerializer(typeof(Folder));
		var folders = (Folder)xmlSerializer.Deserialize(new StringReader(xml));

		var foldersMatchingCharacter = new List<string>();
		if (folders.StartsWith(startingLetter))
		{
			foldersMatchingCharacter.Add(folders.Name);
		}
		foldersMatchingCharacter.AddRange(folders.SubFolders.Where(x => x.StartsWith(startingLetter)).Select(x => x.Name));
		foldersMatchingCharacter.AddRange(folders.SubFolders.SelectMany(x => x.SubFolders).Where(x => x.StartsWith(startingLetter)).Select(x => x.Name));

		return foldersMatchingCharacter;
	}
}

