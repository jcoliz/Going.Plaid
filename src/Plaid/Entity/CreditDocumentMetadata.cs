namespace Going.Plaid.Entity;

/// <summary>
/// <para>Object representing metadata pertaining to the document.</para>
/// </summary>
public record CreditDocumentMetadata
{
	/// <summary>
	/// <para>The name of the document.</para>
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; init; } = default!;

	/// <summary>
	/// <para>The type of document.</para>
	/// <para><c>PAYSTUB</c>: A paystub.</para>
	/// <para><c>BANK_STATEMENT</c>: A bank statement.</para>
	/// <para><c>US_TAX_W2</c>: A W-2 wage and tax statement provided by a US employer reflecting wages earned by the employee.</para>
	/// <para><c>US_MILITARY_ERAS</c>: An electronic Retirement Account Statement (eRAS) issued by the US military.</para>
	/// <para><c>US_MILITARY_LES</c>: A Leave and Earnings Statement (LES) issued by the US military.</para>
	/// <para><c>US_MILITARY_CLES</c>: A Civilian Leave and Earnings Statment (CLES) issued by the US military.</para>
	/// <para><c>GIG</c>: Used to indicate that the income is related to gig work. Does not necessarily correspond to a specific document type.</para>
	/// <para><c>NONE</c>: Used to indicate that there is no underlying document for the data.</para>
	/// <para><c>UNKNOWN</c>: Document type could not be determined.</para>
	/// </summary>
	[JsonPropertyName("document_type")]
	public string? DocumentType { get; init; } = default!;

	/// <summary>
	/// <para>Signed URL to retrieve the underlying file.</para>
	/// </summary>
	[JsonPropertyName("download_url")]
	public string? DownloadUrl { get; init; } = default!;

	/// <summary>
	/// <para>The processing status of the document.</para>
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; init; } = default!;
}