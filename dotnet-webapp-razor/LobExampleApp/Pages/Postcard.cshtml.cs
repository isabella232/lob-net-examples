using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LobExampleApp;
using Flurl.Http;
using System.Threading;

namespace LobExampleApp.Pages
{
    public class PostcardModel: PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        protected LobConnector api;
        protected string htmlTextFront;
        protected string htmlTextBack;
        public string previewURLFront;
        public string previewURLBack;
        public string? variable1;
        public string? variable2;
        public string activeAddress;


        public PostcardModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            // // create a template with the name "C# Postcard - Front" and "C# Postcard - Back"
            this.api = new LobConnector();
            this.htmlTextFront = "<html><body>This postcard was sent with Lob.</body></html>";
            this.htmlTextBack = "<html><body>This was card was generated using C#. These are the merge variables for this template: 'variable1' and 'variable2'. Variable 1 is {{variable1}}. Variable 2 is {{variable2}}.</body></html>";
        }
        public async Task OnGet()
        {
            // Now we make a call to the Postcards API to generate a preview of the card that we are going to send
            this.activeAddress = Request.Query["address"];
            Console.WriteLine(Request.Query["variable2"]);
            this.variable1 = Request.Query["variable1"] == "" ? "Access" : Request.Query["variable1"];
            this.variable2 = Request.Query["variable2"] == ""? "22" : Request.Query["variable2"];
            var postcardRequest = new LobPostcardRequest();
            postcardRequest.to = this.activeAddress;
            postcardRequest.front = this.htmlTextFront;
            postcardRequest.back = this.htmlTextBack;
            postcardRequest.description = "C# Postcard";
            postcardRequest.merge_variables = new { variable1=this.variable1, variable2=this.variable2 };
            try {
                var postcardResp = await this.api.previewPostcard(postcardRequest);
                Console.WriteLine(postcardResp.thumbnails[0].small);
                this.previewURLFront = postcardResp.thumbnails[0].large;
                this.previewURLBack = postcardResp.thumbnails[1].large;

            } catch (FlurlHttpException ex) {
                Console.WriteLine("error!");
                var err = await ex.GetResponseJsonAsync<LobError>();
                Console.WriteLine(err.error);
            }


        }
    }
}