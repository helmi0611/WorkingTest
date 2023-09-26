using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestHelmi.Models
{
    public class Penjualan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NamaBarang { get; set; }
        public int Stok {  get; set; }
        public int JumlahTerjual {  get; set; }
        public DateTime TanggalTransaksi { get; set; }
        public string JenisBarang { get; set; }
    }
}
