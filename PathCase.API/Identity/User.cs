using PathCase.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathCaseAPI.Identity
{
    public class User : IdentityUser
    {


      
    }

    public enum EnumUserState
    {
        waiting = 0,
        Completed = 1
    }

    public enum EnumUserLanguage
    {
        Turkish = 1,
        English = 2
    }
}
