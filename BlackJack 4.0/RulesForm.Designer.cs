namespace BlackJack_4._0
{
    partial class RulesForm
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
            this.rchTxtBxRules1 = new System.Windows.Forms.RichTextBox();
            this.rchTxtBxRules2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // rchTxtBxRules1
            // 
            this.rchTxtBxRules1.BackColor = System.Drawing.Color.Black;
            this.rchTxtBxRules1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchTxtBxRules1.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchTxtBxRules1.ForeColor = System.Drawing.Color.White;
            this.rchTxtBxRules1.Location = new System.Drawing.Point(34, 90);
            this.rchTxtBxRules1.Name = "rchTxtBxRules1";
            this.rchTxtBxRules1.Size = new System.Drawing.Size(332, 397);
            this.rchTxtBxRules1.TabIndex = 0;
            this.rchTxtBxRules1.Text = "";
            this.rchTxtBxRules1.UseWaitCursor = true;
            // 
            // rchTxtBxRules2
            // 
            this.rchTxtBxRules2.BackColor = System.Drawing.Color.Black;
            this.rchTxtBxRules2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchTxtBxRules2.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchTxtBxRules2.ForeColor = System.Drawing.Color.White;
            this.rchTxtBxRules2.Location = new System.Drawing.Point(847, 90);
            this.rchTxtBxRules2.Name = "rchTxtBxRules2";
            this.rchTxtBxRules2.Size = new System.Drawing.Size(349, 397);
            this.rchTxtBxRules2.TabIndex = 1;
            this.rchTxtBxRules2.Text = "";
            this.rchTxtBxRules2.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Castellar", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(463, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "BlackJack Rules:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(469, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 3);
            this.panel1.TabIndex = 3;
            // 
            // RulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::BlackJack_4._0.Properties.Resources.rules_1230_600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1208, 549);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rchTxtBxRules2);
            this.Controls.Add(this.rchTxtBxRules1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(1230, 600);
            this.MinimumSize = new System.Drawing.Size(1230, 600);
            this.Name = "RulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "How To Play";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.RulesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchTxtBxRules1;
        private System.Windows.Forms.RichTextBox rchTxtBxRules2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}