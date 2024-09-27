using Framework.Exception;
using Locazation.Author;

namespace Application.Exception;

public class AuthorServiceException() : BaseException(AuthorResource.AuthorDuplicate);
public class AuthorFoundServiceException() : BaseException(AuthorResource.AuthorNoutFoundService);