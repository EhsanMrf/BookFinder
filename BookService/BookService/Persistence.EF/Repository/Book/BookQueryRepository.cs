using Domain.Model.Model.Book.IRepository;
using Domain.Model.Model.Book.QueryModel;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF.Repository.Book;

public class BookQueryRepository(DatabaseContext dbContext) : IBookQueryRepository
{
    public async Task<BookQueryModel?> GetById(Guid id)
    {
        return await dbContext.Books.Where(x => x.Id == id).Select(s => new BookQueryModel
        {
            AuthorName = dbContext.Authors.Where(q => q.Id == s.AuthorId).Select(s => s.Name).FirstOrDefault(),
            Id = s.Id,
            PublishYear = s.PublishYear,
            Title = s.BookTitle.Title
        }).FirstOrDefaultAsync();
    }

    public async Task<Domain.Model.Model.Book.Book?> Load(Guid id)
    {
        return await dbContext.Books.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<BookQueryModel>> GetList()
    {
        return await dbContext.Books.Select(s => new BookQueryModel
        {
            AuthorName = dbContext.Authors.Where(q => q.Id == s.AuthorId).Select(s => s.Name).FirstOrDefault(),
            Id = s.Id,
            PublishYear = s.PublishYear,
            Title = s.BookTitle.Title
        }).ToListAsync();
    }
}