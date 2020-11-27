using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBS2.DTOs.Responses;
using LBS2.Entities;

namespace LBS2.DTOs.Mappings
{
    public class AutoMappersDef : AutoMapper.Profile 
    {
        public AutoMappersDef()
        {
            CreateMap<Book, BookResponse>()
                .ForMember(
                    dest => dest.WhenBorrowed,
                    opt => opt.MapFrom(
                        src => src.Borrowings.Select(borrowing => borrowing.WhenBorrowed).FirstOrDefault()
                        )
                    )
                .ForMember(
                    dest => dest.WhoBorrowedName,
                    opt => opt.MapFrom(
                        src => src.Borrowings.Select(borrowing => borrowing.WhoBorrowed.Name).FirstOrDefault()
                        )
                    );
            CreateMap<Account, AccountResponse>()
                .ForMember(
                    dest => dest.BooksBorrowedTitles,
                    opt=>opt.MapFrom(
                        src=>src.BooksBorrowed
                        .Select(borrowing=>borrowing.BorrowedBook.Title)
                         .ToList()));
        }
    }
}
