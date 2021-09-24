using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Models
{
    /// <summary>
    /// I have separated the classes. Each class for the appropiate entity, in case of some class have to build their own methods
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
