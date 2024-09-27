using Framework.Exception;
using Locazation.Author;

namespace Domain.Model.Model.Author;

public class AuthorNameNullException() : BaseException(AuthorResource.AuthorNameNull);
public class AuthorNameLengthException() : BaseException(AuthorResource.AuthorNameLength);