using System.ComponentModel.DataAnnotations;

namespace FirstNP
{
    public class Adreses
    {
        [Key]
        public int Id { get; set; }
        public string AdressName { get; set; }
        public int PostCode { get; set; }
    }
}
