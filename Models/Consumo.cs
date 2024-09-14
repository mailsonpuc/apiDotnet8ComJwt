using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mf_apis_web_services_fuel_manager.Models
{
    [Table("Consumos")]
    public class Consumo : LinksHATEOS
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime Data  { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Required]
        public TipoCombustivel Tipo { get; set; }
        [Required]
        public int VeiculoId { get; set; }

        //navegação virtual
        public Veiculo Veiculo { get; set; }


        public ICollection<VeiculoUsuarios> Usuarios { get; set; }
    }

    public enum TipoCombustivel 
    {
        Diesel,
        Etanol,
        Gasolina
    }


}