
using Domain.Model.Model.Book.QueryModel;
using Framework.Response;
using MediatR;

namespace Domain.Model.Model.Book.Query;

public class GetBooksQuery :IRequest<ServiceResponse<IEnumerable<BookQueryModel>>>;