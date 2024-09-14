using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mf_apis_web_services_fuel_manager.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]

        //não mostrar a senha
        [JsonIgnore]
        public string Password { get; set; }
        [Required]
        public Perfil Perfil { get; set; }

        public ICollection<VeiculoUsuarios> Veiculos { get; set; }
    }

    public enum Perfil
    {
        [Display(Name = "Administrador")]
        Administrador,
        [Display(Name = "Usuario")]
        Usuario

    }

}