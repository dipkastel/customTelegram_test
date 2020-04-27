using System.Collections.Generic;
using System.Linq;
using alphadinCore.Common.Filters;
using Database.Common.Enums;
using Database.Config;
using Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace alphadinCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TrackMethodsFilter]
    [ResultFixer]
    public class GeneralDataController : ControllerBase
    {

        private DbContextModel db;
        public GeneralDataController(DbContextModel _db)
        {
            db = _db;
        }


        [Route("GetRelationTypes")]
        [HttpGet]
        public JsonResult GetRelationTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.Relation).Select(s=>new { 
            ID=s.TypeKey,
            Name = s.TypeName
            }).ToList());
        }

        [Route("GetGenderTypes")]
        [HttpGet]
        public JsonResult GetGenderTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.Gender).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetEducationGrades")]
        [HttpGet]
        public JsonResult GetEducationGrades()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.EducationGrades).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetJobSalaries")]
        [HttpGet]
        public JsonResult GetJobSalaries()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.JobSalaries).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        
        [Route("GetCompanyScales")]
        [HttpGet]
        public JsonResult GetCompanyScales()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.CompanyScales).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        [Route("GetSocialTypes")]
        [HttpGet]
        public JsonResult GetSocialTypes()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.SocialTypes).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }
        [Route("GetActivateTimeType")]
        [HttpGet]
        public JsonResult GetActivateTimeType()
        {
            return new JsonResult(db.GeneralTypes.Where(o => o.TypeModel == (int)GeneralTypeModel.ActivateTimeType).Select(s => new {
                ID = s.TypeKey,
                Name = s.TypeName
            }).ToList());
        }

        [Route("GetLanguages")]
        [HttpGet]
        public JsonResult GetLanguages()
        {
            List<Language> languages = db.Languages.ToList();
            return new JsonResult(languages);
        }

        [Route("GetFavoriteTags")]
        [HttpGet]
        public JsonResult GetFavoriteTags()
        {
            List<FavoriteTag> favorites = db.FavoriteTags.ToList();
            return new JsonResult(favorites);
        }

        [Route("GetCityCodes")]
        [HttpGet]
        public JsonResult GetCityCodes()
        {
            IQueryable<Location> locations = db.Locations;
            List<Location> master = locations.Where(p => p.Parent == null).ToList();
            foreach (Location loc in master) {
                Addchilds(loc,locations);
            }
            return new JsonResult(master);
        }

        private void Addchilds(Location loc, IQueryable<Location> locations)
        {
            List<Location> childs = locations.Where(i => i.Parent.Id == loc.Id).ToList();
            loc.Childs = childs;
            foreach (Location child in childs) {
                Addchilds(child, locations);
            }
        }
    }
}