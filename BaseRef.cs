public class BaseRef
{
	private const string GLYPHS = "0123456789ACDEFHJKMNPQRTUVWX";
	private int _base = 0;
	
	public BaseRef()
	{
		_base = GLYPHS.Length;
	}
	
	public bool IsValid(string test)
	{
		char containsNonAuthorizedGlyph = test.AsEnumerable().FirstOrDefault(glyph => !GLYPHS.Contains(glyph));
		return containsNonAuthorizedGlyph == default(char);
	}
	
	public int Decode(string baseRefString)
	{
		baseRefString = baseRefString.ToUpperInvariant();
		if(!IsValid(baseRefString))
		throw new ArgumentOutOfRangeException("baseRefString", "The input string is not a valid BaseRef string");
		int result = 0;
		if(baseRefString.Length > 1)
		{
			result += Decode(baseRefString.Substring(0,baseRefString.Length-1)) * _base;
		}
		result += GLYPHS.IndexOf(baseRefString[0]);
		return result;
	}
}
