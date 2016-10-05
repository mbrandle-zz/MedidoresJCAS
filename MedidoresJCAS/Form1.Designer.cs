namespace MedidoresJCAS
{
    partial class frmMedidores
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedidores));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.wbMapa = new System.Windows.Forms.WebBrowser();
            this.grupoPeriodo = new System.Windows.Forms.GroupBox();
            this.btnPeriodo = new System.Windows.Forms.Button();
            this.cbPeriodo = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.revisionDeCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbRutas = new System.Windows.Forms.ComboBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.grupoPeriodo.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(252, 658);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // wbMapa
            // 
            this.wbMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMapa.Location = new System.Drawing.Point(252, 24);
            this.wbMapa.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMapa.Name = "wbMapa";
            this.wbMapa.Size = new System.Drawing.Size(1012, 658);
            this.wbMapa.TabIndex = 1;
            // 
            // grupoPeriodo
            // 
            this.grupoPeriodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.grupoPeriodo.Controls.Add(this.lblRuta);
            this.grupoPeriodo.Controls.Add(this.cbRutas);
            this.grupoPeriodo.Controls.Add(this.btnPeriodo);
            this.grupoPeriodo.Controls.Add(this.cbPeriodo);
            this.grupoPeriodo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grupoPeriodo.ForeColor = System.Drawing.Color.White;
            this.grupoPeriodo.Location = new System.Drawing.Point(12, 44);
            this.grupoPeriodo.Name = "grupoPeriodo";
            this.grupoPeriodo.Size = new System.Drawing.Size(219, 131);
            this.grupoPeriodo.TabIndex = 6;
            this.grupoPeriodo.TabStop = false;
            this.grupoPeriodo.Text = "Periodo";
            // 
            // btnPeriodo
            // 
            this.btnPeriodo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeriodo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeriodo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(161)))), ((int)(((byte)(186)))));
            this.btnPeriodo.Location = new System.Drawing.Point(104, 96);
            this.btnPeriodo.Name = "btnPeriodo";
            this.btnPeriodo.Size = new System.Drawing.Size(109, 28);
            this.btnPeriodo.TabIndex = 1;
            this.btnPeriodo.Text = "Seleccionar";
            this.btnPeriodo.UseVisualStyleBackColor = false;
            this.btnPeriodo.Click += new System.EventHandler(this.btnPeriodo_Click);
            // 
            // cbPeriodo
            // 
            this.cbPeriodo.FormattingEnabled = true;
            this.cbPeriodo.Location = new System.Drawing.Point(6, 19);
            this.cbPeriodo.Name = "cbPeriodo";
            this.cbPeriodo.Size = new System.Drawing.Size(206, 24);
            this.cbPeriodo.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revisionDeCuentasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // revisionDeCuentasToolStripMenuItem
            // 
            this.revisionDeCuentasToolStripMenuItem.Name = "revisionDeCuentasToolStripMenuItem";
            this.revisionDeCuentasToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.revisionDeCuentasToolStripMenuItem.Text = "Revisión De Cuentas";
            this.revisionDeCuentasToolStripMenuItem.Click += new System.EventHandler(this.revisionDeCuentasToolStripMenuItem_Click);
            // 
            // cbRutas
            // 
            this.cbRutas.FormattingEnabled = true;
            this.cbRutas.Location = new System.Drawing.Point(6, 66);
            this.cbRutas.Name = "cbRutas";
            this.cbRutas.Size = new System.Drawing.Size(206, 24);
            this.cbRutas.TabIndex = 3;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(6, 48);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(40, 16);
            this.lblRuta.TabIndex = 4;
            this.lblRuta.Text = "Ruta";
            // 
            // frmMedidores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MedidoresJCAS.Properties.Resources.images;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.grupoPeriodo);
            this.Controls.Add(this.wbMapa);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMedidores";
            this.Text = "Interfaz de Tomas de Agua";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grupoPeriodo.ResumeLayout(false);
            this.grupoPeriodo.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.WebBrowser wbMapa;
        private System.Windows.Forms.GroupBox grupoPeriodo;
        private System.Windows.Forms.Button btnPeriodo;
        private System.Windows.Forms.ComboBox cbPeriodo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem revisionDeCuentasToolStripMenuItem;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.ComboBox cbRutas;
    }
}

