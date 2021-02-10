namespace ContosoUniversity.SharedKernel.Domain
{
    public interface IDomainRule
    {
        bool IsViolated();

        string Message { get; }
    }
}