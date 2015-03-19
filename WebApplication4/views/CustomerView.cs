using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;
using WebApplication4.Model;
using WebApplication4.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

namespace WebApplication4.views
{
    public class CustomerView
    {
        private CustomerList customerSummary = new CustomerList();
        private Customer aCustomer = new Customer();
        private string requestTemplate = "main:Customers";

        public CustomerList CustomerSummary
        {
            get { return customerSummary; }
        }
        public Customer SingleCustomer
        {
            get { return aCustomer; }
        }

        public CustomerView(string id)
        {
            ApiHelper.ApiKey = "0afmo2PA6zBBgDK7tKLb";
            BaseURLHelper.BaseURL = "http://eval.espressologic.com/rest/ValsEval/nwnds/v1/";
            requestTemplate += "/" + id;
            Task<CustomerList> customerListTask = GetCustomerSummaryAsync();
            customerListTask.Wait();
            customerSummary = customerListTask.Result;
            foreach (Customer customer in customerSummary)
            {
                if (customer.CustomerID == id)
                {
                    aCustomer = customer;
                    break;
                }
            }
        }

        public CustomerView()
        {
            ApiHelper.ApiKey = "0afmo2PA6zBBgDK7tKLb";
            BaseURLHelper.BaseURL = "http://eval.espressologic.com/rest/ValsEval/nwnds/v1/";


            Task<CustomerList> customerListTask = GetCustomerSummaryAsync();
            customerListTask.Wait();
            customerSummary = customerListTask.Result;

            Debug.WriteLine("CustomerSummary: count = {0}", CustomerSummary.Count);
            foreach (Customer customer in CustomerSummary)
            {
                Debug.WriteLine("\t{0} {1}", customer.CompanyName, customer.Address);
            }
        }

        private async Task<CustomerList> GetCustomerSummaryAsync()
        {
            CustomerList customerList = new CustomerList();
            String requesturl = BaseURLHelper.BaseURL + requestTemplate;

            using (HttpClient client = new HttpClient())
            {
                //do
                //{
                try
                {
                    string response = await HttpHelper.GetAsync(client, requesturl);
                    CustomerList newCustomers = JsonConvert.DeserializeObject<CustomerList>(response);
                    customerList.AddRange(newCustomers.Take<Customer>(20));
                    String nextBatch = (string)JArray.Parse(response).Last["@metadata"]["next_batch"];
                    if (requesturl != null)
                    {
                        //requesturl = requesturl + "&auth=" + apiKey;
                    }
                    Debug.WriteLine("Just a break point.");
                }
                catch (Exception)
                {
                    Debug.WriteLine("Just a break point.");
                }
                //  } while (requesturl != null);
            }

            return customerList;
        }
    }
}