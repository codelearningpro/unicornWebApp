using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Unicorn.Domain.Concrete;
using Unicorn.Domain.Interfaces;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;

namespace Unicorn.Domain.Repositories
{
    public class CustomerChannelRepository : BaseRepository, ICustomerChannelRepository
    {
        public CustomerChannelRepository(int userID) : base(userID)
        {

        }

        /// <summary>
        /// Create a channel
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public CustomerChannel CreateCustomerChannel(CustomerChannel customerChannel)
        {
            // using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                ctx.CustomerChannel.Add(customerChannel);
                ctx.SaveChanges();

                return customerChannel;
            }
        }

        public bool DeleteCustomerChannel(int id)
        {
            var customerChannel = ctx.CustomerChannel.Where(x => x.ID == id).First();
            ctx.CustomerChannel.Remove(customerChannel);
            if (ctx.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public CustomerChannel GetCustomerChannel(int id)
        {
            return ctx.CustomerChannel.Where(x => x.ID == id).First();
        }

        public IEnumerable<CustomerChannel> GetCustomerChannels()
        {
            return ctx.CustomerChannel.AsEnumerable();
        }

        public CustomerChannel UpdateCustomerChannel(CustomerChannel customerChannel)
        {
            var c = ctx.CustomerChannel.Where(x => x.ID == customerChannel.ID).First();

            if (c != null)
            {
                // field changes goes here
               
                ctx.SaveChanges();
            }
            return c;
        }

        public Customer CreateCustomerChannel(string userName, string message)
        {
            return null;
            
        }


    }
}

