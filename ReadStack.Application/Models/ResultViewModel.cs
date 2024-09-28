
namespace ReadStack.Application.Models
{
    public class ResultViewModel
    {
        public ResultViewModel(bool isSuccess = true, string error = "")
        {
            IsSuccess = isSuccess;
            Message = error;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ResultViewModel Success()
            => new ResultViewModel();

        public static ResultViewModel Erro(string message)
            => new ResultViewModel(false, message);

        public static ResultViewModel Success(string v)
        => new ResultViewModel(false, v);
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public ResultViewModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public T? Data { get; set; }

        public static ResultViewModel<T> Success(T data)
            => new ResultViewModel<T>(data);

        public static ResultViewModel<T> Erro(string message)
            => new ResultViewModel<T>(default, false, message);
    }
}
