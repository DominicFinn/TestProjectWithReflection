using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestProjectWithReflection.WhenTheDogsAreLetOut
{
	[TestFixture]
	public class IfThereAreDogs
	{
		private Dog[] dogs { get; set; }

		public IfThereAreDogs()
		{
			this.dogs = new Dog[0];
		}

		[SetUp]
		public void Setup()
		{
			var fileName = TestFileStructure.File(this.GetType().Name);
			
			if(File.Exists(fileName))
			{
				var json = File.ReadAllText(fileName);
				JToken root = JObject.Parse(json);

				if (root["Dogs"] != null)
				{
					this.dogs = JsonConvert.DeserializeObject<Dog[]>(root["Dogs"].ToString()) ?? new Dog[0];
				} else
				{
					dogs = new Dog[0];
				}
			} else
			{
				throw new TestFileStructure.NoTestFileException();
			}	
		}

		[Test]
		public void WeShouldKnowWhoReleasedThem()
		{
			foreach (Dog dog in this.dogs)
			{
				Assert.NotNull(dog.ReleasedBy);
			}
		}
	}
}