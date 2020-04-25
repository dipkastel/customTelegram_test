using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Common.Filters;
using alphadinCore.data;
using alphadinCore.Model;
using alphadinCore.Model.controllerModels;
using alphadinCore.Model.dbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alphadinCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TrackMethodsFilter]
    [ResultFixer]
    public class GeneralDataController : ControllerBase
    {

        private dbContextModel db;
        public GeneralDataController(dbContextModel _db)
        {
            db = _db;
        }


        [Route("GetRelationTypes")]
        [HttpGet]
        public JsonResult GetRelationTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.Relation).Select(s=>new { 
            ID=s.TypeKey,
            Name = s.TypeName
            }).ToList());
        }

        [Route("GetGenderTypes")]
        [HttpGet]
        public JsonResult GetGenderTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.Gender).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetEducationGrades")]
        [HttpGet]
        public JsonResult GetEducationGrades()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.EducationGrades).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetJobSalaries")]
        [HttpGet]
        public JsonResult GetJobSalaries()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.JobSalaries).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetCompanyScales")]
        [HttpGet]
        public JsonResult GetCompanyScales()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.CompanyScales).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        [Route("GetSocialTypes")]
        [HttpGet]
        public JsonResult GetSocialTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.SocialTypes).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        [Route("GetActivateTimeType")]
        [HttpGet]
        public JsonResult GetActivateTimeType()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)TypeModel.ActivateTimeType).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }

        [Route("GetLanguages")]
        [HttpGet]
        public JsonResult GetLanguages()
        {
            List<LanguageModel> languages = db.Languages.ToList();
            return new JsonResult(languages);
        }

        [Route("GetFavoriteTags")]
        [HttpGet]
        public JsonResult GetFavoriteTags()
        {
            List<FavoriteTagModel> favorites = db.FavoriteTags.ToList();
            return new JsonResult(favorites);
        }

        [Route("GetCityCodes")]
        [HttpGet]
        public JsonResult GetCityCodes()
        {
            IQueryable<LocationModel> locations = db.Locations;
            List<LocationModel> master = locations.Where(p => p.Parent == null).ToList();
            foreach (LocationModel loc in master) {
                Addchilds(loc,locations);
            }
            return new JsonResult(master);
        }

        private void Addchilds(LocationModel loc, IQueryable<LocationModel> locations)
        {
            List<LocationModel> childs = locations.Where(i => i.Parent.Id == loc.Id).ToList();
            loc.Childs = childs;
            foreach (LocationModel child in childs) {
                Addchilds(child, locations);
            }
        }
    }
}