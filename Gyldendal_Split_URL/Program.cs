using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gyldendal_Split_URL.Models;

namespace Gyldendal_Split_URL
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var _context = new Gyldendal_Split_URLDBContext())
            {
                var urlsToUpdate = _context.Clickstream_LookUp_Produktvej.Where(x => x.Processed == null).ToList();

                var updatedProduktvej = SplitUrlIntoLevels(urlsToUpdate.ToList());

                _context.UpdateRange(updatedProduktvej);
                var result = _context.SaveChanges();
            }

        }

        public static List<Produktvej> SplitUrlIntoLevels(List<Produktvej> list_Produktvej)
        {
            List<Produktvej> updatedList = new List<Produktvej>();

            foreach (var produktvej in list_Produktvej)
            {
                string removeStartOfProduktvej = produktvej.BKey_Produktvej.Substring(produktvej.BKey_Produktvej.IndexOf('/') + 2);
                var produktvejArray = removeStartOfProduktvej.Split('/');
             
                if (produktvejArray.Length >= 1) {produktvej.Niveau1 = produktvejArray[0];}
                if (produktvejArray.Length >= 2) { produktvej.Niveau2 = produktvejArray[1]; }
                if (produktvejArray.Length >= 3) { produktvej.Niveau3 = produktvejArray[2]; }
                if (produktvejArray.Length >= 4) { produktvej.Niveau4 = produktvejArray[3]; }
                if (produktvejArray.Length >= 5) { produktvej.Niveau5 = produktvejArray[4]; }
                if (produktvejArray.Length >= 6) { produktvej.Niveau6 = produktvejArray[5]; }
                if (produktvejArray.Length >= 7) { produktvej.Rest = String.Join("/", produktvejArray[6..produktvejArray.Length]); }
                produktvej.Processed = true;
                updatedList.Add(produktvej);
            }
           
            return updatedList;
        }
    }
}
