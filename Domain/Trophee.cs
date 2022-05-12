using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain

{
    public enum TypeTrophee
    {
        coupe , chompionat
    }
    public class Trophee
    {
        
        public int TropheeId { get; set; }
        
        public TypeTrophee TypeTrophee { get; set; }

        [DataType(DataType.Currency)]
        public double Recomponse { get; set; }


        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }

        public virtual Equipe Equipe { get; set; }

        //[ForeignKey("Equipe")]
        public int EquipeFK { get; set; }

    }
}
