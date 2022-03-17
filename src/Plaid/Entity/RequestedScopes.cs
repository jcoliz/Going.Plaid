namespace Going.Plaid.Entity;

/// <summary>
/// <para>Scope of required and optional account features or content from a ConnectedApplication.</para>
/// </summary>
public record RequestedScopes
{
	/// <summary>
	/// <para>Enumerates the account subtypes that the application wishes for the user to be able to select from. For more details refer to Plaid documentation on account filters.</para>
	/// </summary>
	[JsonPropertyName("account_filters")]
	public Entity.AccountFilter AccountFilters { get; init; } = default!;

	/// <summary>
	/// <para>The application requires that accounts be limited to a specific cardinality.</para>
	/// </summary>
	[JsonPropertyName("account_selection_cardinality")]
	public Entity.AccountSelectionCardinality AccountSelectionCardinality { get; init; } = default!;
}