using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Property = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TypeModel = table.Column<int>(nullable: false),
                    TypeKey = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    iso_639 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Latetude = table.Column<double>(nullable: false),
                    Longtude = table.Column<double>(nullable: false),
                    Radius = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuizQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolTopics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Reciver = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    AccessName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAccess_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MobileNumber = table.Column<string>(nullable: true),
                    RefreshToken = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuisQuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Option = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false),
                    SchoolQuizQuestionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuisQuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolQuisQuestionOptions_SchoolQuizQuestions_SchoolQuizQuestionId",
                        column: x => x.SchoolQuizQuestionId,
                        principalTable: "SchoolQuizQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchoolCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ReadTime = table.Column<int>(nullable: false),
                    SchoolTopicId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolCourses_SchoolTopics_SchoolTopicId",
                        column: x => x.SchoolTopicId,
                        principalTable: "SchoolTopics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    Major = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    InProgress = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    SalaryId = table.Column<int>(nullable: false),
                    CompanyScaleId = table.Column<int>(nullable: false),
                    InProgress = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TesterProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    ProfileImageUrl = table.Column<string>(nullable: true),
                    UserBio = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    BirthDay = table.Column<DateTime>(nullable: false),
                    RelationType = table.Column<int>(nullable: false),
                    GenderType = table.Column<int>(nullable: false),
                    NationalCode = table.Column<long>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailVerified = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    CityCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesterProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TesterProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFavorites_FavoriteTags_TagId",
                        column: x => x.TagId,
                        principalTable: "FavoriteTags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFavorites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false),
                    ReadingRate = table.Column<int>(nullable: false),
                    WritingRate = table.Column<int>(nullable: false),
                    SpeakingRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSocials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    SocialType = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ActivateTimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocials_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ExpiteDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchoolQuizCourses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    QuestionId = table.Column<int>(nullable: true),
                    SchoolCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolQuizCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolQuizCourses_SchoolQuizQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "SchoolQuizQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SchoolQuizCourses_SchoolCourses_SchoolCourseId",
                        column: x => x.SchoolCourseId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SchoolUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    DeletedByUserId = table.Column<int>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    OwnerUserId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    SchoolCourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolUnits_SchoolCourses_SchoolCourseId",
                        column: x => x.SchoolCourseId,
                        principalTable: "SchoolCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParentId",
                table: "Locations",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccess_RoleId",
                table: "RoleAccess",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolCourses_SchoolTopicId",
                table: "SchoolCourses",
                column: "SchoolTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuisQuestionOptions_SchoolQuizQuestionId",
                table: "SchoolQuisQuestionOptions",
                column: "SchoolQuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuizCourses_QuestionId",
                table: "SchoolQuizCourses",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolQuizCourses_SchoolCourseId",
                table: "SchoolQuizCourses",
                column: "SchoolCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolUnits_SchoolCourseId",
                table: "SchoolUnits",
                column: "SchoolCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TesterProfiles_UserId",
                table: "TesterProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_TagId",
                table: "UserFavorites",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguages_UserId",
                table: "UserLanguages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocials_UserId",
                table: "UserSocials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "GeneralTypes");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RoleAccess");

            migrationBuilder.DropTable(
                name: "SchoolQuisQuestionOptions");

            migrationBuilder.DropTable(
                name: "SchoolQuizCourses");

            migrationBuilder.DropTable(
                name: "SchoolUnits");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "TesterProfiles");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropTable(
                name: "UserSocials");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "SchoolQuizQuestions");

            migrationBuilder.DropTable(
                name: "SchoolCourses");

            migrationBuilder.DropTable(
                name: "FavoriteTags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SchoolTopics");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
