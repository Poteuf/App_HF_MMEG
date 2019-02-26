using AppMMEG.DLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppMMEG.Winform
{
    public class SuccessKillPanel : Panel
    {
        public SuccesKill Achiev { get; }
        public int NbRefArea { get; }

        public uint NbRestToKill { get { return Achiev.Nombre - Convert.ToUInt32(NumericUPKills.Value); } }

        private Label LabelTitle { get; set; }
        private Label LabelMaxKills { get; set; }
        private NumericUpDown NumericUPKills { get; set; }

        private const int C_SIZE_LABEL_TITLE = 150;

        public SuccessKillPanel(SuccesKill achievement, int nbRefArea) : base()
        {
            Achiev = achievement;
            NbRefArea = nbRefArea;

            Name = $"pnl_{Achiev.CreatureAKill.ToString()}";
            Width = 500;
            Height = 30;

            // On gère le label titre
            LabelTitle = new Label
            {
                Name = $"lblTitre_{Achiev.CreatureAKill.ToString()}",
                Text = $"{Achiev.Titre}",
                Width = C_SIZE_LABEL_TITLE,
                Location = new Point(0, 4),
                RightToLeft = RightToLeft.Yes
            };
            Controls.Add(LabelTitle);

            // On gère la NumericUpDown
            NumericUPKills = new NumericUpDown
            {
                Name = $"tb_{Achiev.CreatureAKill.ToString()}",
                Location = new Point(C_SIZE_LABEL_TITLE + 5, 0),
                RightToLeft = RightToLeft.Yes,
                Value = 0,
                Minimum = 0,
                Maximum = Achiev.Nombre,
                DecimalPlaces = 0,
                ThousandsSeparator = true
            };
            NumericUPKills.Controls.RemoveAt(0);
            Controls.Add(NumericUPKills);

            // On gère le label des kills à faire
            LabelMaxKills = new Label
            {
                Name = $"lblMax_{Achiev.CreatureAKill.ToString()}",
                Text = $"/ {Achiev.Nombre.ToString()}",
                Location = new Point(C_SIZE_LABEL_TITLE + NumericUPKills.Width + 10, 4)
            };
            LabelMaxKills.Click += new EventHandler(nud_ControlClick);
            Controls.Add(LabelMaxKills);
        }

        public void SetVisible(Boolean isVisible)
        {
            Visible = isVisible;
        }

        public Boolean IsVisible()
        {
            return LabelTitle.Visible && LabelMaxKills.Visible && NumericUPKills.Visible;
        }

        private void nud_ControlClick(object sender, EventArgs e)
        {
            NumericUPKills.Value = Achiev.Nombre;
        }        
    }
}


