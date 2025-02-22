namespace Going.Plaid.Signal;

/// <summary>
/// <para>SignalReturnReportRequest defines the request schema for <c>/signal/return/report</c></para>
/// </summary>
public partial class SignalReturnReportRequest : RequestBase
{
	/// <summary>
	/// <para>Must be the same as the <c>client_transaction_id</c> supplied when calling <c>/signal/evaluate</c></para>
	/// </summary>
	[JsonPropertyName("client_transaction_id")]
	public string ClientTransactionId { get; set; } = default!;

	/// <summary>
	/// <para>Must be a valid ACH return code (e.g. "R01")</para>
	/// </summary>
	[JsonPropertyName("return_code")]
	public string ReturnCode { get; set; } = default!;
}