using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SignalR_Streaming_Trial21.Developer_classes;

namespace SignalR_Streaming_Trial21.Pages
{
    public class IndexModel : PageModel
    {
        public Person Person { get; set; }
        private DataSerializer serializer=new DataSerializer();
        Person newPerson;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {            
            Person person = new Person("Anas","Al Kala",34, "Alberschwende");
            serializer.JsonSerialize(person, @"C:\Users\alan\Desktop\SignalR_Streaming_Trial21\SignalR_Streaming_Trial21\SerializedObjects.txt");
            newPerson= (Person)serializer.JsonDeserialize(typeof(Person), @"C:\Users\alan\Desktop\SignalR_Streaming_Trial21\SignalR_Streaming_Trial21\SerializedObjects.txt");
        }
    }
}
