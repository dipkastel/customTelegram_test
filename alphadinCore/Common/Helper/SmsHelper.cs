using alphadinCore.Model;
using alphadinCore.Model.NetworkModels;
using alphadinCore.Model.smsModels;
using Kavenegar.Core.Models;
using System;
using System.Linq;
using Database.Common.Enums;
using Database.Config;
using Database.Models;
using Kavenegar;
using Kavenegar.Core.Exceptions;
using Services.Operator.Interfaces;

namespace alphadinCore.Common.Helper
{
    public class SmsHelper
    {
        const string SENDER_LINE = "10008663";
        const int MAX_SMS_COUNT_IN_THRESHOLD_TIME = 2;
        const int THRESHOLD_TIME_IN_MINUTS = 5;
        const string API_KEY = "672F63374D31584673477577684157626567643831513D3D";
        ISmsService _smsService;

        public SmsHelper(ISmsService smsService)
        {
            _smsService = smsService;
        }
        public SendSmsResultModel SendSms(string phoneNumber, string smsMessage, string code = "0")
        {
            var smsResult = new SendSmsResultModel();
            try
            {
               
                if (/*res.Status.Equals(1)*/ true)
                {
                    smsResult.success = true;
                    smsResult.Message = "کد ورود برای کاربر ارسال شد";
                    _smsService.Add(new Sms
                    {
                        Key = code,
                        Text = smsMessage,
                        Reciver = phoneNumber,
                        SendDate = DateTime.Now,
                        Status = (int)SmsStatus.Success,
                        SmsResult = "Success"
                    }, 0);
                    return smsResult;
                }
                var api = new KavenegarApi(API_KEY);
                var smsTask = api.Send(SENDER_LINE, phoneNumber, smsMessage);
                var res = smsTask.Result;

                _smsService.Add(new Sms
                {
                    Key = code,
                    Text = smsMessage,
                    Reciver = phoneNumber,
                    SendDate = DateTime.Now,
                    Status = (int)SmsStatus.Faild,
                    SmsResult = res.Message
                }, 0);
                throw new CustomException("خطا در ارسال اس ام اس", ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "01");
            }
            catch (ApiException ex)
            {
                _smsService.Add(new Sms
                {
                    Key = code,
                    Text = "",
                    Reciver = phoneNumber,
                    SendDate = DateTime.Now,
                    Status = (int)SmsStatus.Faild,
                    SmsResult = ex.Message
                }, 0);
                throw new CustomException("خطا در ارسال اس ام اس", ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "02");
            }
            catch (HttpException ex)
            {
                _smsService.Add(new Sms
                {
                    Key = code,
                    Text = "",
                    Reciver = phoneNumber,
                    SendDate = DateTime.Now,
                    Status = (int)SmsStatus.Faild,
                    SmsResult = ex.Message
                }, 0);
                throw new CustomException("خطا در برقراری ارتباط با ارسال کننده اس ام اس", ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "03");
            }
            catch (Exception ex)
            {
                _smsService.Add(new Sms
                {
                    Key = code,
                    Text = "",
                    Reciver = phoneNumber,
                    SendDate = DateTime.Now,
                    Status = (int)SmsStatus.Faild,
                    SmsResult = ex.Message
                }, 0);
                throw new CustomException("خطا در ارسال اس ام اس", ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "04");
            }

        }

        public SendSmsResultModel SendAuthSms(string phoneNumber)
        {
            string code = GenerateRandomSmsCode();
            string smsMessage = CodeToMessage(code);
            bool IsOver = _smsService.FindAll(p => p.Reciver == phoneNumber && p.SmsType == (int)SmsTypes.Auth && p.SendDate.AddMinutes(THRESHOLD_TIME_IN_MINUTS) > DateTime.Now).Count > MAX_SMS_COUNT_IN_THRESHOLD_TIME;
            if (IsOver)
                throw new CustomException("تعداد پیامک های ارسال شده بیش از حد مجاز است", ErrorsPreFix.HELPER_SMS + ERROR_SEND_AUTH_SMS + "01");

            return SendSms(phoneNumber, smsMessage, code);
        }

        private string CodeToMessage(string code)
        {
            return "کد ورود شما به آلفادین :" + code + "می باشد.";
        }

        private string GenerateRandomSmsCode()
        {
            Random generator = new Random();
            String r = generator.Next(10000, 99999).ToString();
            return r;
        }

        public string ERROR_SEND_SMS = "01";
        public string ERROR_SEND_AUTH_SMS = "02";
    }
}
