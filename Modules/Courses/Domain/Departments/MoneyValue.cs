using ContosoUniversity.Modules.Courses.Domain.Common;
using ContosoUniversity.SharedKernel.Domain;
using System;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public class MoneyValue : ValueObject 
    {
        public decimal Value { get; }
        public string Currency { get; }
        public DateTime Moment { get; }

        private MoneyValue(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
            Moment = SystemClock.Now;
        }
      
        public static MoneyValue Of(decimal value, string currency)
        {
            CheckRule(new MoneyValueMustHaveCurrencyRule(currency));

            return new MoneyValue(value, currency);
        }

        public static MoneyValue Of(MoneyValue value)
        {
            return new MoneyValue(value.Value, value.Currency);
        }

        public static MoneyValue operator +(MoneyValue moneyValueLeft, MoneyValue moneyValueRight)
        {
            CheckRule(new MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(moneyValueLeft, moneyValueRight));

            if (moneyValueLeft.Currency != moneyValueRight.Currency)
            {
                throw new ArgumentException();
            }

            return new MoneyValue(moneyValueLeft.Value + moneyValueRight.Value, moneyValueLeft.Currency);
        }

        internal class MoneyValueMustHaveCurrencyRule : IDomainRule
        {
            private readonly string _currency;

            public MoneyValueMustHaveCurrencyRule(string currency)
            {
                _currency = currency;
            }

            public bool IsViolated() => string.IsNullOrEmpty(_currency);

            public string Message => "Money value must have currency";
        }
        internal class MoneyValueOperationMustBePerformedOnTheSameCurrencyRule : IDomainRule
        {
            private readonly MoneyValue _left;

            private readonly MoneyValue _right;

            public MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(MoneyValue left, MoneyValue right)
            {
                _left = left;
                _right = right;
            }

            public bool IsViolated() => _left.Currency != _right.Currency;

            public string Message => "Money value currencies must be the same";
        }

        public static bool operator >(decimal left, MoneyValue right) => left > right.Value;

        public static bool operator <(decimal left, MoneyValue right) => left < right.Value;

        public static bool operator >=(decimal left, MoneyValue right) => left >= right.Value;

        public static bool operator <=(decimal left, MoneyValue right) => left <= right.Value;

        public static bool operator >(MoneyValue left, decimal right) => left.Value > right;

        public static bool operator <(MoneyValue left, decimal right) => left.Value < right;

        public static bool operator >=(MoneyValue left, decimal right) => left.Value >= right;

        public static bool operator <=(MoneyValue left, decimal right) => left.Value <= right;
    }
}
