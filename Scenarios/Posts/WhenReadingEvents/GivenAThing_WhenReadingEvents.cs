namespace TestProjectWithReflection.Scenarios.Posts.WhenReadingEvents
{
	[TestFixture]
	public class GivenAThing_WhenReadingEvents : EventScenario<GivenAThing_WhenReadingEvents>
	{
		[SetUp]
		public void Setup( )
		{
			base.HydrateEventsForTest(this);
		}

		[Test]
		public void TestAThing()
		{
			Assert.That(this.Events.Count(), Is.EqualTo(3));
		}
	}
}
