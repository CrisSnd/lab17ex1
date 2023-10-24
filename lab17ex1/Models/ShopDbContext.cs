using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab17ex1.Models
{
    internal class ShopDbContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }

        public DbSet<Categorie> Categorii { get; set; }

        public DbSet<Eticheta> Etichete { get; set; }

        public DbSet<Producator> Producatori { get; set; }

        public ShopDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\sandu\Desktop\C#\Proiecte C#\lab17ex1\lab17ex1\Produse .mdf"";Integrated Security=True").LogTo(Console.WriteLine);
        }

        public Categorie AddCategorie(string nume, string pictograma)
        {

            var categorie = new Categorie { Nume = nume, Pictograma = pictograma };
            Add(categorie);
            SaveChanges();

            return categorie;
        }

        public double GetValoareStoc(int producId)
        {
            if (!Producatori.Any(p => p.Id == producId))
            {
                throw new InvalidIdException($"Id producator invalid {producId}");
            }
            return Produse
                .Where(p => p.ProducatorId == producId)
                .Sum(p => p.Eticheta.Pret * p.Stoc);
        }

        public void ModificaPretProdus(Guid idProdus, double noulPret)
        {
            if (!Produse.Any(p => p.Id == idProdus))
            {
                throw new InvalidIdException($"Id produs invalid {idProdus}");
            }

            if (!Etichete.Any(p => p.ProdusId == idProdus))
            {
                throw new InvalidIdException($" Produsul {idProdus} nu are eticheta.");
            }

            var eticheta = Etichete.FirstOrDefault(p => p.ProdusId == idProdus);
            eticheta.Pret = noulPret;

            this.SaveChanges();
        }

         public void AddProdusLaCategorie(int catId, Guid iDprodus)
        {
            if (!Categorii.Any(c => c.Id == catId))
            {
                throw new InvalidIdException($" Id categorie invalid {catId}");
            }

            if (!Produse.Any(c => c.Id == iDprodus))
            {
                throw new InvalidIdException($" Id produs invalid {iDprodus}");
            }

            var categorie=Categorii.FirstOrDefault(c => c.Id == catId);
            var produs = Produse.FirstOrDefault(c => c.Id == iDprodus);
            //categorie.Produse.Add(produs);
            produs.Categorii.Add(categorie);
            SaveChanges();
        }




        public Produs AdaugaProdus(string nume, int stoc, double price, int prodId)
        {
            var eticheta = new Eticheta
            {
                Pret = price
            };

            var produs = new Produs
            {
                Nume = nume,
                Stoc = stoc,
                Eticheta = eticheta,
                ProducatorId = prodId
            };

            this.Add( produs );
            SaveChanges();
            return produs;
        }
    }
}