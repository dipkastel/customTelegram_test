using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.controllerModels
{
    public class TesterProfileModels
    {
    }

    public class TesterProfileSetRequst
    {

        public DateTime BirthDay { get; set; }
        public int RelationType { get; set; }
        public int GenderType { get; set; }
        public long NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public int cityCode { get; set; }
        public string UserName { get; set; }

    }
    public class UserEducationAddRequest
    {
        public int Grade { get; set; }
        public string Major { get; set; }
        public string Place { get; set; }
        public bool InProgress { get; set; }

    }
    public class UserEducationUpdateRequest
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Major { get; set; }
        public string Place { get; set; }
        public bool InProgress { get; set; }

    }
    public class RemoveUserEducationRequest
    {
        public int Id { get; set; }

    }
    public class UserJobAddRequest
    {
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int SalaryId { get; set; }
        public int CompanyScaleId { get; set; }
        public bool InProgress { get; set; }

    }
    public class UserJobUpdateRequest
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public int SalaryId { get; set; }
        public int CompanyScaleId { get; set; }
        public bool InProgress { get; set; }

    }
    public class RemoveUserJobsRequest
    {
        public int Id { get; set; }

    }
    public class UserLanguageAddRequest
    {
        public int LanguageId { get; set; }
        public int ReadingRate { get; set; }
        public int WritingRate { get; set; }
        public int SpeakingRate { get; set; }

    }
    public class UserLanguageUpdateRequest
    {

        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int ReadingRate { get; set; }
        public int WritingRate { get; set; }
        public int SpeakingRate { get; set; }

    }
    public class UserSocialRemoveRequest
    {
        public int Id { get; set; }

    }
    public class UserSocialAddRequest
    {
        public int SocialType { get; set; }
        public string Address { get; set; }
        public int ActivateTimeId { get; set; }

    }
    public class UserSocialUpdateRequest
    {
        public int Id { get; set; }
        public int SocialType { get; set; }
        public string Address { get; set; }
        public int ActivateTimeId { get; set; }

    }
    public class RemoveUserLanguageRequest
    {
        public int Id { get; set; }

    }
    
    public class AddUserFavoritRequest
    {
        public List<int> TagIds { get; set; }

    }
    
    public class RemoveUserFavoritRequest
    {
        public int UserFavoritId { get; set; }

    }
    
    public class SetGeneralProfileRequest
    {
        public string NickName { get; set; }
        public string Bio { get; set; }
        public int GenderType { get; set; }

    }
    public class SetPersonalProfileRequest
    {
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public int RelationType { get; set; }
        public long NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public int cityCode { get; set; }

    }

}
