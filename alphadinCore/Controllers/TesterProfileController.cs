using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using alphadinCore.Common.Controllers;
using alphadinCore.Common.Filters;
using alphadinCore.Model.NetworkModels;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alphadinCore.Model.controllerModels
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TesterProfileController : BaseController
    {
        private DbContextModel db;
        public TesterProfileController(DbContextModel _db)
        {
            db = _db;
        }

        /*profile*/

        //[Route("GetTesterProfile")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Include(o => o.User).Include(p => p.User.Role).Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            if (testerProfile == null)
                testerProfile = new TesterProfile();
            var result = new
            {

                mobileNumber = mobileNumber,
                role = (testerProfile.User != null && testerProfile.User.Role != null) ? testerProfile.User.Role.Name : "tester",
                userName = testerProfile.UserName,
                profileImageUrl = testerProfile.ProfileImageUrl,
                userBio = testerProfile.UserBio,
                nickName = testerProfile.NickName,
                birthDay = testerProfile.BirthDay,
                relationType = testerProfile.RelationType,
                genderType = testerProfile.GenderType,
                nationalCode = testerProfile.NationalCode,
                phoneNumber = testerProfile.PhoneNumber,
                email = testerProfile.Email,
                emailVerified = testerProfile.EmailVerified,
                postalCode = testerProfile.PostalCode,
                cityCode = testerProfile.CityCode
            };
            return new JsonResult(result);
        }

        //[Route("SetTesterProfile")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult SetProfile(TesterProfileSetRequst input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            if (testerProfile == null)
            {
                //FirstUpdate
                testerProfile = new TesterProfile();
                var user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
                if (user == null)
                    throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_TESTER_PROFILE + ERROR_SET_PROFILE + "01");
                testerProfile.User = user;
                testerProfile.BirthDay = input.BirthDay;
                testerProfile.CityCode = input.cityCode;
                testerProfile.Email = input.Email;
                testerProfile.GenderType = input.GenderType;
                testerProfile.NationalCode = input.NationalCode;
                testerProfile.PhoneNumber = input.PhoneNumber;
                testerProfile.PostalCode = input.PostalCode;
                testerProfile.RelationType = input.RelationType;
                testerProfile.UserName = input.UserName;

                db.TesterProfiles.Add(testerProfile);
                db.SaveChanges();
            }
            else
            {
                testerProfile.BirthDay = input.BirthDay;
                testerProfile.CityCode = input.cityCode;
                testerProfile.Email = input.Email;
                testerProfile.GenderType = input.GenderType;
                testerProfile.NationalCode = input.NationalCode;
                testerProfile.PhoneNumber = input.PhoneNumber;
                testerProfile.PostalCode = input.PostalCode;
                testerProfile.RelationType = input.RelationType;
                testerProfile.UserName = input.UserName;
                db.TesterProfiles.Update(testerProfile);
                db.SaveChanges();

            }
            return new JsonResult(testerProfile);
        }

        //[Route("GetGeneralProfile")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetGeneralProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            if (testerProfile == null)
                testerProfile = new TesterProfile();

            var result = new
            {
                NickName = testerProfile.NickName,
                Bio = testerProfile.UserBio,
                Gender = testerProfile.GenderType,
                ImageUrl = testerProfile.ProfileImageUrl
            };
            return new JsonResult(result);
        }


        //[Route("SetGeneralProfile")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult SetGeneralProfile(SetGeneralProfileRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            if (testerProfile == null)
            {
                testerProfile = new TesterProfile();
                testerProfile.NickName = input.NickName;
                testerProfile.UserBio = input.Bio;
                testerProfile.GenderType = input.GenderType;
                db.TesterProfiles.Add(testerProfile);
                db.SaveChanges();

            }
            else
            {
                testerProfile.NickName = input.NickName;
                testerProfile.UserBio = input.Bio;
                testerProfile.GenderType = input.GenderType;
                db.TesterProfiles.Update(testerProfile);
                db.SaveChanges();
            }

            return new JsonResult(GetGeneralProfile().Value);
        }

        //[Route("GetPersonalProfile")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetPersonalProfile()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            if (testerProfile == null)
                testerProfile = new TesterProfile();

            var result = new
            {
                UserName = testerProfile.UserName,
                Email = testerProfile.Email,
                EmailVerified = testerProfile.EmailVerified,
                BirthDay = testerProfile.BirthDay,

            };
            return new JsonResult(result);
        }

        //[Route("SetPersonalProfile")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult SetPersonalProfile(SetPersonalProfileRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();

            testerProfile.UserName = input.UserName;
            testerProfile.BirthDay = input.BirthDay;
            testerProfile.RelationType = input.RelationType;
            testerProfile.NationalCode = input.NationalCode;
            testerProfile.PhoneNumber = input.PhoneNumber;
            testerProfile.Email = input.Email;
            testerProfile.PostalCode = input.PostalCode;
            testerProfile.CityCode = input.cityCode;
            db.TesterProfiles.Update(testerProfile);
            db.SaveChanges();
            return new JsonResult(GetPersonalProfile().Value);
        }

        /*Educations*/

        //[Route("GetEducations")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetEducations()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            var testerProfile = db.Educations.Where(o => o.User.MobileNumber == mobileNumber).Select(a => new
            {
                Id = a.Id,
                Grade = a.Grade,
                Major = a.Major,
                place = a.Place,
                InProgress = a.InProgress

            }
                    ).ToList();
            return new JsonResult(testerProfile);
        }

        //[Route("AddEducation")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult AddEducation(UserEducationAddRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_Add_EdUcation + "01");
            UserEducation education = new UserEducation()
            {
                Grade = input.Grade,
                Major = input.Major,
                Place = input.Place,
                InProgress = input.InProgress,
                Status = 0,
                User = user
            };
            db.Educations.Add(education);
            db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        //[Route("UpdateEducation")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult UpdateEducation(UserEducationUpdateRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            UserEducation education = db.Educations.Where(e => e.User.Id == user.Id && e.Id == input.Id).FirstOrDefault();
            if (education == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            education.Grade = input.Grade;
            education.Major = input.Major;
            education.Place = input.Place;
            education.InProgress = input.InProgress;
            db.Educations.Update(education);
            db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        //[Route("RemoveEducation")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult RemoveEducation(RemoveUserEducationRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_EDUCATION + "01");
            UserEducation education = db.Educations.Where(o => o.Id == input.Id && o.User == user).FirstOrDefault();
            if (education == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_EDUCATION + "02");
            db.Educations.Remove(education);
            db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        /*Jobs*/

        //[Route("GetJobs")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetJobs()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            var testerProfile = db.Jobs.Where(o => o.User.MobileNumber == mobileNumber).Select(a => new
            {
                Id = a.Id,
                CompanyName = a.CompanyName,
                JobTitle = a.JobTitle,
                SalaryId = a.SalaryId,
                CompanyScaleId = a.CompanyScaleId,
                InProgress = a.InProgress

            }
                    ).ToList();
            return new JsonResult(testerProfile);
        }

        //[Route("AddJob")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult AddJob(UserJobAddRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_ADD_JOB + "01");
            UserJob job = new UserJob()
            {
                CompanyName = input.CompanyName,
                JobTitle = input.JobTitle,
                SalaryId = input.SalaryId,
                CompanyScaleId = input.CompanyScaleId,
                InProgress = input.InProgress,
                Status = 0,
                User = user
            };
            db.Jobs.Add(job);
            db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }


        //[Route("UpdateJob")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult UpdateJob(UserJobUpdateRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            UserJob job = db.Jobs.Where(e => e.User.Id == user.Id && e.Id == input.Id).FirstOrDefault();
            if (job == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            job.CompanyName = input.CompanyName;
            job.CompanyScaleId = input.CompanyScaleId;
            job.InProgress = input.InProgress;
            job.JobTitle = input.JobTitle;
            job.SalaryId = input.SalaryId;
            db.Jobs.Update(job);
            db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

        //[Route("RemoveJob")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult RemoveJob(RemoveUserJobsRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "01");
            UserJob job = db.Jobs.Where(o => o.Id == input.Id && o.User == user).FirstOrDefault();
            if (job == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");
            db.Jobs.Remove(job);
            db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

        /*Languages*/

        //[Route("GetLanguages")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetLanguages()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            var testerLanguages = db.UserLanguages.Where(o => o.User.MobileNumber == mobileNumber).Select(a => new
            {
                Id = a.Id,
                LanguageId = a.LanguageId,
                ReadingRate = a.ReadingRate,
                WritingRate = a.WritingRate,
                SpeakingRate = a.SpeakingRate

            }
                    ).ToList();
            return new JsonResult(testerLanguages);
        }

        //[Route("AddLanguage")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult AddLanguage(UserLanguageAddRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_ADD_LANGUAGE + "01");
            UserLanguage lang = new UserLanguage()
            {
                LanguageId = input.LanguageId,
                ReadingRate = input.ReadingRate,
                WritingRate = input.WritingRate,
                SpeakingRate = input.SpeakingRate,
                Status = 0,
                User = user
            };
            db.UserLanguages.Add(lang);
            db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        //[Route("UpdateLanguage")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult UpdateLanguage(UserLanguageUpdateRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            UserLanguage language = db.UserLanguages.Where(e => e.User.Id == user.Id && e.Id == input.Id).FirstOrDefault();
            if (language == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_LANGUAGE + "01");

            language.LanguageId = input.LanguageId;
            language.ReadingRate = input.ReadingRate;
            language.WritingRate = input.WritingRate;
            language.SpeakingRate = input.SpeakingRate;
            db.UserLanguages.Update(language);
            db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        //[Route("RemoveLanguage")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult RemoveLanguage(RemoveUserLanguageRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_LANGUAGE + "01");
            UserLanguage lang = db.UserLanguages.Where(o => o.Id == input.Id && o.User == user).FirstOrDefault();
            if (lang == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_LANGUAGE + "02");
            db.UserLanguages.Remove(lang);
            db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        /*Favorites*/

        //[Route("GetFavorites")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetFavorites()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            var Favorites = db.UserFavorites.Where(o => o.User.MobileNumber == mobileNumber).Select(a => new
            {
                Id = a.Id,
                TagId = a.Tag.Id,
                Category = a.Tag.Category

            }
            ).ToList();
            return new JsonResult(Favorites);
        }

        //[Route("UpdateFavorites")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult UpdateFavorites(AddUserFavoritRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_ADD_FAVORITE + "01");
            db.UserFavorites.RemoveRange(db.UserFavorites.Where(p => p.User == user).ToList());
            List<FavoriteTag> tags = db.FavoriteTags.Where(o => input.TagIds.Contains(o.Id)).ToList();

            List<UserFavorite> UserFavorites = new List<UserFavorite>();
            foreach (FavoriteTag tag in tags) {
                UserFavorites.Add(new UserFavorite
                {
                    Tag = tag,
                    User = user
                });
            }
            db.UserFavorites.AddRange(UserFavorites);
            db.SaveChanges();

            return new JsonResult(GetFavorites().Value);
        }

        //[Route("RemoveFavorite")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult RemoveFavorite(RemoveUserFavoritRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_FAVORITE + "01");
            UserFavorite userfav = db.UserFavorites.Where(o => o.Id == input.UserFavoritId && o.User == user).FirstOrDefault();
            if (userfav == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_FAVORITE + "02");
            db.UserFavorites.Remove(userfav);
            db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        /*social*/




        //[Route("GetSocials")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetSocials()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            List<UserSocials> socials = db.UserSocials.Where(o => o.User.MobileNumber == mobileNumber).ToList();
            return new JsonResult(socials);
        }

        //[Route("AddSocial")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult AddSocial(UserSocialAddRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_ADD_JOB + "01");
            UserSocials Social = new UserSocials()
            {
                SocialType = input.SocialType,
                Address = input.Address,
                ActivateTimeId = input.ActivateTimeId,
                Status = 0,
                User = user
            };
            db.UserSocials.Add(Social);
            db.SaveChanges();

            return new JsonResult(GetSocials().Value);
        }


       //[Route("UpdateSocial")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult UpdateSocial(UserSocialUpdateRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            UserSocials Social = db.UserSocials.Where(e => e.User.Id == user.Id && e.Id == input.Id).FirstOrDefault();
            if (Social == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            Social.SocialType = input.SocialType;
            Social.Address = input.Address;
            Social.ActivateTimeId = input.ActivateTimeId;
            db.UserSocials.Update(Social);
            db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

       //[Route("RemoveSocial")]
        [HttpPost]
        [Authorize(Roles = "tester")]
        public JsonResult RemoveSocial(UserSocialRemoveRequest input)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            User user = db.Users.Where(o => o.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "01");
            UserSocials Social = db.UserSocials.Where(o => o.Id == input.Id && o.User == user).FirstOrDefault();
            if (Social == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد", ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");
            db.UserSocials.Remove(Social);
            db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }


        /*Percentage*/

        //[Route("GetProfilePercentage")]
        [HttpGet]
        [Authorize(Roles = "tester")]
        public JsonResult GetProfilePercentage()
        {
            int perc = 0;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var mobileNumber = claim[0].Value;
            TesterProfile testerProfile = db.TesterProfiles.Where(o => o.User.MobileNumber == mobileNumber).FirstOrDefault();
            List<UserEducation> educations = db.Educations.Where(o => o.User.MobileNumber == mobileNumber).ToList();
            List<UserLanguage> languages = db.UserLanguages.Where(o => o.User.MobileNumber == mobileNumber).ToList();
            List<UserJob> jobs = db.Jobs.Where(o => o.User.MobileNumber == mobileNumber).ToList();
            List<UserSocials> socials = db.UserSocials.Where(o => o.User.MobileNumber == mobileNumber).ToList();
            List<UserFavorite> favorits = db.UserFavorites.Include(f=>f.Tag).Where(o => o.User.MobileNumber == mobileNumber).ToList();
            if (testerProfile == null)
                testerProfile = new TesterProfile();
            if (testerProfile.UserName != null&& testerProfile.UserName != "")
                perc++;
            if (testerProfile.NickName != null && testerProfile.NickName != "")
                perc++;
            if (testerProfile.UserBio != null && testerProfile.UserBio != "")
                perc++;
            if (testerProfile.RelationType > 0)
                perc++;
            if (testerProfile.ProfileImageUrl != null && testerProfile.ProfileImageUrl != "")
                perc++;
            if (testerProfile.PostalCode != null && testerProfile.PostalCode != "")
                perc++;
            if (testerProfile.GenderType > 0)
                perc++;
            if (testerProfile.BirthDay != null )
                perc++;
            if (testerProfile.PhoneNumber != null && testerProfile.PhoneNumber != "")
                perc++;
                perc++;
            if (testerProfile.NationalCode > 0)
                perc++;
            if (testerProfile.Email != null && testerProfile.Email != "")
                perc++;
            if (testerProfile.EmailVerified)
                perc++;
                perc++;
            if (educations.Count > 0)
                perc++;
            if (educations.Count > 1)
                perc++;
            if (languages.Count > 0)
                perc++;
            if (jobs.Count > 0)
                perc++;
            if (socials.Count > 0)
                perc++;
            if (socials.Count > 1)
                perc++;
            if (socials.Count > 2)
                perc++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 0)
                perc++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 1)
                perc++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 2)
                perc++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 3)
                perc++;
            return new JsonResult(perc*4);
        }


        


        public string ERROR_GET_PROFILE = "01";
        public string ERROR_SET_PROFILE = "02";
        public string ERROR_GET_EDUCATIONS = "03";
        public string ERROR_Add_EdUcation = "04";
        public string ERROR_REMOVE_EDUCATION = "05";
        public string ERROR_GET_JOBS = "06";
        public string ERROR_ADD_JOB = "07";
        public string ERROR_REMOVE_JOB = "08";
        public string ERROR_GET_LANGUAGES = "09";
        public string ERROR_ADD_LANGUAGE = "10";
        public string ERROR_REMOVE_LANGUAGE = "11";
        public string ERROR_GET_FAVORITES = "12";
        public string ERROR_ADD_FAVORITE = "13";
        public string ERROR_REMOVE_FAVORITE = "14";
        public string ERROR_GET_PROFILE_PERCENTAGE = "15";
        public string ERROR_GET_GENERAL_PROFILE = "16";
        public string ERROR_SET_GENERAL_PROFILE = "17";
        public string ERROR_GET_PERSONAL_PROFILE = "18";
        public string ERROR_SET_PERSONAL_PROFILE = "19";
        public string ERROR_UPDATE_EDUCATION = "20";
        public string ERROR_UPDATE_LANGUAGE = "21";

    }
}