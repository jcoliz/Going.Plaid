namespace Going.Plaid.Entity;

/// <summary>
/// <para>A filter to apply to <c>depository</c>-type accounts</para>
/// </summary>
public class DepositoryFilter
{
	/// <summary>
	/// <para>An array of account subtypes to display in Link. If not specified, all account subtypes will be shown. For a full list of valid types and subtypes, see the <a href="https://plaid.com/docs/api/accounts#account-type-schema">Account schema</a>.</para>
	/// </summary>
	[JsonPropertyName("account_subtypes")]
	public IReadOnlyList<Entity.DepositoryAccountSubtype> AccountSubtypes { get; set; } = default!;
}