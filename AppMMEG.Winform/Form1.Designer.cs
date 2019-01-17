namespace AppMMEG.Winform
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbGeneral = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cb_Iles = new System.Windows.Forms.ComboBox();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.btn_traitement = new System.Windows.Forms.Button();
            this.panelGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbGeneral
            // 
            this.rtbGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtbGeneral.Location = new System.Drawing.Point(0, 0);
            this.rtbGeneral.Name = "rtbGeneral";
            this.rtbGeneral.Size = new System.Drawing.Size(283, 450);
            this.rtbGeneral.TabIndex = 0;
            this.rtbGeneral.Text = "";
            // 
            // cb_Iles
            // 
            this.cb_Iles.FormattingEnabled = true;
            this.cb_Iles.Location = new System.Drawing.Point(289, 12);
            this.cb_Iles.Name = "cb_Iles";
            this.cb_Iles.Size = new System.Drawing.Size(334, 21);
            this.cb_Iles.TabIndex = 1;
            this.cb_Iles.SelectedValueChanged += new System.EventHandler(this.cb_Iles_SelectedValueChanged);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.Add(this.btn_traitement);
            this.panelGeneral.Controls.Add(this.rtbGeneral);
            this.panelGeneral.Controls.Add(this.cb_Iles);
            this.panelGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGeneral.Location = new System.Drawing.Point(0, 0);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(1203, 450);
            this.panelGeneral.TabIndex = 2;
            // 
            // btn_traitement
            // 
            this.btn_traitement.Location = new System.Drawing.Point(289, 356);
            this.btn_traitement.Name = "btn_traitement";
            this.btn_traitement.Size = new System.Drawing.Size(334, 82);
            this.btn_traitement.TabIndex = 2;
            this.btn_traitement.Text = "Launch Treatment";
            this.btn_traitement.UseVisualStyleBackColor = true;
            this.btn_traitement.Click += new System.EventHandler(this.btn_traitement_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 450);
            this.Controls.Add(this.panelGeneral);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelGeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbGeneral;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cb_Iles;
        private System.Windows.Forms.Panel panelGeneral;
        private System.Windows.Forms.Button btn_traitement;
    }
}

