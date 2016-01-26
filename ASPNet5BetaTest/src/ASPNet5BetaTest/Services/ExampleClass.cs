using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.ConfigurationModel;

namespace Messages.Services
{
    public class GreetingMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public interface IGreetingService
    {
        GreetingMessage GetTodaysGreeting();
    }

    public class GreetingService : IGreetingService
    {
        int _id = 1;
        IConfiguration _config;
        public GreetingService(IConfiguration config)
        {
            _config = config;
        }

        public GreetingMessage GetTodaysGreeting()
        {

            return new GreetingMessage
            {
                Id = _id++,
                Text = _config.Get("message")
            };
        }
    }
}
