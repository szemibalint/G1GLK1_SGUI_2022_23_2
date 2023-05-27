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
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set;}

        public DateTime TimeOfOrder { get; set; }

        public string Food { get; set; }

        public int Price { get; set; }

        [ForeignKey("Restaurants")]
        public int RestaurantId { get; set; }

        [ForeignKey("Consumers")]
        public int ConsumerId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Consumer Consumer { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
    }
}
