using alphadinCore.Model;
using alphadinCore.Model.dbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphadinCore.data
{
    public class FirstData
    {

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<dbContextModel>();
                db.Database.EnsureCreated();
                //context.Database.Migrate();

                Refresh(db);
                if (!db.Roles.Any())
                {
                    db.Roles.AddRange(GetRoles().ToArray());
                    db.SaveChanges();
                }

                if (!db.Users.Any())
                {
                    db.Users.AddRange(GetUsers(db).ToArray());
                    db.SaveChanges();

                }
                if (!db.Languages.Any())
                {
                    db.Languages.AddRange(GetLanguage());
                    db.SaveChanges();

                }
                if (!db.GeneralTypes.Any())
                {
                    db.GeneralTypes.AddRange(GetGeneralTypes());
                    db.SaveChanges();

                }

            }
        }

        private static List<GeneralTypesModel> GetGeneralTypes()
        {
            List<GeneralTypesModel> generalTypes = new List<GeneralTypesModel>();
            GeneralTypesGenerator gtg = new GeneralTypesGenerator();
            generalTypes.AddRange(gtg.GetRelation());
            generalTypes.AddRange(gtg.GetGenderTypes());
            generalTypes.AddRange(gtg.GetEducationGrades());
            generalTypes.AddRange(gtg.GetJobSalaries());
            generalTypes.AddRange(gtg.GetCompanyScales());
            generalTypes.AddRange(gtg.GetSocialTypes());
            generalTypes.AddRange(gtg.GetActivateTimeType());

            return generalTypes;
        }

        private static void Refresh(dbContextModel db)
        {
            //db.Roles.RemoveRange(db.Roles.ToList());
        }

        private static List<LanguageModel> GetLanguage()
        {
            List<LanguageModel> languages = new List<LanguageModel>() {
new LanguageModel { Id= 1 ,Name="English",iso_639="en" },
new LanguageModel { Id= 2 ,Name="Afar",iso_639="aa" },
new LanguageModel { Id= 3 ,Name="Abkhazian",iso_639="ab" },
new LanguageModel { Id= 4 ,Name="Afrikaans",iso_639="af" },
new LanguageModel { Id= 5 ,Name="Amharic",iso_639="am" },
new LanguageModel { Id= 6 ,Name="Arabic",iso_639="ar" },
new LanguageModel { Id= 7 ,Name="Assamese",iso_639="as" },
new LanguageModel { Id= 8 ,Name="Aymara",iso_639="ay" },
new LanguageModel { Id= 9 ,Name="Azerbaijani",iso_639="az" },
new LanguageModel { Id= 10 ,Name="Bashkir",iso_639="ba" },
new LanguageModel { Id= 11 ,Name="Belarusian",iso_639="be" },
new LanguageModel { Id= 12 ,Name="Bulgarian",iso_639="bg" },
new LanguageModel { Id= 13 ,Name="Bihari",iso_639="bh" },
new LanguageModel { Id= 14 ,Name="Bislama",iso_639="bi" },
new LanguageModel { Id= 15 ,Name="Bengali/Bangla",iso_639="bn" },
new LanguageModel { Id= 16 ,Name="Tibetan",iso_639="bo" },
new LanguageModel { Id= 17 ,Name="Breton",iso_639="br" },
new LanguageModel { Id= 18 ,Name="Catalan",iso_639="ca" },
new LanguageModel { Id= 19 ,Name="Corsican",iso_639="co" },
new LanguageModel { Id= 20 ,Name="Czech",iso_639="cs" },
new LanguageModel { Id= 21 ,Name="Welsh",iso_639="cy" },
new LanguageModel { Id= 22 ,Name="Danish",iso_639="da" },
new LanguageModel { Id= 23 ,Name="German",iso_639="de" },
new LanguageModel { Id= 24 ,Name="Bhutani",iso_639="dz" },
new LanguageModel { Id= 25 ,Name="Greek",iso_639="el" },
new LanguageModel { Id= 26 ,Name="Esperanto",iso_639="eo" },
new LanguageModel { Id= 27 ,Name="Spanish",iso_639="es" },
new LanguageModel { Id= 28 ,Name="Estonian",iso_639="et" },
new LanguageModel { Id= 29 ,Name="Basque",iso_639="eu" },
new LanguageModel { Id= 30 ,Name="Persian",iso_639="fa" },
new LanguageModel { Id= 31 ,Name="Finnish",iso_639="fi" },
new LanguageModel { Id= 32 ,Name="Fiji",iso_639="fj" },
new LanguageModel { Id= 33 ,Name="Faeroese",iso_639="fo" },
new LanguageModel { Id= 34 ,Name="French",iso_639="fr" },
new LanguageModel { Id= 35 ,Name="Frisian",iso_639="fy" },
new LanguageModel { Id= 36 ,Name="Irish",iso_639="ga" },
new LanguageModel { Id= 37 ,Name="Scots/Gaelic",iso_639="gd" },
new LanguageModel { Id= 38 ,Name="Galician",iso_639="gl" },
new LanguageModel { Id= 39 ,Name="Guarani",iso_639="gn" },
new LanguageModel { Id= 40 ,Name="Gujarati",iso_639="gu" },
new LanguageModel { Id= 41 ,Name="Hausa",iso_639="ha" },
new LanguageModel { Id= 42 ,Name="Hindi",iso_639="hi" },
new LanguageModel { Id= 43 ,Name="Croatian",iso_639="hr" },
new LanguageModel { Id= 44 ,Name="Hungarian",iso_639="hu" },
new LanguageModel { Id= 45 ,Name="Armenian",iso_639="hy" },
new LanguageModel { Id= 46 ,Name="Interlingua",iso_639="ia" },
new LanguageModel { Id= 47 ,Name="Interlingue",iso_639="ie" },
new LanguageModel { Id= 48 ,Name="Inupiak",iso_639="ik" },
new LanguageModel { Id= 49 ,Name="Indonesian",iso_639="in" },
new LanguageModel { Id= 50 ,Name="Icelandic",iso_639="is" },
new LanguageModel { Id= 51 ,Name="Italian",iso_639="it" },
new LanguageModel { Id= 52 ,Name="Hebrew",iso_639="iw" },
new LanguageModel { Id= 53 ,Name="Japanese",iso_639="ja" },
new LanguageModel { Id= 54 ,Name="Yiddish",iso_639="ji" },
new LanguageModel { Id= 55 ,Name="Javanese",iso_639="jw" },
new LanguageModel { Id= 56 ,Name="Georgian",iso_639="ka" },
new LanguageModel { Id= 57 ,Name="Kazakh",iso_639="kk" },
new LanguageModel { Id= 58 ,Name="Greenlandic",iso_639="kl" },
new LanguageModel { Id= 59 ,Name="Cambodian",iso_639="km" },
new LanguageModel { Id= 60 ,Name="Kannada",iso_639="kn" },
new LanguageModel { Id= 61 ,Name="Korean",iso_639="ko" },
new LanguageModel { Id= 62 ,Name="Kashmiri",iso_639="ks" },
new LanguageModel { Id= 63 ,Name="Kurdish",iso_639="ku" },
new LanguageModel { Id= 64 ,Name="Kirghiz",iso_639="ky" },
new LanguageModel { Id= 65 ,Name="Latin",iso_639="la" },
new LanguageModel { Id= 66 ,Name="Lingala",iso_639="ln" },
new LanguageModel { Id= 67 ,Name="Laothian",iso_639="lo" },
new LanguageModel { Id= 68 ,Name="Lithuanian",iso_639="lt" },
new LanguageModel { Id= 69 ,Name="Latvian/Lettish",iso_639="lv" },
new LanguageModel { Id= 70 ,Name="Malagasy",iso_639="mg" },
new LanguageModel { Id= 71 ,Name="Maori",iso_639="mi" },
new LanguageModel { Id= 72 ,Name="Macedonian",iso_639="mk" },
new LanguageModel { Id= 73 ,Name="Malayalam",iso_639="ml" },
new LanguageModel { Id= 74 ,Name="Mongolian",iso_639="mn" },
new LanguageModel { Id= 75 ,Name="Moldavian",iso_639="mo" },
new LanguageModel { Id= 76 ,Name="Marathi",iso_639="mr" },
new LanguageModel { Id= 77 ,Name="Malay",iso_639="ms" },
new LanguageModel { Id= 78 ,Name="Maltese",iso_639="mt" },
new LanguageModel { Id= 79 ,Name="Burmese",iso_639="my" },
new LanguageModel { Id= 80 ,Name="Nauru",iso_639="na" },
new LanguageModel { Id= 81 ,Name="Nepali",iso_639="ne" },
new LanguageModel { Id= 82 ,Name="Dutch",iso_639="nl" },
new LanguageModel { Id= 83 ,Name="Norwegian",iso_639="no" },
new LanguageModel { Id= 84 ,Name="Occitan",iso_639="oc" },
new LanguageModel { Id= 85 ,Name="(Afan)/Oromoor/Oriya",iso_639="om" },
new LanguageModel { Id= 86 ,Name="Punjabi",iso_639="pa" },
new LanguageModel { Id= 87 ,Name="Polish",iso_639="pl" },
new LanguageModel { Id= 88 ,Name="Pashto/Pushto",iso_639="ps" },
new LanguageModel { Id= 89 ,Name="Portuguese",iso_639="pt" },
new LanguageModel { Id= 90 ,Name="Quechua",iso_639="qu" },
new LanguageModel { Id= 91 ,Name="Rhaeto-Romance",iso_639="rm" },
new LanguageModel { Id= 92 ,Name="Kirundi",iso_639="rn" },
new LanguageModel { Id= 93 ,Name="Romanian",iso_639="ro" },
new LanguageModel { Id= 94 ,Name="Russian",iso_639="ru" },
new LanguageModel { Id= 95 ,Name="Kinyarwanda",iso_639="rw" },
new LanguageModel { Id= 96 ,Name="Sanskrit",iso_639="sa" },
new LanguageModel { Id= 97 ,Name="Sindhi",iso_639="sd" },
new LanguageModel { Id= 98 ,Name="Sangro",iso_639="sg" },
new LanguageModel { Id= 99 ,Name="Serbo-Croatian",iso_639="sh" },
new LanguageModel { Id= 100 ,Name="Singhalese",iso_639="si" },
new LanguageModel { Id= 101 ,Name="Slovak",iso_639="sk" },
new LanguageModel { Id= 102 ,Name="Slovenian",iso_639="sl" },
new LanguageModel { Id= 103 ,Name="Samoan",iso_639="sm" },
new LanguageModel { Id= 104 ,Name="Shona",iso_639="sn" },
new LanguageModel { Id= 105 ,Name="Somali",iso_639="so" },
new LanguageModel { Id= 106 ,Name="Albanian",iso_639="sq" },
new LanguageModel { Id= 107 ,Name="Serbian",iso_639="sr" },
new LanguageModel { Id= 108 ,Name="Siswati",iso_639="ss" },
new LanguageModel { Id= 109 ,Name="Sesotho",iso_639="st" },
new LanguageModel { Id= 110 ,Name="Sundanese",iso_639="su" },
new LanguageModel { Id= 111 ,Name="Swedish",iso_639="sv" },
new LanguageModel { Id= 112 ,Name="Swahili",iso_639="sw" },
new LanguageModel { Id= 113 ,Name="Tamil",iso_639="ta" },
new LanguageModel { Id= 114 ,Name="Telugu",iso_639="te" },
new LanguageModel { Id= 115 ,Name="Tajik",iso_639="tg" },
new LanguageModel { Id= 116 ,Name="Thai",iso_639="th" },
new LanguageModel { Id= 117 ,Name="Tigrinya",iso_639="ti" },
new LanguageModel { Id= 118 ,Name="Turkmen",iso_639="tk" },
new LanguageModel { Id= 119 ,Name="Tagalog",iso_639="tl" },
new LanguageModel { Id= 120 ,Name="Setswana",iso_639="tn" },
new LanguageModel { Id= 121 ,Name="Tonga",iso_639="to" },
new LanguageModel { Id= 122 ,Name="Turkish",iso_639="tr" },
new LanguageModel { Id= 123 ,Name="Tsonga",iso_639="ts" },
new LanguageModel { Id= 124 ,Name="Tatar",iso_639="tt" },
new LanguageModel { Id= 125 ,Name="Twi",iso_639="tw" },
new LanguageModel { Id= 126 ,Name="Ukrainian",iso_639="uk" },
new LanguageModel { Id= 127 ,Name="Urdu",iso_639="ur" },
new LanguageModel { Id= 128 ,Name="Uzbek",iso_639="uz" },
new LanguageModel { Id= 129 ,Name="Vietnamese",iso_639="vi" },
new LanguageModel { Id= 130 ,Name="Volapuk",iso_639="vo" },
new LanguageModel { Id= 131 ,Name="Wolof",iso_639="wo" },
new LanguageModel { Id= 132 ,Name="Xhosa",iso_639="xh" },
new LanguageModel { Id= 133 ,Name="Yoruba",iso_639="yo" },
new LanguageModel { Id= 134 ,Name="Chinese",iso_639="zh" },
new LanguageModel { Id= 135 ,Name="Zulu",iso_639="zu" }
            };
            return languages;
        }

        public static List<RoleModel> GetRoles()
        {
            List<RoleModel> roles = new List<RoleModel>() {
              new RoleModel {Name="admin"},
              new RoleModel {Name="manager"},
              new RoleModel {Name="supervisor"},
              new RoleModel {Name="tester"},
              new RoleModel {Name="customer"}
            };
            return roles;
        }

        public static List<UserModel> GetUsers(dbContextModel db)
        {
            List<UserModel> FirstUsers = new List<UserModel>() {
                new UserModel {MobileNumber="09126540027",Role=db.Roles.Where(R=>R.Name=="admin").FirstOrDefault(),Status=0,RefreshToken = Guid.NewGuid().ToString()}
            };
            return FirstUsers;
        }


        private class GeneralTypesGenerator
        {

            internal IEnumerable<GeneralTypesModel> GetActivateTimeType()
            {

                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=0,TypeName = "چند ساعت در ماه" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=1,TypeName = "چند ساعت در هفته" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=2,TypeName = "روزانه کمتر از 1 ساعت" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=3,TypeName = "روزانه 1 تا 2 ساعت" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=4,TypeName = "روزانه 2 تا 3 ساعت" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=5,TypeName = "روزانه 3 تا 4 ساعت" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.ActivateTimeType,TypeKey=6,TypeName = "روزانه بیش از 4 ساعت"  }
                };
                return list;
            }
            internal IEnumerable<GeneralTypesModel> GetSocialTypes()
            {
                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=0,TypeName = "telegram" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=1,TypeName = "instagram" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=2,TypeName = "LinkedIn" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=3,TypeName = "twitter" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=4,TypeName = "Facebook" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=5,TypeName = "YouTube" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=6,TypeName = "WhatsApp" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=7,TypeName = "WeChat" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=8,TypeName = "QQ" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=9,TypeName = "QZone" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=10,TypeName = "TikTok" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=11,TypeName = "Sina Weibo" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=12,TypeName = "Reddit" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=13,TypeName = "Baidu Tieba" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=14,TypeName = "Snapchat" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=15,TypeName = "Pinterest" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=16,TypeName = "Viber" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.SocialTypes,TypeKey=17,TypeName = "Discord" }
                };
                return list;
            }
            internal IEnumerable<GeneralTypesModel> GetCompanyScales()
            {
                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=0,TypeName = "زیر 10 نفر" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=1,TypeName = "10 تا 20 نفر" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=2,TypeName = "20 تا 40 نفر" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=3,TypeName = "40 تا 100 نفر" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=4,TypeName = "100 تا 1000 نفر" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.CompanyScales,TypeKey=5,TypeName = "بیش از 1000 نفر" }
                };
                return list;
            }
            internal IEnumerable<GeneralTypesModel> GetJobSalaries()
            {
                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.JobSalaries,TypeKey=0,TypeName = "کمتر از 2 ملیون تومان"},
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.JobSalaries,TypeKey=1,TypeName = "2 تا 5 ملیون تومان" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.JobSalaries,TypeKey=2,TypeName = "5 تا 10 ملیون تومان" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.JobSalaries,TypeKey=3,TypeName = "10 تا 20 ملیون تومان" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.JobSalaries,TypeKey=4,TypeName = "بالای 20 ملیون تومان" }
                };
                return list;
            }

            internal IEnumerable<GeneralTypesModel> GetEducationGrades()
            {
                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=0,TypeName = "سیکل" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=1,TypeName = "دیپلم" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=2,TypeName = "فوق دیپلم" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=3,TypeName = "لیسانس" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=4,TypeName = "فوق لیسانس" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=5,TypeName = "دکتری" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.EducationGrades,TypeKey=6,TypeName =  "دیگر" }
                };
                return list;
            }

            internal IEnumerable<GeneralTypesModel> GetGenderTypes()
            {

                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Gender,TypeKey=0,TypeName = "نامشخص" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Gender,TypeKey=1,TypeName = "آقا" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Gender,TypeKey=2,TypeName = "خانم" }
                };
                return list;
            }

            internal IEnumerable<GeneralTypesModel> GetRelation()
            {
                List<GeneralTypesModel> list = new List<GeneralTypesModel>()
                {
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=0,TypeName = "نامشخص" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=1,TypeName = "مجرد" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=2,TypeName = "متاهل" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=3,TypeName = "جدا شده" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=4,TypeName = "در رابطه دوستی" },
                    new GeneralTypesModel{Status=0,TypeModel = (int)TypeModel.Relation,TypeKey=5,TypeName = "دیگر" }
                };
                return list;
            }

        }

    }
}
