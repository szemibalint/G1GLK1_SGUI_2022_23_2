using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Models
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Cuisine { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
