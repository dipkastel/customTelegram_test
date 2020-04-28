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

namespace alphadinCore.Common.Helper
{
    public class SmsHelper
    {
        const string SENDER_LINE = "10008663";
        const string API_KEY = "672F63374D31584673477577684157626567643831513D3D";


        public SendSmsResultModel SendAuthSms(string phoneNumber, DbContextModel db) {
            string code = GenerateRandomSmsCode();
            return SendSms(phoneNumber, code, db);
        }

        public SendSmsResultModel SendSms(String phoneNumber, String code, DbContextModel db) {
            var smsResult = new SendSmsResultModel();
           
            try
            {
                var api = new KavenegarApi(API_KEY);
                var smsMessage = CodeToMessage(code, db);
                var smsTask = api.Send(SENDER_LINE, phoneNumber, smsMessage);
                var res = smsTask.Result;

                if (res.Status.Equals(1))
                {
                    smsResult.success = true;
                    smsResult.FaMessage = "کد ورود برای کاربر ارسال شد";
                    smsResult.EnMessage = "entry code Successfully sended";
                    InsertUser(phoneNumber, code, db);
                    
                    db.Sms.Add(new Sms
                    {
                        Key = code,
                        Text = smsMessage,
                        Reciver = phoneNumber,
                        SendDate = DateTime.Now,
                        Status = (int) SmsStatus.Success
                    });
                    db.SaveChanges();
                    return smsResult;
                }

                smsResult.success = false;
                smsResult.FaMessage = "خطا در ارسال اس ام اس";
                smsResult.EnMessage = "error in sending sms";
                db.Sms.Add(new Sms
                {
                    Key = code, Text = smsMessage, Reciver = phoneNumber, SendDate = DateTime.Now,
                    Status = (int) SmsStatus.Faild
                });
                db.SaveChanges();
                throw new CustomException(smsResult.FaMessage, ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "01");
            }
            catch (ApiException ex)
            {
                smsResult.success = false;
                smsResult.FaMessage = "خطا در ارسال اس ام اس";
                smsResult.EnMessage = ex.Message;
                db.Sms.Add(new Sms
                {
                    Key = code, Text = "", Reciver = phoneNumber, SendDate = DateTime.Now,
                    Status = (int) SmsStatus.Faild
                });
                db.SaveChanges();
                throw new CustomException(smsResult.FaMessage, ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "02");
            }
            catch (HttpException ex)
            {
                smsResult.success = false;
                smsResult.FaMessage = "خطا در برقراری ارتباط با ارسال کننده اس ام اس";
                smsResult.EnMessage = ex.Message;
                db.Sms.Add(new Sms
                {
                    Key = code, Text = "", Reciver = phoneNumber, SendDate = DateTime.Now,
                    Status = (int) SmsStatus.Faild
                });
                db.SaveChanges();
                throw new CustomException(smsResult.FaMessage, ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "03");
            }
            catch (Exception ex)
            {
                smsResult.success = false;
                smsResult.FaMessage = ex.Message;
                smsResult.EnMessage = ex.Message;
                db.Sms.Add(new Sms
                {
                    Key = code, Text = "", Reciver = phoneNumber, SendDate = DateTime.Now,
                    Status = (int) SmsStatus.Faild
                });
                db.SaveChanges();
                throw new CustomException(smsResult.FaMessage, ErrorsPreFix.HELPER_SMS + ERROR_SEND_SMS + "04");
            }

        }

        private User InsertUser(string phoneNumber,string code ,DbContextModel db)
        {
            var user = db.Users.FirstOrDefault(a => a.MobileNumber == phoneNumber);
            if (user == null)
            {
                var role = db.Roles.FirstOrDefault(t => t.Name == "tester");
                db.Users.Add(new User
                {
                    MobileNumber = phoneNumber, Role = role, Status = (int) UserStatus.Active,
                    RefreshToken = Guid.NewGuid().ToString()
                });
                db.SaveChanges();
            }
            else
            {
                user.RefreshToken = Guid.NewGuid().ToString();
                db.Users.Update(user);
                db.SaveChanges();
            }

            return user;
        }

        private string CodeToMessage(string code,DbContextModel db) {

            return "کد ورود شما به آلفادین :" + code + "می باشد.";
        }
        private string GenerateRandomSmsCode() {
            Random generator = new Random();
            String r = generator.Next(10000, 99999).ToString();
            return r;
        }

        public string ERROR_SEND_SMS = "01";
    }
}
