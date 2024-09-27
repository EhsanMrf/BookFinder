using Domain.Model.Model.Book.IRepository;

namespace Persistence.EF.Repository.Book;

public class BookCommandRepository(DatabaseContext dbContext) : IBookCommandRepository
{
    public async Task<bool> Create(Domain.Model.Model.Book.Book command)
    {
        dbContext.Books.Add(command);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Domain.Model.Model.Book.Book> Update(Domain.Model.Model.Book.Book command)
    {
        dbContext.Books.Update(command);
        await dbContext.SaveChangesAsync();
        return command;
    }
}