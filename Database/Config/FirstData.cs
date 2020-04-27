using System;
using System.Collections.Generic;
using System.Linq;
using Database.Common.Enums;
using Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Config
{
    public class FirstData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<DbContextModel>();
                
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

        private static List<GeneralTypes> GetGeneralTypes()
        {
            List<GeneralTypes> generalTypes = new List<GeneralTypes>();
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

        private static void Refresh(DbContextModel db)
        {
            //db.Roles.RemoveRange(db.Roles.ToList());
        }

        private static List<Language> GetLanguage()
        {
            List<Language> languages = new List<Language>()
            {
                new Language {Id = 1, Name = "English", iso_639 = "en"},
                new Language {Id = 2, Name = "Afar", iso_639 = "aa"},
                new Language {Id = 3, Name = "Abkhazian", iso_639 = "ab"},
                new Language {Id = 4, Name = "Afrikaans", iso_639 = "af"},
                new Language {Id = 5, Name = "Amharic", iso_639 = "am"},
                new Language {Id = 6, Name = "Arabic", iso_639 = "ar"},
                new Language {Id = 7, Name = "Assamese", iso_639 = "as"},
                new Language {Id = 8, Name = "Aymara", iso_639 = "ay"},
                new Language {Id = 9, Name = "Azerbaijani", iso_639 = "az"},
                new Language {Id = 10, Name = "Bashkir", iso_639 = "ba"},
                new Language {Id = 11, Name = "Belarusian", iso_639 = "be"},
                new Language {Id = 12, Name = "Bulgarian", iso_639 = "bg"},
                new Language {Id = 13, Name = "Bihari", iso_639 = "bh"},
                new Language {Id = 14, Name = "Bislama", iso_639 = "bi"},
                new Language {Id = 15, Name = "Bengali/Bangla", iso_639 = "bn"},
                new Language {Id = 16, Name = "Tibetan", iso_639 = "bo"},
                new Language {Id = 17, Name = "Breton", iso_639 = "br"},
                new Language {Id = 18, Name = "Catalan", iso_639 = "ca"},
                new Language {Id = 19, Name = "Corsican", iso_639 = "co"},
                new Language {Id = 20, Name = "Czech", iso_639 = "cs"},
                new Language {Id = 21, Name = "Welsh", iso_639 = "cy"},
                new Language {Id = 22, Name = "Danish", iso_639 = "da"},
                new Language {Id = 23, Name = "German", iso_639 = "de"},
                new Language {Id = 24, Name = "Bhutani", iso_639 = "dz"},
                new Language {Id = 25, Name = "Greek", iso_639 = "el"},
                new Language {Id = 26, Name = "Esperanto", iso_639 = "eo"},
                new Language {Id = 27, Name = "Spanish", iso_639 = "es"},
                new Language {Id = 28, Name = "Estonian", iso_639 = "et"},
                new Language {Id = 29, Name = "Basque", iso_639 = "eu"},
                new Language {Id = 30, Name = "Persian", iso_639 = "fa"},
                new Language {Id = 31, Name = "Finnish", iso_639 = "fi"},
                new Language {Id = 32, Name = "Fiji", iso_639 = "fj"},
                new Language {Id = 33, Name = "Faeroese", iso_639 = "fo"},
                new Language {Id = 34, Name = "French", iso_639 = "fr"},
                new Language {Id = 35, Name = "Frisian", iso_639 = "fy"},
                new Language {Id = 36, Name = "Irish", iso_639 = "ga"},
                new Language {Id = 37, Name = "Scots/Gaelic", iso_639 = "gd"},
                new Language {Id = 38, Name = "Galician", iso_639 = "gl"},
                new Language {Id = 39, Name = "Guarani", iso_639 = "gn"},
                new Language {Id = 40, Name = "Gujarati", iso_639 = "gu"},
                new Language {Id = 41, Name = "Hausa", iso_639 = "ha"},
                new Language {Id = 42, Name = "Hindi", iso_639 = "hi"},
                new Language {Id = 43, Name = "Croatian", iso_639 = "hr"},
                new Language {Id = 44, Name = "Hungarian", iso_639 = "hu"},
                new Language {Id = 45, Name = "Armenian", iso_639 = "hy"},
                new Language {Id = 46, Name = "Interlingua", iso_639 = "ia"},
                new Language {Id = 47, Name = "Interlingue", iso_639 = "ie"},
                new Language {Id = 48, Name = "Inupiak", iso_639 = "ik"},
                new Language {Id = 49, Name = "Indonesian", iso_639 = "in"},
                new Language {Id = 50, Name = "Icelandic", iso_639 = "is"},
                new Language {Id = 51, Name = "Italian", iso_639 = "it"},
                new Language {Id = 52, Name = "Hebrew", iso_639 = "iw"},
                new Language {Id = 53, Name = "Japanese", iso_639 = "ja"},
                new Language {Id = 54, Name = "Yiddish", iso_639 = "ji"},
                new Language {Id = 55, Name = "Javanese", iso_639 = "jw"},
                new Language {Id = 56, Name = "Georgian", iso_639 = "ka"},
                new Language {Id = 57, Name = "Kazakh", iso_639 = "kk"},
                new Language {Id = 58, Name = "Greenlandic", iso_639 = "kl"},
                new Language {Id = 59, Name = "Cambodian", iso_639 = "km"},
                new Language {Id = 60, Name = "Kannada", iso_639 = "kn"},
                new Language {Id = 61, Name = "Korean", iso_639 = "ko"},
                new Language {Id = 62, Name = "Kashmiri", iso_639 = "ks"},
                new Language {Id = 63, Name = "Kurdish", iso_639 = "ku"},
                new Language {Id = 64, Name = "Kirghiz", iso_639 = "ky"},
                new Language {Id = 65, Name = "Latin", iso_639 = "la"},
                new Language {Id = 66, Name = "Lingala", iso_639 = "ln"},
                new Language {Id = 67, Name = "Laothian", iso_639 = "lo"},
                new Language {Id = 68, Name = "Lithuanian", iso_639 = "lt"},
                new Language {Id = 69, Name = "Latvian/Lettish", iso_639 = "lv"},
                new Language {Id = 70, Name = "Malagasy", iso_639 = "mg"},
                new Language {Id = 71, Name = "Maori", iso_639 = "mi"},
                new Language {Id = 72, Name = "Macedonian", iso_639 = "mk"},
                new Language {Id = 73, Name = "Malayalam", iso_639 = "ml"},
                new Language {Id = 74, Name = "Mongolian", iso_639 = "mn"},
                new Language {Id = 75, Name = "Moldavian", iso_639 = "mo"},
                new Language {Id = 76, Name = "Marathi", iso_639 = "mr"},
                new Language {Id = 77, Name = "Malay", iso_639 = "ms"},
                new Language {Id = 78, Name = "Maltese", iso_639 = "mt"},
                new Language {Id = 79, Name = "Burmese", iso_639 = "my"},
                new Language {Id = 80, Name = "Nauru", iso_639 = "na"},
                new Language {Id = 81, Name = "Nepali", iso_639 = "ne"},
                new Language {Id = 82, Name = "Dutch", iso_639 = "nl"},
                new Language {Id = 83, Name = "Norwegian", iso_639 = "no"},
                new Language {Id = 84, Name = "Occitan", iso_639 = "oc"},
                new Language {Id = 85, Name = "(Afan)/Oromoor/Oriya", iso_639 = "om"},
                new Language {Id = 86, Name = "Punjabi", iso_639 = "pa"},
                new Language {Id = 87, Name = "Polish", iso_639 = "pl"},
                new Language {Id = 88, Name = "Pashto/Pushto", iso_639 = "ps"},
                new Language {Id = 89, Name = "Portuguese", iso_639 = "pt"},
                new Language {Id = 90, Name = "Quechua", iso_639 = "qu"},
                new Language {Id = 91, Name = "Rhaeto-Romance", iso_639 = "rm"},
                new Language {Id = 92, Name = "Kirundi", iso_639 = "rn"},
                new Language {Id = 93, Name = "Romanian", iso_639 = "ro"},
                new Language {Id = 94, Name = "Russian", iso_639 = "ru"},
                new Language {Id = 95, Name = "Kinyarwanda", iso_639 = "rw"},
                new Language {Id = 96, Name = "Sanskrit", iso_639 = "sa"},
                new Language {Id = 97, Name = "Sindhi", iso_639 = "sd"},
                new Language {Id = 98, Name = "Sangro", iso_639 = "sg"},
                new Language {Id = 99, Name = "Serbo-Croatian", iso_639 = "sh"},
                new Language {Id = 100, Name = "Singhalese", iso_639 = "si"},
                new Language {Id = 101, Name = "Slovak", iso_639 = "sk"},
                new Language {Id = 102, Name = "Slovenian", iso_639 = "sl"},
                new Language {Id = 103, Name = "Samoan", iso_639 = "sm"},
                new Language {Id = 104, Name = "Shona", iso_639 = "sn"},
                new Language {Id = 105, Name = "Somali", iso_639 = "so"},
                new Language {Id = 106, Name = "Albanian", iso_639 = "sq"},
                new Language {Id = 107, Name = "Serbian", iso_639 = "sr"},
                new Language {Id = 108, Name = "Siswati", iso_639 = "ss"},
                new Language {Id = 109, Name = "Sesotho", iso_639 = "st"},
                new Language {Id = 110, Name = "Sundanese", iso_639 = "su"},
                new Language {Id = 111, Name = "Swedish", iso_639 = "sv"},
                new Language {Id = 112, Name = "Swahili", iso_639 = "sw"},
                new Language {Id = 113, Name = "Tamil", iso_639 = "ta"},
                new Language {Id = 114, Name = "Telugu", iso_639 = "te"},
                new Language {Id = 115, Name = "Tajik", iso_639 = "tg"},
                new Language {Id = 116, Name = "Thai", iso_639 = "th"},
                new Language {Id = 117, Name = "Tigrinya", iso_639 = "ti"},
                new Language {Id = 118, Name = "Turkmen", iso_639 = "tk"},
                new Language {Id = 119, Name = "Tagalog", iso_639 = "tl"},
                new Language {Id = 120, Name = "Setswana", iso_639 = "tn"},
                new Language {Id = 121, Name = "Tonga", iso_639 = "to"},
                new Language {Id = 122, Name = "Turkish", iso_639 = "tr"},
                new Language {Id = 123, Name = "Tsonga", iso_639 = "ts"},
                new Language {Id = 124, Name = "Tatar", iso_639 = "tt"},
                new Language {Id = 125, Name = "Twi", iso_639 = "tw"},
                new Language {Id = 126, Name = "Ukrainian", iso_639 = "uk"},
                new Language {Id = 127, Name = "Urdu", iso_639 = "ur"},
                new Language {Id = 128, Name = "Uzbek", iso_639 = "uz"},
                new Language {Id = 129, Name = "Vietnamese", iso_639 = "vi"},
                new Language {Id = 130, Name = "Volapuk", iso_639 = "vo"},
                new Language {Id = 131, Name = "Wolof", iso_639 = "wo"},
                new Language {Id = 132, Name = "Xhosa", iso_639 = "xh"},
                new Language {Id = 133, Name = "Yoruba", iso_639 = "yo"},
                new Language {Id = 134, Name = "Chinese", iso_639 = "zh"},
                new Language {Id = 135, Name = "Zulu", iso_639 = "zu"}
            };
            return languages;
        }

        public static List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>()
            {
                new Role {Name = "admin"},
                new Role {Name = "manager"},
                new Role {Name = "supervisor"},
                new Role {Name = "tester"},
                new Role {Name = "customer"}
            };
            return roles;
        }

        public static List<User> GetUsers(DbContextModel db)
        {
            var firstUsers = new List<User>()
            {
                new User
                {
                    MobileNumber = "09126540027",
                    Role = db.Roles.FirstOrDefault(r => r.Name.ToLower() == "admin"),
                    Status = (int) UserStatus.Active,
                    RefreshToken = Guid.NewGuid().ToString()
                }
            };
            return firstUsers;
        }


        private class GeneralTypesGenerator
        {
            internal IEnumerable<GeneralTypes> GetActivateTimeType()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 0,
                        TypeName = "چند ساعت در ماه"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 1,
                        TypeName = "چند ساعت در هفته"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 2,
                        TypeName = "روزانه کمتر از 1 ساعت"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 3,
                        TypeName = "روزانه 1 تا 2 ساعت"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 4,
                        TypeName = "روزانه 2 تا 3 ساعت"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 5,
                        TypeName = "روزانه 3 تا 4 ساعت"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.ActivateTimeType, TypeKey = 6,
                        TypeName = "روزانه بیش از 4 ساعت"
                    }
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetSocialTypes()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 0, TypeName = "telegram"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 1, TypeName = "instagram"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 2, TypeName = "LinkedIn"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 3, TypeName = "twitter"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 4, TypeName = "Facebook"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 5, TypeName = "YouTube"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 6, TypeName = "WhatsApp"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 7, TypeName = "WeChat"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 8, TypeName = "QQ"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 9, TypeName = "QZone"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 10, TypeName = "TikTok"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 11, TypeName = "Sina Weibo"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 12, TypeName = "Reddit"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 13, TypeName = "Baidu Tieba"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 14, TypeName = "Snapchat"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 15, TypeName = "Pinterest"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 16, TypeName = "Viber"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.SocialTypes, TypeKey = 17, TypeName = "Discord"}
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetCompanyScales()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 0, TypeName = "زیر 10 نفر"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 1, TypeName = "10 تا 20 نفر"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 2, TypeName = "20 تا 40 نفر"},
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 3, TypeName = "40 تا 100 نفر"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 4, TypeName = "100 تا 1000 نفر"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.CompanyScales, TypeKey = 5, TypeName = "بیش از 1000 نفر"
                    }
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetJobSalaries()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.JobSalaries, TypeKey = 0,
                        TypeName = "کمتر از 2 ملیون تومان"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.JobSalaries, TypeKey = 1,
                        TypeName = "2 تا 5 ملیون تومان"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.JobSalaries, TypeKey = 2,
                        TypeName = "5 تا 10 ملیون تومان"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.JobSalaries, TypeKey = 3,
                        TypeName = "10 تا 20 ملیون تومان"
                    },
                    new GeneralTypes
                    {
                        Status = 0, TypeModel = (int) GeneralTypeModel.JobSalaries, TypeKey = 4,
                        TypeName = "بالای 20 ملیون تومان"
                    }
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetEducationGrades()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 0, TypeName = "سیکل"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 1, TypeName = "دیپلم"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 2, TypeName = "فوق دیپلم"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 3, TypeName = "لیسانس"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 4, TypeName = "فوق لیسانس"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 5, TypeName = "دکتری"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.EducationGrades, TypeKey = 6, TypeName = "دیگر"}
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetGenderTypes()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Gender, TypeKey = 0, TypeName = "نامشخص"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Gender, TypeKey = 1, TypeName = "آقا"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Gender, TypeKey = 2, TypeName = "خانم"}
                };
                return list;
            }

            internal IEnumerable<GeneralTypes> GetRelation()
            {
                List<GeneralTypes> list = new List<GeneralTypes>()
                {
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 0, TypeName = "نامشخص"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 1, TypeName = "مجرد"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 2, TypeName = "متاهل"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 3, TypeName = "جدا شده"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 4, TypeName = "در رابطه دوستی"},
                    new GeneralTypes
                        {Status = 0, TypeModel = (int) GeneralTypeModel.Relation, TypeKey = 5, TypeName = "دیگر"}
                };
                return list;
            }
        }

    }
}
