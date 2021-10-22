using Data.Context;
using Domain.Interface;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LoanRepository : BaseRepository<Loan>, ILoanRepository
    {
        public LoanRepository(SqlContext context) : base(context)
        {

        }

        public IEnumerable<Loan> GetAll()
        {
            var obj = CurrentSet
                        .Include(x => x.Book)
                        .Include(x => x.User)
                        .ToList();

            return obj;
        }

        public IEnumerable<Loan> GetAllByBookId(int IdBook)
        {
            var obj = CurrentSet
                        .Include(x => x.Book)
                        .Include(x => x.User)
                        .Where(x => x.BookId == IdBook)
                        .ToList();

            return obj;
        }

        public IEnumerable<Loan> GetAllByUserId(int IdUser)
        {
            var obj = CurrentSet
                        .Include(x => x.Book)
                        .Include(x => x.User)
                        .Where(x => x.UserId == IdUser)
                        .ToList();

            return obj;
        }

        public Loan GetById(int Id)
        {
            var obj = CurrentSet
                        .Include(x => x.Book)
                        .Include(x => x.User)
                        .Where(x => x.Id == Id)
                        .FirstOrDefault();

            return obj;
        }
    }
}
