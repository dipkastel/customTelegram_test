using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using alphadinCore.Common.Controllers;
using alphadinCore.Model.NetworkModels;
using Authentication.Services.Interface;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Operator.Interfaces;

namespace alphadinCore.Model.controllerModels
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class TesterProfileController : BaseController
    {
        private readonly DbContextModel _db;
        private readonly User _user;
        private readonly ITesterProfileService _testerProfileService;

        public TesterProfileController(DbContextModel db, IOnlineUserService onlineUserService,
            ITesterProfileService testerProfileService) : base(onlineUserService)
        {
            _user = GetUser();
            _db = db;
            _testerProfileService = testerProfileService;
        }

        /*profile*/

        [HttpGet]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client, NoStore = false)]
        public JsonResult GetProfile()
        {
            var testerProfile = _db.TesterProfiles
                                    .Include(o => o.User)
                                    .ThenInclude(u => u.Role)
                                    .FirstOrDefault(o => o.User == _user) ?? new TesterProfile();
                //_testerProfileService.Include(o=>o.User).MyThenInclude(u => u.)

            var result = new
            {
                mobileNumber = _user.Id,
                role = (testerProfile.User?.Role != null) ? testerProfile.User.Role.Name : "tester",
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

        [HttpPost]
        public JsonResult SetProfile(TesterProfileSetRequst input)
        {
            var testerProfile = _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id) ?? new TesterProfile();

            testerProfile.User = _user;
            testerProfile.BirthDay = input.BirthDay;
            testerProfile.CityCode = input.cityCode;
            testerProfile.Email = input.Email;
            testerProfile.GenderType = input.GenderType;
            testerProfile.NationalCode = input.NationalCode;
            testerProfile.PhoneNumber = input.PhoneNumber;
            testerProfile.PostalCode = input.PostalCode;
            testerProfile.RelationType = input.RelationType;
            testerProfile.UserName = input.UserName;

            _db.TesterProfiles.Update(testerProfile);
            _db.SaveChanges();

            return new JsonResult(testerProfile);
        }

        [HttpGet]
        public JsonResult GetGeneralProfile()
        {
            var testerProfile = _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id) ??
                                new TesterProfile();

            var result = new
            {
                NickName = testerProfile.NickName,
                Bio = testerProfile.UserBio,
                Gender = testerProfile.GenderType,
                ImageUrl = testerProfile.ProfileImageUrl
            };

            return new JsonResult(result);
        }


        [HttpPost]
        public JsonResult SetGeneralProfile(SetGeneralProfileRequest input)
        {
            var testerProfile =
                _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id) ??
                new TesterProfile();

            testerProfile.User = _user;
            testerProfile.NickName = input.NickName;
            testerProfile.UserBio = input.Bio;
            testerProfile.GenderType = input.GenderType;

            _db.TesterProfiles.Update(testerProfile);
            _db.SaveChanges();

            return new JsonResult(GetGeneralProfile().Value);
        }

        [HttpGet]
        public JsonResult GetPersonalProfile()
        {
            var testerProfile =
                _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id) ??
                new TesterProfile();

            var result = new
            {
                UserName = testerProfile.UserName,
                Email = testerProfile.Email,
                EmailVerified = testerProfile.EmailVerified,
                BirthDay = testerProfile.BirthDay,
            };

            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult SetPersonalProfile(SetPersonalProfileRequest input)
        {
            var testerProfile =
                _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id) ??
                new TesterProfile();

            testerProfile.User = _user;
            testerProfile.UserName = input.UserName;
            testerProfile.BirthDay = input.BirthDay;
            testerProfile.RelationType = input.RelationType;
            testerProfile.NationalCode = input.NationalCode;
            testerProfile.PhoneNumber = input.PhoneNumber;
            testerProfile.Email = input.Email;
            testerProfile.PostalCode = input.PostalCode;
            testerProfile.CityCode = input.cityCode;

            _db.TesterProfiles.Update(testerProfile);
            _db.SaveChanges();

            return new JsonResult(GetPersonalProfile().Value);
        }

        /*Educations*/

        [HttpGet]
        public JsonResult GetEducations()
        {
            var testerProfile = _db.Educations.Where(o => o.User.Id == _user.Id)
                .Select(a =>
                    new
                    {
                        Id = a.Id,
                        Grade = a.Grade,
                        Major = a.Major,
                        place = a.Place,
                        InProgress = a.InProgress
                    })
                .ToList();

            return new JsonResult(testerProfile);
        }

        [HttpPost]
        public JsonResult AddEducation(UserEducationAddRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_Add_EdUcation + "01");

            var education = new UserEducation()
            {
                Grade = input.Grade,
                Major = input.Major,
                Place = input.Place,
                InProgress = input.InProgress,
                Status = 0,
                User = user
            };

            _db.Educations.Add(education);
            _db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        [HttpPost]
        public JsonResult UpdateEducation(UserEducationUpdateRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            var education = _db.Educations.FirstOrDefault(e => e.User.Id == user.Id && e.Id == input.Id);

            if (education == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            education.Grade = input.Grade;
            education.Major = input.Major;
            education.Place = input.Place;
            education.InProgress = input.InProgress;

            _db.Educations.Update(education);
            _db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        [HttpPost]
        public JsonResult RemoveEducation(RemoveUserEducationRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_EDUCATION + "01");

            var education = _db.Educations.FirstOrDefault(o => o.Id == input.Id && o.User == user);
            if (education == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_EDUCATION + "02");

            _db.Educations.Remove(education);
            _db.SaveChanges();

            return new JsonResult(GetEducations().Value);
        }

        /*Jobs*/

        [HttpGet]
        public JsonResult GetJobs()
        {
            var testerProfile = _db.Jobs.Where(o => o.User.Id == _user.Id).Select(a => new
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

        [HttpPost]
        public JsonResult AddJob(UserJobAddRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            var job = new UserJob()
            {
                CompanyName = input.CompanyName,
                JobTitle = input.JobTitle,
                SalaryId = input.SalaryId,
                CompanyScaleId = input.CompanyScaleId,
                InProgress = input.InProgress,
                Status = 0,
                User = user
            };

            _db.Jobs.Add(job);
            _db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }


        [HttpPost]
        public JsonResult UpdateJob(UserJobUpdateRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            var job = _db.Jobs.FirstOrDefault(e => e.User.Id == user.Id && e.Id == input.Id);

            if (job == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            job.CompanyName = input.CompanyName;
            job.CompanyScaleId = input.CompanyScaleId;
            job.InProgress = input.InProgress;
            job.JobTitle = input.JobTitle;
            job.SalaryId = input.SalaryId;
            _db.Jobs.Update(job);
            _db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

        [HttpPost]
        public JsonResult RemoveJob(RemoveUserJobsRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "01");

            var job = _db.Jobs.FirstOrDefault(o => o.Id == input.Id && o.User == user);

            if (job == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");

            _db.Jobs.Remove(job);
            _db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

        /*Languages*/

        [HttpGet]
        public JsonResult GetLanguages()
        {
            var testerLanguages = _db.UserLanguages.Where(o => o.User.Id == _user.Id).Select(a =>
                new
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

        [HttpPost]
        public JsonResult AddLanguage(UserLanguageAddRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            var lang = new UserLanguage()
            {
                LanguageId = input.LanguageId,
                ReadingRate = input.ReadingRate,
                WritingRate = input.WritingRate,
                SpeakingRate = input.SpeakingRate,
                Status = 0,
                User = user
            };

            _db.UserLanguages.Add(lang);
            _db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        [HttpPost]
        public JsonResult UpdateLanguage(UserLanguageUpdateRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);
            var language = _db.UserLanguages.FirstOrDefault(e => e.User.Id == user.Id && e.Id == input.Id);

            if (language == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_LANGUAGE + "01");

            language.LanguageId = input.LanguageId;
            language.ReadingRate = input.ReadingRate;
            language.WritingRate = input.WritingRate;
            language.SpeakingRate = input.SpeakingRate;
            _db.UserLanguages.Update(language);
            _db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        [HttpPost]
        public JsonResult RemoveLanguage(RemoveUserLanguageRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);

            if (user == null)
                throw new CustomException("کاربر ثبت نام نشده",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_LANGUAGE + "01");

            var lang = _db.UserLanguages.FirstOrDefault(o => o.Id == input.Id && o.User == user);

            if (lang == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_LANGUAGE + "02");

            _db.UserLanguages.Remove(lang);
            _db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        /*Favorites*/

        [HttpGet]
        public JsonResult GetFavorites()
        {
            var favorites = _db.UserFavorites.Where(o => o.User.Id == _user.Id).Select(a => new
                {
                    Id = a.Id,
                    TagId = a.Tag.Id,
                    Category = a.Tag.Category
                }
            ).ToList();
            return new JsonResult(favorites);
        }

        [HttpPost]
        public JsonResult UpdateFavorites(AddUserFavoritRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);
            
            _db.UserFavorites.RemoveRange(_db.UserFavorites.Where(p => p.User == user).ToList());
            var tags = _db.FavoriteTags.Where(o => input.TagIds.Contains(o.Id)).ToList();

            var userFavorites = tags.Select(tag => new UserFavorite {Tag = tag, User = user}).ToList();

            _db.UserFavorites.AddRange(userFavorites);
            _db.SaveChanges();

            return new JsonResult(GetFavorites().Value);
        }

        [HttpPost]
        public JsonResult RemoveFavorite(RemoveUserFavoritRequest input)
        {
            var userFavorite = _db.UserFavorites
                .FirstOrDefault(o => o.Id == input.UserFavoritId && o.User.Id == _user.Id);

            if (userFavorite == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_FAVORITE + "02");

            _db.UserFavorites.Remove(userFavorite);
            _db.SaveChanges();

            return new JsonResult(GetLanguages().Value);
        }

        /*social*/

        [HttpGet]
        public JsonResult GetSocials()
        {
            var socials = _db.UserSocials.Where(o => o.User.Id == _user.Id).ToList();
            return new JsonResult(socials);
        }

        [HttpPost]
        public JsonResult AddSocial(UserSocialAddRequest input)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == _user.Id);

            var social = new UserSocials()
            {
                SocialType = input.SocialType,
                Address = input.Address,
                ActivateTimeId = input.ActivateTimeId,
                Status = 0,
                User = user
            };

            _db.UserSocials.Add(social);
            _db.SaveChanges();

            return new JsonResult(GetSocials().Value);
        }

        [HttpPost]
        public JsonResult UpdateSocial(UserSocialUpdateRequest input)
        {
            var user = _db.Users.FirstOrDefault(o => o.Id == _user.Id);
            var social = _db.UserSocials.FirstOrDefault(e => e.User.Id == user.Id && e.Id == input.Id);

            if (social == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            social.SocialType = input.SocialType;
            social.Address = input.Address;
            social.ActivateTimeId = input.ActivateTimeId;

            _db.UserSocials.Update(social);
            _db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }

        [HttpPost]
        public JsonResult RemoveSocial(UserSocialRemoveRequest input)
        {
            var social = _db.UserSocials.Where(o => o.Id == input.Id && o.User.Id == _user.Id).FirstOrDefault();
            
            if (social == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");
            
            _db.UserSocials.Remove(social);
            _db.SaveChanges();

            return new JsonResult(GetJobs().Value);
        }


        /*Percentage*/

        [HttpGet]
        public JsonResult GetProfilePercentage()
        {
            var percentage = 0;

            var testerProfile = _db.TesterProfiles.FirstOrDefault(o => o.User.Id == _user.Id);
            var educations = _db.Educations.Where(o => o.User.Id == _user.Id).ToList();
            var languages = _db.UserLanguages.Where(o => o.User.Id == _user.Id).ToList();
            var jobs = _db.Jobs.Where(o => o.User.Id == _user.Id).ToList();
            var socials = _db.UserSocials.Where(o => o.User.Id == _user.Id).ToList();

            var favorits =
                _db.UserFavorites.Include(f => f.Tag).Where(o => o.User.Id == _user.Id).ToList();
            if (testerProfile == null)
                testerProfile = new TesterProfile();
            if (!string.IsNullOrWhiteSpace(testerProfile.UserName))
                percentage++;
            if (!string.IsNullOrWhiteSpace(testerProfile.NickName))
                percentage++;
            if (!string.IsNullOrWhiteSpace(testerProfile.UserBio))
                percentage++;
            if (testerProfile.RelationType > 0)
                percentage++;
            if (!string.IsNullOrWhiteSpace(testerProfile.ProfileImageUrl))
                percentage++;
            if (!string.IsNullOrWhiteSpace(testerProfile.PostalCode))
                percentage++;
            if (testerProfile.GenderType > 0)
                percentage++;
            if (testerProfile.BirthDay != null) //TODO: this expression is always true
                percentage++;

            if (!string.IsNullOrWhiteSpace(testerProfile.PhoneNumber))
            {
                percentage++;
                percentage++;
            }

            if (testerProfile.NationalCode > 0)
                percentage++;
            if (!string.IsNullOrWhiteSpace(testerProfile.Email))
                percentage++;
            if (testerProfile.EmailVerified)
            {
                percentage++;
                percentage++;
            }

            if (educations.Any())
                percentage++;
            if (educations.Count > 1)
                percentage++;
            if (languages.Any())
                percentage++;
            if (jobs.Any())
                percentage++;
            if (socials.Any())
                percentage++;
            if (socials.Count > 1)
                percentage++;
            if (socials.Count > 2)
                percentage++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Any())
                percentage++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 1)
                percentage++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 2)
                percentage++;
            if (favorits.GroupBy(f => f.Tag.Category).ToList().Count > 3)
                percentage++;

            return new JsonResult(percentage * 4);
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