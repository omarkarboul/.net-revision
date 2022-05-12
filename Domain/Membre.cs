using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Membre
    {
        
        [Key]
        public int Identifiant { get; set; }

        [Required(ErrorMessage = "Nom obligatoire")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Prenom obligatoire")]
        public string Prenom { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        public virtual List<Contrat> Contrats { get; set; }
    }
}
