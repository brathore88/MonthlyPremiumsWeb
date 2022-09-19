using MonthlyPremiumsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyPremiumsWeb.Repository
{
	public class MonthlyPremium : IMonthlyPremium
	{
		public async Task<double> GetPremium(int Age, int SumInsured, string OccupatioRating)
		{
			var data = Calculate.GetOccupationRating();
			double occupationRating = 0;
			data.TryGetValue(OccupatioRating, out occupationRating);
			double deathPremium = (SumInsured * occupationRating * Age) / 1000 * 12;
			await Task.CompletedTask;
			return deathPremium;
		}
	}
}
