using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MomoGateWay.Model
{
    public class JsonRequest
    {
        public string ApiEndPoint { get; set; }
        public string PartnerCode { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string RequestId { get; set; }
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string OrderInfo { get; set; }
        public string ReturnUrl { get; set; }
        public string NotifyUrl { get; set; }
        public string RequestType { get; set; }
        public string Signature { get; set; }
        public string ExtraData { get; set; }
    }
}