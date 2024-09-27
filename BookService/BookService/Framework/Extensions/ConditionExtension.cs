using Framework.Exception;

namespace Framework.Extensions;

public static class ConditionExtension
{
    public static void ThrowIfNull<T>(this T @object, BaseException exception)
    {
        if (@object==null) throw exception;
    }
}