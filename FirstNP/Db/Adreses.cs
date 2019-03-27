using System.ComponentModel.DataAnnotations;

namespace FirstNP
{
    class Adreses
    {
        [Key]
        public int Id { get; set; }
        public  string AdressName { get; set; }
        public int PostCode { get; set; }
    }
}
