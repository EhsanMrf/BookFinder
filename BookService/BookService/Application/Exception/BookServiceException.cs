using Framework.Exception;
using Locazation.Book;

namespace Application.Exception;

public class BookNotFoundServiceException() : BaseException(BookResource.BookNoutFoundService);
public class BookDuplicateServiceException() : BaseException(BookResource.BookDuplicate);