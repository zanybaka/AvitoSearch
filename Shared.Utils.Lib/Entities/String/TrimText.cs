namespace Shared.Utils.Lib.Entities.String
{
    public class TrimText
    {
        private readonly string _input;

        public TrimText(string input)
        {
            _input = input ?? "";
        }

        public static implicit operator string(TrimText obj)
        {
            return obj.Trim();
        }

        public string Trim()
        {
            return _input.Trim();
        }

        public string TrimLeft()
        {
            return _input.TrimStart();
        }

        public string TrimRight()
        {
            return _input.TrimEnd();
        }
    }
}