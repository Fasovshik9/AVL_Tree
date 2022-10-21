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
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(133, 21);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNode.TabIndex = 0;
            this.buttonAddNode.Text = "Add Node";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.Location = new System.Drawing.Point(133, 50);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteNode.TabIndex = 1;
            this.buttonDeleteNode.Text = "Delete Node";
            this.buttonDeleteNode.UseVisualStyleBackColor = true;
            this.buttonDeleteNode.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAddNode
            // 
            this.textBoxAddNode.Location = new System.Drawing.Point(6, 24);
            this.textBoxAddNode.Name = "textBoxAddNode";
            this.textBoxAddNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddNode.TabIndex = 2;
            // 
            // textBoxDeleteNode
            // 
            this.textBoxDeleteNode.Location = new System.Drawing.Point(6, 50);
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
            this.panelDrawTree1.Size = new System.Drawing.Size(1184, 485);
            this.panelDrawTree1.TabIndex = 4;
            this.panelDrawTree1.UseWaitCursor = true;
            this.panelDrawTree1.SizeChanged += new System.EventHandler(this.panelDrawTree_SizeChanged);
            this.panelDrawTree1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawTree_Paint);
            // 
            // buttonTestCase
            // 
            this.buttonTestCase.Location = new System.Drawing.Point(258, 22);
            this.buttonTestCase.Name = "buttonTestCase";
            this.buttonTestCase.Size = new System.Drawing.Size(85, 23);
            this.buttonTestCase.TabIndex = 5;
            this.buttonTestCase.Text = "Test Case";
            this.buttonTestCase.UseVisualStyleBackColor = true;
            this.buttonTestCase.Click += new System.EventHandler(this.buttonTestCase_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonAddNode);
            this.panel1.Controls.Add(this.buttonTestCase);
            this.panel1.Controls.Add(this.buttonDeleteNode);
            this.panel1.Controls.Add(this.textBoxAddNode);
            this.panel1.Controls.Add(this.textBoxDeleteNode);
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 100);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "buttonRepeat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1208, 662);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDrawTree1);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}

