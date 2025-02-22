namespace Going.Plaid.Entity;

/// <summary>
/// <para>The processor you are integrating with.</para>
/// </summary>
public enum ProcessorTokenCreateRequestProcessorEnum
{
	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "dwolla")]
	Dwolla,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "galileo")]
	Galileo,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "modern_treasury")]
	ModernTreasury,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "ocrolus")]
	Ocrolus,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "prime_trust")]
	PrimeTrust,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "vesta")]
	Vesta,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "drivewealth")]
	Drivewealth,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "vopay")]
	Vopay,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "achq")]
	Achq,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "check")]
	Check,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "checkbook")]
	Checkbook,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "circle")]
	Circle,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "sila_money")]
	SilaMoney,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "rize")]
	Rize,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "svb_api")]
	SvbApi,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "unit")]
	Unit,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "wyre")]
	Wyre,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "lithic")]
	Lithic,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "alpaca")]
	Alpaca,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "astra")]
	Astra,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "moov")]
	Moov,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "treasury_prime")]
	TreasuryPrime,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "marqeta")]
	Marqeta,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "checkout")]
	Checkout,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "solid")]
	Solid,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "highnote")]
	Highnote,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "apex_clearing")]
	ApexClearing,

	/// <summary>
	/// 
	/// </summary>
	[EnumMember(Value = "gusto")]
	Gusto,

	/// <summary>
	/// <para>Catch-all for unknown values returned by Plaid. If you encounter this, please check if there is a later version of the Going.Plaid library.</para>
	/// </summary>
	[EnumMember(Value = "undefined")]
	Undefined,
}