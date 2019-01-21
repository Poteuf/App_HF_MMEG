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
        private Monde MonMonde { get; set; }
        private PlanTraitement MonPlan { get; set; }

        public Form1()
        {
            InitializeComponent();

            rtbGeneral.ForeColor = Color.DarkRed;
            rtbGeneral.AppendText("Salut, bienvenue sur l'optimiseur de HF pour MMEG\n\n\n");

            var truc = new import();
            var bidule = truc.construireListElement();

            GenererMonde();



            // Initialisation affichage

            cb_Iles.DataSource = MonMonde.MesZones.ToList();
            cb_Iles.DisplayMember = "NomFormate";

            //AfficherInfosMonde();
        }

        private void GenererMonde()
        {
            MonMonde = InitialisationV2.InitialiserMondeIlesMorcelees();
        }

        private void AfficherInfosMonde()
        {
            foreach (Zone z in MonMonde.MesZones)
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
        private void GenererPlanTraitement()
        {
            var mySelectedArea = (Zone)cb_Iles.SelectedValue;
            var enemiesToKill = new Dictionary<E_NomEnnemiSucces, uint>();

            foreach (SuccessKillPanel myPnl in panelGeneral.Controls.OfType<SuccessKillPanel>().Where(f => f.IsVisible()))
            {
                enemiesToKill.Add(myPnl.Achiev.CreatureAKill, myPnl.NbRestToKill);
            }

            MonPlan = new PlanTraitement()
            {
                Algorithme = E_TypeTraitement.AlgoMaxTargetNumberPerEnemi,
                RunsPossibles = mySelectedArea.MesEtages,
                EnnemisAElliminer = enemiesToKill
            };
        }

        private void cb_Iles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Iles.SelectedValue.GetType() == typeof(Zone))
            {
                var mySelectedArea = (Zone)cb_Iles.SelectedValue;
                rtbGeneral.Clear();
                AfficherInfosZone(mySelectedArea);
                // On affiche que les panels concernés
                foreach (SuccessKillPanel myPnl in panelGeneral.Controls.OfType<SuccessKillPanel>())
                {
                    myPnl.SetVisible(myPnl.NbRefArea == mySelectedArea.Numero);
                }

                var i = 1;
                if (mySelectedArea.MesSucces != null)
                {
                    foreach (SuccesKill achiev in mySelectedArea.MesSucces)
                    {
                        if (panelGeneral.Controls.Find(Name = $"pnl_{achiev.CreatureAKill.ToString()}", false).Count() == 0)
                        {
                            SuccessKillPanel skp = new SuccessKillPanel(achiev, mySelectedArea.Numero);
                            panelGeneral.Controls.Add(skp);
                            skp.Location = new Point(cb_Iles.Location.X, cb_Iles.Location.Y + 25 + 30 * i);

                            i++;
                        }
                    }
                }
            }
        }
        private void btn_traitement_Click(object sender, EventArgs e)
        {
            GenererPlanTraitement();

            AlgorithmeHandler algo = new AlgorithmeHandler(MonPlan);
            var result = algo.EffectuerTraitement();

            rtbGeneral.Clear();

            if (result == null)
            {
                rtbGeneral.AppendText($"Aucun ennemi à abattre");
            }
            else
            {
                rtbGeneral.AppendText("Traitement terminé\n");
                rtbGeneral.AppendText($"{result.Count()} simulations effectuées\n");
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
        }        
    }
}
