using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Core.Models
{
    public class StockedProduct
    {
        public int Id { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
