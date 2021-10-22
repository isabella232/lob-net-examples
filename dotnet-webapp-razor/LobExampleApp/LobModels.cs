using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace LobExampleApp
{

    public class LobAddressListResult
    {
        public List<LobAddressResult> data { get; set; }
    }
    public class LobAddressResult
    {
        public string id { get; set; }
        public string description { get; set; }
        [Required, StringLength(40, MinimumLength = 3)]
        public string name { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        [Required, StringLength(64)]
        public string address_line1 { get; set; }
        [Required, StringLength(200)]
        public string address_city { get; set; }
        [Required]
        public string address_state { get; set; }
        [Required]
        public string address_zip { get; set; }
        public string address_country { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
    }

    public class LobPostcardRequest
    {
        public string to { get; set; }
        public string front { get; set; }
        public string back { get; set; }
        public string description { get; set; }
        public object merge_variables { get; set; } 
    }

    public class LobPostcardResponse
    {
        public dynamic to { get; set; }
        public string carrier { get; set; }
        public string id { get; set; }
        public string front_template_id { get; set; }
        public string back_template_id { get; set; }
        public string front_template_version_id { get; set; }
        public string back_template_version_id { get; set; }
        public string url { get; set; }

        public dynamic thumbnails { get; set; }

    }

    public class ErrorInfo
    {
        public string message { get; set; }
        public int status_code { get; set; }
        public string code { get; set; }
    }

    public class LobError
    {
        public dynamic error { get; set; }
        
    }
}