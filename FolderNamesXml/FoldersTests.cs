using System.Linq;
using NUnit.Framework;

namespace FolderNamesXml
{
	[TestFixture]
	public class FoldersTests
	{
		[Test]
		public void FolderNames_GivenXmlAndStartingLetter_ShouldReturnFoldersStartingWithStartingLetter()
		{
			// Arrange
			string xml =
				"<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
				"<folder name=\"c\">" +
				"<folder name=\"program files\">" +
				"<folder name=\"uninstall information\" />" +
				"</folder>" +
				"<folder name=\"users\" />" +
				"</folder>";

			// Act
			var folderNames = Folders.FolderNames(xml, 'u');

			// Assert
			Assert.That(folderNames.Count(), Is.EqualTo(2));
		}
	}
}
