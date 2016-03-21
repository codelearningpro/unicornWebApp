using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unicorn.Domain.Entities;
using Unicorn.Domain.Repositories;
using Unicorn.Domain.Helpers;
using Unicorn.WebLibrary.Config;
using Unicorn.WebLibrary.Helpers;
using System.Net;
using PusherServer;

namespace Unicorn.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {


        /// <summary>
        /// API too create a new channel between two way communication between two individuals ex: a user and a advisor
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost, ActionName("CreateChannel")]
        public IHttpActionResult SendMessage(string user, string message)
        {

            return CreateResult(true, MessageHelper.SUCCESS);
        }


        [HttpPost, ActionName("SendMessage")]
        public IHttpActionResult SendMessage(string message)
        {
            var pusher = new Pusher("181640", "c691d4eeb0c0aa00d2bc", "174ae11faf7d6a247e9f", new PusherOptions() { Encrypted = true });
            var result = pusher.Trigger("atest_channel", "my_event", new { message = (DateTime.Now.ToLongTimeString().ToString()) +  "|" + message });

            return CreateResult(true, MessageHelper.SUCCESS);
        }

        // GET: api/customer
        public IEnumerable<string> Get()
        {
            //CustomerRepository customerRespository = new CustomerRepository(1);
            // Customer customer =  customerRespository.GetCustomer(1);

            return new string[] { "Coming", "Soon", "To", "Save", "Money", "And", "Grow" };
        }

        public IHttpActionResult CreateResult(bool success, string message)
        {
            return Json(new { success =  success, message = message});
        }


        [HttpPost, ActionName("SignIn")]
        public IHttpActionResult SignIn(int id, string signinname, string password)
        {
            CustomerSignInRepository customerSignInRespository = new CustomerSignInRepository(WebConfig.SystemUserID);
            CustomerSignIn customerSignIn = customerSignInRespository.GetCustomerSignIn(ConfigSignInType.Email, signinname, password);

            if (customerSignIn == null)
                return CreateResult(false, ErrorMessageHelper.INVALID_SIGIN); 

            if (!customerSignIn.ConfirmDate.HasValue)
                return CreateResult(false, ErrorMessageHelper.ACCOUNT_NOT_ACTIVE);

            return CreateResult(true, customerSignIn.CustomerID.ToString().Trim());
        }

        [HttpPost, ActionName("CreateCustomer")]
        public IHttpActionResult CreateCustomer(string firstname, string lastname, string email, string phone, string password)
        {
            using (CustomerRepository customerRespository = new CustomerRepository(WebConfig.SystemUserID))
            { 

                Customer customer = customerRespository.CreateCustomer(firstname, lastname, email, phone, password);

                if (customer == null)
                    return CreateResult(false, ErrorMessageHelper.INVALID_SIGIN);

                EmailHelper.SendCustomerActivationEmail(customer);

                return CreateResult(true, MessageHelper.SUCCESS + customer.ID.ToString().Trim() + "|" + customer.FirstName + "|" + lastname);  
            }
            //sample: return firstname + "|" + lastname + "|" + email +  "|" + phone + "|" + password;
        }

        [HttpGet, ActionName("Activate")]
        public string Activate(int id, string token)
        {
            CustomerSignInRepository customerSignInRespository = new CustomerSignInRepository(WebConfig.SystemUserID);

            List<CustomerSignIn> customerSignIns = customerSignInRespository.GetCustomerSignIn(ConfigSignInType.Email, new Guid(token));

            if (customerSignIns == null)
                return ErrorMessageHelper.INVALID_TOKEN;

            else if (customerSignIns[0].ConfirmDate.HasValue)
                return ErrorMessageHelper.ACCOUNT_ALREADY_ACTIVE;


            customerSignIns = customerSignInRespository.ActivateSignIn(customerSignIns);

            if(customerSignIns==null)
            {
                return ErrorMessageHelper.ACCOUNT_ALREADY_ACTIVE;
            }

            return MessageHelper.ACCOUNT_ACTIVATED;
                    
        
            //sample: return id.ToString().Trim() + siginname + "|" + signinpassword;
        }
    }

}
