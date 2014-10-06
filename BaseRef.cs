using System;
using System.Linq;

namespace BaseRef
{
    /// <summary>
    /// BaseRef transcode a integer from and to base 10 to a alphanumerical base where the 
    /// handwritten numbers won't have potential homoglyphes. 
    /// Original source: http://dascritch.net/post/2014/09/23/BaseRef-1-comment-relire-le-num%C3%A9ro-de-commande-%C3%A9crit-%C3%A0-la-main
    /// </summary>
    public class BaseRef
    {
        private const string GLYPHS = "0123456789ACDEFHJKMNPQRTUVWX";
        private int _base = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRef"/> class.
        /// </summary>
        public BaseRef()
        {
            _base = GLYPHS.Length;
        }

        /// <summary>
        /// Determines whether the specified string is a valid BaseRef string.
        /// </summary>
        /// <param name="test">The string to test.</param>
        /// <returns><c>true</c> if the specified string is a valid BaseRef; otherwise, <c>false</c>.</returns>
        public bool IsValid(string test)
        {
            char containsNonAuthorizedGlyph = test.AsEnumerable().FirstOrDefault(glyph => !GLYPHS.Contains(glyph));
            return containsNonAuthorizedGlyph == default(char);
        }

        /// <summary>
        /// Encodes the specified base10 int.
        /// </summary>
        /// <param name="base10Int">The base10 int.</param>
        /// <returns>A BaseRef encoded string</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">base10Int;Works only for positive integers.</exception>
        public string Encode(int base10Int)
        {
            string output = null;
            if (base10Int < 0)
                throw new ArgumentOutOfRangeException("base10Int", "Works only for positive integers.");

            if (base10Int >= _base)
            {
                output += Encode((int)Math.Floor((double)(base10Int / _base)));
                base10Int = base10Int % _base;
            }
            
            output = string.Concat(output, GLYPHS[base10Int]);
            return output;
        }

        /// <summary>
        /// Decodes the specified BaseRef string.
        /// </summary>
        /// <param name="baseRefString">The BaseRef string.</param>
        /// <returns>The decoded value</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">baseRefString;The input string is not a valid BaseRef string</exception>
        public int Decode(string baseRefString)
        {
            baseRefString = baseRefString.ToUpperInvariant();
            if (!IsValid(baseRefString))
                throw new ArgumentOutOfRangeException("baseRefString", "The input string is not a valid BaseRef string");

            int result = 0;
            if (baseRefString.Length > 1)
            {
                result += Decode(baseRefString.Substring(0, baseRefString.Length - 1)) * _base;
                baseRefString = baseRefString.Substring(baseRefString.Length - 1, 1);
            }
            result += GLYPHS.IndexOf(baseRefString[0]);
            return result;
        }
    }
}
