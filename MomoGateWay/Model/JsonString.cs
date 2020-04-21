using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MomoGateWay.Model
{
    public class JsonString
    {
        public string PartnerCode { get; set; }
        public string PartnerRefId { get; set; }
        public string Amount { get; set; }
        public string PaymentCode { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
    }
}