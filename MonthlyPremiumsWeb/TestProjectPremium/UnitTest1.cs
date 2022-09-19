using MonthlyPremiumsWeb.Repository;
using NUnit.Framework;

namespace TestProjectPremium
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public  void Test1()
		{
			MonthlyPremium monthlyPremium = new MonthlyPremium();
			var data= monthlyPremium.GetPremium(34,500, "Light Manual");
			Assert.IsNotNull(data);
		}
	}
}