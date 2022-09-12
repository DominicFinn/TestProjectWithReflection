namespace TestProjectWithReflection
{
	internal class TestFileStructure
	{
		public static string File(string name)
		{
			// use path.combine to work on different platforms perhaps
			return "TestFiles\\TestFixtures\\" + name + ".json";
		}

		public class NoTestFileException : FileNotFoundException
		{
			public NoTestFileException() : base("No test file found with the class name supplied")
			{
			}
		}
	}
}