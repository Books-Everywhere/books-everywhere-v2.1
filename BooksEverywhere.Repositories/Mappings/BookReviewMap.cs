﻿using BooksEverywhere.Models;
using FluentNHibernate.Mapping;

namespace BooksEverywhere.Repositories.Mappings
{
    public class BookReviewMap : ClassMap<BookReview>
    {
        public BookReviewMap()
        {
            Table("book_review");
            References(x => x.Book).Column("book_id").Not.Nullable();
            References(x => x.User).Column("user_id").Not.Nullable();
            Map(x => x.Review, "review").Not.Nullable();
        }
    }
}
