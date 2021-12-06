namespace SecretSanta.Backend.Common;

public class OperationResult<TResult, TError>
{
    public TResult Result { get; }

    public IReadOnlyCollection<TError> Errors { get; }

    public bool IsSuccessful => Errors.Count == 0;


    private OperationResult(TResult result, IReadOnlyCollection<TError> errors)
    {
        Result = result;
        Errors = errors;
    }


    public static OperationResult<TResult, TError> CreateSuccessful(TResult result) => new(result, Array.Empty<TError>());

    public static OperationResult<TResult, TError> CreateUnsuccessful(params TError[] errors)
    {
        if (errors.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(errors), "At least one error must be provided");
        }

        return new OperationResult<TResult, TError>(default, errors);
    }
}