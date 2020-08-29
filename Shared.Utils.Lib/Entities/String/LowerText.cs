using System;

namespace Shared.Utils.Lib.Entities.String
{
    public class LowerText
    {
        private readonly Lazy<string> _lazyValue;

        public LowerText(string input)
        {
            _lazyValue = new Lazy<string>(() => (input ?? "").ToLowerInvariant());
        }

        public static implicit operator string(LowerText obj)
        {
            return obj.ToString();
        }

        public override string ToString()
        {
            return _lazyValue.Value;
        }
    }
}