using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LobExampleApp;

namespace LobExampleApp.Pages
{
    public class NewAddressModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public NewAddressModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public LobAddressResult addressResult { get; set; }

        public async Task<IActionResult> OnPost(LobAddressResult addressResult)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var api = new LobConnector();
            var resp = await api.saveAddress(addressResult);
            
            return RedirectToPage("./Index");
        }

    }
}