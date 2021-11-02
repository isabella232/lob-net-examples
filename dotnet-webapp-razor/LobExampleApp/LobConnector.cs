using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System;
using System.IO;

namespace LobExampleApp 
{
    public class LobConnector
    {
        private string baseUrl = "https://api.lob.com/v1/";

        private string apiKey = Environment.GetEnvironmentVariable("LOB_API_KEY");
        public async Task<LobAddressListResult> listAddresses()
        {
            var url = this.baseUrl + "addresses";
            LobAddressListResult resp = await url.WithBasicAuth(this.apiKey, "").GetJsonAsync<LobAddressListResult>();
            return resp;
        }

        public async Task<LobAddressResult> saveAddress( LobAddressResult address)
        {
            var url = this.baseUrl + "addresses";
            LobAddressResult resp = await url.WithBasicAuth(this.apiKey, "").PostJsonAsync(new {
                description = "",
                name = address.name,
                company = address.company,
                email = address.email,
                phone = address.phone,
                address_line1 = address.address_line1,
                address_line2 = "",
                address_city = address.address_city,
                address_state = address.address_state,
                address_zip = address.address_zip,
                address_country = address.address_country
            }).ReceiveJson<LobAddressResult>();
            return resp;
        }

        public async Task<LobPostcardResponse> previewPostcard( LobPostcardRequest postcard)
        {
            var url = this.baseUrl + "postcards";
            LobPostcardResponse resp = await url.WithBasicAuth(this.apiKey, "").PostJsonAsync(postcard)
                .ReceiveJson<LobPostcardResponse>();
            // We wait a few seconds to allow for the thumbnails to populate. All Postcards created via
            // the Lob API go through a print-ready checklist to make sure that what you see is exactly how
            // the final printed results will be. 
            await Task.Delay(5000);
            return resp;
        }
        
    }
}