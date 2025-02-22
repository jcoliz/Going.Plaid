namespace Going.Plaid.Entity;

/// <summary>
/// <para>An object containing information about the payroll item.</para>
/// </summary>
public record PayrollItem
{
	/// <summary>
	/// <para>The <c>item_id</c> of the Item associated with this webhook, warning, or error</para>
	/// </summary>
	[JsonPropertyName("item_id")]
	public string ItemId { get; init; } = default!;

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("payroll_income")]
	public IReadOnlyList<Entity.PayrollIncomeObject> PayrollIncome { get; init; } = default!;

	/// <summary>
	/// <para>Details about the status of the payroll item.</para>
	/// </summary>
	[JsonPropertyName("status")]
	public Entity.PayrollItemStatus? Status { get; init; } = default!;
}