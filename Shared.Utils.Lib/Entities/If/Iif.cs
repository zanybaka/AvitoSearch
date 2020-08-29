using System;

namespace Shared.Utils.Lib.Entities.If
{
    public class Iif<TResult>
    {
        private readonly Func<bool> _condition;
        private readonly TResult _trueResult;
        private readonly TResult _falseResult;

        public Iif(Func<bool> condition, TResult trueResult, TResult falseResult)
        {
            _condition = condition;
            _trueResult = trueResult;
            _falseResult = falseResult;
        }

        public static implicit operator TResult(Iif<TResult> obj)
        {
            return obj.GetValue();
        }

        public TResult GetValue()
        {
            return _condition() ? _trueResult : _falseResult;
        }

        public override string ToString()
        {
            return GetValue().ToString();
        }
    }
}
