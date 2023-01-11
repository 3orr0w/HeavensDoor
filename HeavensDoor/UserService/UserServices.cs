
using HeavensDoorClass;
using Microsoft.AspNetCore.SignalR.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavensDoor.UserService
{
   public class UserServices
    {
        private static UserServices instance;
        private UserServices()
        {

        }
        public static UserServices Instance => instance == null ? instance = new UserServices() : instance;
        public staff Account { get; set; }
        public RestClient restClient = new RestClient(@"http://127.0.0.1:5000");
        public HubConnection HubConnections { get; set; }

    }
}
