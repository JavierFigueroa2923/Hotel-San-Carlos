﻿namespace produccion
{
    partial class frm_recetario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_recetario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_recetario)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_recetario
            // 
            this.dgv_recetario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_recetario.Location = new System.Drawing.Point(126, 93);
            this.dgv_recetario.Name = "dgv_recetario";
            this.dgv_recetario.Size = new System.Drawing.Size(143, 263);
            this.dgv_recetario.TabIndex = 0;
            this.dgv_recetario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_recetario_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recetario Hotel San Carlos";
            // 
            // frm_recetario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(429, 417);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_recetario);
            this.Name = "frm_recetario";
            this.Text = "recetario";
            this.Load += new System.EventHandler(this.frm_recetario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_recetario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_recetario;
        private System.Windows.Forms.Label label1;
    }
}