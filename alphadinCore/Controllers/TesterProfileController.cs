using System;
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
using Services.ViewModels.TesterProfile;

namespace alphadinCore.Model.controllerModels
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TesterProfileController : BaseController
    {
        private  User _user;
        private readonly ITesterProfileService _profileService;
        private readonly IUserEducationService _educationService;
        private readonly IUserJobService _jobService;
        private readonly IUserLanguageService _languageService;
        private readonly IUserFavoriteService _userFavoriteService;
        private readonly IFavoriteTagService _favoriteTagService;
        private readonly IUserSocialsService _socialsService;

        public TesterProfileController(IOnlineUserService onlineUserService,
            ITesterProfileService profileService, IUserEducationService educationService, IUserJobService jobService, IUserLanguageService languageService, IUserFavoriteService userFavoriteService, IFavoriteTagService favoriteTagService, IUserSocialsService socialsService) : base(onlineUserService)
        {
            _profileService = profileService;
            _educationService = educationService;
            _jobService = jobService;
            _languageService = languageService;
            _userFavoriteService = userFavoriteService;
            _favoriteTagService = favoriteTagService;
            _socialsService = socialsService;
        }


        #region User Profile

        [HttpGet]
        public JsonResult GetProfile()
        {
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.GetAllIncluding(tp => tp.User,
                                        tp => tp.User.Role).FirstOrDefault(tp => tp.OwnerUserId == _user.Id) ??
                                new TesterProfile();

            var result = new
            {
                mobileNumber = _user.Id,
                role = (testerProfile.User?.Role != null)
                    ? testerProfile.User.Role.Name
                    : "tester",
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
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.Find(tp => tp.OwnerUserId == _user.Id).Data ?? new TesterProfile();

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

            _profileService.Update(testerProfile, _user.Id);

            return new JsonResult(testerProfile);
        }

        [HttpGet]
        public JsonResult GetGeneralProfile()
        {
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.Find(tp => tp.OwnerUserId == _user.Id).Data ?? new TesterProfile();

            var generalProfile = new GeneralProfileViewModel()
            {
                NickName = testerProfile.NickName,
                Bio = testerProfile.UserBio,
                Gender = testerProfile.GenderType,
                ImageUrl = testerProfile.ProfileImageUrl
            };

            return new JsonResult(generalProfile);
        }


        [HttpPost]
        public JsonResult SetGeneralProfile(SetGeneralProfileRequest input)
        {
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.Find(tp => tp.OwnerUserId == _user.Id).Data ?? new TesterProfile();

            testerProfile.User = _user;
            testerProfile.NickName = input.NickName;
            testerProfile.UserBio = input.Bio;
            testerProfile.GenderType = input.GenderType;

            _profileService.Update(testerProfile, _user.Id);

            return new JsonResult(GetGeneralProfile().Value);
        }

        [HttpGet]
        public JsonResult GetPersonalProfile()
        {
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.Find(tp => tp.OwnerUserId == _user.Id).Data ?? new TesterProfile();

            var personalProfile = new PersonalProfileViewModel()
            {
                UserName = testerProfile.UserName,
                Email = testerProfile.Email,
                EmailVerified = testerProfile.EmailVerified,
                BirthDay = testerProfile.BirthDay,
            };

            return new JsonResult(personalProfile);
        }

        [HttpPost]
        public JsonResult SetPersonalProfile(SetPersonalProfileRequest input)
        {
            _user = GetUser(HttpContext);

            var testerProfile = _profileService.Find(tp => tp.OwnerUserId == _user.Id).Data ?? new TesterProfile();


            testerProfile.User = _user;
            testerProfile.UserName = input.UserName;
            testerProfile.BirthDay = input.BirthDay;
            testerProfile.RelationType = input.RelationType;
            testerProfile.NationalCode = input.NationalCode;
            testerProfile.PhoneNumber = input.PhoneNumber;
            testerProfile.Email = input.Email;
            testerProfile.PostalCode = input.PostalCode;
            testerProfile.CityCode = input.cityCode;

            _profileService.Update(testerProfile, _user.Id);

            return new JsonResult(GetPersonalProfile().Value);
        }

        #endregion


        #region User Educations


        [HttpGet]
        public JsonResult GetEducations()
        {
            _user = GetUser(HttpContext);


            var testerProfile = _educationService.FindAll(o => o.OwnerUserId == _user.Id)
                .Data
                .Select(userEducation =>
                    new UserEducationViewModel(userEducation.Id,
                        userEducation.Grade,
                        userEducation.Major,
                        userEducation.Place,
                        userEducation.InProgress))
                .ToList();

            return new JsonResult(testerProfile);
        }

        [HttpPost]
        public JsonResult AddEducation(UserEducationAddRequest input)
        {
            _user = GetUser(HttpContext);

            var education = new UserEducation()
            {
                Grade = input.Grade,
                Major = input.Major,
                Place = input.Place,
                InProgress = input.InProgress,
                Status = 0,
                User = _user
            };

            _educationService.Add(education, _user.Id);

            return new JsonResult(GetEducations().Value);
        }

        [HttpPost]
        public JsonResult UpdateEducation(UserEducationUpdateRequest input)
        {
            _user = GetUser(HttpContext);

            var education = _educationService.Find(ue => ue.OwnerUserId == _user.Id && ue.Id == input.Id).Data;

            if (education == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            education.Grade = input.Grade;
            education.Major = input.Major;
            education.Place = input.Place;
            education.InProgress = input.InProgress;

            _educationService.Update(education, _user.Id);

            return new JsonResult(GetEducations().Value);
        }

        [HttpPost]
        public JsonResult RemoveEducation(RemoveUserEducationRequest input)
        {
            _user = GetUser(HttpContext);

            var education = _educationService.Find(ue => ue.OwnerUserId == _user.Id && ue.Id == input.Id).Data;

            if (education == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_EDUCATION + "02");

            _educationService.Disable(education.Id, _user.Id);

            return new JsonResult(GetEducations().Value);
        }

        #endregion


        #region User Jobs

        [HttpGet]
        public JsonResult GetJobs()
        {
            _user = GetUser(HttpContext);

            var testerProfile = _jobService.FindAll(o => o.OwnerUserId == _user.Id)
                .Data
                .Select(userJob => new UserJobViewModel(userJob.Id,
                    userJob.CompanyName,
                    userJob.JobTitle,
                    userJob.SalaryId,
                    userJob.CompanyScaleId,
                    userJob.InProgress)
                )
                .ToList();

            return new JsonResult(testerProfile);
        }

        [HttpPost]
        public JsonResult AddJob(UserJobAddRequest input)
        {
            _user = GetUser(HttpContext);

            var job = new UserJob()
            {
                CompanyName = input.CompanyName,
                JobTitle = input.JobTitle,
                SalaryId = input.SalaryId,
                CompanyScaleId = input.CompanyScaleId,
                InProgress = input.InProgress,
                Status = 0,
                User = _user
            };

            _jobService.Add(job, _user.Id);

            return new JsonResult(GetJobs().Value);
        }


        [HttpPost]
        public JsonResult UpdateJob(UserJobUpdateRequest input)
        {
            _user = GetUser(HttpContext);

            var job = _jobService.Find(uj => uj.OwnerUserId == _user.Id && uj.Id == input.Id).Data;

            if (job == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            job.CompanyName = input.CompanyName;
            job.CompanyScaleId = input.CompanyScaleId;
            job.InProgress = input.InProgress;
            job.JobTitle = input.JobTitle;
            job.SalaryId = input.SalaryId;

            _jobService.Update(job, _user.Id);

            return new JsonResult(GetJobs().Value);
        }

        [HttpPost]
        public JsonResult RemoveJob(RemoveUserJobsRequest input)
        {
            _user = GetUser(HttpContext);

            var job = _jobService.Find(o => o.Id == input.Id && o.OwnerUserId == _user.Id).Data;

            if (job == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");

            _jobService.Disable(job.Id, _user.Id);

            return new JsonResult(GetJobs().Value);
        }

        #endregion


        #region User Languages

        [HttpGet]
        public JsonResult GetLanguages()
        {
            _user = GetUser(HttpContext);
            var testerLanguages = _languageService.FindAll(o => o.OwnerUserId == _user.Id)
                .Data.Select(userLanguage =>
                    new UserLanguesViewModel(userLanguage.Id,
                        userLanguage.LanguageId,
                        userLanguage.ReadingRate,
                        userLanguage.WritingRate,
                        userLanguage.SpeakingRate)
                )
                .ToList();
            return new JsonResult(testerLanguages);
        }

        [HttpPost]
        public JsonResult AddLanguage(UserLanguageAddRequest input)
        {
            _user = GetUser(HttpContext);

            var lang = new UserLanguage()
            {
                LanguageId = input.LanguageId,
                ReadingRate = input.ReadingRate,
                WritingRate = input.WritingRate,
                SpeakingRate = input.SpeakingRate,
                Status = 0,
                User = _user
            };

            _languageService.Add(lang, _user.Id);

            return new JsonResult(GetLanguages().Value);
        }

        [HttpPost]
        public JsonResult UpdateLanguage(UserLanguageUpdateRequest input)
        {
            _user = GetUser(HttpContext);

            var language = _languageService.Find(e => e.OwnerUserId == _user.Id && e.Id == input.Id).Data;

            if (language == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_LANGUAGE + "01");

            language.LanguageId = input.LanguageId;
            language.ReadingRate = input.ReadingRate;
            language.WritingRate = input.WritingRate;
            language.SpeakingRate = input.SpeakingRate;

            _languageService.Update(language, _user.Id);

            return new JsonResult(GetLanguages().Value);
        }

        [HttpPost]
        public JsonResult RemoveLanguage(RemoveUserLanguageRequest input)
        {
            _user = GetUser(HttpContext);

            var lang = _languageService.Find(o => o.Id == input.Id && o.OwnerUserId == _user.Id).Data;

            if (lang == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_LANGUAGE + "02");

            _languageService.Disable(lang.LanguageId, _user.Id);

            return new JsonResult(GetLanguages().Value);
        }

        #endregion


        #region User Favorites

        [HttpGet]
        public JsonResult GetFavorites()
        {
            _user = GetUser(HttpContext);
            var favorites = _userFavoriteService.FindAll(o => o.OwnerUserId == _user.Id)
                .Data.Select(
                    userFavorite =>
                        new UserFavoriteViewModel(userFavorite.Id,
                            userFavorite.Tag.Id,
                            userFavorite.Tag.Category)
                )
                .ToList();
            return new JsonResult(favorites);
        }

        [HttpPost]
        public JsonResult UpdateFavorites(AddUserFavoritRequest input)
        {
            _user = GetUser(HttpContext);

            _userFavoriteService.DisableAll(_user.Id);

            var tags = _favoriteTagService.FindAll(o => input.TagIds.Contains(o.Id)).Data;

            var userFavorites = tags.Select(tag => new UserFavorite {Tag = tag, User = _user}).ToList();

            _userFavoriteService.AddRange(userFavorites, _user.Id);
            
            return new JsonResult(GetFavorites().Value);
        }

        [HttpPost]
        public JsonResult RemoveFavorite(RemoveUserFavoritRequest input)
        {
            _user = GetUser(HttpContext);

            var userFavorite = _userFavoriteService.Find(f => f.Id == input.UserFavoritId && f.OwnerUserId == _user.Id).Data;

            if (userFavorite == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_FAVORITE + "02");

            _userFavoriteService.Disable(userFavorite.Id, _user.Id);

            return new JsonResult(GetLanguages().Value);
        }

        #endregion


        #region User Social

        [HttpGet]
        public JsonResult GetSocials()
        {
            _user = GetUser(HttpContext);
            var socials = _socialsService.FindAll(o => o.OwnerUserId == _user.Id).Data;
            return new JsonResult(socials);
        }

        [HttpPost]
        public JsonResult AddSocial(UserSocialAddRequest input)
        {
            _user = GetUser(HttpContext);

            var social = new UserSocials()
            {
                SocialType = input.SocialType,
                Address = input.Address,
                ActivateTimeId = input.ActivateTimeId,
                Status = 0,
                User = _user
            };

            _socialsService.Add(social, _user.Id);

            return new JsonResult(GetSocials().Value);
        }

        [HttpPost]
        public JsonResult UpdateSocial(UserSocialUpdateRequest input)
        {
            _user = GetUser(HttpContext);

            var social = _socialsService.Find(us => us.OwnerUserId == _user.Id && us.Id == input.Id).Data;

            if (social == null)
                throw new CustomException("رکوردی برای آپدیت وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_UPDATE_EDUCATION + "01");

            social.SocialType = input.SocialType;
            social.Address = input.Address;
            social.ActivateTimeId = input.ActivateTimeId;

            _socialsService.Update(social, _user.Id);

            return new JsonResult(GetJobs().Value);
        }

        [HttpPost]
        public JsonResult RemoveSocial(UserSocialRemoveRequest input)
        {
            _user = GetUser(HttpContext);
            var social = _socialsService.Find(o => o.Id == input.Id && o.OwnerUserId == _user.Id).Data;

            if (social == null)
                throw new CustomException("رکوردی برای حذف وجود ندارد",
                    ErrorsPreFix.CONTROLLER_ACOUNT + ERROR_REMOVE_JOB + "02");

            _socialsService.Disable(social.Id, _user.Id);

            return new JsonResult(GetJobs().Value);
        }

        #endregion


        #region User Percentage

        [HttpGet]
        public JsonResult GetProfilePercentage()
        {
            _user = GetUser(HttpContext);
            var percentage = 0;

            var testerProfile = _profileService.Find(o => o.OwnerUserId == _user.Id).Data;
            var educations = _educationService.FindAll(o => o.OwnerUserId == _user.Id).Data;
            var languages = _languageService.FindAll(o => o.OwnerUserId == _user.Id).Data;
            var jobs = _jobService.FindAll(o => o.OwnerUserId == _user.Id).Data;
            var socials = _socialsService.FindAll(o => o.OwnerUserId == _user.Id).Data;
            var favorits = _userFavoriteService.GetAllIncluding(f => f.Tag).Where(o => o.OwnerUserId == _user.Id).ToList();

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

            if (testerProfile.BirthDay > DateTime.MinValue)
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

        #endregion


        #region ErrorCodes

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

        #endregion


    }
}