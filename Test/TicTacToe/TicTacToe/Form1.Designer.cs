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
            NinthGameFieldButton = new Button();
            EighthGameFieldButton = new Button();
            SeventhGameFieldButton = new Button();
            SixthGameFieldButton = new Button();
            FifthGameFieldButton = new Button();
            FourthGameFieldButton = new Button();
            ThirdGameFieldButton = new Button();
            SecondGameFieldButton = new Button();
            FirstGameFieldButton = new Button();
            GameInfoTextBox = new TextBox();
            GamePanel.SuspendLayout();
            SuspendLayout();
            // 
            // GamePanel
            // 
            GamePanel.ColumnCount = 3;
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            GamePanel.Controls.Add(NinthGameFieldButton, 2, 2);
            GamePanel.Controls.Add(EighthGameFieldButton, 1, 2);
            GamePanel.Controls.Add(SeventhGameFieldButton, 0, 2);
            GamePanel.Controls.Add(SixthGameFieldButton, 2, 1);
            GamePanel.Controls.Add(FifthGameFieldButton, 1, 1);
            GamePanel.Controls.Add(FourthGameFieldButton, 0, 1);
            GamePanel.Controls.Add(ThirdGameFieldButton, 2, 0);
            GamePanel.Controls.Add(SecondGameFieldButton, 1, 0);
            GamePanel.Controls.Add(FirstGameFieldButton, 0, 0);
            GamePanel.Location = new Point(12, 72);
            GamePanel.Name = "GamePanel";
            GamePanel.RowCount = 3;
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            GamePanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            GamePanel.Size = new Size(635, 366);
            GamePanel.TabIndex = 0;
            GamePanel.UseWaitCursor = true;
            // 
            // NinthGameFieldButton
            // 
            NinthGameFieldButton.BackColor = SystemColors.Info;
            NinthGameFieldButton.Dock = DockStyle.Fill;
            NinthGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            NinthGameFieldButton.Location = new Point(425, 247);
            NinthGameFieldButton.Name = "NinthGameFieldButton";
            NinthGameFieldButton.Size = new Size(207, 116);
            NinthGameFieldButton.TabIndex = 8;
            NinthGameFieldButton.UseVisualStyleBackColor = false;
            NinthGameFieldButton.UseWaitCursor = true;
            NinthGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // EighthGameFieldButton
            // 
            EighthGameFieldButton.BackColor = SystemColors.Info;
            EighthGameFieldButton.Dock = DockStyle.Fill;
            EighthGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            EighthGameFieldButton.Location = new Point(214, 247);
            EighthGameFieldButton.Name = "EighthGameFieldButton";
            EighthGameFieldButton.Size = new Size(205, 116);
            EighthGameFieldButton.TabIndex = 7;
            EighthGameFieldButton.UseVisualStyleBackColor = false;
            EighthGameFieldButton.UseWaitCursor = true;
            EighthGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // SeventhGameFieldButton
            // 
            SeventhGameFieldButton.BackColor = SystemColors.Info;
            SeventhGameFieldButton.Dock = DockStyle.Fill;
            SeventhGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            SeventhGameFieldButton.Location = new Point(3, 247);
            SeventhGameFieldButton.Name = "SeventhGameFieldButton";
            SeventhGameFieldButton.Size = new Size(205, 116);
            SeventhGameFieldButton.TabIndex = 6;
            SeventhGameFieldButton.UseVisualStyleBackColor = false;
            SeventhGameFieldButton.UseWaitCursor = true;
            SeventhGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // SixthGameFieldButton
            // 
            SixthGameFieldButton.BackColor = SystemColors.Info;
            SixthGameFieldButton.Dock = DockStyle.Fill;
            SixthGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            SixthGameFieldButton.Location = new Point(425, 125);
            SixthGameFieldButton.Name = "SixthGameFieldButton";
            SixthGameFieldButton.Size = new Size(207, 116);
            SixthGameFieldButton.TabIndex = 5;
            SixthGameFieldButton.UseVisualStyleBackColor = false;
            SixthGameFieldButton.UseWaitCursor = true;
            SixthGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // FifthGameFieldButton
            // 
            FifthGameFieldButton.BackColor = SystemColors.Info;
            FifthGameFieldButton.Dock = DockStyle.Fill;
            FifthGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            FifthGameFieldButton.Location = new Point(214, 125);
            FifthGameFieldButton.Name = "FifthGameFieldButton";
            FifthGameFieldButton.Size = new Size(205, 116);
            FifthGameFieldButton.TabIndex = 4;
            FifthGameFieldButton.UseVisualStyleBackColor = false;
            FifthGameFieldButton.UseWaitCursor = true;
            FifthGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // FourthGameFieldButton
            // 
            FourthGameFieldButton.BackColor = SystemColors.Info;
            FourthGameFieldButton.Dock = DockStyle.Fill;
            FourthGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            FourthGameFieldButton.Location = new Point(3, 125);
            FourthGameFieldButton.Name = "FourthGameFieldButton";
            FourthGameFieldButton.Size = new Size(205, 116);
            FourthGameFieldButton.TabIndex = 3;
            FourthGameFieldButton.UseVisualStyleBackColor = false;
            FourthGameFieldButton.UseWaitCursor = true;
            FourthGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // ThirdGameFieldButton
            // 
            ThirdGameFieldButton.BackColor = SystemColors.Info;
            ThirdGameFieldButton.Dock = DockStyle.Fill;
            ThirdGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            ThirdGameFieldButton.Location = new Point(425, 3);
            ThirdGameFieldButton.Name = "ThirdGameFieldButton";
            ThirdGameFieldButton.Size = new Size(207, 116);
            ThirdGameFieldButton.TabIndex = 2;
            ThirdGameFieldButton.UseVisualStyleBackColor = false;
            ThirdGameFieldButton.UseWaitCursor = true;
            ThirdGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // SecondGameFieldButton
            // 
            SecondGameFieldButton.BackColor = SystemColors.Info;
            SecondGameFieldButton.Dock = DockStyle.Fill;
            SecondGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            SecondGameFieldButton.Location = new Point(214, 3);
            SecondGameFieldButton.Name = "SecondGameFieldButton";
            SecondGameFieldButton.Size = new Size(205, 116);
            SecondGameFieldButton.TabIndex = 1;
            SecondGameFieldButton.UseVisualStyleBackColor = false;
            SecondGameFieldButton.UseWaitCursor = true;
            SecondGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // FirstGameFieldButton
            // 
            FirstGameFieldButton.BackColor = SystemColors.Info;
            FirstGameFieldButton.Dock = DockStyle.Fill;
            FirstGameFieldButton.Font = new Font("Franklin Gothic Medium", 55F, FontStyle.Bold, GraphicsUnit.Point);
            FirstGameFieldButton.Location = new Point(3, 3);
            FirstGameFieldButton.Name = "FirstGameFieldButton";
            FirstGameFieldButton.Size = new Size(205, 116);
            FirstGameFieldButton.TabIndex = 0;
            FirstGameFieldButton.Tag = "";
            FirstGameFieldButton.UseVisualStyleBackColor = false;
            FirstGameFieldButton.UseWaitCursor = true;
            FirstGameFieldButton.Click += OnGameFieldButtonClick;
            // 
            // GameInfoTextBox
            // 
            GameInfoTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GameInfoTextBox.BackColor = SystemColors.ControlLightLight;
            GameInfoTextBox.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point);
            GameInfoTextBox.Location = new Point(15, 18);
            GameInfoTextBox.Name = "GameInfoTextBox";
            GameInfoTextBox.Size = new Size(629, 39);
            GameInfoTextBox.TabIndex = 9;
            GameInfoTextBox.Text = "Time for Player 1 to move !";
            GameInfoTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(659, 450);
            Controls.Add(GameInfoTextBox);
            Controls.Add(GamePanel);
            Name = "Form1";
            Text = "Form1";
            GamePanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel GamePanel;
        private Button NinthGameFieldButton;
        private Button EighthGameFieldButton;
        private Button button2;
        private Button button1;
        private Button FirstGameFieldButton;
        private Button SeventhGameFieldButton;
        private Button SixthGameFieldButton;
        private Button FifthGameFieldButton;
        private Button FourthGameFieldButton;
        private Button ThirdGameFieldButton;
        private Button SecondGameFieldButton;
        private TextBox GameInfoTextBox;
    }
}