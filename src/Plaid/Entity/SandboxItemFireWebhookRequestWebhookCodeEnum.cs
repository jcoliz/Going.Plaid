namespace Going.Plaid.Entity;

/// <summary>
/// 
/// </summary>
public enum SandboxItemFireWebhookRequestWebhookCodeEnum
{
	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "DEFAULT_UPDATE")]
	DefaultUpdate,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "NEW_ACCOUNTS_AVAILABLE")]
	NewAccountsAvailable,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "AUTH_DATA_UPDATE")]
	AuthDataUpdate,

	/// <summary>
	/// <para>Catch-all for unknown values returned by Plaid. If you encounter this, please check if there is a later version of the Going.Plaid library.</para>
	/// </summary>
	[EnumMember(Value = "undefined")]
	Undefined,
}