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
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxAddNode = new System.Windows.Forms.TextBox();
            this.textBoxDeleteNode = new System.Windows.Forms.TextBox();
            this.panelDrawTree = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // buttonAddNode
            // 
            this.buttonAddNode.Location = new System.Drawing.Point(326, 12);
            this.buttonAddNode.Name = "buttonAddNode";
            this.buttonAddNode.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNode.TabIndex = 0;
            this.buttonAddNode.Text = "Add Node";
            this.buttonAddNode.UseVisualStyleBackColor = true;
            this.buttonAddNode.Click += new System.EventHandler(this.buttonAddNode_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(326, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Delete Node";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAddNode
            // 
            this.textBoxAddNode.Location = new System.Drawing.Point(199, 15);
            this.textBoxAddNode.Name = "textBoxAddNode";
            this.textBoxAddNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxAddNode.TabIndex = 2;
            // 
            // textBoxDeleteNode
            // 
            this.textBoxDeleteNode.Location = new System.Drawing.Point(199, 41);
            this.textBoxDeleteNode.Name = "textBoxDeleteNode";
            this.textBoxDeleteNode.Size = new System.Drawing.Size(100, 20);
            this.textBoxDeleteNode.TabIndex = 3;
            // 
            // panelDrawTree
            // 
            this.panelDrawTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDrawTree.Location = new System.Drawing.Point(12, 85);
            this.panelDrawTree.Name = "panelDrawTree";
            this.panelDrawTree.Size = new System.Drawing.Size(614, 445);
            this.panelDrawTree.TabIndex = 4;
            this.panelDrawTree.UseWaitCursor = true;
            this.panelDrawTree.SizeChanged += new System.EventHandler(this.panelDrawTree_SizeChanged);
            this.panelDrawTree.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawTree_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 542);
            this.Controls.Add(this.panelDrawTree);
            this.Controls.Add(this.textBoxDeleteNode);
            this.Controls.Add(this.textBoxAddNode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAddNode);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxAddNode;
        private System.Windows.Forms.TextBox textBoxDeleteNode;
        private System.Windows.Forms.Panel panelDrawTree;
    }
}

