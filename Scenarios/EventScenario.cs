namespace TestProjectWithReflection.Scenarios
{
	[TestFixture]
	public abstract class EventScenario<T>
	{
		protected IEnumerable<string> Events;

		public EventScenario()
		{
			this.Events = new List<string>();
		}

		protected void HydrateEventsForTest(T instance) 
		{
			if (instance == null)
				return;

			var nameSpace = instance.GetType().Namespace;

			if (nameSpace != null)
			{
				this.Events = this.GetFiles(nameSpace);
			}
		}

		private IEnumerable<string> GetFiles(string nameSpace)
		{
			var directory = string.Join('\\', nameSpace.Split('.').Skip(1)) + "\\Events";
			if (Directory.Exists(directory))
			{
				foreach (var fileName in Directory.GetFiles(directory).OrderBy(fileName => fileName))
				{
					yield return File.ReadAllText(fileName);
				}
			}
		}
	}
}