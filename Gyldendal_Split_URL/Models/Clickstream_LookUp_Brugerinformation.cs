using System.ComponentModel.DataAnnotations.Schema;

namespace Gyldendal_Split_URL.Models
{
    [Table("Clickstream_LookUp_Produktvej", Schema = "Staging")]
    public class Produktvej
    {
        public int Id { get; set; }
        public string BKey_Produktvej { get; set; }
        public string? Niveau1 { get; set; }
        public string? Niveau2 { get; set; }
        public string? Niveau3 { get; set; }
        public string? Niveau4 { get; set; }
        public string? Niveau5 { get; set; }
        public string? Niveau6 { get; set; }
        public string? Rest { get; set; }
        public bool? Processed { get; set; }

    }
}


