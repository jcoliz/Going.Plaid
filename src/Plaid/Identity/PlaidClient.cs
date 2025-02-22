namespace Going.Plaid;

public sealed partial class PlaidClient
{
	/// <summary>
	/// <para>The <c>/identity/get</c> endpoint allows you to retrieve various account holder information on file with the financial institution, including names, emails, phone numbers, and addresses. Only name data is guaranteed to be returned; other fields will be empty arrays if not provided by the institution.</para>
	/// <para>This request may take some time to complete if identity was not specified as an initial product when creating the Item. This is because Plaid must communicate directly with the institution to retrieve the data.</para>
	/// <para>Note: In API versions 2018-05-22 and earlier, the <c>owners</c> object is not returned, and instead identity information is returned in the top level <c>identity</c> object. For more details, see <a href="https://plaid.com/docs/api/versioning/#version-2019-05-29">Plaid API versioning</a>.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/identity/#identityget" /></remarks>
	public Task<Identity.IdentityGetResponse> IdentityGetAsync(Identity.IdentityGetRequest request) =>
		PostAsync("/identity/get", request)
			.ParseResponseAsync<Identity.IdentityGetResponse>();
}