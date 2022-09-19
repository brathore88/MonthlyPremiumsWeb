using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MonthlyPremiumsWeb.Models;
using Microsoft.AspNetCore.Authorization;
using MonthlyPremiumsWeb.Repository;

namespace MonthlyPremiumsWeb
{
	[Route("api/Premium")]
	[AllowAnonymous]
	[ApiController]
	public class PremiumController : ControllerBase
	{
		private readonly IMonthlyPremium monthlyPremiumRepository;
		public PremiumController(IMonthlyPremium monthlyPremiumRepository)
		{
			this.monthlyPremiumRepository = monthlyPremiumRepository;

		}
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
		public async Task<IActionResult> GetPremium(int Age, int SumInsured, string OccupatioRating)
		{
			var Result = await monthlyPremiumRepository.GetPremium(Age, SumInsured, OccupatioRating);

			return Ok(Result);
		}
	}

	}
