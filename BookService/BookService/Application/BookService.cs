using Application.Contract;
using Application.Exception;
using Domain.Model.Model.Author.IRepository;
using Domain.Model.Model.Book;
using Domain.Model.Model.Book.Command;
using Domain.Model.Model.Book.IRepository;
using Domain.Model.Model.Book.Query;
using Domain.Model.Model.Book.QueryModel;
using Framework.Extensions;
using Framework.Response;
using MassTransit;

namespace Application;

public class BookService : IBookService
{
    private readonly IBookCommandRepository _commandRepository;
    private readonly IBookQueryRepository _queryRepository;
    private readonly IAuthorQueryRepository _authorQueryRepository;
    private readonly IPublishEndpoint _publishEndPoint;
    public BookService(IBookCommandRepository commandRepository, IBookQueryRepository queryRepository, IAuthorQueryRepository authorQueryRepository, IPublishEndpoint publishEndPoint)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _authorQueryRepository = authorQueryRepository;
        _publishEndPoint = publishEndPoint;
    }

    public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var authorId = await GetAuthorId(request.AuthorId);
        var book = CreateByAddBookCommandAndAuthorId(request, authorId);

        var created= await _commandRepository.Create(book);
        if (!created) return created;

        var bookQueryModel = await _queryRepository.GetById(book.Id, cancellationToken);
        await _publishEndPoint.Publish(bookQueryModel!, cancellationToken);
        return created;

    }

    public async Task<ServiceResponse<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _queryRepository.Load(request.Id, cancellationToken);
        book.ThrowIfNull(new BookNotFoundServiceException());
        book!.Update(request.Title,request.PublishYear,request.AuthorId);
        await _commandRepository.Update(book);
        return new ServiceResponse<Book>(book);
    }


    public async Task<ServiceResponse<BookQueryModel?>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _queryRepository.GetById(request.Id, cancellationToken);
        return book.ReturnDataOrInstance();
    }

    public async Task<ServiceResponse<IEnumerable<BookQueryModel>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _queryRepository.GetList(cancellationToken);
        return books.ReturnDataOrInstance();
    }

    private async Task<Guid?> GetAuthorId(Guid authorId)
    {
        return await _authorQueryRepository.GetAuthorId(authorId);
    }

    private Book CreateByAddBookCommandAndAuthorId(AddBookCommand request, Guid? authorId)
    {
        return BookBuilder.Instance()
            .WithBookTitle(BookTitle.CreateInstance(request.Title))
            .WithPublishYear(request.PublishYear)
            .WithAuthorId(authorId ?? Guid.Empty)
            .Build();
    }

}