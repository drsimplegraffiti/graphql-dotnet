using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace GraphQlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangFireController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public String Login()
        {
            //Fire - and - Forget Job - this job is executed only once
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to Shopping World!"));
            return $"Job ID: {jobId}. Welcome mail sent to the user!";
        }
        [HttpGet]
        [Route("productcheckout")]
        public String CheckoutProduct()
        {
            //Delayed Job - this job executed only once but not immedietly after some time.
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist!"),TimeSpan.FromSeconds(20));
            return $"Job ID: {jobId}. You added one product into your checklist successfully!";
        }
        [HttpGet]
        [Route("productpayment")]
        public String ProductPayment()
        {
            //Fire and Forget Job - this job is executed only once
            var parentjobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));
            //Continuations Job - this job executed when its parent job is executed.
            BackgroundJob.ContinueJobWith(parentjobId, () => Console.WriteLine("Product receipt sent!"));
            return "You have done payment and receipt sent on your mail id!";
        }
        [HttpGet]
        [Route("dailyoffers")]
        public String DailyOffers()
        {
            //Recurring Job - this job is executed many times on the specified cron schedule
            // RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Daily); // Obsolete method

            RecurringJob.AddOrUpdate("jobId", () => Console.WriteLine("Sent similar product offer and suggestions"), Cron.Minutely);
            return "offer sent!";
        }
    }
}