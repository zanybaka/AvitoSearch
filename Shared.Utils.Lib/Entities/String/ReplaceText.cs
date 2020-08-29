namespace Shared.Utils.Lib.Entities.String
{
    public class ReplaceText
    {
        private readonly string _old;
        private readonly string _new;
        private readonly string _input;

        public ReplaceText(string input, string old, string @new)
        {
            _old = old;
            _new = @new;
            _input = input ?? "";
        }

        public static implicit operator string(ReplaceText obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _input.Replace(_old, _new);
        }
    }
}