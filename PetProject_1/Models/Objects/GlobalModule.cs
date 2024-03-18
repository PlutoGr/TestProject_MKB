using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetProject_1.Models
{
    public class GlobalModule
    {
        // ID
        public int Id { get; set; }
        // Uid
        public string Uid { get; set; }
        // название
        public string Name { get; set; }
        // Использующий пользователь - id
        public int? UsingUserId { get; set; }
        //Использующий пользователь
        public User UsingUser { get; set; }
        // Выбранный элемент
        public Boolean Selected { get; set; }


    }
}