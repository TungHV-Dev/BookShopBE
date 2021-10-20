namespace BookShopBE.Common.Responses
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public Error Error { get; set; }
    }

    public class Result<TData> : Result
    {
        public TData Data { get; set; }

        public static Result<TData> Success(TData data)
        {
            return new Result<TData>
            {
                Data = data,
                IsSuccess = true,
                Error = null
            };
        }

        public static Result<TData> Fail(Error error)
        {
            return new Result<TData>
            {
                Data = default,
                IsSuccess = false,
                Error = error
            };
        }
    }
}
