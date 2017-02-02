namespace Array
{
    partial class Form1
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
            this.btnArray1 = new System.Windows.Forms.Button();
            this.btnCarta = new System.Windows.Forms.Button();
            this.btnArray2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnArray1
            // 
            this.btnArray1.Location = new System.Drawing.Point(21, 25);
            this.btnArray1.Name = "btnArray1";
            this.btnArray1.Size = new System.Drawing.Size(75, 23);
            this.btnArray1.TabIndex = 0;
            this.btnArray1.Text = "Array 1";
            this.btnArray1.UseVisualStyleBackColor = true;
            this.btnArray1.Click += new System.EventHandler(this.btnArray1_Click);
            // 
            // btnCarta
            // 
            this.btnCarta.Location = new System.Drawing.Point(119, 24);
            this.btnCarta.Name = "btnCarta";
            this.btnCarta.Size = new System.Drawing.Size(75, 23);
            this.btnCarta.TabIndex = 1;
            this.btnCarta.Text = "Carta";
            this.btnCarta.UseVisualStyleBackColor = true;
            this.btnCarta.Click += new System.EventHandler(this.btnCarta_Click);
            // 
            // btnArray2
            // 
            this.btnArray2.Location = new System.Drawing.Point(21, 75);
            this.btnArray2.Name = "btnArray2";
            this.btnArray2.Size = new System.Drawing.Size(75, 23);
            this.btnArray2.TabIndex = 2;
            this.btnArray2.Text = "Array 2";
            this.btnArray2.UseVisualStyleBackColor = true;
            this.btnArray2.Click += new System.EventHandler(this.btnArray2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(140, 169);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(75, 95);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 261);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnArray2);
            this.Controls.Add(this.btnCarta);
            this.Controls.Add(this.btnArray1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnArray1;
        private System.Windows.Forms.Button btnCarta;
        private System.Windows.Forms.Button btnArray2;
        private System.Windows.Forms.ListBox listBox1;
    }
}

