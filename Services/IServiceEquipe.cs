using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IServiceEquipe : IService<Equipe>
    {
        Double SommeRecompense(Equipe e);
        List<Joueur> ListeJoueurTrophee(Trophee t);
        List<Entraineur> ListeEntraineurParEquipe(Equipe e);
        DateTime DatePremierChampionat(Equipe e);
    }
}
