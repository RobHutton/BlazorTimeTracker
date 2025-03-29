namespace TimeTracker.Shared.Models
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            if (isSuccess && error != null)
                throw new InvalidOperationException("Success result cannot have an error.");
            if (!isSuccess && error == null)
                throw new InvalidOperationException("Failure result must have an error.");

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);

        public static Result Fail(string error) => new Result(false, error);
    }

}
