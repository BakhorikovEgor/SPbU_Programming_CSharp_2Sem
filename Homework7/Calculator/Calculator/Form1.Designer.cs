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
        button4 = new Button();
        button3 = new Button();
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
        result = new TextBox();
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
        InputTable.Controls.Add(button4, 2, 3);
        InputTable.Controls.Add(button3, 1, 3);
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
        InputTable.Size = new Size(458, 258);
        InputTable.TabIndex = 2;
        // 
        // divideButton
        // 
        divideButton.Dock = DockStyle.Fill;
        divideButton.Font = new Font("Liberation Sans", 24F, FontStyle.Bold, GraphicsUnit.Point);
        divideButton.Location = new Point(345, 195);
        divideButton.Name = "divideButton";
        divideButton.Size = new Size(110, 60);
        divideButton.TabIndex = 14;
        divideButton.Text = "/";
        divideButton.UseVisualStyleBackColor = true;
        divideButton.Click += OnOperationOrDigitButtonClick;
        // 
        // button4
        // 
        button4.Dock = DockStyle.Fill;
        button4.Font = new Font("Liberation Sans", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
        button4.Location = new Point(231, 195);
        button4.Name = "button4";
        button4.Size = new Size(108, 60);
        button4.TabIndex = 15;
        button4.Text = "=";
        button4.UseVisualStyleBackColor = true;
        button4.Click += OnOperationOrDigitButtonClick;
        // 
        // button3
        // 
        button3.Dock = DockStyle.Fill;
        button3.Font = new Font("Liberation Sans", 24F, FontStyle.Bold, GraphicsUnit.Point);
        button3.Location = new Point(117, 195);
        button3.Name = "button3";
        button3.Size = new Size(108, 60);
        button3.TabIndex = 0;
        button3.Text = "+/-";
        button3.UseVisualStyleBackColor = true;
        button3.Click += OnOperationOrDigitButtonClick;
        // 
        // multiplyButton
        // 
        multiplyButton.Dock = DockStyle.Fill;
        multiplyButton.Font = new Font("Miriam CLM", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
        multiplyButton.Location = new Point(345, 131);
        multiplyButton.Name = "multiplyButton";
        multiplyButton.Size = new Size(110, 58);
        multiplyButton.TabIndex = 13;
        multiplyButton.Text = "*";
        multiplyButton.UseVisualStyleBackColor = true;
        multiplyButton.Click += OnOperationOrDigitButtonClick;
        // 
        // minusButton
        // 
        minusButton.Dock = DockStyle.Fill;
        minusButton.Font = new Font("Liberation Mono", 28.8000011F, FontStyle.Bold, GraphicsUnit.Point);
        minusButton.Location = new Point(345, 67);
        minusButton.Name = "minusButton";
        minusButton.Size = new Size(110, 58);
        minusButton.TabIndex = 12;
        minusButton.Text = "-";
        minusButton.UseVisualStyleBackColor = true;
        minusButton.Click += OnOperationOrDigitButtonClick;
        // 
        // zeroButton
        // 
        zeroButton.Dock = DockStyle.Fill;
        zeroButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        zeroButton.Location = new Point(3, 195);
        zeroButton.Name = "zeroButton";
        zeroButton.Size = new Size(108, 60);
        zeroButton.TabIndex = 1;
        zeroButton.Text = "0";
        zeroButton.UseVisualStyleBackColor = true;
        zeroButton.Click += OnOperationOrDigitButtonClick;
        // 
        // oneButton
        // 
        oneButton.Dock = DockStyle.Fill;
        oneButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        oneButton.Location = new Point(3, 131);
        oneButton.Name = "oneButton";
        oneButton.Size = new Size(108, 58);
        oneButton.TabIndex = 2;
        oneButton.Text = "1";
        oneButton.UseVisualStyleBackColor = true;
        oneButton.Click += OnOperationOrDigitButtonClick;
        // 
        // twoButton
        // 
        twoButton.Dock = DockStyle.Fill;
        twoButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        twoButton.Location = new Point(117, 131);
        twoButton.Name = "twoButton";
        twoButton.Size = new Size(108, 58);
        twoButton.TabIndex = 2;
        twoButton.Text = "2";
        twoButton.UseVisualStyleBackColor = true;
        twoButton.Click += OnOperationOrDigitButtonClick;
        // 
        // threeButton
        // 
        threeButton.Dock = DockStyle.Fill;
        threeButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        threeButton.Location = new Point(231, 131);
        threeButton.Name = "threeButton";
        threeButton.Size = new Size(108, 58);
        threeButton.TabIndex = 3;
        threeButton.Text = "3";
        threeButton.UseVisualStyleBackColor = true;
        threeButton.Click += OnOperationOrDigitButtonClick;
        // 
        // sixButton
        // 
        sixButton.Dock = DockStyle.Fill;
        sixButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        sixButton.Location = new Point(231, 67);
        sixButton.Name = "sixButton";
        sixButton.Size = new Size(108, 58);
        sixButton.TabIndex = 6;
        sixButton.Text = "6";
        sixButton.UseVisualStyleBackColor = true;
        sixButton.Click += OnOperationOrDigitButtonClick;
        // 
        // fiveButton
        // 
        fiveButton.Dock = DockStyle.Fill;
        fiveButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        fiveButton.Location = new Point(117, 67);
        fiveButton.Name = "fiveButton";
        fiveButton.Size = new Size(108, 58);
        fiveButton.TabIndex = 5;
        fiveButton.Text = "5";
        fiveButton.UseVisualStyleBackColor = true;
        fiveButton.Click += OnOperationOrDigitButtonClick;
        // 
        // fourButton
        // 
        fourButton.Dock = DockStyle.Fill;
        fourButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        fourButton.Location = new Point(3, 67);
        fourButton.Name = "fourButton";
        fourButton.Size = new Size(108, 58);
        fourButton.TabIndex = 4;
        fourButton.Text = "4";
        fourButton.UseVisualStyleBackColor = true;
        fourButton.Click += OnOperationOrDigitButtonClick;
        // 
        // nineButton
        // 
        nineButton.Dock = DockStyle.Fill;
        nineButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        nineButton.Location = new Point(231, 3);
        nineButton.Name = "nineButton";
        nineButton.Size = new Size(108, 58);
        nineButton.TabIndex = 9;
        nineButton.Text = "9";
        nineButton.UseVisualStyleBackColor = true;
        nineButton.Click += OnOperationOrDigitButtonClick;
        // 
        // eightButton
        // 
        eightButton.Dock = DockStyle.Fill;
        eightButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        eightButton.Location = new Point(117, 3);
        eightButton.Name = "eightButton";
        eightButton.Size = new Size(108, 58);
        eightButton.TabIndex = 8;
        eightButton.Text = "8";
        eightButton.UseVisualStyleBackColor = true;
        eightButton.Click += OnOperationOrDigitButtonClick;
        // 
        // sevenButton
        // 
        sevenButton.Dock = DockStyle.Fill;
        sevenButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
        sevenButton.Location = new Point(3, 3);
        sevenButton.Name = "sevenButton";
        sevenButton.Size = new Size(108, 58);
        sevenButton.TabIndex = 7;
        sevenButton.Text = "7";
        sevenButton.UseVisualStyleBackColor = true;
        sevenButton.Click += OnOperationOrDigitButtonClick;
        // 
        // plusButton
        // 
        plusButton.Dock = DockStyle.Fill;
        plusButton.Font = new Font("Liberation Sans", 28.2F, FontStyle.Bold, GraphicsUnit.Point);
        plusButton.Location = new Point(345, 3);
        plusButton.Name = "plusButton";
        plusButton.Size = new Size(110, 58);
        plusButton.TabIndex = 11;
        plusButton.Text = "+";
        plusButton.UseVisualStyleBackColor = true;
        plusButton.Click += OnOperationOrDigitButtonClick;
        // 
        // result
        // 
        result.BackColor = SystemColors.InfoText;
        result.BorderStyle = BorderStyle.None;
        result.Font = new Font("Cascadia Code SemiBold", 20F, FontStyle.Regular, GraphicsUnit.Point);
        result.ForeColor = SystemColors.HotTrack;
        result.Location = new Point(232, 95);
        result.Name = "result";
        result.Size = new Size(238, 39);
        result.TabIndex = 3;
        result.TextAlign = HorizontalAlignment.Right;
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Desktop;
        ClientSize = new Size(482, 560);
        Controls.Add(result);
        Controls.Add(InputTable);
        Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(500, 560);
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
    private Button button4;
    private Button button3;
    private Button multiplyButton;
    private Button minusButton;
    private TextBox result;
}