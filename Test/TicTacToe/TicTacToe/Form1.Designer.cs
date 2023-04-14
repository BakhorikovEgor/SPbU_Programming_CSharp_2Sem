namespace TicTacToe
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
            GamePanel = new TableLayoutPanel();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            FirstButton = new Button();
            GamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.ColumnCount = 3;
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.Controls.Add(button8, 2, 2);
            GamePanel.Controls.Add(button7, 1, 2);
            GamePanel.Controls.Add(button6, 0, 2);
            GamePanel.Controls.Add(button5, 2, 1);
            GamePanel.Controls.Add(button4, 1, 1);
            GamePanel.Controls.Add(button3, 0, 1);
            GamePanel.Controls.Add(button2, 2, 0);
            GamePanel.Controls.Add(button1, 1, 0);
            GamePanel.Controls.Add(FirstButton, 0, 0);
            GamePanel.Location = new Point(12, 72);
            GamePanel.Name = "GamePanel";
            GamePanel.RowCount = 3;
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.Size = new Size(635, 366);
            GamePanel.TabIndex = 0;
            GamePanel.UseWaitCursor = true;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button8.Location = new Point(425, 247);
            button8.Name = "button8";
            button8.Size = new Size(207, 116);
            button8.TabIndex = 8;
            button8.UseVisualStyleBackColor = true;
            button8.UseWaitCursor = true;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button7.Location = new Point(214, 247);
            button7.Name = "button7";
            button7.Size = new Size(205, 116);
            button7.TabIndex = 7;
            button7.UseVisualStyleBackColor = true;
            button7.UseWaitCursor = true;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(3, 247);
            button6.Name = "button6";
            button6.Size = new Size(205, 116);
            button6.TabIndex = 6;
            button6.UseVisualStyleBackColor = true;
            button6.UseWaitCursor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(425, 125);
            button5.Name = "button5";
            button5.Size = new Size(207, 116);
            button5.TabIndex = 5;
            button5.UseVisualStyleBackColor = true;
            button5.UseWaitCursor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(214, 125);
            button4.Name = "button4";
            button4.Size = new Size(205, 116);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = true;
            button4.UseWaitCursor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(3, 125);
            button3.Name = "button3";
            button3.Size = new Size(205, 116);
            button3.TabIndex = 3;
            button3.UseVisualStyleBackColor = true;
            button3.UseWaitCursor = true;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(425, 3);
            button2.Name = "button2";
            button2.Size = new Size(207, 116);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.UseWaitCursor = true;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(214, 3);
            button1.Name = "button1";
            button1.Size = new Size(205, 116);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.UseWaitCursor = true;
            // 
            // FirstButton
            // 
            FirstButton.Dock = DockStyle.Fill;
            FirstButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            FirstButton.Location = new Point(3, 3);
            FirstButton.Name = "FirstButton";
            FirstButton.Size = new Size(205, 116);
            FirstButton.TabIndex = 0;
            FirstButton.Tag = "";
            FirstButton.UseVisualStyleBackColor = true;
            FirstButton.UseWaitCursor = true;
            FirstButton.Click += OnGameFieldButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 450);
            Controls.Add(GamePanel);
            Name = "Form1";
            Text = "Form1";
            GamePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel GamePanel;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button FirstButton;
    }
}