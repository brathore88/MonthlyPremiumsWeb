using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonthlyPremiumsWeb.Models
{
	public class CalculatePremium
	{
		public string OccupationType { get; set; }
		public double SumInsured { get; set; }
		public int Age { get; set; }

		public static Dictionary<string,double> GetOccupationRating()
		{
			Dictionary<string, double> occupationRating = new Dictionary<string, double>();
			occupationRating.Add("Professional", 1.0);
			occupationRating.Add("White Collar", 1.25);
			occupationRating.Add("Light Manual", 1.50);
			occupationRating.Add("Heavy Manual", 1.75);
			return occupationRating;
		}
	}
}
