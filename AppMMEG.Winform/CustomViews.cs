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

        private Label LabelTitle { get; set; }
        private Label LabelMaxKills { get; set; }
        private TextBox TextBoxActualKills { get; set; }


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

            // On gère la textBox
            TextBoxActualKills = new TextBox
            {
                Name = $"tb_{Achiev.CreatureAKill.ToString()}",
                Location = new Point(C_SIZE_LABEL_TITLE + 5, 0),
                RightToLeft = RightToLeft.Yes
            };
            TextBoxActualKills.TextChanged += new EventHandler(tb_ControlValue);
            TextBoxActualKills.KeyPress += new KeyPressEventHandler(tb_ControlKeyPress);
            Controls.Add(TextBoxActualKills);

            // On gère le label des kills à faire
            LabelMaxKills = new Label
            {
                Name = $"lblMax_{Achiev.CreatureAKill.ToString()}",
                Text = $"/ {Achiev.Nombre.ToString()}",
                Location = new Point(C_SIZE_LABEL_TITLE + TextBoxActualKills.Width + 10, 4)
            };
            Controls.Add(LabelMaxKills);

        }

        public void SetVisible(Boolean isVisible)
        {
            LabelTitle.Visible = isVisible;
            LabelMaxKills.Visible = isVisible;
            TextBoxActualKills.Visible = isVisible;
        }

        private void tb_ControlKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9]*$"))
            {
                e.Handled = true;
            }
        }
        private void tb_ControlValue(object sender, EventArgs e)
        {
            var myTb = (TextBox)sender;

            if (myTb.Text != "" && int.Parse(myTb.Text) > Achiev.Nombre)
            {
                myTb.Text = "";
            }
        }
    }
}


