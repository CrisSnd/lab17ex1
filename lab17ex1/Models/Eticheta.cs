using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17ex1.Models
{
    internal class Eticheta
    {
        public int Id { get; set; }
        public double Pret { get; set; }

        public Guid CodBare { get; set; } = Guid.NewGuid();

        public Guid ProdusId { get; set; }
        public Produs Produs { get; set; }
    }
}
