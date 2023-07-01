using Azure;

namespace MonthlyExpenses.Api.Test.Fakes
{
    public class FakeResponse<T> : NullableResponse<T>
    {
        public FakeResponse(bool hasValue, T value)
        {
            HasValue = hasValue;
            Value = value;
        }

        public override bool HasValue { get; }

        public override T Value { get; }

        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }
    }
}
