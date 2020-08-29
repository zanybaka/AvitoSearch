namespace Shared.Utils.Lib.Entities.String
{
    public class IsEmptyString
    {
        private readonly string _input;

        public IsEmptyString(string input)
        {
            _input = input;
        }

        public static implicit operator bool(IsEmptyString obj)
        {
            return string.IsNullOrEmpty(obj.ToString());
        }

        public override string ToString()
        {
            return _input;
        }
    }
}
