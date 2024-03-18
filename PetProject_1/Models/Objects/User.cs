using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetProject_1.Models
{
    public class User
    {
        // ID
        public int Id { get; set; }
        // Uid
        public string Uid { get; set; }
        // название
        public string FullName { get; set; }

        //public ICollection<GlobalModule> GlobalModules { get; set; }

        //public User()
        //{
        //    GlobalModules = new List<GlobalModule>();
        //}
    }
}