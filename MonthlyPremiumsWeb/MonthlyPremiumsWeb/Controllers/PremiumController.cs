using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  MonthlyPremiumsWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace MonthlyPremiumsWeb
{
	[Route("api/Premium")]
	[AllowAnonymous]
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
		[HttpGet("GetPremium")]
		[AllowAnonymous]
		public async Task<IActionResult> GetPremium(int Age,int SumInsured,string OccupatioRating)
		{
			var data = Calculate.GetOccupationRating();
			double occupationRating = 0;
			data.TryGetValue(OccupatioRating, out occupationRating);
			double deathPremium = (SumInsured * occupationRating * Age) / 1000 * 12;
			await Task.CompletedTask;
			return Ok(deathPremium);
		}



	}
}
