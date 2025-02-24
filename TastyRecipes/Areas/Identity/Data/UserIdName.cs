using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TastyRecipes.Areas.Identity.Data
{
    public class UserIdName :IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar (100)")]
        public string User_Name { get; set; }
    }
}
