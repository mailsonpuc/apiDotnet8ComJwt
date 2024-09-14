using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mf_apis_web_services_fuel_manager.Models
{
    [Table("VeiculoUsuarios")]
    public class VeiculoUsuarios
    {
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

        
        public int UsuarioId { get; set; }
        public  Usuario Usuario { get; set; }
        
    }
}