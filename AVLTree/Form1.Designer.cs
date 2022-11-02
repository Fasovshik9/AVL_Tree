namespace AVLTree
{
    partial class MainForm
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
            this.buttonAddNode = new System.Windows.Forms.Button();
            this.buttonDeleteNode = new System.Windows.Forms.Button();
            this.textBoxAddNode = new System.Windows.Forms.TextBox();
            this.textBoxDeleteNode = new System.Windows.Forms.TextBox();
            this.panelDrawTree1 = new System.Windows.Forms.Panel();
            this.buttonTestCase = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonSpeed3 = new System.Windows.Forms.RadioButton();
            this.radioButtonSpeed2 = new System.Windows.Forms.RadioButton();
            this.radioButtonSpeed1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(423, 23);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(119, 23);
            this.buttonAddNode.TabIndex = 0;
            this.buttonAddNode.Text = "Вставить элемент";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.Location = new System.Drawing.Point(423, 50);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(119, 23);
            this.buttonDeleteNode.TabIndex = 1;
            this.buttonDeleteNode.Text = "Удалить элемент";
            this.buttonDeleteNode.UseVisualStyleBackColor = true;
            this.buttonDeleteNode.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAddNode
            // 
            this.textBoxAddNode.Location = new System.Drawing.Point(317, 26);
            this.textBoxAddNode.Name = "textBoxAddNode";
            this.textBoxAddNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddNode.TabIndex = 2;
            // 
            // textBoxDeleteNode
            // 
            this.textBoxDeleteNode.Location = new System.Drawing.Point(317, 52);
            this.textBoxDeleteNode.Name = "textBoxDeleteNode";
            this.textBoxDeleteNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteNode.TabIndex = 3;
            // 
            // panelDrawTree1
            // 
            this.panelDrawTree1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDrawTree1.Location = new System.Drawing.Point(12, 133);
            this.panelDrawTree1.Name = "panelDrawTree1";
            this.panelDrawTree1.Size = new System.Drawing.Size(1184, 568);
            this.panelDrawTree1.TabIndex = 4;
            this.panelDrawTree1.UseWaitCursor = true;
            this.panelDrawTree1.Visible = false;
            this.panelDrawTree1.SizeChanged += new System.EventHandler(this.panelDrawTree_SizeChanged);
            this.panelDrawTree1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawTree_Paint);
            // 
            // buttonTestCase
            // 
            this.buttonTestCase.Location = new System.Drawing.Point(569, 23);
            this.buttonTestCase.Name = "buttonTestCase";
            this.buttonTestCase.Size = new System.Drawing.Size(128, 23);
            this.buttonTestCase.TabIndex = 5;
            this.buttonTestCase.Text = "Вставить из файла";
            this.buttonTestCase.UseVisualStyleBackColor = true;
            this.buttonTestCase.Click += new System.EventHandler(this.buttonTestCase_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButtonSpeed3);
            this.panel1.Controls.Add(this.radioButtonSpeed2);
            this.panel1.Controls.Add(this.radioButtonSpeed1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonAddNode);
            this.panel1.Controls.Add(this.buttonTestCase);
            this.panel1.Controls.Add(this.buttonDeleteNode);
            this.panel1.Controls.Add(this.textBoxAddNode);
            this.panel1.Controls.Add(this.textBoxDeleteNode);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1181, 100);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(723, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Скорость отображения дерева";
            // 
            // radioButtonSpeed3
            // 
            this.radioButtonSpeed3.AutoSize = true;
            this.radioButtonSpeed3.Location = new System.Drawing.Point(758, 63);
            this.radioButtonSpeed3.Name = "radioButtonSpeed3";
            this.radioButtonSpeed3.Size = new System.Drawing.Size(76, 17);
            this.radioButtonSpeed3.TabIndex = 9;
            this.radioButtonSpeed3.Text = "Медленно";
            this.radioButtonSpeed3.UseVisualStyleBackColor = true;
            this.radioButtonSpeed3.CheckedChanged += new System.EventHandler(this.radioButtonSpeed3_CheckedChanged);
            // 
            // radioButtonSpeed2
            // 
            this.radioButtonSpeed2.AutoSize = true;
            this.radioButtonSpeed2.Checked = true;
            this.radioButtonSpeed2.Location = new System.Drawing.Point(758, 40);
            this.radioButtonSpeed2.Name = "radioButtonSpeed2";
            this.radioButtonSpeed2.Size = new System.Drawing.Size(83, 17);
            this.radioButtonSpeed2.TabIndex = 8;
            this.radioButtonSpeed2.TabStop = true;
            this.radioButtonSpeed2.Text = "Нормально";
            this.radioButtonSpeed2.UseVisualStyleBackColor = true;
            this.radioButtonSpeed2.CheckedChanged += new System.EventHandler(this.radioButtonSpeed2_CheckedChanged);
            // 
            // radioButtonSpeed1
            // 
            this.radioButtonSpeed1.AutoSize = true;
            this.radioButtonSpeed1.Location = new System.Drawing.Point(758, 18);
            this.radioButtonSpeed1.Name = "radioButtonSpeed1";
            this.radioButtonSpeed1.Size = new System.Drawing.Size(63, 17);
            this.radioButtonSpeed1.TabIndex = 7;
            this.radioButtonSpeed1.Text = "Быстро";
            this.radioButtonSpeed1.UseVisualStyleBackColor = true;
            this.radioButtonSpeed1.CheckedChanged += new System.EventHandler(this.radioButtonSpeed1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Отобразить повторно";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 713);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDrawTree1);
            this.MaximumSize = new System.Drawing.Size(1224, 752);
            this.MinimumSize = new System.Drawing.Size(1224, 752);
            this.Name = "MainForm";
            this.Text = "AVLTree";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNode;
        private System.Windows.Forms.Button buttonDeleteNode;
        private System.Windows.Forms.TextBox textBoxAddNode;
        private System.Windows.Forms.TextBox textBoxDeleteNode;
        public System.Windows.Forms.Panel panelDrawTree1;
        private System.Windows.Forms.Button buttonTestCase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonSpeed3;
        private System.Windows.Forms.RadioButton radioButtonSpeed2;
        private System.Windows.Forms.RadioButton radioButtonSpeed1;
        private System.Windows.Forms.Label label1;
    }
}

