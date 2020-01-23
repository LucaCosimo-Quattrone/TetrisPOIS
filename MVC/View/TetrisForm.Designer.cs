namespace TetrisPOIS
{
    using System;

    partial class TetrisForm

    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.Punteggio = new System.Windows.Forms.Label();
            this.Livello = new System.Windows.Forms.Label();
            this.MenuPrincipale = new System.Windows.Forms.TableLayoutPanel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.NuovaPartita = new System.Windows.Forms.Button();
            this.Esci = new System.Windows.Forms.Button();
            this.Aiuto = new System.Windows.Forms.Button();
            this.ProssimaFigura = new System.Windows.Forms.Label();
            this.Pausa = new System.Windows.Forms.Label();
            this.Riprendi = new System.Windows.Forms.Label();
            this.MenuPrincipale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Punteggio
            // 
            this.Punteggio.AutoSize = true;
            this.Punteggio.BackColor = System.Drawing.Color.DarkBlue;
            this.Punteggio.Font = new System.Drawing.Font("Snap ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Punteggio.ForeColor = System.Drawing.Color.Gold;
            this.Punteggio.Location = new System.Drawing.Point(252, 212);
            this.Punteggio.Name = "Punteggio";
            this.Punteggio.Size = new System.Drawing.Size(107, 17);
            this.Punteggio.TabIndex = 0;
            this.Punteggio.Text = "Punteggio = 0";
            // 
            // Livello
            // 
            this.Livello.AutoSize = true;
            this.Livello.BackColor = System.Drawing.Color.DarkBlue;
            this.Livello.Font = new System.Drawing.Font("Snap ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Livello.ForeColor = System.Drawing.Color.Gold;
            this.Livello.Location = new System.Drawing.Point(251, 175);
            this.Livello.Name = "Livello";
            this.Livello.Size = new System.Drawing.Size(113, 19);
            this.Livello.TabIndex = 1;
            this.Livello.Text = "Livello = 1";
            // 
            // MenuPrincipale
            // 
            this.MenuPrincipale.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.MenuPrincipale.BackColor = System.Drawing.Color.DarkBlue;
            this.MenuPrincipale.ColumnCount = 3;
            this.MenuPrincipale.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.3913F));
            this.MenuPrincipale.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.2174F));
            this.MenuPrincipale.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.3913F));
            this.MenuPrincipale.Controls.Add(this.Logo, 1, 0);
            this.MenuPrincipale.Controls.Add(this.NuovaPartita, 1, 1);
            this.MenuPrincipale.Controls.Add(this.Esci, 1, 3);
            this.MenuPrincipale.Controls.Add(this.Aiuto, 1, 2);
            this.MenuPrincipale.Location = new System.Drawing.Point(-4, 0);
            this.MenuPrincipale.Name = "MenuPrincipale";
            this.MenuPrincipale.RowCount = 5;
            this.MenuPrincipale.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.MenuPrincipale.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuPrincipale.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuPrincipale.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuPrincipale.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.MenuPrincipale.Size = new System.Drawing.Size(379, 408);
            this.MenuPrincipale.TabIndex = 2;
            // 
            // Logo
            // 
            this.Logo.Image = global::TetrisPOIS.Properties.Resources.Logo;
            this.Logo.Location = new System.Drawing.Point(68, 3);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(241, 211);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // NuovaPartita
            // 
            this.NuovaPartita.BackColor = System.Drawing.Color.Black;
            this.NuovaPartita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.NuovaPartita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NuovaPartita.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NuovaPartita.ForeColor = System.Drawing.Color.Gold;
            this.NuovaPartita.Location = new System.Drawing.Point(68, 247);
            this.NuovaPartita.Name = "NuovaPartita";
            this.NuovaPartita.Size = new System.Drawing.Size(241, 34);
            this.NuovaPartita.TabIndex = 1;
            this.NuovaPartita.Text = "Nuova Partita";
            this.NuovaPartita.UseVisualStyleBackColor = false;
            // 
            // Esci
            // 
            this.Esci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Esci.BackColor = System.Drawing.Color.Black;
            this.Esci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Esci.Font = new System.Drawing.Font("Snap ITC", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Esci.ForeColor = System.Drawing.Color.Gold;
            this.Esci.Location = new System.Drawing.Point(68, 327);
            this.Esci.Name = "Esci";
            this.Esci.Size = new System.Drawing.Size(241, 34);
            this.Esci.TabIndex = 3;
            this.Esci.Text = "Esci";
            this.Esci.UseVisualStyleBackColor = false;
            // 
            // Aiuto
            // 
            this.Aiuto.BackColor = System.Drawing.Color.Black;
            this.Aiuto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Aiuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aiuto.Font = new System.Drawing.Font("Snap ITC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aiuto.ForeColor = System.Drawing.Color.Gold;
            this.Aiuto.Location = new System.Drawing.Point(68, 287);
            this.Aiuto.Name = "Aiuto";
            this.Aiuto.Size = new System.Drawing.Size(241, 34);
            this.Aiuto.TabIndex = 4;
            this.Aiuto.Text = "Comandi";
            this.Aiuto.UseVisualStyleBackColor = false;
            // 
            // ProssimaFigura
            // 
            this.ProssimaFigura.AutoSize = true;
            this.ProssimaFigura.BackColor = System.Drawing.Color.DarkBlue;
            this.ProssimaFigura.Font = new System.Drawing.Font("Snap ITC", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProssimaFigura.ForeColor = System.Drawing.Color.Gold;
            this.ProssimaFigura.Location = new System.Drawing.Point(252, 19);
            this.ProssimaFigura.Name = "ProssimaFigura";
            this.ProssimaFigura.Size = new System.Drawing.Size(123, 15);
            this.ProssimaFigura.TabIndex = 3;
            this.ProssimaFigura.Text = "Prossima figura";
            // 
            // Pausa
            // 
            this.Pausa.AutoSize = true;
            this.Pausa.BackColor = System.Drawing.Color.DarkBlue;
            this.Pausa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pausa.Font = new System.Drawing.Font("Snap ITC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pausa.ForeColor = System.Drawing.Color.Gold;
            this.Pausa.Location = new System.Drawing.Point(285, 248);
            this.Pausa.Name = "Pausa";
            this.Pausa.Size = new System.Drawing.Size(79, 27);
            this.Pausa.TabIndex = 7;
            this.Pausa.Text = "Pausa";
            // 
            // Riprendi
            // 
            this.Riprendi.AutoSize = true;
            this.Riprendi.BackColor = System.Drawing.Color.DarkBlue;
            this.Riprendi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Riprendi.Font = new System.Drawing.Font("Snap ITC", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Riprendi.ForeColor = System.Drawing.Color.Gold;
            this.Riprendi.Location = new System.Drawing.Point(268, 287);
            this.Riprendi.Name = "Riprendi";
            this.Riprendi.Size = new System.Drawing.Size(96, 25);
            this.Riprendi.TabIndex = 8;
            this.Riprendi.Text = "Riprendi";
            this.Riprendi.Visible = false;
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(376, 401);
            this.Controls.Add(this.MenuPrincipale);
            this.Controls.Add(this.Livello);
            this.Controls.Add(this.Punteggio);
            this.Controls.Add(this.ProssimaFigura);
            this.Controls.Add(this.Pausa);
            this.Controls.Add(this.Riprendi);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(392, 440);
            this.MinimumSize = new System.Drawing.Size(392, 440);
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.MenuPrincipale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label Punteggio;
        public System.Windows.Forms.Label Livello;
        public System.Windows.Forms.TableLayoutPanel MenuPrincipale;
        private System.Windows.Forms.PictureBox Logo;
        public System.Windows.Forms.Button NuovaPartita;
        public System.Windows.Forms.Button Esci;
        public System.Windows.Forms.Label ProssimaFigura;
        public System.Windows.Forms.Button Aiuto;
        public System.Windows.Forms.Label Pausa;
        public System.Windows.Forms.Label Riprendi;
    }
}

