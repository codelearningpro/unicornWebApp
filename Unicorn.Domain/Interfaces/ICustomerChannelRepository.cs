using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Domain.Entities;

namespace Unicorn.Domain.Interfaces
{
    /// <summary>
    /// Interface for defining the methods for performing CRUD operations 
    /// on the Customer table
    /// </summary>
    public interface ICustomerChannelRepository
    {
        IEnumerable<CustomerChannel> GetCustomerChannels();
        CustomerChannel GetCustomerChannel(int id);
        CustomerChannel CreateCustomerChannel(CustomerChannel customer);
        CustomerChannel UpdateCustomerChannel(CustomerChannel customer);
        bool DeleteCustomerChannel(int id);

        Customer CreateCustomerChannel(string userName, string message);
    }
}
