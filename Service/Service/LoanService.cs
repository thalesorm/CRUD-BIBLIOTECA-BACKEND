using Domain.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class LoanService : ILoanService 
    {
        private readonly IBaseRepository<Loan> _baseRepository;

        private readonly ILoanRepository _loanRepository;

        public LoanService(IBaseRepository<Loan> baseRepository, ILoanRepository loanRepository)
        {
            _baseRepository = baseRepository;
            _loanRepository = loanRepository;
        }

        public Loan Create(Loan obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> GetAll()
        {
            var loans = _loanRepository.GetAll();
            return loans;
        }

        public IEnumerable<Loan> GetAllByBookId(int IdBook)
        {
            var loans = _loanRepository.GetAllByBookId(IdBook);
            return loans;
        }

        public IEnumerable<Loan> GetAllByUserId(int IdUser)
        {
            var loans = _loanRepository.GetAllByUserId(IdUser);
            return loans;
        }

        public Loan GetById(int Id)
        {
            var loan = _loanRepository.GetById(Id);
            return loan;
        }
    }
}
