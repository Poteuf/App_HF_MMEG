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

            rtbGeneral.BackColor = Color.Black;
            rtbGeneral.ForeColor = Color.WhiteSmoke;
            rtbGeneral.AppendText("Salut, bienvenue sur l'optimiseur de HF pour MMEG\n\n\n");

            GenererMonde();

            // Initialisation affichage
            cb_Iles.DataSource = MonMonde.MesZones.ToList();
            cb_Iles.DisplayMember = "NomFormate";
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
                            skp.Font = new Font(rtbGeneral.Font, FontStyle.Regular);
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
            btn_traitement.Text = "Processing...";
            btn_traitement.Enabled = false;
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
                rtbGeneral.AppendText($"-{result.Count()} simulations effectuées\n\n");
                int j = 1;

                rtbGeneral.AppendText($"----- Scenarii nécessitants le moins de runs -----\n\n");
                foreach (var scenar in result.Where(u => u.NbDeRunTotal == result.Min(f => f.NbDeRunTotal)).Distinct().OrderBy(g => g.CoutTotalScenario))
                {
                    rtbGeneral.AppendText($"=> Scenario ({j}) - {scenar.NbDeRunTotal} Runs - {scenar.CoutTotalScenario} Energie :\n");

                    foreach (var item in scenar.EtagesEffectues.Where(f => f.Value != 0).OrderByDescending(k => k.Value))
                    {
                        Color mycolor = new Color();
                        switch (item.Key.Difficulte)
                        {
                            case E_ModeDifficulte.Normal:
                                mycolor = Color.Turquoise;
                                break;
                            case E_ModeDifficulte.Avance:
                                mycolor = Color.Yellow;
                                break;
                            case E_ModeDifficulte.Cauchemard:
                                mycolor = Color.MediumPurple;
                                break;
                            default:
                                break;
                        }

                        AppendText(rtbGeneral, mycolor, $" - {item.Value} runs sur l'étage {item.Key.Numero} en {item.Key.Difficulte.ToString()} ({item.Key.NomZone})\n");
                    }
                    j++;
                    rtbGeneral.AppendText("\n");
                }

                rtbGeneral.AppendText($"----- Scenarii nécessitants le moins d'énergie -----\n\n");
                foreach (var scenar in result.Where(u => u.CoutTotalScenario == result.Min(f => f.CoutTotalScenario)).Distinct().OrderBy(g => g.NbDeRunTotal))
                {
                    rtbGeneral.AppendText($"=> Scenario ({j}) - {scenar.NbDeRunTotal} Runs - {scenar.CoutTotalScenario} Energie :\n");

                    foreach (var item in scenar.EtagesEffectues.Where(f => f.Value != 0).OrderByDescending(k => k.Value))
                    {
                        Color mycolor = new Color();
                        switch (item.Key.Difficulte)
                        {
                            case E_ModeDifficulte.Normal:
                                mycolor = Color.Turquoise;
                                break;
                            case E_ModeDifficulte.Avance:
                                mycolor = Color.Yellow;
                                break;
                            case E_ModeDifficulte.Cauchemard:
                                mycolor = Color.MediumPurple;
                                break;
                            default:
                                break;
                        }

                        AppendText(rtbGeneral, mycolor, $" - {item.Value} runs sur l'étage {item.Key.Numero} en {item.Key.Difficulte.ToString()} ({item.Key.NomZone})\n");
                    }
                    j++;
                    rtbGeneral.AppendText("\n");
                }
            }

            btn_traitement.Enabled = true;
            btn_traitement.Text = "Launch Treatment";
        }

        void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
