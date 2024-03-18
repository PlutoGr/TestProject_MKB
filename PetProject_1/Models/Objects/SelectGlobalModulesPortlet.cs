using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace PetProject_1.Models
{
    public class SelectGlobalModulesPortlet
    {
        public SelectList UsingUser { get; set; }
        public ICollection<GlobalModule> GlobalModules { get; set; }
    }
}