﻿namespace Going.Plaid.AssetReport;

/// <summary>
/// <para>AssetReportGetRequest defines the request schema for <c>/asset_report/get</c></para>
/// </summary>
public partial class AssetReportPdfGetRequest : RequestBase
{
	/// <summary>
	/// <para>A token that can be provided to endpoints such as <c>/asset_report/get</c> or <c>/asset_report/pdf/get</c> to fetch or update an Asset Report.</para>
	/// </summary>
	[JsonPropertyName("asset_report_token")]
	public string AssetReportToken { get; set; } = default!;
}
