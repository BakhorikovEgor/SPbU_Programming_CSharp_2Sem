namespace CalculatorForm;

partial class CalculatorForm
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
        InputTable = new TableLayoutPanel();
        divideButton = new Button();
        calculateButton = new Button();
        changeSignButton = new Button();
        multiplyButton = new Button();
        minusButton = new Button();
        zeroButton = new Button();
        oneButton = new Button();
        twoButton = new Button();
        threeButton = new Button();
        sixButton = new Button();
        fiveButton = new Button();
        fourButton = new Button();
        nineButton = new Button();
        eightButton = new Button();
        sevenButton = new Button();
        plusButton = new Button();
        ClearButton = new Button();
        result = new Label();
        InputTable.SuspendLayout();
        SuspendLayout();
        // 
        // InputTable
        // 
        InputTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        InputTable.ColumnCount = 4;
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.Controls.Add(divideButton, 3, 3);
        InputTable.Controls.Add(calculateButton, 2, 3);
        InputTable.Controls.Add(changeSignButton, 1, 3);
        InputTable.Controls.Add(multiplyButton, 3, 2);
        InputTable.Controls.Add(minusButton, 3, 1);
        InputTable.Controls.Add(zeroButton, 0, 3);
        InputTable.Controls.Add(oneButton, 0, 2);
        InputTable.Controls.Add(twoButton, 0, 2);
        InputTable.Controls.Add(threeButton, 1, 2);
        InputTable.Controls.Add(sixButton, 1, 1);
        InputTable.Controls.Add(fiveButton, 1, 1);
        InputTable.Controls.Add(fourButton, 0, 1);
        InputTable.Controls.Add(nineButton, 2, 0);
        InputTable.Controls.Add(eightButton, 1, 0);
        InputTable.Controls.Add(sevenButton, 0, 0);
        InputTable.Controls.Add(plusButton, 3, 0);
        InputTable.Location = new Point(12, 290);
        InputTable.Name = "InputTable";
        InputTable.RowCount = 4;
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        InputTable.Size = new Size(408, 256);
        InputTable.TabIndex = 2;
        // 
        // divideButton
        // 
        divideButton.BackColor = SystemColors.ActiveCaptionText;
        divideButton.Dock = DockStyle.Fill;
        divideButton.Font = new Font("Liberation Sans", 24F, FontStyle.Bold, GraphicsUnit.Point);
        divideButton.ForeColor = Color.Crimson;
        divideButton.Location = new Point(309, 195);
        divideButton.Name = "divideButton";
        divideButton.Size = new Size(96, 58);
        divideButton.TabIndex = 13;
        divideButton.Text = "/";
        divideButton.UseVisualStyleBackColor = false;
        divideButton.Click += OnOperationButtonClick;
        // 
        // calculateButton
        // 
        calculateButton.BackColor = SystemColors.ActiveCaptionText;
        calculateButton.Dock = DockStyle.Fill;
        calculateButton.Font = new Font("Liberation Sans", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
        calculateButton.ForeColor = Color.Crimson;
        calculateButton.Location = new Point(207, 195);
        calculateButton.Name = "calculateButton";
        calculateButton.Size = new Size(96, 58);
        calculateButton.TabIndex = 14;
        calculateButton.Text = "=";
        calculateButton.UseVisualStyleBackColor = false;
        calculateButton.Click += OnCalculateButtonClick;
        // 
        // changeSignButton
        // 
        changeSignButton.BackColor = SystemColors.ActiveCaptionText;
        changeSignButton.Dock = DockStyle.Fill;
        changeSignButton.Font = new Font("Liberation Sans", 24F, FontStyle.Bold, GraphicsUnit.Point);
        changeSignButton.ForeColor = Color.Crimson;
        changeSignButton.Location = new Point(105, 195);
        changeSignButton.Name = "changeSignButton";
        changeSignButton.Size = new Size(96, 58);
        changeSignButton.TabIndex = 0;
        changeSignButton.Text = "+/-";
        changeSignButton.UseVisualStyleBackColor = false;
        changeSignButton.Click += OnOperationButtonClick;
        // 
        // multiplyButton
        // 
        multiplyButton.BackColor = SystemColors.ActiveCaptionText;
        multiplyButton.Dock = DockStyle.Fill;
        multiplyButton.Font = new Font("Miriam CLM", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
        multiplyButton.ForeColor = Color.Crimson;
        multiplyButton.Location = new Point(309, 131);
        multiplyButton.Name = "multiplyButton";
        multiplyButton.Size = new Size(96, 58);
        multiplyButton.TabIndex = 12;
        multiplyButton.Text = "*";
        multiplyButton.UseVisualStyleBackColor = false;
        multiplyButton.Click += OnOperationButtonClick;
        // 
        // minusButton
        // 
        minusButton.BackColor = SystemColors.ActiveCaptionText;
        minusButton.Dock = DockStyle.Fill;
        minusButton.Font = new Font("Liberation Mono", 28.8000011F, FontStyle.Bold, GraphicsUnit.Point);
        minusButton.ForeColor = Color.Crimson;
        minusButton.Location = new Point(309, 67);
        minusButton.Name = "minusButton";
        minusButton.Size = new Size(96, 58);
        minusButton.TabIndex = 11;
        minusButton.Text = "-";
        minusButton.UseVisualStyleBackColor = false;
        minusButton.Click += OnOperationButtonClick;
        // 
        // zeroButton
        // 
        zeroButton.BackColor = SystemColors.ActiveCaptionText;
        zeroButton.Dock = DockStyle.Fill;
        zeroButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        zeroButton.ForeColor = SystemColors.Info;
        zeroButton.Location = new Point(3, 195);
        zeroButton.Name = "zeroButton";
        zeroButton.Size = new Size(96, 58);
        zeroButton.TabIndex = 1;
        zeroButton.Text = "0";
        zeroButton.UseVisualStyleBackColor = false;
        zeroButton.Click += OnDigitButtonClick;
        // 
        // oneButton
        // 
        oneButton.BackColor = SystemColors.ActiveCaptionText;
        oneButton.Dock = DockStyle.Fill;
        oneButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        oneButton.ForeColor = SystemColors.Info;
        oneButton.Location = new Point(3, 131);
        oneButton.Name = "oneButton";
        oneButton.Size = new Size(96, 58);
        oneButton.TabIndex = 2;
        oneButton.Text = "1";
        oneButton.UseVisualStyleBackColor = false;
        oneButton.Click += OnDigitButtonClick;
        // 
        // twoButton
        // 
        twoButton.BackColor = SystemColors.ActiveCaptionText;
        twoButton.Dock = DockStyle.Fill;
        twoButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        twoButton.ForeColor = SystemColors.Info;
        twoButton.Location = new Point(105, 131);
        twoButton.Name = "twoButton";
        twoButton.Size = new Size(96, 58);
        twoButton.TabIndex = 2;
        twoButton.Text = "2";
        twoButton.UseVisualStyleBackColor = false;
        twoButton.Click += OnDigitButtonClick;
        // 
        // threeButton
        // 
        threeButton.BackColor = SystemColors.ActiveCaptionText;
        threeButton.Dock = DockStyle.Fill;
        threeButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        threeButton.ForeColor = SystemColors.Info;
        threeButton.Location = new Point(207, 131);
        threeButton.Name = "threeButton";
        threeButton.Size = new Size(96, 58);
        threeButton.TabIndex = 3;
        threeButton.Text = "3";
        threeButton.UseVisualStyleBackColor = false;
        threeButton.Click += OnDigitButtonClick;
        // 
        // sixButton
        // 
        sixButton.BackColor = SystemColors.ActiveCaptionText;
        sixButton.Dock = DockStyle.Fill;
        sixButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        sixButton.ForeColor = SystemColors.Info;
        sixButton.Location = new Point(207, 67);
        sixButton.Name = "sixButton";
        sixButton.Size = new Size(96, 58);
        sixButton.TabIndex = 6;
        sixButton.Text = "6";
        sixButton.UseVisualStyleBackColor = false;
        sixButton.Click += OnDigitButtonClick;
        // 
        // fiveButton
        // 
        fiveButton.BackColor = SystemColors.ActiveCaptionText;
        fiveButton.Dock = DockStyle.Fill;
        fiveButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        fiveButton.ForeColor = SystemColors.Info;
        fiveButton.Location = new Point(105, 67);
        fiveButton.Name = "fiveButton";
        fiveButton.Size = new Size(96, 58);
        fiveButton.TabIndex = 5;
        fiveButton.Text = "5";
        fiveButton.UseVisualStyleBackColor = false;
        fiveButton.Click += OnDigitButtonClick;
        // 
        // fourButton
        // 
        fourButton.BackColor = SystemColors.ActiveCaptionText;
        fourButton.Dock = DockStyle.Fill;
        fourButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        fourButton.ForeColor = SystemColors.Info;
        fourButton.Location = new Point(3, 67);
        fourButton.Name = "fourButton";
        fourButton.Size = new Size(96, 58);
        fourButton.TabIndex = 4;
        fourButton.Text = "4";
        fourButton.UseVisualStyleBackColor = false;
        fourButton.Click += OnDigitButtonClick;
        // 
        // nineButton
        // 
        nineButton.BackColor = SystemColors.ActiveCaptionText;
        nineButton.Dock = DockStyle.Fill;
        nineButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        nineButton.ForeColor = SystemColors.Info;
        nineButton.Location = new Point(207, 3);
        nineButton.Name = "nineButton";
        nineButton.Size = new Size(96, 58);
        nineButton.TabIndex = 9;
        nineButton.Text = "9";
        nineButton.UseVisualStyleBackColor = false;
        nineButton.Click += OnDigitButtonClick;
        // 
        // eightButton
        // 
        eightButton.BackColor = SystemColors.ActiveCaptionText;
        eightButton.Dock = DockStyle.Fill;
        eightButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        eightButton.ForeColor = SystemColors.Info;
        eightButton.Location = new Point(105, 3);
        eightButton.Name = "eightButton";
        eightButton.Size = new Size(96, 58);
        eightButton.TabIndex = 8;
        eightButton.Text = "8";
        eightButton.UseVisualStyleBackColor = false;
        eightButton.Click += OnDigitButtonClick;
        // 
        // sevenButton
        // 
        sevenButton.BackColor = SystemColors.ActiveCaptionText;
        sevenButton.Dock = DockStyle.Fill;
        sevenButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        sevenButton.ForeColor = SystemColors.Info;
        sevenButton.Location = new Point(3, 3);
        sevenButton.Name = "sevenButton";
        sevenButton.Size = new Size(96, 58);
        sevenButton.TabIndex = 7;
        sevenButton.Text = "7";
        sevenButton.UseVisualStyleBackColor = false;
        sevenButton.Click += OnDigitButtonClick;
        // 
        // plusButton
        // 
        plusButton.BackColor = SystemColors.ActiveCaptionText;
        plusButton.Dock = DockStyle.Fill;
        plusButton.Font = new Font("Liberation Sans", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
        plusButton.ForeColor = Color.Crimson;
        plusButton.Location = new Point(309, 3);
        plusButton.Name = "plusButton";
        plusButton.Size = new Size(96, 58);
        plusButton.TabIndex = 10;
        plusButton.Text = "+";
        plusButton.UseVisualStyleBackColor = false;
        plusButton.Click += OnOperationButtonClick;
        // 
        // ClearButton
        // 
        ClearButton.BackColor = SystemColors.ActiveCaptionText;
        ClearButton.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point);
        ClearButton.ForeColor = Color.Lavender;
        ClearButton.Location = new Point(12, 12);
        ClearButton.Name = "ClearButton";
        ClearButton.Size = new Size(96, 58);
        ClearButton.TabIndex = 15;
        ClearButton.Text = "C";
        ClearButton.UseVisualStyleBackColor = false;
        ClearButton.Click += OnClearButtonClick;
        // 
        // result
        // 
        result.Anchor = AnchorStyles.Right;
        result.AutoSize = true;
        result.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Regular, GraphicsUnit.Point);
        result.ForeColor = SystemColors.Control;
        result.Location = new Point(380, 143);
        result.Name = "result";
        result.Size = new Size(40, 45);
        result.TabIndex = 18;
        result.Text = "0";
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Desktop;
        ClientSize = new Size(432, 558);
        Controls.Add(result);
        Controls.Add(ClearButton);
        Controls.Add(InputTable);
        Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(450, 605);
        Name = "CalculatorForm";
        Text = "Calculator";
        InputTable.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TextBox chain;
    private TableLayoutPanel InputTable;
    private Button sevenButton;
    private Button nineButton;
    private Button eightButton;
    private Button zeroButton;
    private Button oneButton;
    private Button twoButton;
    private Button threeButton;
    private Button sixButton;
    private Button fiveButton;
    private Button fourButton;
    private Button plusButton;
    private Button divideButton;
    private Button calculateButton;
    private Button changeSignButton;
    private Button multiplyButton;
    private Button minusButton;
    private Button ClearButton;
    private Label result;
}