using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWithMvvm.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
