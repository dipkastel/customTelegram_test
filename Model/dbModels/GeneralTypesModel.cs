using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.Model.dbModels
{
    public class GeneralTypesModel
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Status { get; set; }
        public int TypeModel { get; set; }
        public int TypeKey { get; set; }
        public string TypeName { get; set; }

    }

    enum TypeModel { Relation = 0, Gender = 1 , EducationGrades = 2 , JobSalaries = 3 , CompanyScales = 4 , SocialTypes = 5 , ActivateTimeType = 6 }


}
