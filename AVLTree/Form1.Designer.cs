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
            this.SuspendLayout();
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(236, 9);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNode.TabIndex = 0;
            this.buttonAddNode.Text = "Add Node";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.Location = new System.Drawing.Point(236, 38);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteNode.TabIndex = 1;
            this.buttonDeleteNode.Text = "Delete Node";
            this.buttonDeleteNode.UseVisualStyleBackColor = true;
            this.buttonDeleteNode.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAddNode
            // 
            this.textBoxAddNode.Location = new System.Drawing.Point(109, 12);
            this.textBoxAddNode.Name = "textBoxAddNode";
            this.textBoxAddNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddNode.TabIndex = 2;
            // 
            // textBoxDeleteNode
            // 
            this.textBoxDeleteNode.Location = new System.Drawing.Point(109, 38);
            this.textBoxDeleteNode.Name = "textBoxDeleteNode";
            this.textBoxDeleteNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteNode.TabIndex = 3;
            // 
            // panelDrawTree1
            // 
            this.panelDrawTree1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDrawTree1.Location = new System.Drawing.Point(20, 95);
            this.panelDrawTree1.Name = "panelDrawTree1";
            this.panelDrawTree1.Size = new System.Drawing.Size(652, 534);
            this.panelDrawTree1.TabIndex = 4;
            this.panelDrawTree1.UseWaitCursor = true;
            this.panelDrawTree1.SizeChanged += new System.EventHandler(this.panelDrawTree_SizeChanged);
            this.panelDrawTree1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawTree_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 641);
            this.Controls.Add(this.panelDrawTree1);
            this.Controls.Add(this.textBoxDeleteNode);
            this.Controls.Add(this.textBoxAddNode);
            this.Controls.Add(this.buttonDeleteNode);
            this.Controls.Add(this.buttonAddNode);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNode;
        private System.Windows.Forms.Button buttonDeleteNode;
        private System.Windows.Forms.TextBox textBoxAddNode;
        private System.Windows.Forms.TextBox textBoxDeleteNode;
        public System.Windows.Forms.Panel panelDrawTree1;
    }
}

