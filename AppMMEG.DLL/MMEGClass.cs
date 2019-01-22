using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMMEG.DLL
{
    public enum E_ModeDifficulte { Normal = 1, Avance = 2, Cauchemard = 3 }
    public enum E_NomEnnemi
    {
        ArcherHommeLezard,
        ChamaneHommeLezard,
        GuerrierHommeLezard,
        Louveteau,
        Loup,
        LoupEvolue,
        OiseauArcanique,
        AigleArcanique,
        AigleArcaniqueEvolue,
        Harpie,
        HarpieEvoluee,
        DragonDuVent,

        MoucheAspic,
        MoucheSerpent,
        MoucheSerpentEvolue,
        GuerrierGnoll,
        ArbaletrierGnoll,
        MageGnoll,
        Minotaure,
        MinotaureEvolue,
        DragonDeGlace
    }
    public enum E_NomEnnemiSucces
    {
        // AUCUN
        NONE,
        // Zone 1
        ArcaneEagles,
        ArcaneBirds,
        EvolvedArcaneEagles,
        EvolvedHarpies,
        Harpies,
        // Zone 2
        Minotaurs,
        Snakeflies,
        EvolvedSerpentflies,
        Serpentflies,
        EvolvedMinotaurs,
        // Zone 3
        Griffins,
        Felicores,
        Manticores,
        YoungGriffins,
        EvolvedManticores,
        EvolvedGriffins,
        // Zone 4
        SpiritCubs,
        SpiritFoxs,
        Centaurs,
        EvolvedSpiritFoxes,
        EvolvedCentaurs,
        // Zone 5
        MasaruMonks,
        EvolvedMasaruMonks,
        Ninjas,
        EvolvedNinjas,
        Samurais,
        EvolvedSamurais,
        // Zone 6
        Unicorns,
        EvolvedUnicorns,
        Sprites,
        EvolvedSprites,
        Pixies,
        UnicornFoals,
        // Zone 7
        SphinxKittens,
        Sphinxs,
        EvolvedSphinxs,
        Djinns,
        EvolvedDjinns,
        // Zone 8
        RuneSentinels,
        RuneGuardians,
        EvolvedRuneGuardians,
        Shieldguards,
        EvolvedShieldguards,
        // Zone 9
        Ghosts,
        EvolvedGhosts,
        SoulllessMarionettes,
        SoullessStriders,
        EvolvedSoulless
    }

    public static class MMEGValues
    {
        public static Dictionary<E_NomEnnemiSucces, TitreSuccesML> CorresNomsSuccesML = new Dictionary<E_NomEnnemiSucces, TitreSuccesML>
        {
            // Ile 1
            {E_NomEnnemiSucces.ArcaneEagles , new TitreSuccesML(){En = "Arcane Eagles", Fr = "Aigles Arcaniques" }  },
            {E_NomEnnemiSucces.ArcaneBirds , new TitreSuccesML(){En = "Arcane Birds", Fr = "Oiseaux Arcanique" }  },
            {E_NomEnnemiSucces.EvolvedArcaneEagles , new TitreSuccesML(){En = "Evolved Arcane Eagles", Fr = "Aigles Arcanique Evolués" }  },
            {E_NomEnnemiSucces.EvolvedHarpies , new TitreSuccesML(){En = "Evolved Harpies", Fr = "Harpies Evoluées" }  },
            {E_NomEnnemiSucces.Harpies , new TitreSuccesML(){En = "Harpies", Fr = "Harpies" }  },
            // Ile 2
            {E_NomEnnemiSucces.Minotaurs , new TitreSuccesML(){En = "Minotaurs", Fr = "Minotaures" }  },
            {E_NomEnnemiSucces.EvolvedMinotaurs , new TitreSuccesML(){En = "Evolved Minotaurs", Fr = "Minotaures évolués" }  },
            {E_NomEnnemiSucces.Snakeflies , new TitreSuccesML(){En = "Snakeflies", Fr = "Mouches-Aspics" }  },
            {E_NomEnnemiSucces.Serpentflies , new TitreSuccesML(){En = "Serpentflies", Fr = "Mouches-Serpents" }  },
            {E_NomEnnemiSucces.EvolvedSerpentflies , new TitreSuccesML(){En = "Evolved Serpentflies", Fr = "Mouches-Serpents évoluées" }  },
            // Ile 3
            {E_NomEnnemiSucces.Griffins , new TitreSuccesML(){En = "Griffins", Fr = "---" }  },
            {E_NomEnnemiSucces.Felicores , new TitreSuccesML(){En = "Felicores", Fr = "---" }  },
            {E_NomEnnemiSucces.Manticores , new TitreSuccesML(){En = "Manticores", Fr = "---" }  },
            {E_NomEnnemiSucces.YoungGriffins , new TitreSuccesML(){En = "Young Griffins", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedManticores , new TitreSuccesML(){En = "Evolved Manticores", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedGriffins , new TitreSuccesML(){En = "Evolved Griffins", Fr = "---" }  },
            // Ile 4
            {E_NomEnnemiSucces.SpiritCubs , new TitreSuccesML(){En = "Spirit Cubs", Fr = "---" }  },
            {E_NomEnnemiSucces.SpiritFoxs , new TitreSuccesML(){En = "Spirit Foxs", Fr = "---" }  },
            {E_NomEnnemiSucces.Centaurs , new TitreSuccesML(){En = "Centaurs", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedSpiritFoxes , new TitreSuccesML(){En = "Evolved Spirit Foxes", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedCentaurs , new TitreSuccesML(){En = "Evolved Centaurs", Fr = "---" }  },
            // Ile 5
            {E_NomEnnemiSucces.MasaruMonks , new TitreSuccesML(){En = "Masaru Monks", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedMasaruMonks , new TitreSuccesML(){En = "Evolved Masaru Monks", Fr = "---" }  },
            {E_NomEnnemiSucces.Ninjas , new TitreSuccesML(){En = "Ninjas", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedNinjas , new TitreSuccesML(){En = "Evolved Ninjas", Fr = "---" }  },
            {E_NomEnnemiSucces.Samurais , new TitreSuccesML(){En = "Samurais", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedSamurais , new TitreSuccesML(){En = "Evolved Samurais", Fr = "---" }  },
            // Ile 6
            {E_NomEnnemiSucces.Unicorns , new TitreSuccesML(){En = "Unicorns", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedUnicorns , new TitreSuccesML(){En = "Evolved Unicorns", Fr = "---" }  },
            {E_NomEnnemiSucces.Sprites , new TitreSuccesML(){En = "Sprites", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedSprites , new TitreSuccesML(){En = "Evolved Sprites", Fr = "---" }  },
            {E_NomEnnemiSucces.Pixies , new TitreSuccesML(){En = "Pixies", Fr = "---" }  },
            {E_NomEnnemiSucces.UnicornFoals , new TitreSuccesML(){En = "Unicorn Foals", Fr = "---" }  },
            // Ile 7
            {E_NomEnnemiSucces.SphinxKittens , new TitreSuccesML(){En = "Sphinx Kittens", Fr = "---" }  },
            {E_NomEnnemiSucces.Sphinxs , new TitreSuccesML(){En = "Sphinxs", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedSphinxs , new TitreSuccesML(){En = "Evolved Sphinxs", Fr = "---" }  },
            {E_NomEnnemiSucces.Djinns , new TitreSuccesML(){En = "Djinns", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedDjinns , new TitreSuccesML(){En = "Evolved Djinns", Fr = "---" }  },
            // Ile 8
            {E_NomEnnemiSucces.RuneSentinels , new TitreSuccesML(){En = "Rune Sentinels", Fr = "---" }  },
            {E_NomEnnemiSucces.RuneGuardians , new TitreSuccesML(){En = "Rune Guardians", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedRuneGuardians , new TitreSuccesML(){En = "Evolved Rune Guardians", Fr = "---" }  },
            {E_NomEnnemiSucces.Shieldguards , new TitreSuccesML(){En = "Shieldguards", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedShieldguards , new TitreSuccesML(){En = "Evolved Shieldguards", Fr = "---" }  },
            // Ile 9
            {E_NomEnnemiSucces.Ghosts , new TitreSuccesML(){En = "Ghosts", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedGhosts , new TitreSuccesML(){En = "Evolved Ghosts", Fr = "---" }  },
            {E_NomEnnemiSucces.SoulllessMarionettes , new TitreSuccesML(){En = "Soullless Marionettes", Fr = "---" }  },
            {E_NomEnnemiSucces.SoullessStriders , new TitreSuccesML(){En = "Soulless Striders", Fr = "---" }  },
            {E_NomEnnemiSucces.EvolvedSoulless , new TitreSuccesML(){En = "Evolved Soulless", Fr = "---" }  }
        };
    }
    public class TitreSuccesML
    {
        public string En { get; set; }
        public string Fr { get; set; }
    }

    public class SuccesKill : Succes
    {
        #region:Attributs
        public E_NomEnnemiSucces CreatureAKill { get; }
        public uint Nombre { get; }
        #endregion

        public SuccesKill(E_NomEnnemiSucces creatureAKill, uint nombre) : base($"{MMEGValues.CorresNomsSuccesML[creatureAKill].En}", $"Kill {nombre.ToString()} {MMEGValues.CorresNomsSuccesML[creatureAKill].En}")
        {
            CreatureAKill = creatureAKill;
            Nombre = nombre;
        }
    }
    public abstract class Succes
    {
        #region:Attributs
        public string Titre { get; }
        public string Description { get; }
        #endregion

        #region:Constructeurs
        public Succes(string titre, string description)
        {
            Titre = titre;
            Description = description;
        }
        #endregion
    }

    public class Monde
    {
        #region:Attributs
        public string Nom { get; set; }
        public List<Zone> MesZones { get; set; }
        #endregion
    }
    public class Zone
    {
        #region:Attributs
        public int Numero { get; }
        public String Nom { get; }
        public List<Etage> MesEtages { get; }
        public List<Succes> MesSucces { get; set; }

        public string NomFormate { get { return $"{Numero} - {Nom}"; } }

        #endregion

        public Zone(int numero, string nom, List<Etage> mesEtages)
        {
            Numero = numero;
            Nom = nom;
            MesEtages = mesEtages;
            // On donne le nom de la zone à l'étage pour l'affichage des informations
            foreach (var e in MesEtages)
            {
                e.NomZone = Nom;
            }
        }

        public Zone(int numero, string nom)
        {
            Numero = numero;
            Nom = nom;
            MesEtages = new List<Etage>();
        }

        #region:Methodes
        /// <summary>
        /// Retourne tous les ennemis contenus dans cette zone
        /// </summary>
        public List<Ennemi> ObtenirTousLesEnnemis()
        {
            var maListe = new List<Ennemi>();
            foreach (Etage etg in MesEtages)
            {
                maListe.AddRange(etg.ObtenirTousLesEnnemis());
            }
            return maListe;
        }



        public void AjouterEnnemi(Ennemi e, int numEtage, E_ModeDifficulte modeDifficulte)
        {
            if (MesEtages.Exists(x => x.Difficulte == modeDifficulte && x.Numero == numEtage))
            {
                MesEtages.Find(x => x.Difficulte == modeDifficulte && x.Numero == numEtage).AjouteEnnemi(e);
            }
            else
            {
                MesEtages.Add(new Etage(numEtage, modeDifficulte, Nom));
                MesEtages.Find(x => x.Difficulte == modeDifficulte && x.Numero == numEtage).AjouteEnnemi(e);
            }
        }
        #endregion
    }
    public class Etage : IEquatable<Etage>
    {
        #region:Attributs
        public string NomZone { get; set; }
        public int Numero { get; set; }
        public E_ModeDifficulte Difficulte { get; set; }
        public List<Vague> MesVagues { get; set; }

        public int Cout
        {
            get
            {
                switch (Difficulte)
                {
                    case E_ModeDifficulte.Normal:
                        return 5;
                    case E_ModeDifficulte.Avance:
                        return 6;
                    case E_ModeDifficulte.Cauchemard:
                        return 7;
                    default:
                        throw new Exception("Difficulte incorrecte");
                }
            }
        }
        #endregion

        #region:Constructeur
        public Etage(E_ModeDifficulte difficulte, List<Vague> mesVagues, int numero, string nomZone)
        {
            NomZone = nomZone;
            Numero = numero;
            Difficulte = difficulte;
            MesVagues = mesVagues.ToList();
        }

        public Etage(int numero, E_ModeDifficulte difficulte, List<Vague> mesVagues)
        {
            NomZone = "";
            Numero = numero;
            Difficulte = difficulte;
            MesVagues = mesVagues.ToList();
        }

        public Etage(int numero, E_ModeDifficulte difficulte, string nomZone)
        {
            Numero = numero;
            Difficulte = difficulte;
            NomZone = nomZone;
            MesVagues = new List<Vague> { new Vague(0) };
        }
        #endregion

        #region:Methodes
        /// <summary>
        /// Retourne tous les ennemis de cet étage
        /// </summary>
        public List<Ennemi> ObtenirTousLesEnnemis()
        {
            var maListe = new List<Ennemi>();
            foreach (Vague v in MesVagues)
            {
                maListe.AddRange(v.MesEnnemis);
            }
            return maListe;
        }

        public int ObtenirNbEnnemis(E_NomEnnemiSucces typeEnnemi)
        {
            int nb = 0;
            foreach (var e in ObtenirTousLesEnnemis())
            {
                if (e.TitreSucces == typeEnnemi)
                {
                    nb++;
                }
            }
            return nb;
        }

        public void AjouteEnnemi(Ennemi e)
        {
            MesVagues[0].AjouterEnnemi(e);
        }
        #endregion

        #region:Surcharges
        public override bool Equals(object obj)
        {
            return Equals(obj as Etage);
        }
        public bool Equals(Etage other)
        {
            return other != null &&
                   NomZone == other.NomZone &&
                   Numero == other.Numero &&
                   Difficulte == other.Difficulte;
        }
        public override int GetHashCode()
        {
            var hashCode = -674022627;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NomZone);
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            hashCode = hashCode * -1521134295 + Difficulte.GetHashCode();
            return hashCode;
        }
        #endregion
    }
    public class Vague : IEquatable<Vague>
    {
        #region:Attributs
        public int Numero { get; set; }
        public List<Ennemi> MesEnnemis { get; set; }
        #endregion

        #region:Methodes
        public Vague(int numVague)
        {
            Numero = numVague;
            MesEnnemis = new List<Ennemi>();

        }
        public Vague(int numVague, E_NomEnnemi ennemi1)
        {
            Numero = numVague;
            MesEnnemis = new List<Ennemi>
            {
                new Ennemi(ennemi1.ToString())
            };
        }
        public Vague(int numVague, E_NomEnnemi ennemi1, E_NomEnnemi ennemi2)
        {
            Numero = numVague;
            MesEnnemis = new List<Ennemi>
            {
                new Ennemi(ennemi1.ToString()),
                new Ennemi(ennemi2.ToString())
            };
        }
        public Vague(int numVague, E_NomEnnemi ennemi1, E_NomEnnemi ennemi2, E_NomEnnemi ennemi3)
        {
            Numero = numVague;
            MesEnnemis = new List<Ennemi>
            {
                new Ennemi(ennemi1.ToString()),
                new Ennemi(ennemi2.ToString()),
                new Ennemi(ennemi3.ToString())
            };
        }

        public void AjouterEnnemi(Ennemi e)
        {
            MesEnnemis.Add(e);
        }
        #endregion

        #region:Surcharges
        public override bool Equals(object obj)
        {
            return Equals(obj as Vague);
        }
        public bool Equals(Vague other)
        {
            return other != null &&
                   Numero == other.Numero &&
                   EqualityComparer<List<Ennemi>>.Default.Equals(MesEnnemis, other.MesEnnemis);
        }
        public override int GetHashCode()
        {
            var hashCode = -738316462;
            hashCode = hashCode * -1521134295 + Numero.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Ennemi>>.Default.GetHashCode(MesEnnemis);
            return hashCode;
        }
        #endregion
    }
    public class Ennemi : IEquatable<Ennemi>
    {
        #region:Attributs
        public string Nom { get; set; }
        public string NomDeBase { get; set; }
        public E_NomEnnemiSucces TitreSucces { get; set; }
        #endregion

        public Ennemi(string nom, string nomDeBase = "")
        {
            Nom = nom;
            NomDeBase = nomDeBase;
            GererCategorieSucces();
        }

        private void GererCategorieSucces()
        {
            switch (Nom)
            {
                // Ile 1
                case "Arcane Bird":
                    TitreSucces = E_NomEnnemiSucces.ArcaneBirds;
                    break;
                case "Arcane Eagle":
                    TitreSucces = E_NomEnnemiSucces.ArcaneEagles;
                    break;
                case "Harpy":
                    TitreSucces = E_NomEnnemiSucces.Harpies;
                    break;
                // Ile 2
                case "Minotaur":
                    TitreSucces = E_NomEnnemiSucces.Minotaurs;
                    break;
                case "SerpentFly":
                    TitreSucces = E_NomEnnemiSucces.Serpentflies;
                    break;
                case "SnakeFly":
                    TitreSucces = E_NomEnnemiSucces.Snakeflies;
                    break;
                // Ile 3
                case "Griffin":
                    TitreSucces = E_NomEnnemiSucces.Griffins;
                    break;
                case "Felicore":
                    TitreSucces = E_NomEnnemiSucces.Felicores;
                    break;
                case "Manticore":
                    TitreSucces = E_NomEnnemiSucces.Manticores;
                    break;
                case "Young Griffin":
                    TitreSucces = E_NomEnnemiSucces.YoungGriffins;
                    break;
                // Ile 4
                case "Spirit Cub":
                    TitreSucces = E_NomEnnemiSucces.SpiritCubs;
                    break;
                case "Spirit Fox":
                    TitreSucces = E_NomEnnemiSucces.SpiritFoxs;
                    break;
                case "Centaur":
                    TitreSucces = E_NomEnnemiSucces.Centaurs;
                    break;
                // Ile 5
                case "Bunraku Samurai":
                    TitreSucces = E_NomEnnemiSucces.Samurais;
                    break;
                case "Kabuki Ninja":
                    TitreSucces = E_NomEnnemiSucces.Ninjas;
                    break;
                case "Masaru Monk":
                    TitreSucces = E_NomEnnemiSucces.MasaruMonks;
                    break;
                // Ile 6
                case "Unicorn Foal":
                    TitreSucces = E_NomEnnemiSucces.UnicornFoals;
                    break;
                case "Unicorn":
                    TitreSucces = E_NomEnnemiSucces.Unicorns;
                    break;
                case "Sprite":
                    TitreSucces = E_NomEnnemiSucces.Sprites;
                    break;
                case "Pixie":
                    TitreSucces = E_NomEnnemiSucces.Pixies;
                    break;
                // Ile 7
                case "Sphinx Kitten":
                    TitreSucces = E_NomEnnemiSucces.SphinxKittens;
                    break;
                case "Sphinx":
                    TitreSucces = E_NomEnnemiSucces.Sphinxs;
                    break;
                case "Djinn":
                    TitreSucces = E_NomEnnemiSucces.Djinns;
                    break;
                // Ile 8
                case "Rune Sentinel":
                    TitreSucces = E_NomEnnemiSucces.RuneSentinels;
                    break;
                case "Rune Guardian":
                    TitreSucces = E_NomEnnemiSucces.RuneGuardians;
                    break;
                case "Shieldguard":
                    TitreSucces = E_NomEnnemiSucces.Shieldguards;
                    break;
                // Ile 9
                case "Ghost":
                    TitreSucces = E_NomEnnemiSucces.Ghosts;
                    break;
                case "Soulless Marionette":
                    TitreSucces = E_NomEnnemiSucces.SoulllessMarionettes;
                    break;
                case "Soulless Strider":
                    TitreSucces = E_NomEnnemiSucces.SoullessStriders;
                    break;
                default:
                    TitreSucces = E_NomEnnemiSucces.NONE;
                    break;
            }
            if (TitreSucces == E_NomEnnemiSucces.NONE)
            {
                switch (NomDeBase)
                {
                    // Ile 1
                    case "Arcane Eagle":
                        TitreSucces = E_NomEnnemiSucces.EvolvedArcaneEagles;
                        break;
                    case "Harpy":
                        TitreSucces = E_NomEnnemiSucces.EvolvedHarpies;
                        break;
                    // Ile 2
                    case "Minotaur":
                        TitreSucces = E_NomEnnemiSucces.EvolvedMinotaurs;
                        break;
                    case "SerpentFly":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSerpentflies;
                        break;
                    // Ile 3
                    case "Manticore":
                        TitreSucces = E_NomEnnemiSucces.EvolvedManticores;
                        break;
                    case "Griffin":
                        TitreSucces = E_NomEnnemiSucces.EvolvedGriffins;
                        break;
                    // Ile 4
                    case "Spirit Fox":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSpiritFoxes;
                        break;
                    case "Centaur":
                        TitreSucces = E_NomEnnemiSucces.EvolvedCentaurs;
                        break;
                    // Ile 5
                    case "Bunraku Samurai":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSamurais;
                        break;
                    case "Kabuki Ninja":
                        TitreSucces = E_NomEnnemiSucces.EvolvedNinjas;
                        break;
                    case "Masaru Monk":
                        TitreSucces = E_NomEnnemiSucces.EvolvedMasaruMonks;
                        break;
                    // Ile 6
                    case "Unicorn":
                        TitreSucces = E_NomEnnemiSucces.EvolvedUnicorns;
                        break;
                    case "Sprite":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSprites;
                        break;
                    // Ile 7
                    case "Sphinx":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSphinxs;
                        break;
                    case "Djinn":
                        TitreSucces = E_NomEnnemiSucces.EvolvedDjinns;
                        break;
                    // Ile 8
                    case "Rune Guardian":
                        TitreSucces = E_NomEnnemiSucces.EvolvedRuneGuardians;
                        break;
                    case "Shieldguard":
                        TitreSucces = E_NomEnnemiSucces.EvolvedShieldguards;
                        break;
                    // Ile 9
                    case "Ghost":
                        TitreSucces = E_NomEnnemiSucces.EvolvedGhosts;
                        break;
                    case "Soulless Strider":
                        TitreSucces = E_NomEnnemiSucces.EvolvedSoulless;
                        break;
                    default:
                        TitreSucces = E_NomEnnemiSucces.NONE;
                        break;
                }
            }
        }

        #region:Surcharges
        public override bool Equals(object obj)
        {
            return Equals(obj as Ennemi);
        }

        public bool Equals(Ennemi other)
        {
            return other != null &&
                   Nom == other.Nom;
        }

        public override int GetHashCode()
        {
            return 217408413 + EqualityComparer<string>.Default.GetHashCode(Nom);
        }
        #endregion
    }
}
