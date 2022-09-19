using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyPremiumsWeb.Repository
{
	public interface IMonthlyPremium
	{
		Task<double> GetPremium(int Age, int SumInsured, string OccupatioRating);
	}
}
