using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMMEG.DLL
{
    public enum E_TypeTraitement
    {
        AlgoMaxTargetNumber,
        AlgoMaxTargetNumberPerEnemi,
        AlgoEmpiric
    }

    public class PlanTraitement
    {
        public E_TypeTraitement Algorithme { get; set; }
        public List<Etage> RunsPossibles { get; set; }
        public Dictionary<E_NomEnnemiSucces, uint> EnnemisAElliminer { get; set; }

        public Boolean IsEnemiesLeft()
        {
            return EnnemisAElliminer.Sum(x => x.Value) == 0 ? false : true;
        }
    }

    public class ResultatTraitement
    {
        public List<string> MesResultats { get; set; }
        public List<MaxTargetNumberSimulationWorker> MesRunsPossibles { get; set; }
    }

    //public class Scenario
    //{
    //    public Scenario(Etage etg, int nbRuns)
    //    {

    //    }

    //    public Dictionary<Etage, uint> MesRuns { get; set; }
    //}

    //public class Run
    //{
    //    public string NomZone { get; set; }
    //    public Etage EtageParcouru { get; set; }
    //}

    public class AlgorithmeHandler
    {
        private List<MaxTargetNumberSimulationWorker> MesScenarii { get; set; }
        private PlanTraitement MonPlan { get; set; }

        public AlgorithmeHandler(PlanTraitement lePlan)
        {
            MonPlan = lePlan;
            MesScenarii = new List<MaxTargetNumberSimulationWorker>();
        }

        public List<AlgoMaxTargetNumberPerEnemiSimulationWorker> EffectuerTraitement()
        {
            if (MonPlan.IsEnemiesLeft())
            {
                switch (MonPlan.Algorithme)
                {
                    //case E_TypeTraitement.AlgoMaxTargetNumber:
                    //    return AlgoAuPlusGrandNombre2(MonPlan);
                    case E_TypeTraitement.AlgoMaxTargetNumberPerEnemi:
                        var monAlgo = new AlgoMaxTargetNumberPerEnemiFactory(MonPlan);
                        return monAlgo.EffectuerTraitement();

                        //case E_TypeTraitement.AlgoEmpirique:
                        //    var monAlgo = new AlgoEmpiricFactory2(MonPlan);
                        //    return monAlgo.LancerTraitement();
                }
            }
            return null;
        }

        /// <summary>
        /// Algorithme de traitement au plus grand nombre (L'étage avec le plus grand nombre de cible visé est sélectionné à chaque boucle)
        /// </summary>
        private ResultatTraitement AlgoAuPlusGrandNombre(PlanTraitement plan)
        {
            var runRealisees = new Dictionary<Etage, int>();

            while (!plan.EnnemisAElliminer.All(w => w.Value == 0))
            {
                // Création du tableau des (Etage/NbEnnemis)
                var etageQteEnnemis = new Dictionary<Etage, int>();
                foreach (Etage etg in plan.RunsPossibles)
                {
                    var ennemisAElliminerTempo = new Dictionary<E_NomEnnemiSucces, uint>(plan.EnnemisAElliminer);
                    etageQteEnnemis.Add(etg, 0);
                    foreach (Ennemi e in etg.ObtenirTousLesEnnemis())
                    {
                        if (ennemisAElliminerTempo.ContainsKey(e.TitreSucces) && ennemisAElliminerTempo[e.TitreSucces] > 0)
                        {
                            etageQteEnnemis[etg]++;
                            ennemisAElliminerTempo[e.TitreSucces]--;
                        }
                    }
                }

                // Choix de l'étage
                var etageSelectionne = etageQteEnnemis.OrderByDescending(f => f.Value).First().Key;

                // Réalisation de l'étage
                if (runRealisees.ContainsKey(etageSelectionne))
                {
                    runRealisees[etageSelectionne]++;
                }
                else
                {
                    runRealisees.Add(etageSelectionne, 1);
                }

                foreach (Ennemi e in etageSelectionne.ObtenirTousLesEnnemis())
                {
                    if (plan.EnnemisAElliminer.ContainsKey(e.TitreSucces) && plan.EnnemisAElliminer[e.TitreSucces] > 0)
                    {
                        plan.EnnemisAElliminer[e.TitreSucces]--;
                    }
                }
            }

            // Inscription des informations dans les résultats
            var monResultat = new ResultatTraitement
            {
                MesResultats = new List<string>()
            };

            foreach (var run in runRealisees.OrderByDescending(f => f.Value))
            {
                monResultat.MesResultats.Add($"{run.Value} run(s) sur l'étage {run.Key.Numero} en difficulté {run.Key.Difficulte.ToString()}");
            }

            return monResultat;
        }

        /// <summary>
        /// Algorithme de traitement au plus grand nombre (L'étage avec le plus grand nombre de cible visé est sélectionné à chaque boucle) => et ce de manière répétée
        /// </summary>
        private List<MaxTargetNumberSimulationWorker> AlgoAuPlusGrandNombre2(PlanTraitement plan)
        {
            // Création du tableau des (Etage/NbEnnemis)
            var etageNbEnnemis = GenererDicoEtageNbEnnemis(plan);

            // Sélection des étages avec le plus grand nombre
            var nbEnnemisMax = etageNbEnnemis.OrderByDescending(f => f.Value).First().Value;

            foreach (var etg in etageNbEnnemis.Where(f => f.Value == nbEnnemisMax || f.Value == nbEnnemisMax - 1))
            {
                var monScenario = new MaxTargetNumberSimulationWorker(plan.EnnemisAElliminer, etg.Key, nbEnnemisMax);
                GenererScenarii(monScenario);
            }

            return MesScenarii;
        }

        private void GenererScenarii(MaxTargetNumberSimulationWorker scenar)
        {
            while (VerifierNbEnnemisEtage(
                scenar.EtageActuel,
                new PlanTraitement() { EnnemisAElliminer = scenar.EnnemisAElliminer, RunsPossibles = MonPlan.RunsPossibles }) == scenar.NbEnnemisParRun)
            {
                scenar.Objectifs[scenar.EtageActuel]++;
                foreach (Ennemi e in scenar.EtageActuel.ObtenirTousLesEnnemis())
                {
                    if (scenar.EnnemisAElliminer.ContainsKey(e.TitreSucces) && scenar.EnnemisAElliminer[e.TitreSucces] > 0)
                    {
                        scenar.EnnemisAElliminer[e.TitreSucces]--;
                    }
                }
            }

            if (scenar.IsTermine())
            {
                MesScenarii.Add(scenar);
            }
            else
            {
                // Création du tableau des (Etage/NbEnnemis)
                var etageNbEnnemis = GenererDicoEtageNbEnnemis(new PlanTraitement() { EnnemisAElliminer = scenar.EnnemisAElliminer, RunsPossibles = MonPlan.RunsPossibles });

                // Sélection des étages avec le plus grand nombre
                var nbEnnemisMax = etageNbEnnemis.OrderByDescending(f => f.Value).First().Value;

                foreach (var etg in etageNbEnnemis.Where(f => f.Value == nbEnnemisMax))
                {
                    //var monScenario = new Scenario(plan.EnnemisAElliminer, etg.Key, nbEnnemisMax);
                    if (!scenar.Objectifs.ContainsKey(etg.Key))
                    {
                        scenar.Objectifs.Add(etg.Key, 0);
                    }
                    scenar.EtageActuel = etg.Key;
                    scenar.NbEnnemisParRun = nbEnnemisMax;
                    GenererScenarii(scenar);
                }
            }
        }

        /// <summary>
        /// Génére un dictionnaire des (Etage/NbEnnemis) par rapport à un plan donné
        /// </summary>
        private Dictionary<Etage, int> GenererDicoEtageNbEnnemis(PlanTraitement plan)
        {
            // Création du tableau des (Etage/NbEnnemis)
            var etageNbEnnemis = new Dictionary<Etage, int>();
            foreach (Etage etg in plan.RunsPossibles)
            {
                var ennemisAElliminerTempo = new Dictionary<E_NomEnnemiSucces, uint>(plan.EnnemisAElliminer);
                etageNbEnnemis.Add(etg, 0);
                foreach (Ennemi e in etg.ObtenirTousLesEnnemis())
                {
                    if (ennemisAElliminerTempo.ContainsKey(e.TitreSucces) && ennemisAElliminerTempo[e.TitreSucces] > 0)
                    {
                        etageNbEnnemis[etg]++;
                        ennemisAElliminerTempo[e.TitreSucces]--;
                    }
                }
            }
            return etageNbEnnemis;
        }

        /// <summary>
        /// Retourne le nb d'ennemi que l'on peut éliminer dans un étage par rapport à un plan donné
        /// </summary>
        private int VerifierNbEnnemisEtage(Etage etg, PlanTraitement plan)
        {
            plan.RunsPossibles = new List<Etage>() { etg };
            return GenererDicoEtageNbEnnemis(plan).First().Value;
        }
    }

    class AlgoMaxTargetNumberFactory
    {
        // REFACTOR NECESSAIRE DU CODE DE TRAITEMENT DE L'ALGO DE AlgorithmeHandler => ICI
    }

    /// <summary>
    /// Classe de travail pour l'algo Nombre maximum de cibles
    /// </summary>
    public class MaxTargetNumberSimulationWorker
    {
        public Dictionary<Etage, int> Objectifs { get; set; }
        public Dictionary<E_NomEnnemiSucces, uint> EnnemisAElliminer { get; set; }
        public int NbEnnemisParRun { get; set; }
        public Etage EtageActuel { get; set; }
        public PlanTraitement PlanAssocie { get; set; }

        public MaxTargetNumberSimulationWorker(Dictionary<E_NomEnnemiSucces, uint> ennemisAElliminer, Etage etageDeDepart, int nbEnnemisParRun, PlanTraitement lePlan = null)
        {
            EnnemisAElliminer = ennemisAElliminer.ToDictionary(x => x.Key, x => x.Value);
            NbEnnemisParRun = nbEnnemisParRun;
            Objectifs = new Dictionary<Etage, int>
            {
                { new Etage(etageDeDepart.Difficulte, etageDeDepart.MesVagues, etageDeDepart.Numero, etageDeDepart.NomZone), 0 }
            };
            EtageActuel = new Etage(etageDeDepart.Difficulte, etageDeDepart.MesVagues, etageDeDepart.Numero, etageDeDepart.NomZone);

            PlanAssocie = lePlan == null ? null : new PlanTraitement()
            {
                Algorithme = lePlan.Algorithme,
                EnnemisAElliminer = lePlan.EnnemisAElliminer.ToDictionary(x => x.Key, x => x.Value),
                RunsPossibles = lePlan.RunsPossibles.ToList()
            };
        }

        public bool IsTermine()
        {
            return EnnemisAElliminer.All(w => w.Value <= 0) ? true : false;
        }
        public int NbDeRunTotal()
        {
            var nbRuns = 0;
            foreach (var item in Objectifs)
            {
                nbRuns += item.Value;
            }
            return nbRuns;
        }
        public List<string> ObtenirLesRun()
        {
            var maListe = new List<string>();
            foreach (var item in Objectifs.Where(f => f.Value != 0).OrderByDescending(k => k.Value))
            {
                maListe.Add($"{item.Value} runs sur l'étage {item.Key.Numero} en {item.Key.Difficulte.ToString()} ({item.Key.NomZone})");
            }
            return maListe;
        }
        public int CoutTotalScenario()
        {
            int result = 0;
            foreach (var etg in Objectifs)
            {
                result += etg.Key.Cout * etg.Value;
            }
            return result;
        }
    }

    /// <summary>
    /// Algo de traitement empirique => On test toutes les combinaisons d'étage possible (Temps de travail TREEEEEEESSSSSS LONG!!!!)
    /// </summary>
    class AlgoEmpiricFactory
    {
        private PlanTraitement PlanGeneral { get; set; }
        private List<EmpiricSimulationWorker> Scenarii { get; set; }

        public AlgoEmpiricFactory(PlanTraitement lePlan)
        {
            PlanGeneral = lePlan;
            Scenarii = new List<EmpiricSimulationWorker>();
        }

        public List<EmpiricSimulationWorker> LancerTraitement()
        {
            TraiterPattern();
            return Scenarii;
        }

        /// <summary>
        /// Boucle de traitement
        /// </summary>
        /// <param name="lePattern"></param>
        private void TraiterPattern(EmpiricSimulationWorker lePattern = null)
        {
            if (lePattern != null)
            {
                while (lePattern.IsCiblesRestantesEtageActuel())
                {
                    lePattern.EffectuerRunEtageEnCours();
                }
            }
            else
            {
                foreach (Etage e in PlanGeneral.RunsPossibles)
                {
                    var wsp = new EmpiricSimulationWorker(e, PlanGeneral.RunsPossibles, PlanGeneral.EnnemisAElliminer);
                    TraiterPattern(wsp);
                }
            }
            if (lePattern != null)
            {
                if (lePattern.IsCiblesRestantes())
                {
                    foreach (Etage e in lePattern.EtagesDisponibles)
                    {
                        var wsp = new EmpiricSimulationWorker(lePattern, e);
                        TraiterPattern(wsp);
                    }
                }
                else
                {
                    Scenarii.Add(lePattern);
                }
            }
        }
    }

    /// <summary>
    /// Classe de travail pour l'algo empirique
    /// </summary>
    public class EmpiricSimulationWorker
    {
        private Dictionary<Etage, uint> EtagesEffectues { get; set; }
        private Dictionary<E_NomEnnemiSucces, uint> CiblesAAbattre { get; set; }
        public List<Etage> EtagesDisponibles { get; set; }
        private int Overkills { get; set; }

        public EmpiricSimulationWorker(Etage etageDeDepart, List<Etage> etagesRestants, Dictionary<E_NomEnnemiSucces, uint> cibles)
        {
            EtagesEffectues = new Dictionary<Etage, uint>() { { new Etage(etageDeDepart.Difficulte, etageDeDepart.MesVagues, etageDeDepart.Numero, etageDeDepart.NomZone), 0 } };
            EtagesDisponibles = etagesRestants.ToList();
            EtagesDisponibles.Remove(etageDeDepart);
            CiblesAAbattre = cibles.ToDictionary(x => x.Key, x => x.Value);
            Overkills = 0;
        }
        public EmpiricSimulationWorker(EmpiricSimulationWorker wsp, Etage etageDeCombat)
        {
            EtagesEffectues = wsp.EtagesEffectues.ToDictionary(x => x.Key, x => x.Value);
            EtagesEffectues.Add(new Etage(etageDeCombat.Difficulte, etageDeCombat.MesVagues, etageDeCombat.Numero, etageDeCombat.NomZone), 0);
            EtagesDisponibles = wsp.EtagesDisponibles.ToList();
            EtagesDisponibles.Remove(etageDeCombat);
            CiblesAAbattre = wsp.CiblesAAbattre.ToDictionary(x => x.Key, x => x.Value);
            Overkills = wsp.Overkills;
        }

        public bool IsCiblesRestantesEtageActuel()
        {
            foreach (Ennemi e in GetEtageEnCours().ObtenirTousLesEnnemis())
            {
                if (CiblesAAbattre.ContainsKey(e.TitreSucces) && CiblesAAbattre[e.TitreSucces] > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsCiblesRestantes()
        {
            foreach (var cible in CiblesAAbattre)
            {
                if (cible.Value > 0) { return true; }
            }
            return false;
        }
        public Etage GetEtageEnCours()
        {
            return EtagesEffectues.Last().Key;
        }
        public void EffectuerRunEtageEnCours()
        {
            foreach (Ennemi e in GetEtageEnCours().ObtenirTousLesEnnemis())
            {
                if (CiblesAAbattre.ContainsKey(e.TitreSucces))
                {
                    if (CiblesAAbattre[e.TitreSucces] > 0)
                    {
                        CiblesAAbattre[e.TitreSucces]--;
                    }
                    else
                    {
                        Overkills++;
                    }
                }
            }
            EtagesEffectues[GetEtageEnCours()]++;
        }
    }

    /// <summary>
    /// Algo de traitement des représentation max d'un ennemi donné => On choisi un ennemi et on le pourri là où il est le plus présent, une fois finit on passe aux ennemis suivants
    /// </summary>
    class AlgoMaxTargetNumberPerEnemiFactory
    {
        private PlanTraitement PlanGeneral { get; set; }
        private List<AlgoMaxTargetNumberPerEnemiSimulationWorker> Scenarii { get; set; }

        public AlgoMaxTargetNumberPerEnemiFactory(PlanTraitement lePlan)
        {
            PlanGeneral = lePlan;
            Scenarii = new List<AlgoMaxTargetNumberPerEnemiSimulationWorker>();
        }

        public List<AlgoMaxTargetNumberPerEnemiSimulationWorker> EffectuerTraitement()
        {
            TraiterPattern();
            return Scenarii;
        }

        private void TraiterPattern(AlgoMaxTargetNumberPerEnemiSimulationWorker worker = null)
        {
            if (worker != null)
            {
                worker.EffectuerRunsEtageEnCours();
            }
            else
            {
                foreach (var ennemi in PlanGeneral.EnnemisAElliminer.Keys)
                {
                    if (PlanGeneral.EnnemisAElliminer[ennemi] > 0)
                    {
                        foreach (var etg in ObtenirListeEtagesMaxNbEnnemi(ennemi))
                        {
                            var myWorker = new AlgoMaxTargetNumberPerEnemiSimulationWorker(etg, ennemi, PlanGeneral.EnnemisAElliminer);
                            TraiterPattern(myWorker);
                        }
                    }
                }
            }
            if (worker != null)
            {
                if (worker.IsCiblesRestantes())
                {
                    foreach (var ennemi in PlanGeneral.EnnemisAElliminer.Keys)
                    {
                        if (worker.CiblesAAbattre[ennemi] > 0)
                        {
                            foreach (var etg in ObtenirListeEtagesMaxNbEnnemi(ennemi))
                            {
                                var myWorker = new AlgoMaxTargetNumberPerEnemiSimulationWorker(etg, ennemi, worker);
                                TraiterPattern(myWorker);
                            }
                        }
                    }
                }
                else
                {
                    Scenarii.Add(worker);
                }
            }
        }

        /// <summary>
        /// Retourne la liste des etages qui contiennent le plus d'ennemis d'un type donné
        /// </summary>
        private List<Etage> ObtenirListeEtagesMaxNbEnnemi(E_NomEnnemiSucces typeEnnemi)
        {
            int nb = 0;
            foreach (var etg in PlanGeneral.RunsPossibles)
            {
                if (etg.ObtenirNbEnnemis(typeEnnemi) > nb)
                {
                    nb = etg.ObtenirNbEnnemis(typeEnnemi);
                }
            }
            return PlanGeneral.RunsPossibles.Where(f => f.ObtenirNbEnnemis(typeEnnemi) == nb).ToList();
        }
    }

    /// <summary>
    /// Classe de travail pour l'ago MaxTargetNumberPerEnemi
    /// </summary>
    public class AlgoMaxTargetNumberPerEnemiSimulationWorker
    {
        private Etage EtageEnCours { get; set; }
        private E_NomEnnemiSucces TypeEnnemiEnCours { get;set;}
        public Dictionary<E_NomEnnemiSucces, uint> CiblesAAbattre { get; set; }
        private int Overkills { get; set; }
        private Dictionary<Etage, int> EtagesEffectues { get; set; }

        internal AlgoMaxTargetNumberPerEnemiSimulationWorker(Etage etageEnCours, E_NomEnnemiSucces typeEnnemiEnCours, AlgoMaxTargetNumberPerEnemiSimulationWorker oldWorker)
        {
            EtagesEffectues = oldWorker.EtagesEffectues.ToDictionary(x => x.Key, x => x.Value);
            if (!EtagesEffectues.ContainsKey(etageEnCours))
            {
                EtagesEffectues.Add(new Etage(etageEnCours.Difficulte, etageEnCours.MesVagues, etageEnCours.Numero, etageEnCours.NomZone), 0);
            }
            CiblesAAbattre = oldWorker.CiblesAAbattre.ToDictionary(x => x.Key, x => x.Value);
            Overkills = oldWorker.Overkills;
            EtageEnCours = etageEnCours;
            TypeEnnemiEnCours = typeEnnemiEnCours;
        }

        internal AlgoMaxTargetNumberPerEnemiSimulationWorker(Etage etageEnCours, E_NomEnnemiSucces typeEnnemiEnCours, Dictionary<E_NomEnnemiSucces, uint> cibles)
        {
            EtagesEffectues = new Dictionary<Etage, int>() { { new Etage(etageEnCours.Difficulte, etageEnCours.MesVagues, etageEnCours.Numero, etageEnCours.NomZone), 0 } };
            EtageEnCours = etageEnCours;
            TypeEnnemiEnCours = typeEnnemiEnCours;
            CiblesAAbattre = cibles.ToDictionary(x => x.Key, x => x.Value);
            Overkills = 0;
        }

        private bool IsCiblesRestantesEtageActuel()
        {
            foreach (Ennemi e in EtageEnCours.ObtenirTousLesEnnemis())
            {
                if (CiblesAAbattre.ContainsKey(TypeEnnemiEnCours) && CiblesAAbattre[TypeEnnemiEnCours] > 0)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IsCiblesRestantes()
        {
            foreach (var cible in CiblesAAbattre)
            {
                if (cible.Value > 0) { return true; }
            }
            return false;
        }

        public int NbDeRunTotal()
        {
            return EtagesEffectues.Sum(f => f.Value);
        }

        public List<string> ObtenirLesRun()
        {
            var maListe = new List<string>();
            foreach (var item in EtagesEffectues.Where(f => f.Value != 0).OrderByDescending(k => k.Value))
            {
                maListe.Add($"{item.Value} runs sur l'étage {item.Key.Numero} en {item.Key.Difficulte.ToString()} ({item.Key.NomZone})");
            }
            return maListe;
        }

        public int CoutTotalScenario()
        {
            int result = 0;
            foreach (var etg in EtagesEffectues)
            {
                result += etg.Key.Cout * etg.Value;
            }
            return result;
        }

        /// <summary>
        /// Lance la simulation jusqu'à ce que l'ennemi choisi soit terminé!
        /// </summary>
        internal void EffectuerRunsEtageEnCours()
        {
            while (IsCiblesRestantesEtageActuel())
            {
                foreach (Ennemi e in EtageEnCours.ObtenirTousLesEnnemis())
                {
                    if (CiblesAAbattre.ContainsKey(e.TitreSucces))
                    {
                        if (CiblesAAbattre[e.TitreSucces] > 0)
                        {
                            CiblesAAbattre[e.TitreSucces]--;
                        }
                        else
                        {
                            Overkills++;
                        }
                    }
                }
                EtagesEffectues[EtageEnCours]++;
            }
        }
    }
}
