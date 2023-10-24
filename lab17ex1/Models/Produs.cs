using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17ex1.Models
{
    internal class Produs
    {
        public Guid Id { get; set; }

        public int Stoc { get; set; }
        public string Nume { get; set; }

        public int ProducatorId { get; set; }

        public Producator Producator { get; set; }

        public List<Categorie> Categorii { get; set; }=new List<Categorie>();

        public Eticheta Eticheta { get; set; }

    }
}
