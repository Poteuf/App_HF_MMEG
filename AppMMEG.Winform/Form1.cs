using AppMMEG.DLL;
using ImportMMEG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMMEG.Winform
{
    public partial class Form1 : Form
    {
        //private Monde MonMonde { get; set; }
        private Monde MonMonde2 { get; set; }

        public Form1()
        {
            InitializeComponent();

            rtbGeneral.ForeColor = Color.DarkRed;
            rtbGeneral.AppendText("Salut, bienvenue sur l'optimiseur de HF pour MMEG\n\n\n");


            var truc = new import();
            var bidule = truc.construireListElement();

            GenererMonde();

            //Initialisation affichage

            cb_Iles.DataSource = MonMonde2.MesZones.ToList();
            cb_Iles.DisplayMember = "NomFormate";

            AfficherInfosMonde();

            // Appel traitement Ile 1

            PlanTraitement monPlan = new PlanTraitement()
            {
                Algorithme = E_TypeTraitement.AlgoMaxTargetNumber,
                RunsPossibles = MonMonde2.MesZones.Find(f => f.Numero == 1).MesEtages,
                EnnemisAElliminer = new Dictionary<E_NomEnnemiSucces, uint> {
                    { E_NomEnnemiSucces.ArcaneEagles, 1500-960},
                    { E_NomEnnemiSucces.ArcaneBirds, 1500-906},
                    { E_NomEnnemiSucces.EvolvedArcaneEagles, 1500-436},
                    { E_NomEnnemiSucces.EvolvedHarpies, 1000-678},
                    { E_NomEnnemiSucces.Harpies, 1000-1000}
                }
            };

            AlgorithmeHandler algo = new AlgorithmeHandler(monPlan);
            var result = algo.EffectuerTraitement();

            rtbGeneral.AppendText("Traitement terminé\n");

            int j = 1;
            foreach (var scenar in result.Where(u => u.NbDeRunTotal() == result.Min(f => f.NbDeRunTotal())).Distinct())
            {
                rtbGeneral.AppendText($"--+-- Scenario le plus performant ({j}) - {scenar.NbDeRunTotal()} Runs - {scenar.CoutTotalScenario()} Energie :\n\n");
                foreach (var item in scenar.ObtenirLesRun())
                {
                    rtbGeneral.AppendText($"{item}\n");
                }
                j++;
                rtbGeneral.AppendText("\n");
            }
        }

        private void GenererMonde()
        {
            //MonMonde = Initialisation.InitialiserMondeIlesMorcelees();
            MonMonde2 = InitialisationV2.InitialiserMondeIlesMorcelees();
        }

        private void AfficherInfosMonde()
        {
            foreach (Zone z in MonMonde2.MesZones)
            {
                AfficherInfosZone(z);
            }
        }
        private void AfficherInfosZone(Zone maZone)
        {
            rtbGeneral.AppendText($"===== Area {maZone.Numero} - {maZone.Nom} =====\n\n");
            var mesEnnemis = new Dictionary<Ennemi, int>();
            foreach (Ennemi e in maZone.ObtenirTousLesEnnemis())
            {
                if (mesEnnemis.ContainsKey(e))
                {
                    mesEnnemis[e]++;
                }
                else
                {
                    mesEnnemis.Add(e, 1);
                }
            }
            foreach (var item in mesEnnemis.OrderByDescending(x => x.Value))
            {
                if (item.Key.NomDeBase != "")
                {
                    rtbGeneral.AppendText($"{item.Value} {item.Key.Nom} ({item.Key.NomDeBase})\n");
                }
                else
                {
                    rtbGeneral.AppendText($"{item.Value} {item.Key.Nom}\n");
                }

            }
            rtbGeneral.AppendText("\n");
        }

        private void cb_Iles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Iles.SelectedValue.GetType() == typeof(Zone))
            {
                var maZone = (Zone)cb_Iles.SelectedValue;
                rtbGeneral.Clear();
                AfficherInfosZone(maZone);
                // On affiche que les panels concernés
                foreach (SuccessKillPanel myPnl in panelGeneral.Controls.OfType<SuccessKillPanel>())
                {
                    myPnl.SetVisible(myPnl.NbRefArea == maZone.Numero);
                }

                var i = 1;
                if (maZone.MesSucces != null)
                {
                    foreach (SuccesKill achiev in maZone.MesSucces)
                    {
                        if (panelGeneral.Controls.Find(Name = $"pnl_{achiev.CreatureAKill.ToString()}", false).Count() == 0)
                        {
                            SuccessKillPanel skp = new SuccessKillPanel(achiev, maZone.Numero);
                            panelGeneral.Controls.Add(skp);
                            skp.Location = new Point(cb_Iles.Location.X, cb_Iles.Location.Y + 25 + 30 * i);

                            i++;
                        }
                    }
                }
            }
        }
    }
}
