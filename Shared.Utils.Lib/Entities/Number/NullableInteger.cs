namespace Shared.Utils.Lib.Entities.Number
{
    public class NullableInteger
    {
        private readonly string _value;
        private readonly int? _defaultValue;

        public NullableInteger(string value, int? defaultValue = null)
        {
            _value = value;
            _defaultValue = defaultValue;
        }

        public static implicit operator int?(NullableInteger obj)
        {
            return obj.Value();
        }

        public int? Value()
        {
            if (string.IsNullOrEmpty(_value) || !int.TryParse(_value, out int result))
            {
                return _defaultValue;
            }
            return result;
        }
    }
}
