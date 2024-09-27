using Domain.Model.Model.Book;
using Domain.Model.Model.Book.Command;
using Domain.Model.Model.Book.Query;
using Domain.Model.Model.Book.QueryModel;
using Framework.Response;
using Framework.TransientService;
using MediatR;

namespace Application.Contract;

public interface IBookService :  
    IRequestHandler<AddBookCommand,bool>,
    IRequestHandler<UpdateBookCommand, ServiceResponse<Book>>,
    IRequestHandler<GetBookByIdQuery,ServiceResponse<BookQueryModel?>>,
    IRequestHandler<GetBooksQuery, ServiceResponse<IEnumerable<BookQueryModel>>>,
    ITransientService;