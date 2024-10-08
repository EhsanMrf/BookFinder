﻿using Common.Validator;
using Framework.Entity;

namespace Domain.Model.Model.Author;

public sealed class Author :BaseEntity<Guid>
{
    public string Name { get; set; }
    public IReadOnlyList<Book.Book> Books { get; set; }


    /// <summary>
    /// for ef core
    /// </summary>
    private Author()
    {
        
    }

    public Author(string name)
    {
        SetName(name);
        CreateDateTime = DateTime.Now;
    }

    public void Update(string name)
    {
        SetName(name);
        UpdateDateTime = DateTime.Now;
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public void SetName(string name)
    {
        GuardAssessment(name);
        Name = name;
    }
    void GuardAssessment(string name)
    {
        ObjectValidator.Instance
            .RuleFor(name)
            .NotNullOrEmpty(new AuthorNameNullException())
            .Must(name, x => x.Length is 2 or < 2,
                new AuthorNameLengthException());
    }
}