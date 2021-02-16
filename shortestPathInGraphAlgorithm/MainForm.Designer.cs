namespace shortestPathInGraphAlgorithm
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
            this.buttonDrawNode = new System.Windows.Forms.Button();
            this.buttonDrawArc = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSource = new System.Windows.Forms.Button();
            this.textBoxCalculation = new System.Windows.Forms.TextBox();
            this.listViewNodes = new System.Windows.Forms.ListView();
            this.columnNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnShortestPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnPreviousNode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEndNode = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDrawNode
            // 
            this.buttonDrawNode.Location = new System.Drawing.Point(12, 29);
            this.buttonDrawNode.Name = "buttonDrawNode";
            this.buttonDrawNode.Size = new System.Drawing.Size(100, 38);
            this.buttonDrawNode.TabIndex = 0;
            this.buttonDrawNode.Text = "Draw Node";
            this.buttonDrawNode.UseVisualStyleBackColor = true;
            this.buttonDrawNode.Click += new System.EventHandler(this.buttonDrawNode_Click);
            // 
            // buttonDrawArc
            // 
            this.buttonDrawArc.Location = new System.Drawing.Point(12, 73);
            this.buttonDrawArc.Name = "buttonDrawArc";
            this.buttonDrawArc.Size = new System.Drawing.Size(100, 33);
            this.buttonDrawArc.TabIndex = 1;
            this.buttonDrawArc.Text = "Draw arc";
            this.buttonDrawArc.UseVisualStyleBackColor = true;
            this.buttonDrawArc.Click += new System.EventHandler(this.buttonDrawArc_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 112);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 33);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSource
            // 
            this.buttonSource.Location = new System.Drawing.Point(1052, 12);
            this.buttonSource.Name = "buttonSource";
            this.buttonSource.Size = new System.Drawing.Size(88, 23);
            this.buttonSource.TabIndex = 4;
            this.buttonSource.Text = "Source";
            this.buttonSource.UseVisualStyleBackColor = true;
            this.buttonSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // textBoxCalculation
            // 
            this.textBoxCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCalculation.ForeColor = System.Drawing.Color.Black;
            this.textBoxCalculation.Location = new System.Drawing.Point(22, 578);
            this.textBoxCalculation.Name = "textBoxCalculation";
            this.textBoxCalculation.Size = new System.Drawing.Size(268, 30);
            this.textBoxCalculation.TabIndex = 5;
            // 
            // listViewNodes
            // 
            this.listViewNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNode,
            this.columnShortestPath,
            this.columnPreviousNode});
            this.listViewNodes.GridLines = true;
            this.listViewNodes.HideSelection = false;
            this.listViewNodes.Location = new System.Drawing.Point(831, 356);
            this.listViewNodes.Name = "listViewNodes";
            this.listViewNodes.Size = new System.Drawing.Size(278, 216);
            this.listViewNodes.TabIndex = 6;
            this.listViewNodes.UseCompatibleStateImageBehavior = false;
            this.listViewNodes.View = System.Windows.Forms.View.Details;
            // 
            // columnNode
            // 
            this.columnNode.Text = "Node";
            this.columnNode.Width = 40;
            // 
            // columnShortestPath
            // 
            this.columnShortestPath.DisplayIndex = 2;
            this.columnShortestPath.Text = "Shortest Path";
            this.columnShortestPath.Width = 97;
            // 
            // columnPreviousNode
            // 
            this.columnPreviousNode.DisplayIndex = 1;
            this.columnPreviousNode.Text = "Previous Node";
            this.columnPreviousNode.Width = 90;
            // 
            // buttonEndNode
            // 
            this.buttonEndNode.Location = new System.Drawing.Point(1052, 53);
            this.buttonEndNode.Name = "buttonEndNode";
            this.buttonEndNode.Size = new System.Drawing.Size(88, 23);
            this.buttonEndNode.TabIndex = 7;
            this.buttonEndNode.Text = "End Node";
            this.buttonEndNode.UseVisualStyleBackColor = true;
            this.buttonEndNode.Click += new System.EventHandler(this.buttonEndNode_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(12, 151);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(100, 31);
            this.buttonRestart.TabIndex = 8;
            this.buttonRestart.Text = "Restrart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 613);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonEndNode);
            this.Controls.Add(this.listViewNodes);
            this.Controls.Add(this.textBoxCalculation);
            this.Controls.Add(this.buttonSource);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonDrawArc);
            this.Controls.Add(this.buttonDrawNode);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDrawNode;
        private System.Windows.Forms.Button buttonDrawArc;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSource;
        private System.Windows.Forms.TextBox textBoxCalculation;
        private System.Windows.Forms.ListView listViewNodes;
        private System.Windows.Forms.ColumnHeader columnNode;
        private System.Windows.Forms.ColumnHeader columnShortestPath;
        private System.Windows.Forms.ColumnHeader columnPreviousNode;
        private System.Windows.Forms.Button buttonEndNode;
        private System.Windows.Forms.Button buttonRestart;
    }
}

