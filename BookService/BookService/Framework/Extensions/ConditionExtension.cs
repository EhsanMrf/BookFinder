using Framework.Exception;
using Framework.Response;

namespace Framework.Extensions;

public static class ConditionExtension
{
    public static void ThrowIfNull<T>(this T @object, BaseException exception)
    {
        if (@object==null) throw exception;
    }
    public static ServiceResponse<T> ReturnDataOrInstance<T>(this T data)
    {
        if (data == null)
            return new ServiceResponse<T>
            {
                Message = "Not Found",
                StatusCode = 402,
            };
        return new ServiceResponse<T>(data)
        {
            Message = "SuccessFully",
            StatusCode = 200,
        };
    }
}