using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServiceEquipe : Service<Equipe>, IServiceEquipe
    {
        public ServiceEquipe(IUnitOfWork iowk): base(iowk)
        {

        }

        public DateTime DatePremierChampionat(Equipe e)
        {
            return e.trophees.Where(t => t.TypeTrophee == TypeTrophee.chompionat)
                .OrderBy(t => t.DateTrophee).First().DateTrophee;
        }

        public List<Entraineur> ListeEntraineurParEquipe(Equipe e)
        {

            return e.Contrats.Select(c => c.Membre).OfType<Entraineur>().ToList();
        }

        public List<Joueur> ListeJoueurTrophee(Trophee t)
        {
            IDataBaseFactory dbf = new DataBaseFactory();
            IUnitOfWork uow = new UnitOfWork(dbf);
            IServiceContrat cs = new ServiceContrat(uow);
            return cs.GetMany(c => (t.DateTrophee - c.DateContrat).
            TotalDays < c.DureeMois * 30 && c.EquipeId == t.EquipeFK).
            Select(c => c.Membre).OfType<Joueur>().ToList();
        }

        public double SommeRecompense(Equipe e)
        {
            double somme = 0;
            foreach (var t in e.trophees)
            {
                somme += t.Recomponse;
            }
            return somme;
        }

    }
}
