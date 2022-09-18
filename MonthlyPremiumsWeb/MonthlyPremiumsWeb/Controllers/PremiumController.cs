using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  MonthlyPremiumsWeb.Models;
namespace MonthlyPremiumsWeb
{
	[Route("api/[controller]")]
	[ApiController]
	public class PremiumController : ControllerBase
	{
		// GET: api/<PremiumController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<PremiumController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<PremiumController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<PremiumController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<PremiumController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
		[HttpPost("GetDeathPremium")]
		public async Task<IActionResult> GetDeathPremium(CalculatePremium calculatePremium)
		{
			var data = CalculatePremium.GetOccupationRating();
			double occupationRating = 0;
			data.TryGetValue(calculatePremium.OccupatioRating, out occupationRating);
			double deathPremium = (calculatePremium.SumInsured*occupationRating* calculatePremium.Age)/1000*12;
			await Task.CompletedTask;
			return Ok(deathPremium);
		}
	}
}
