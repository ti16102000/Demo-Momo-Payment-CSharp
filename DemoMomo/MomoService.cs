using MomoGateWay.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMomo
{
    public class MomoService
    {
        public object CreateOrderByMomo(Guid orderNo, decimal money)
        {

            var jsonRequest = new JsonRequest()
            {
                ApiEndPoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor",
                PartnerCode = "MOMOVYHR20200208",
                AccessKey = "dIn9mqdLZF6htCr5",
                RequestId = Guid.NewGuid().ToString(),
                Amount = ((int)money).ToString(),
                OrderId = orderNo.ToString(),
                OrderInfo = "Thanh toán gói vip nghe nhạc",
                ReturnUrl = "http://localhost:55177/Momo/MomoCallBack/",
                NotifyUrl = "https://localhost:5001/api/",
                RequestType = "captureMoMoWallet",
                SecretKey = "iI0Fg6R7nJUzpda4qbsYd4iFQHE9HDny",
                Signature = "",
                ExtraData = "" //optional not required but no use must write like this, do not delete this line to avoid error badrequest
            };

            string rawHash = "partnerCode=" +
                             jsonRequest.PartnerCode + "&accessKey=" +
                             jsonRequest.AccessKey + "&requestId=" +
                             jsonRequest.RequestId + "&amount=" +
                             jsonRequest.Amount + "&orderId=" +
                             jsonRequest.OrderId + "&orderInfo=" +
                             jsonRequest.OrderInfo + "&returnUrl=" +
                             jsonRequest.ReturnUrl + "&notifyUrl=" +
                             jsonRequest.NotifyUrl + "&extraData=" +
                             jsonRequest.ExtraData;



            string signature = new MomoSecurity().signSHA256(rawHash, jsonRequest.SecretKey);


            JObject message = new JObject
            {
                { "partnerCode", jsonRequest.PartnerCode },
                { "accessKey", jsonRequest.AccessKey },
                { "requestId", jsonRequest.RequestId },
                { "amount", jsonRequest.Amount },
                { "orderId", jsonRequest.OrderId },
                { "orderInfo", jsonRequest.OrderInfo },
                { "returnUrl", jsonRequest.ReturnUrl },
                { "notifyUrl", jsonRequest.NotifyUrl },
                { "extraData", jsonRequest.ExtraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(jsonRequest.ApiEndPoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);
            return jmessage.GetValue("payUrl").ToString();
        }
    }
}