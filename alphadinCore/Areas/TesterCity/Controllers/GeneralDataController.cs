using System.Collections.Generic;
using System.Linq;
using alphadinCore.Areas.TesterCity.Common;
using Authentication.Services.Interface;
using Database.Common.Enums;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace alphadinCore.Areas.TesterCity.Controllers
{
    public class GeneralDataController : TesterCityController
    {
        private readonly DbContextModel _db;

        public GeneralDataController(DbContextModel db, IOnlineUserService onlineUserService) : base(onlineUserService)
        {
            _db = db;
        }


        [HttpGet]
        public JsonResult GetRelationTypes()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.Relation).Select(
                s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }

        [HttpGet]
        public JsonResult GetGenderTypes()
        {
            var a = new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.Gender).Select(s =>
                new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());

            return a;
        }
        
        [HttpGet]
        public JsonResult GetEducationGrades()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.EducationGrades)
                .Select(s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }
        
        [HttpGet]
        public JsonResult GetJobSalaries()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.JobSalaries).Select(
                s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }
        
        [HttpGet]
        public JsonResult GetCompanyScales()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.CompanyScales)
                .Select(s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }
        
        [HttpGet]
        public JsonResult GetSocialTypes()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.SocialTypes).Select(
                s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }

        [HttpGet]
        public JsonResult GetActivateTimeType()
        {
            return new JsonResult(_db.GeneralTypes.Where(o => o.TypeModel == (int) GeneralTypeModel.ActivateTimeType)
                .Select(s => new
                {
                    ID = s.TypeKey,
                    Name = s.TypeName
                }).ToList());
        }

        [HttpGet]
        public JsonResult GetLanguages()
        {
            List<Language> languages = _db.Languages.ToList();
            return new JsonResult(languages);
        }

        [HttpGet]
        public JsonResult GetFavoriteTags()
        {
            var favorites = _db.FavoriteTags.ToList();
            return new JsonResult(favorites);
        }

        [HttpGet]
        public JsonResult GetCityCodes()
        {
            IQueryable<Location> allLocations = _db.Locations;
            var countries = allLocations.Where(loc => loc.Parent == null).ToList();
            foreach (var provinces in countries)
            {
                Addchilds(provinces, allLocations);
            }

            return new JsonResult(countries);
        }

        private void Addchilds(Location parentLocation, IQueryable<Location> allLocations)
        {
            var childs = allLocations.Where(loc => loc.Parent.Id == parentLocation.Id).ToList();

            parentLocation.Childs = childs;

            foreach (var childLocation in childs)
            {
                Addchilds(childLocation, allLocations);
            }
        }
    }
}