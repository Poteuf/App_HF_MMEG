using AppMMEG.DLL;
using ImportMMEG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMMEG.Winform
{
    /// <summary>
    /// Ancien mode d'initialisation (A la main)
    /// </summary>
    public static class Initialisation
    {
        public static Monde InitialiserMondeIlesMorcelees()
        {
            var monMonde = new Monde()
            {
                Nom = "Îles Morcelées",
                MesZones = new List<Zone>()
                {
                    GenererZone1(),
                    GenererZone2()
                }
            };
            return monMonde;
        }

        private static Zone GenererZone1()
        {
            // ----- Normal -----
            var monEtage11 = new Etage(1, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArcherHommeLezard),
                    new Vague(2, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.Louveteau)
                });
            var monEtage12 = new Etage(2, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArcherHommeLezard,E_NomEnnemi.ChamaneHommeLezard,E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.Louveteau)
                });
            var monEtage13 = new Etage(3, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.OiseauArcanique, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard,E_NomEnnemi.Louveteau,E_NomEnnemi.GuerrierHommeLezard)
                });
            var monEtage14 = new Etage(4, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Louveteau, E_NomEnnemi.ArcherHommeLezard),
                    new Vague(2, E_NomEnnemi.OiseauArcanique, E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(3, E_NomEnnemi.Harpie,E_NomEnnemi.Louveteau,E_NomEnnemi.ChamaneHommeLezard)
                });
            var monEtage15 = new Etage(5, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.ArcherHommeLezard),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.AigleArcanique,E_NomEnnemi.Loup,E_NomEnnemi.Loup)
                });
            var monEtage16 = new Etage(6, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Harpie, E_NomEnnemi.OiseauArcanique),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.Harpie),
                    new Vague(3, E_NomEnnemi.Harpie,E_NomEnnemi.Loup,E_NomEnnemi.AigleArcanique)
                });
            var monEtage17 = new Etage(7, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Harpie, E_NomEnnemi.AigleArcanique),
                    new Vague(2, E_NomEnnemi.AigleArcaniqueEvolue, E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.DragonDuVent)
                });

            // ----- Avance -----
            var monEtage21 = new Etage(1, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Louveteau, E_NomEnnemi.ArcherHommeLezard),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.Loup,E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(3, E_NomEnnemi.AigleArcanique,E_NomEnnemi.Loup,E_NomEnnemi.ChamaneHommeLezard)
                });
            var monEtage22 = new Etage(2, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.AigleArcanique, E_NomEnnemi.ArcherHommeLezard),
                    new Vague(2, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(3, E_NomEnnemi.Harpie,E_NomEnnemi.ArcherHommeLezard,E_NomEnnemi.GuerrierHommeLezard)
                });
            var monEtage23 = new Etage(3, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(2, E_NomEnnemi.Harpie, E_NomEnnemi.ArcherHommeLezard,E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.Loup,E_NomEnnemi.Loup)
                });
            var monEtage24 = new Etage(4, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Loup, E_NomEnnemi.Harpie),
                    new Vague(2, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.AigleArcanique,E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.GuerrierHommeLezard,E_NomEnnemi.ArcherHommeLezard)
                });
            var monEtage25 = new Etage(5, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(2, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.GuerrierHommeLezard,E_NomEnnemi.ArcherHommeLezard),
                    new Vague(3, E_NomEnnemi.GuerrierHommeLezard,E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.LoupEvolue)
                });
            var monEtage26 = new Etage(6, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.Loup,E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(3, E_NomEnnemi.HarpieEvoluee,E_NomEnnemi.LoupEvolue,E_NomEnnemi.ArcherHommeLezard)
                });
            var monEtage27 = new Etage(7, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.Harpie),
                    new Vague(2, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.DragonDuVent,E_NomEnnemi.HarpieEvoluee,E_NomEnnemi.ChamaneHommeLezard)
                });

            // ----- Cauchemard -----
            var monEtage31 = new Etage(1, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(3, E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.GuerrierHommeLezard,E_NomEnnemi.LoupEvolue)
                });
            var monEtage32 = new Etage(2, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Loup, E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(2, E_NomEnnemi.AigleArcanique, E_NomEnnemi.Harpie),
                    new Vague(3, E_NomEnnemi.HarpieEvoluee,E_NomEnnemi.LoupEvolue,E_NomEnnemi.LoupEvolue)
                });
            var monEtage33 = new Etage(3, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.LoupEvolue, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.AigleArcaniqueEvolue, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.GuerrierHommeLezard),
                    new Vague(3, E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.ChamaneHommeLezard,E_NomEnnemi.ChamaneHommeLezard)
                });
            var monEtage34 = new Etage(4, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Loup, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(2, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.GuerrierHommeLezard,E_NomEnnemi.ChamaneHommeLezard)
                });
            var monEtage35 = new Etage(5, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.LoupEvolue, E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.ArcherHommeLezard,E_NomEnnemi.ArcherHommeLezard)
                });
            var monEtage36 = new Etage(6, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.GuerrierHommeLezard, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.ChamaneHommeLezard),
                    new Vague(3, E_NomEnnemi.HarpieEvoluee,E_NomEnnemi.LoupEvolue,E_NomEnnemi.AigleArcaniqueEvolue)
                });
            var monEtage37 = new Etage(7, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ChamaneHommeLezard, E_NomEnnemi.HarpieEvoluee),
                    new Vague(2, E_NomEnnemi.ArcherHommeLezard, E_NomEnnemi.HarpieEvoluee, E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.DragonDuVent,E_NomEnnemi.AigleArcaniqueEvolue,E_NomEnnemi.LoupEvolue)
                });

            // ----- Zone finale -----
            var mesEtages = new List<Etage>()
            {
                monEtage11, monEtage12, monEtage13, monEtage14, monEtage15, monEtage16, monEtage17,
                monEtage21, monEtage22, monEtage23, monEtage24, monEtage25, monEtage26, monEtage27,
                monEtage31, monEtage32, monEtage33, monEtage34, monEtage35, monEtage36, monEtage37
            };
            var maZone = new Zone(1, "Îles suspendues", mesEtages);
            return maZone;
        }
        private static Zone GenererZone2()
        {
            // ----- Normal -----
            var monEtage11 = new Etage(1, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheAspic, E_NomEnnemi.GuerrierGnoll),
                    new Vague(2, E_NomEnnemi.Louveteau, E_NomEnnemi.MoucheAspic, E_NomEnnemi.Louveteau),
                    new Vague(3, E_NomEnnemi.Loup, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.ArbaletrierGnoll)
              });
            var monEtage12 = new Etage(2, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MageGnoll, E_NomEnnemi.GuerrierGnoll),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.MoucheAspic, E_NomEnnemi.Louveteau),
                    new Vague(3, E_NomEnnemi.MageGnoll, E_NomEnnemi.ArbaletrierGnoll, E_NomEnnemi.GuerrierGnoll)
          });
            var monEtage13 = new Etage(3, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.ArbaletrierGnoll, E_NomEnnemi.Louveteau),
                    new Vague(2, E_NomEnnemi.MageGnoll, E_NomEnnemi.Louveteau, E_NomEnnemi.MoucheAspic),
                    new Vague(3, E_NomEnnemi.Minotaure, E_NomEnnemi.MoucheAspic, E_NomEnnemi.Loup)
           });
            var monEtage14 = new Etage(4, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheAspic, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.MageGnoll, E_NomEnnemi.Minotaure),
                    new Vague(3, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.Loup, E_NomEnnemi.MoucheAspic)
         });
            var monEtage15 = new Etage(5, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Minotaure, E_NomEnnemi.MoucheAspic),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.Minotaure),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.Loup,E_NomEnnemi.Loup)
          });
            var monEtage16 = new Etage(6, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.MageGnoll),
                    new Vague(2, E_NomEnnemi.LoupEvolue, E_NomEnnemi.ArbaletrierGnoll, E_NomEnnemi.GuerrierGnoll),
                    new Vague(3, E_NomEnnemi.ArbaletrierGnoll, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.LoupEvolue)
           });
            var monEtage17 = new Etage(7, E_ModeDifficulte.Normal, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.LoupEvolue, E_NomEnnemi.Minotaure),
                    new Vague(2, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.MoucheSerpent),
                    new Vague(3, E_NomEnnemi.DragonDeGlace)
             });

            // ----- Avance -----
            var monEtage21 = new Etage(1, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.GuerrierGnoll),
                    new Vague(2, E_NomEnnemi.MageGnoll, E_NomEnnemi.GuerrierGnoll,E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.MoucheSerpent,E_NomEnnemi.Loup,E_NomEnnemi.GuerrierGnoll)
            });
            var monEtage22 = new Etage(2, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MageGnoll, E_NomEnnemi.ArbaletrierGnoll),
                    new Vague(2, E_NomEnnemi.Minotaure, E_NomEnnemi.Loup, E_NomEnnemi.Minotaure),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.Loup,E_NomEnnemi.GuerrierGnoll)
               });
            var monEtage23 = new Etage(3, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.Loup),
                    new Vague(2, E_NomEnnemi.LoupEvolue, E_NomEnnemi.Loup,E_NomEnnemi.GuerrierGnoll),
                    new Vague(3, E_NomEnnemi.Minotaure,E_NomEnnemi.MoucheSerpent,E_NomEnnemi.Minotaure)
              });
            var monEtage24 = new Etage(4, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.GuerrierGnoll),
                    new Vague(2, E_NomEnnemi.LoupEvolue, E_NomEnnemi.MoucheSerpent,E_NomEnnemi.ArbaletrierGnoll),
                    new Vague(3, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.GuerrierGnoll,E_NomEnnemi.LoupEvolue)
              });
            var monEtage25 = new Etage(5, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.LoupEvolue, E_NomEnnemi.Minotaure),
                    new Vague(2, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.Minotaure,E_NomEnnemi.MoucheSerpent),
                    new Vague(3, E_NomEnnemi.MinotaureEvolue,E_NomEnnemi.Minotaure,E_NomEnnemi.LoupEvolue)
            });
            var monEtage26 = new Etage(6, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.LoupEvolue),
                    new Vague(2, E_NomEnnemi.Minotaure, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.MageGnoll),
                    new Vague(3, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.GuerrierGnoll,E_NomEnnemi.MinotaureEvolue)
              });
            var monEtage27 = new Etage(7, E_ModeDifficulte.Avance, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.Minotaure),
                    new Vague(2, E_NomEnnemi.MoucheSerpentEvolue, E_NomEnnemi.MinotaureEvolue,E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.DragonDeGlace,E_NomEnnemi.MinotaureEvolue,E_NomEnnemi.MinotaureEvolue)
             });

            // ----- Cauchemard -----
            var monEtage31 = new Etage(1, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.MoucheSerpent),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.MageGnoll, E_NomEnnemi.ArbaletrierGnoll),
                    new Vague(3, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.MoucheSerpent,E_NomEnnemi.GuerrierGnoll)
              });
            var monEtage32 = new Etage(2, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MageGnoll, E_NomEnnemi.MoucheSerpent),
                    new Vague(2, E_NomEnnemi.Loup, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.Loup),
                    new Vague(3, E_NomEnnemi.LoupEvolue,E_NomEnnemi.ArbaletrierGnoll,E_NomEnnemi.MoucheSerpentEvolue)
               });
            var monEtage33 = new Etage(3, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.Minotaure, E_NomEnnemi.LoupEvolue),
                    new Vague(2, E_NomEnnemi.LoupEvolue, E_NomEnnemi.GuerrierGnoll, E_NomEnnemi.MoucheSerpent),
                    new Vague(3, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.Minotaure,E_NomEnnemi.Minotaure)
                });
            var monEtage34 = new Etage(4, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MoucheSerpent, E_NomEnnemi.Minotaure),
                    new Vague(2, E_NomEnnemi.MoucheSerpentEvolue, E_NomEnnemi.Minotaure, E_NomEnnemi.MoucheSerpent),
                    new Vague(3, E_NomEnnemi.MinotaureEvolue,E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.LoupEvolue)
               });
            var monEtage35 = new Etage(5, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.LoupEvolue, E_NomEnnemi.GuerrierGnoll),
                    new Vague(2, E_NomEnnemi.MageGnoll, E_NomEnnemi.MageGnoll, E_NomEnnemi.MinotaureEvolue),
                    new Vague(3, E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.MinotaureEvolue,E_NomEnnemi.Minotaure)
              });
            var monEtage36 = new Etage(6, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.LoupEvolue),
                    new Vague(2, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.MageGnoll),
                    new Vague(3, E_NomEnnemi.GuerrierGnoll,E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.MinotaureEvolue)
                });
            var monEtage37 = new Etage(7, E_ModeDifficulte.Cauchemard, new List<Vague>() {
                    new Vague(1, E_NomEnnemi.LoupEvolue, E_NomEnnemi.MinotaureEvolue),
                    new Vague(2, E_NomEnnemi.MoucheSerpentEvolue, E_NomEnnemi.MinotaureEvolue, E_NomEnnemi.LoupEvolue),
                    new Vague(3, E_NomEnnemi.DragonDeGlace,E_NomEnnemi.MoucheSerpentEvolue,E_NomEnnemi.MinotaureEvolue)
               });

            // ----- Zone finale -----
            var mesEtages = new List<Etage>()
            {
                monEtage11, monEtage12, monEtage13, monEtage14, monEtage15, monEtage16, monEtage17,
                monEtage21, monEtage22, monEtage23, monEtage24, monEtage25, monEtage26, monEtage27,
                monEtage31, monEtage32, monEtage33, monEtage34, monEtage35, monEtage36, monEtage37
            };
            var maZone = new Zone(2, "Grottes de Glace", mesEtages);
            return maZone;
        }
    }

    /// <summary>
    /// Mode d'initailisation via fichier d'import 
    /// </summary>
    public static class InitialisationV2
    {               
        public static Monde InitialiserMondeIlesMorcelees()
        {
            var importFactory = new import();
            var mesElements = importFactory.construireListElement();

            Zone Ile1 = null;
            Zone Ile2 = null;
            Zone Ile3 = null;
            Zone Ile4 = null;
            Zone Ile5 = null;
            Zone Ile6 = null;
            Zone Ile7 = null;
            Zone Ile8 = null;
            Zone Ile9 = null;

            // Succès Zone 1
            SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            // Succès Zone 2
            SuccesKill i2a = new SuccesKill(E_NomEnnemiSucces.Minotaurs, 1500);
            SuccesKill i2b = new SuccesKill(E_NomEnnemiSucces.Snakeflies, 1500);
            SuccesKill i2c = new SuccesKill(E_NomEnnemiSucces.Serpentflies, 1500);
            SuccesKill i2d = new SuccesKill(E_NomEnnemiSucces.EvolvedMinotaurs, 1500);
            SuccesKill i2e = new SuccesKill(E_NomEnnemiSucces.EvolvedSerpentflies, 1500);
            //// Succès Zone 3
            SuccesKill i3a = new SuccesKill(E_NomEnnemiSucces.Griffins, 1500);
            SuccesKill i3b = new SuccesKill(E_NomEnnemiSucces.Felicores, 1500);
            SuccesKill i3c = new SuccesKill(E_NomEnnemiSucces.Manticores, 1500);
            SuccesKill i3d = new SuccesKill(E_NomEnnemiSucces.YoungGriffins, 1500);
            SuccesKill i3e = new SuccesKill(E_NomEnnemiSucces.EvolvedManticores, 1500);
            SuccesKill i3f = new SuccesKill(E_NomEnnemiSucces.EvolvedGriffins, 1500);
            //// Succès Zone 4
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            //// Succès Zone 5
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            //// Succès Zone 6
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            //// Succès Zone 7
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            //// Succès Zone 8
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);
            //// Succès Zone 9
            //SuccesKill i1a = new SuccesKill(E_NomEnnemiSucces.ArcaneBirds, 1500);
            //SuccesKill i1b = new SuccesKill(E_NomEnnemiSucces.ArcaneEagles, 1500);
            //SuccesKill i1c = new SuccesKill(E_NomEnnemiSucces.EvolvedArcaneEagles, 1500);
            //SuccesKill i1d = new SuccesKill(E_NomEnnemiSucces.EvolvedHarpies, 1000);
            //SuccesKill i1e = new SuccesKill(E_NomEnnemiSucces.Harpies, 1000);

            var corresDifficulte = new Dictionary<element.difficulte, E_ModeDifficulte>
            {
                { element.difficulte.normal, E_ModeDifficulte.Normal },
                { element.difficulte.advanced, E_ModeDifficulte.Avance },
                { element.difficulte.nightmare, E_ModeDifficulte.Cauchemard }
            };

            foreach (var elt in mesElements)
            {
                var i = elt.iNombre;
                while (i > 0)
                {
                    switch (elt.eIle)
                    {
                        case element.ile.FloatingIslands:
                            Ile1 = Ile1 ?? new Zone(1, element.ile.FloatingIslands.ToString()) { MesSucces = new List<Succes>() { i1a, i1b, i1c, i1d, i1e } };
                            Ile1.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.IceCaves:
                            Ile2 = Ile2 ?? new Zone(2, element.ile.IceCaves.ToString()) { MesSucces = new List<Succes>() { i2a, i2b, i2c, i2d, i2e } };
                            Ile2.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.Volcano:
                            Ile3 = Ile3 ?? new Zone(3, element.ile.Volcano.ToString()) { MesSucces = new List<Succes>() { i3a, i3b, i3c, i3d, i3e, i3f } };
                            Ile3.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.MysticForest:
                            Ile4 = Ile4 ?? new Zone(4, element.ile.MysticForest.ToString());
                            Ile4.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.SunkenCity:
                            Ile5 = Ile5 ?? new Zone(5, element.ile.SunkenCity.ToString());
                            Ile5.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.WorldTreeMountain:
                            Ile6 = Ile6 ?? new Zone(6, element.ile.WorldTreeMountain.ToString());
                            Ile6.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.ColossusDesert:
                            Ile7 = Ile7 ?? new Zone(7, element.ile.ColossusDesert.ToString());
                            Ile7.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.FireMaze:
                            Ile8 = Ile8 ?? new Zone(8, element.ile.FireMaze.ToString());
                            Ile8.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        case element.ile.Wastelands:
                            Ile9 = Ile9 ?? new Zone(9, element.ile.Wastelands.ToString());
                            Ile9.AjouterEnnemi(new Ennemi(elt.szCreature, elt.szCreatureDeBase), elt.iLevel, corresDifficulte[elt.eDifficulte]);
                            break;
                        default:
                            break;
                    }
                    i--;
                }
            }

            var monMonde = new Monde()
            {
                Nom = "Îles Morcelées",
                MesZones = new List<Zone>()
                {
                    Ile1,Ile2,Ile3,Ile4,Ile5,Ile6,Ile7,Ile8,Ile9
                }
            };

            return monMonde;
        }
    }
}
