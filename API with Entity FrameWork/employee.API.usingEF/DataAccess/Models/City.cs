using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class City
    {
        public City()
        {
            Users = new HashSet<User>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
