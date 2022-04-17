namespace NiTiS.RawSalt;

/// <summary>
/// Range from -20.000 to - 19.000
/// </summary>
public enum RawSaltExitCodes : int
{
	UNKNOWN_ERROR = -20_000,
	REGISTRY_ARRAY_EXCEPTION = -19_800,
	REGISTRY_ARRAY_OVERFLOW = -19_801,
}
