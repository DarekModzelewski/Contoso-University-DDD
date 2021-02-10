using System;

namespace ContosoUniversity.SharedKernel.Domain
{
    public class DomainException : Exception
    {
        public readonly IDomainRule DomainRule;

        public string Details { get; }

        public DomainException(IDomainRule domainRule) : base(domainRule.Message)
        {
            DomainRule = domainRule;
            Details = domainRule.Message;
        }

        public override string ToString()
        {
            return $"{DomainRule.GetType().FullName}: {DomainRule.Message}";
        }
    }

}
