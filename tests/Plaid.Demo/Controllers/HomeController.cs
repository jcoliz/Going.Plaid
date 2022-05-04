﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Going.Plaid.Entity;
using Going.Plaid.Item;
using Going.Plaid.Link;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Going.Plaid.Demo.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(IOptions<Middleware.PlaidCredentials> credentials, PlaidClient client)
		{
			_credentials = credentials.Value;
			_client = client;
		}

		public IActionResult Index() =>
			View(_credentials);

		public async Task<IActionResult> Transactions()
		{
			_client.AccessToken = _credentials.AccessToken;
			var request = new Transactions.TransactionsGetRequest()
			{
				Options = new TransactionsGetRequestOptions()
				{
					Count = 100
				},
				StartDate = DateTime.Now - TimeSpan.FromDays(30),
				EndDate = DateTime.Now
			};
			var result = await _client.TransactionsGetAsync(request);

			return View(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetLinkToken([FromBody] string[] products)
		{
			var result = await _client.LinkTokenCreateAsync(
				new LinkTokenCreateRequest()
				{
					User = new LinkTokenCreateRequestUser { ClientUserId = Guid.NewGuid().ToString(), },
					ClientName = "Going.Plaid.Net Walkthrough Demo ",
					Products = products.Select(p => Enum.Parse<Products>(p, true)).ToArray(),
					Language = Language.English,
					CountryCodes = new[] { CountryCode.Us },
				});
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetAccessToken([FromBody] string publicToken)
		{
			var result = await _client.ItemPublicTokenExchangeAsync(
				new ItemPublicTokenExchangeRequest()
				{
					PublicToken = publicToken,
				});
			_credentials.AccessToken = result.AccessToken;
			System.Diagnostics.Debug.WriteLine($"access_token: '{result.AccessToken}'");

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> GetUpdateToken([FromBody] string accessToken)
		{
			var result = await _client.LinkTokenCreateAsync(
				new LinkTokenCreateRequest()
				{
					AccessToken = accessToken,
					User = new LinkTokenCreateRequestUser { ClientUserId = Guid.NewGuid().ToString(), },
					ClientName = "Going.Plaid.Net Walkthrough Demo ",
					Language = Language.English,
					CountryCodes = new[] { CountryCode.Us },
				});
			System.Diagnostics.Debug.WriteLine($"public_token: '{result.LinkToken}'");

			return Ok(result);
		}

		#region Private Members

		private readonly Middleware.PlaidCredentials _credentials;
		private readonly PlaidClient _client;

		#endregion Private Members
	}
}
