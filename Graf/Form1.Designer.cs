namespace Graf
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.UpDown_Adjacency_1 = new System.Windows.Forms.NumericUpDown();
            this.button_Adjacency = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLaoutPanel_VertexName_1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_Incidence = new System.Windows.Forms.Button();
            this.flowLayoutPanel_Incidence = new System.Windows.Forms.FlowLayoutPanel();
            this.UpDown_Incidence_2 = new System.Windows.Forms.NumericUpDown();
            this.UpDown_Incidence_1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.flowLaoutPanel_VertexName_2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Adjacency_1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Incidence_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Incidence_1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 46);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(900, 835);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Podaj liczbę wierzchołków grafu";
            // 
            // UpDown_Adjacency_1
            // 
            this.UpDown_Adjacency_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpDown_Adjacency_1.Location = new System.Drawing.Point(430, 6);
            this.UpDown_Adjacency_1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.UpDown_Adjacency_1.Name = "UpDown_Adjacency_1";
            this.UpDown_Adjacency_1.Size = new System.Drawing.Size(176, 34);
            this.UpDown_Adjacency_1.TabIndex = 2;
            this.UpDown_Adjacency_1.ValueChanged += new System.EventHandler(this.UpDown_Adjacency_1_ValueChanged);
            // 
            // button_Adjacency
            // 
            this.button_Adjacency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Adjacency.Location = new System.Drawing.Point(612, 6);
            this.button_Adjacency.Name = "button_Adjacency";
            this.button_Adjacency.Size = new System.Drawing.Size(300, 35);
            this.button_Adjacency.TabIndex = 4;
            this.button_Adjacency.Text = "Stwórz graf";
            this.button_Adjacency.UseVisualStyleBackColor = true;
            this.button_Adjacency.Click += new System.EventHandler(this.button_Adjacency_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1346, 936);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.flowLaoutPanel_VertexName_1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button_Adjacency);
            this.tabPage1.Controls.Add(this.UpDown_Adjacency_1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1338, 907);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Macierz sąsiedztwa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(1002, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nazwy wierzchołków";
            // 
            // flowLaoutPanel_VertexName_1
            // 
            this.flowLaoutPanel_VertexName_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLaoutPanel_VertexName_1.Location = new System.Drawing.Point(919, 46);
            this.flowLaoutPanel_VertexName_1.Name = "flowLaoutPanel_VertexName_1";
            this.flowLaoutPanel_VertexName_1.Size = new System.Drawing.Size(413, 835);
            this.flowLaoutPanel_VertexName_1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.flowLaoutPanel_VertexName_2);
            this.tabPage2.Controls.Add(this.button_Incidence);
            this.tabPage2.Controls.Add(this.flowLayoutPanel_Incidence);
            this.tabPage2.Controls.Add(this.UpDown_Incidence_2);
            this.tabPage2.Controls.Add(this.UpDown_Incidence_1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1338, 907);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Macierz Incydencji";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_Incidence
            // 
            this.button_Incidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_Incidence.Location = new System.Drawing.Point(558, 7);
            this.button_Incidence.Name = "button_Incidence";
            this.button_Incidence.Size = new System.Drawing.Size(354, 67);
            this.button_Incidence.TabIndex = 5;
            this.button_Incidence.Text = "Stwórz Graf";
            this.button_Incidence.UseVisualStyleBackColor = true;
            this.button_Incidence.Click += new System.EventHandler(this.button_Incidence_Click);
            // 
            // flowLayoutPanel_Incidence
            // 
            this.flowLayoutPanel_Incidence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_Incidence.Location = new System.Drawing.Point(12, 80);
            this.flowLayoutPanel_Incidence.Name = "flowLayoutPanel_Incidence";
            this.flowLayoutPanel_Incidence.Size = new System.Drawing.Size(900, 643);
            this.flowLayoutPanel_Incidence.TabIndex = 4;
            // 
            // UpDown_Incidence_2
            // 
            this.UpDown_Incidence_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpDown_Incidence_2.Location = new System.Drawing.Point(431, 44);
            this.UpDown_Incidence_2.Name = "UpDown_Incidence_2";
            this.UpDown_Incidence_2.Size = new System.Drawing.Size(120, 30);
            this.UpDown_Incidence_2.TabIndex = 3;
            this.UpDown_Incidence_2.ValueChanged += new System.EventHandler(this.UpDown_Incidence_2_ValueChanged);
            // 
            // UpDown_Incidence_1
            // 
            this.UpDown_Incidence_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpDown_Incidence_1.Location = new System.Drawing.Point(431, 7);
            this.UpDown_Incidence_1.Name = "UpDown_Incidence_1";
            this.UpDown_Incidence_1.Size = new System.Drawing.Size(120, 30);
            this.UpDown_Incidence_1.TabIndex = 2;
            this.UpDown_Incidence_1.ValueChanged += new System.EventHandler(this.UpDown_Incidence_1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "Podaj liczbę krawędzi grafu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Podaj liczbę wierzchołków grafu";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1338, 907);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lista Sąsiedztwa";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1338, 907);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Formularz";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // flowLaoutPanel_VertexName_2
            // 
            this.flowLaoutPanel_VertexName_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLaoutPanel_VertexName_2.Location = new System.Drawing.Point(919, 80);
            this.flowLaoutPanel_VertexName_2.Name = "flowLaoutPanel_VertexName_2";
            this.flowLaoutPanel_VertexName_2.Size = new System.Drawing.Size(413, 835);
            this.flowLaoutPanel_VertexName_2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(1000, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(275, 32);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nazwy wierzchołków";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1370, 960);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Adjacency_1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Incidence_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_Incidence_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown UpDown_Adjacency_1;
        private System.Windows.Forms.Button button_Adjacency;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button_Incidence;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Incidence;
        private System.Windows.Forms.NumericUpDown UpDown_Incidence_2;
        private System.Windows.Forms.NumericUpDown UpDown_Incidence_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLaoutPanel_VertexName_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLaoutPanel_VertexName_2;
    }
}

