namespace Going.Plaid;

public sealed partial class PlaidClient
{
	/// <summary>
	/// <para>The <c>/asset_report/create</c> endpoint initiates the process of creating an Asset Report, which can then be retrieved by passing the <c>asset_report_token</c> return value to the <c>/asset_report/get</c> or <c>/asset_report/pdf/get</c> endpoints.</para>
	/// <para>The Asset Report takes some time to be created and is not available immediately after calling <c>/asset_report/create</c>. When the Asset Report is ready to be retrieved using <c>/asset_report/get</c> or <c>/asset_report/pdf/get</c>, Plaid will fire a <c>PRODUCT_READY</c> webhook. For full details of the webhook schema, see <a href="https://plaid.com/docs/api/products/assets/#webhooks">Asset Report webhooks</a>.</para>
	/// <para>The <c>/asset_report/create</c> endpoint creates an Asset Report at a moment in time. Asset Reports are immutable. To get an updated Asset Report, use the <c>/asset_report/refresh</c> endpoint.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportcreate" /></remarks>
	public Task<AssetReport.AssetReportCreateResponse> AssetReportCreateAsync(AssetReport.AssetReportCreateRequest request) =>
		PostAsync("/asset_report/create", request)
			.ParseResponseAsync<AssetReport.AssetReportCreateResponse>();

	/// <summary>
	/// <para>An Asset Report is an immutable snapshot of a user's assets. In order to "refresh" an Asset Report you created previously, you can use the <c>/asset_report/refresh</c> endpoint to create a new Asset Report based on the old one, but with the most recent data available.</para>
	/// <para>The new Asset Report will contain the same Items as the original Report, as well as the same filters applied by any call to <c>/asset_report/filter</c>. By default, the new Asset Report will also use the same parameters you submitted with your original <c>/asset_report/create</c> request, but the original <c>days_requested</c> value and the values of any parameters in the <c>options</c> object can be overridden with new values. To change these arguments, simply supply new values for them in your request to <c>/asset_report/refresh</c>. Submit an empty string ("") for any previously-populated fields you would like set as empty.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportrefresh" /></remarks>
	public Task<AssetReport.AssetReportRefreshResponse> AssetReportRefreshAsync(AssetReport.AssetReportRefreshRequest request) =>
		PostAsync("/asset_report/refresh", request)
			.ParseResponseAsync<AssetReport.AssetReportRefreshResponse>();

	/// <summary>
	/// <para>The <c>/asset_report/relay/refresh</c> endpoint allows third parties to refresh an Asset Report that was relayed to them, using an <c>asset_relay_token</c> that was created by the report owner. A new Asset Report will be created based on the old one, but with the most recent data available.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/#asset_reportrelayrefresh" /></remarks>
	public Task<AssetReport.AssetReportRelayRefreshResponse> AssetReportRelayRefreshAsync(AssetReport.AssetReportRelayRefreshRequest request) =>
		PostAsync("/asset_report/relay/refresh", request)
			.ParseResponseAsync<AssetReport.AssetReportRelayRefreshResponse>();

	/// <summary>
	/// <para>The <c>/item/remove</c> endpoint allows you to invalidate an <c>access_token</c>, meaning you will not be able to create new Asset Reports with it. Removing an Item does not affect any Asset Reports or Audit Copies you have already created, which will remain accessible until you remove them specifically.</para>
	/// <para>The <c>/asset_report/remove</c> endpoint allows you to remove an Asset Report. Removing an Asset Report invalidates its <c>asset_report_token</c>, meaning you will no longer be able to use it to access Report data or create new Audit Copies. Removing an Asset Report does not affect the underlying Items, but does invalidate any <c>audit_copy_tokens</c> associated with the Asset Report.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportremove" /></remarks>
	public Task<AssetReport.AssetReportRemoveResponse> AssetReportRemoveAsync(AssetReport.AssetReportRemoveRequest request) =>
		PostAsync("/asset_report/remove", request)
			.ParseResponseAsync<AssetReport.AssetReportRemoveResponse>();

	/// <summary>
	/// <para>By default, an Asset Report will contain all of the accounts on a given Item. In some cases, you may not want the Asset Report to contain all accounts. For example, you might have the end user choose which accounts are relevant in Link using the Account Select view, which you can enable in the dashboard. Or, you might always exclude certain account types or subtypes, which you can identify by using the <c>/accounts/get</c> endpoint. To narrow an Asset Report to only a subset of accounts, use the <c>/asset_report/filter</c> endpoint.</para>
	/// <para>To exclude certain Accounts from an Asset Report, first use the <c>/asset_report/create</c> endpoint to create the report, then send the <c>asset_report_token</c> along with a list of <c>account_ids</c> to exclude to the <c>/asset_report/filter</c> endpoint, to create a new Asset Report which contains only a subset of the original Asset Report's data.</para>
	/// <para>Because Asset Reports are immutable, calling <c>/asset_report/filter</c> does not alter the original Asset Report in any way; rather, <c>/asset_report/filter</c> creates a new Asset Report with a new token and id. Asset Reports created via <c>/asset_report/filter</c> do not contain new Asset data, and are not billed.</para>
	/// <para>Plaid will fire a <a href="https://plaid.com/docs/api/products/assets/#product_ready"><c>PRODUCT_READY</c></a> webhook once generation of the filtered Asset Report has completed.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportfilter" /></remarks>
	public Task<AssetReport.AssetReportFilterResponse> AssetReportFilterAsync(AssetReport.AssetReportFilterRequest request) =>
		PostAsync("/asset_report/filter", request)
			.ParseResponseAsync<AssetReport.AssetReportFilterResponse>();

	/// <summary>
	/// <para>The <c>/asset_report/get</c> endpoint retrieves the Asset Report in JSON format. Before calling <c>/asset_report/get</c>, you must first create the Asset Report using <c>/asset_report/create</c> (or filter an Asset Report using <c>/asset_report/filter</c>) and then wait for the <a href="https://plaid.com/docs/api/products/assets/#product_ready"><c>PRODUCT_READY</c></a> webhook to fire, indicating that the Report is ready to be retrieved.</para>
	/// <para>By default, an Asset Report includes transaction descriptions as returned by the bank, as opposed to parsed and categorized by Plaid. You can also receive cleaned and categorized transactions, as well as additional insights like merchant name or location information. We call this an Asset Report with Insights. An Asset Report with Insights provides transaction category, location, and merchant information in addition to the transaction strings provided in a standard Asset Report.</para>
	/// <para>To retrieve an Asset Report with Insights, call the <c>/asset_report/get</c> endpoint with <c>include_insights</c> set to <c>true</c>.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportget" /></remarks>
	public Task<AssetReport.AssetReportGetResponse> AssetReportGetAsync(AssetReport.AssetReportGetRequest request) =>
		PostAsync("/asset_report/get", request)
			.ParseResponseAsync<AssetReport.AssetReportGetResponse>();

	/// <summary>
	/// <para>Plaid can provide an Audit Copy of any Asset Report directly to a participating third party on your behalf. For example, Plaid can supply an Audit Copy directly to Fannie Mae on your behalf if you participate in the Day 1 Certainty™ program. An Audit Copy contains the same underlying data as the Asset Report.</para>
	/// <para>To grant access to an Audit Copy, use the <c>/asset_report/audit_copy/create</c> endpoint to create an <c>audit_copy_token</c> and then pass that token to the third party who needs access. Each third party has its own <c>auditor_id</c>, for example <c>fannie_mae</c>. You’ll need to create a separate Audit Copy for each third party to whom you want to grant access to the Report.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportaudit_copycreate" /></remarks>
	public Task<AssetReport.AssetReportAuditCopyCreateResponse> AssetReportAuditCopyCreateAsync(AssetReport.AssetReportAuditCopyCreateRequest request) =>
		PostAsync("/asset_report/audit_copy/create", request)
			.ParseResponseAsync<AssetReport.AssetReportAuditCopyCreateResponse>();

	/// <summary>
	/// <para>The <c>/asset_report/audit_copy/remove</c> endpoint allows you to remove an Audit Copy. Removing an Audit Copy invalidates the <c>audit_copy_token</c> associated with it, meaning both you and any third parties holding the token will no longer be able to use it to access Report data. Items associated with the Asset Report, the Asset Report itself and other Audit Copies of it are not affected and will remain accessible after removing the given Audit Copy.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/api/products/assets/#asset_reportaudit_copyremove" /></remarks>
	public Task<AssetReport.AssetReportAuditCopyRemoveResponse> AssetReportAuditCopyRemoveAsync(AssetReport.AssetReportAuditCopyRemoveRequest request) =>
		PostAsync("/asset_report/audit_copy/remove", request)
			.ParseResponseAsync<AssetReport.AssetReportAuditCopyRemoveResponse>();

	/// <summary>
	/// <para>Plaid can share an Asset Report directly with a participating third party on your behalf. The shared Asset Report is the exact same Asset Report originally created in <c>/asset_report/create</c>.</para>
	/// <para>To grant access to an Asset Report to a third party, use the <c>/asset_report/relay/create</c> endpoint to create an <c>asset_relay_token</c> and then pass that token to the third party who needs access. Each third party has its own <c>secondary_client_id</c>, for example <c>ce5bd328dcd34123456</c>. You'll need to create a separate <c>asset_relay_token</c> for each third party to whom you want to grant access to the Report.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/none/" /></remarks>
	public Task<AssetReport.AssetReportRelayCreateResponse> AssetReportRelayCreateAsync(AssetReport.AssetReportRelayCreateRequest request) =>
		PostAsync("/asset_report/relay/create", request)
			.ParseResponseAsync<AssetReport.AssetReportRelayCreateResponse>();

	/// <summary>
	/// <para><c>/asset_report/relay/get</c> allows third parties to get an Asset Report that was shared with them, using an <c>asset_relay_token</c> that was created by the report owner.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/none/" /></remarks>
	public Task<AssetReport.AssetReportGetResponse> AssetReportRelayGetAsync(AssetReport.AssetReportRelayGetRequest request) =>
		PostAsync("/asset_report/relay/get", request)
			.ParseResponseAsync<AssetReport.AssetReportGetResponse>();

	/// <summary>
	/// <para>The <c>/asset_report/relay/remove</c> endpoint allows you to invalidate an <c>asset_relay_token</c>, meaning the third party holding the token will no longer be able to use it to access the Asset Report to which the <c>asset_relay_token</c> gives access to. The Asset Report, Items associated with it, and other Asset Relay Tokens that provide access to the same Asset Report are not affected and will remain accessible after removing the given `asset_relay_token.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/none/" /></remarks>
	public Task<AssetReport.AssetReportRelayRemoveResponse> AssetReportRelayRemoveAsync(AssetReport.AssetReportRelayRemoveRequest request) =>
		PostAsync("/asset_report/relay/remove", request)
			.ParseResponseAsync<AssetReport.AssetReportRelayRemoveResponse>();

	/// <summary>
	/// <para><c>/asset_report/audit_copy/get</c> allows auditors to get a copy of an Asset Report that was previously shared via the <c>/asset_report/audit_copy/create</c> endpoint.  The caller of <c>/asset_report/audit_copy/create</c> must provide the <c>audit_copy_token</c> to the auditor.  This token can then be used to call <c>/asset_report/audit_copy/create</c>.</para>
	/// </summary>
	/// <remarks><see href="https://plaid.com/docs/none/" /></remarks>
	public Task<AssetReport.AssetReportGetResponse> AssetReportAuditCopyGetAsync(AssetReport.AssetReportAuditCopyGetRequest request) =>
		PostAsync("/asset_report/audit_copy/get", request)
			.ParseResponseAsync<AssetReport.AssetReportGetResponse>();
}