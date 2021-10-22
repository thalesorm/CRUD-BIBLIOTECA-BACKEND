using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ILoanService
    {
        Loan Create(Loan obj);
        Loan GetById(int id);

        IEnumerable<Loan> GetAll();

        IEnumerable<Loan> GetAllByUserId(int IdUser);

        IEnumerable<Loan> GetAllByBookId(int IdBook);
    }
}
