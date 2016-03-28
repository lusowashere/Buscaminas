namespace Buscaminas
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPartidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.medioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dificilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalizadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Tiempo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(22, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 402);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPartidaToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // nuevaPartidaToolStripMenuItem
            // 
            this.nuevaPartidaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.medioToolStripMenuItem,
            this.dificilToolStripMenuItem,
            this.personalizadoToolStripMenuItem});
            this.nuevaPartidaToolStripMenuItem.Name = "nuevaPartidaToolStripMenuItem";
            this.nuevaPartidaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nuevaPartidaToolStripMenuItem.Text = "Nueva Partida";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
            this.toolStripMenuItem2.Text = "Facil";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // medioToolStripMenuItem
            // 
            this.medioToolStripMenuItem.Name = "medioToolStripMenuItem";
            this.medioToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.medioToolStripMenuItem.Text = "Medio";
            this.medioToolStripMenuItem.Click += new System.EventHandler(this.medioToolStripMenuItem_Click);
            // 
            // dificilToolStripMenuItem
            // 
            this.dificilToolStripMenuItem.Name = "dificilToolStripMenuItem";
            this.dificilToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.dificilToolStripMenuItem.Text = "Dificil";
            this.dificilToolStripMenuItem.Click += new System.EventHandler(this.dificilToolStripMenuItem_Click);
            // 
            // personalizadoToolStripMenuItem
            // 
            this.personalizadoToolStripMenuItem.Name = "personalizadoToolStripMenuItem";
            this.personalizadoToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.personalizadoToolStripMenuItem.Text = "Personalizado";
            this.personalizadoToolStripMenuItem.Click += new System.EventHandler(this.personalizadoToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Tiempo
            // 
            this.Tiempo.AutoSize = true;
            this.Tiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tiempo.Location = new System.Drawing.Point(431, 43);
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.Size = new System.Drawing.Size(13, 18);
            this.Tiempo.TabIndex = 2;
            this.Tiempo.Text = " ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(536, 475);
            this.Controls.Add(this.Tiempo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Buscaminas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaPartidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dificilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalizadoToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Tiempo;
    }
}

