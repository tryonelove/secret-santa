namespace SecretSanta.Backend.Common;

public class OperationResult<TResult>
{
    public TResult Result { get; }

    public IReadOnlyCollection<Exception> Exceptions { get; }

    public bool IsSuccessful => Exceptions.Count == 0;


    private OperationResult(TResult result, IReadOnlyCollection<Exception> exceptions)
    {
        Result = result;
        Exceptions = exceptions;
    }


    public static OperationResult<TResult> CreateSuccessful(TResult result) => new(result, Array.Empty<Exception>());

    public static OperationResult<TResult> CreateUnsuccessful(params Exception[] errors)
    {
        if (errors.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(errors), "At least one error must be provided");
        }

        return new OperationResult<TResult>(default, errors);
    }
}