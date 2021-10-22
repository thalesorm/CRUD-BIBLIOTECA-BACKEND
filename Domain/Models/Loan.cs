using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Loan : Entity
    {
        public int Id { get; set; }
        public int Days { get; set; }

        public DateTime DateLoan { get; set; }

        public DateTime DateDevolution { get; set; }

        public bool Returned { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
