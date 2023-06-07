namespace EvaluateFunction
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Evalute = new System.Windows.Forms.Button();
            this.Fn = new System.Windows.Forms.TextBox();
            this.Pnl1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Evalute
            // 
            this.Evalute.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Evalute.Location = new System.Drawing.Point(261, 29);
            this.Evalute.Name = "Evalute";
            this.Evalute.Size = new System.Drawing.Size(161, 44);
            this.Evalute.TabIndex = 0;
            this.Evalute.Text = "Evalute";
            this.Evalute.UseVisualStyleBackColor = true;
            this.Evalute.Click += new System.EventHandler(this.Evalute_Click);
            // 
            // Fn
            // 
            this.Fn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Fn.Location = new System.Drawing.Point(12, 29);
            this.Fn.Multiline = true;
            this.Fn.Name = "Fn";
            this.Fn.Size = new System.Drawing.Size(243, 44);
            this.Fn.TabIndex = 1;
            this.Fn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pnl1
            // 
            this.Pnl1.AutoScroll = true;
            this.Pnl1.Location = new System.Drawing.Point(9, 85);
            this.Pnl1.Name = "Pnl1";
            this.Pnl1.Size = new System.Drawing.Size(779, 353);
            this.Pnl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pnl1);
            this.Controls.Add(this.Fn);
            this.Controls.Add(this.Evalute);
            this.Name = "Form1";
            this.Text = "Main Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Evalute;
        private System.Windows.Forms.TextBox Fn;
        private System.Windows.Forms.FlowLayoutPanel Pnl1;
    }
}
