using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FLS.Server.Data.DbEntities
{
    public class Country
    {
        public Country()
        {
            Clubs = new HashSet<Club>();
            Users = new HashSet<User>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(2)]
        public string CountryCodeIso2 { get; set; }

        public virtual ICollection<Club> Clubs { get; set; }

        public virtual ICollection<User> Users { get; set; }

    }
}
