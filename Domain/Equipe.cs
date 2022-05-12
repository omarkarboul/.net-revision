using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Equipe
    {
        public string AdressLocal { get; set; }

        
        public int EquipeId { get; set; }

        public string Logo { get; set; }

        public string NomEquipe { get; set; }

        public virtual List<Trophee> trophees { get; set; }

        public virtual List<Contrat> Contrats { get; set; }



    }
}
