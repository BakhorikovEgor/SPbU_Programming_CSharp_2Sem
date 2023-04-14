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
        components = new System.ComponentModel.Container();
        tableLayoutPanel1 = new TableLayoutPanel();
        button15 = new Button();
        button14 = new Button();
        NineDigitButton = new Button();
        EightDigitButton = new Button();
        SevenDigitButton = new Button();
        SixDigitButton = new Button();
        FiveDigitButton = new Button();
        FourDigitButton = new Button();
        ThreeDigitButton = new Button();
        TwoDigitButton = new Button();
        OneDigitButton = new Button();
        ZeroDigitButton = new Button();
        DivideOperationButton = new Button();
        MultiplyOperationButton = new Button();
        MinusOperationButton = new Button();
        PlusOperationButton = new Button();
        textBox1 = new TextBox();
        calculatorBindingSource = new BindingSource(components);
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)calculatorBindingSource).BeginInit();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 4;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.Controls.Add(button15, 3, 3);
        tableLayoutPanel1.Controls.Add(button14, 2, 3);
        tableLayoutPanel1.Controls.Add(NineDigitButton, 1, 3);
        tableLayoutPanel1.Controls.Add(EightDigitButton, 0, 3);
        tableLayoutPanel1.Controls.Add(SevenDigitButton, 3, 2);
        tableLayoutPanel1.Controls.Add(SixDigitButton, 2, 2);
        tableLayoutPanel1.Controls.Add(FiveDigitButton, 1, 2);
        tableLayoutPanel1.Controls.Add(FourDigitButton, 0, 2);
        tableLayoutPanel1.Controls.Add(ThreeDigitButton, 3, 1);
        tableLayoutPanel1.Controls.Add(TwoDigitButton, 2, 1);
        tableLayoutPanel1.Controls.Add(OneDigitButton, 1, 1);
        tableLayoutPanel1.Controls.Add(ZeroDigitButton, 0, 1);
        tableLayoutPanel1.Controls.Add(DivideOperationButton, 3, 0);
        tableLayoutPanel1.Controls.Add(MultiplyOperationButton, 2, 0);
        tableLayoutPanel1.Controls.Add(MinusOperationButton, 1, 0);
        tableLayoutPanel1.Controls.Add(PlusOperationButton, 0, 0);
        tableLayoutPanel1.Dock = DockStyle.Bottom;
        tableLayoutPanel1.Location = new Point(0, 305);
        tableLayoutPanel1.Margin = new Padding(10);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.Size = new Size(482, 255);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // button15
        // 
        button15.Dock = DockStyle.Fill;
        button15.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point);
        button15.Location = new Point(363, 192);
        button15.Name = "button15";
        button15.Size = new Size(116, 60);
        button15.TabIndex = 15;
        button15.Text = "+";
        button15.UseVisualStyleBackColor = true;
        // 
        // button14
        // 
        button14.Dock = DockStyle.Fill;
        button14.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point);
        button14.Location = new Point(243, 192);
        button14.Name = "button14";
        button14.Size = new Size(114, 60);
        button14.TabIndex = 14;
        button14.Text = "+";
        button14.UseVisualStyleBackColor = true;
        // 
        // NineDigitButton
        // 
        NineDigitButton.Dock = DockStyle.Fill;
        NineDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        NineDigitButton.Location = new Point(123, 192);
        NineDigitButton.Name = "NineDigitButton";
        NineDigitButton.Size = new Size(114, 60);
        NineDigitButton.TabIndex = 14;
        NineDigitButton.Text = "9";
        NineDigitButton.UseVisualStyleBackColor = true;
        NineDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // EightDigitButton
        // 
        EightDigitButton.Dock = DockStyle.Fill;
        EightDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        EightDigitButton.Location = new Point(3, 192);
        EightDigitButton.Name = "EightDigitButton";
        EightDigitButton.Size = new Size(114, 60);
        EightDigitButton.TabIndex = 13;
        EightDigitButton.Text = "8";
        EightDigitButton.UseVisualStyleBackColor = true;
        EightDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // SevenDigitButton
        // 
        SevenDigitButton.Dock = DockStyle.Fill;
        SevenDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        SevenDigitButton.Location = new Point(363, 129);
        SevenDigitButton.Name = "SevenDigitButton";
        SevenDigitButton.Size = new Size(116, 57);
        SevenDigitButton.TabIndex = 12;
        SevenDigitButton.Text = "7";
        SevenDigitButton.UseVisualStyleBackColor = true;
        SevenDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // SixDigitButton
        // 
        SixDigitButton.Dock = DockStyle.Fill;
        SixDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        SixDigitButton.Location = new Point(243, 129);
        SixDigitButton.Name = "SixDigitButton";
        SixDigitButton.Size = new Size(114, 57);
        SixDigitButton.TabIndex = 11;
        SixDigitButton.Text = "6";
        SixDigitButton.UseVisualStyleBackColor = true;
        SixDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // FiveDigitButton
        // 
        FiveDigitButton.Dock = DockStyle.Fill;
        FiveDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        FiveDigitButton.Location = new Point(123, 129);
        FiveDigitButton.Name = "FiveDigitButton";
        FiveDigitButton.Size = new Size(114, 57);
        FiveDigitButton.TabIndex = 10;
        FiveDigitButton.Text = "5";
        FiveDigitButton.UseVisualStyleBackColor = true;
        FiveDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // FourDigitButton
        // 
        FourDigitButton.Dock = DockStyle.Fill;
        FourDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        FourDigitButton.Location = new Point(3, 129);
        FourDigitButton.Name = "FourDigitButton";
        FourDigitButton.Size = new Size(114, 57);
        FourDigitButton.TabIndex = 9;
        FourDigitButton.Text = "4";
        FourDigitButton.UseVisualStyleBackColor = true;
        FourDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // ThreeDigitButton
        // 
        ThreeDigitButton.Dock = DockStyle.Fill;
        ThreeDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        ThreeDigitButton.Location = new Point(363, 66);
        ThreeDigitButton.Name = "ThreeDigitButton";
        ThreeDigitButton.Size = new Size(116, 57);
        ThreeDigitButton.TabIndex = 8;
        ThreeDigitButton.Text = "3";
        ThreeDigitButton.UseVisualStyleBackColor = true;
        ThreeDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // TwoDigitButton
        // 
        TwoDigitButton.Dock = DockStyle.Fill;
        TwoDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        TwoDigitButton.Location = new Point(243, 66);
        TwoDigitButton.Name = "TwoDigitButton";
        TwoDigitButton.Size = new Size(114, 57);
        TwoDigitButton.TabIndex = 7;
        TwoDigitButton.Text = "2";
        TwoDigitButton.UseVisualStyleBackColor = true;
        TwoDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // OneDigitButton
        // 
        OneDigitButton.Dock = DockStyle.Fill;
        OneDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        OneDigitButton.Location = new Point(123, 66);
        OneDigitButton.Name = "OneDigitButton";
        OneDigitButton.Size = new Size(114, 57);
        OneDigitButton.TabIndex = 6;
        OneDigitButton.Text = "1";
        OneDigitButton.UseVisualStyleBackColor = true;
        OneDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // ZeroDigitButton
        // 
        ZeroDigitButton.Dock = DockStyle.Fill;
        ZeroDigitButton.Font = new Font("Tahoma", 21F, FontStyle.Bold, GraphicsUnit.Point);
        ZeroDigitButton.Location = new Point(3, 66);
        ZeroDigitButton.Name = "ZeroDigitButton";
        ZeroDigitButton.Size = new Size(114, 57);
        ZeroDigitButton.TabIndex = 5;
        ZeroDigitButton.Text = "0";
        ZeroDigitButton.UseVisualStyleBackColor = true;
        ZeroDigitButton.Click += OnOperationOrDigitButtonClick;
        // 
        // DivideOperationButton
        // 
        DivideOperationButton.Dock = DockStyle.Fill;
        DivideOperationButton.Font = new Font("Tahoma", 19F, FontStyle.Bold, GraphicsUnit.Point);
        DivideOperationButton.Location = new Point(363, 3);
        DivideOperationButton.Name = "DivideOperationButton";
        DivideOperationButton.Size = new Size(116, 57);
        DivideOperationButton.TabIndex = 4;
        DivideOperationButton.Text = "/";
        DivideOperationButton.UseVisualStyleBackColor = true;
        DivideOperationButton.Click += OnOperationOrDigitButtonClick;
        // 
        // MultiplyOperationButton
        // 
        MultiplyOperationButton.Dock = DockStyle.Fill;
        MultiplyOperationButton.Font = new Font("Franklin Gothic Medium", 31.8000011F, FontStyle.Regular, GraphicsUnit.Point);
        MultiplyOperationButton.Location = new Point(243, 3);
        MultiplyOperationButton.Name = "MultiplyOperationButton";
        MultiplyOperationButton.Size = new Size(114, 57);
        MultiplyOperationButton.TabIndex = 3;
        MultiplyOperationButton.Text = "*";
        MultiplyOperationButton.UseVisualStyleBackColor = true;
        MultiplyOperationButton.Click += OnOperationOrDigitButtonClick;
        // 
        // MinusOperationButton
        // 
        MinusOperationButton.Dock = DockStyle.Fill;
        MinusOperationButton.Font = new Font("Tahoma", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
        MinusOperationButton.Location = new Point(123, 3);
        MinusOperationButton.Name = "MinusOperationButton";
        MinusOperationButton.Size = new Size(114, 57);
        MinusOperationButton.TabIndex = 2;
        MinusOperationButton.Text = "-";
        MinusOperationButton.UseVisualStyleBackColor = true;
        MinusOperationButton.Click += OnOperationOrDigitButtonClick;
        // 
        // PlusOperationButton
        // 
        PlusOperationButton.Dock = DockStyle.Fill;
        PlusOperationButton.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point);
        PlusOperationButton.Location = new Point(3, 3);
        PlusOperationButton.Name = "PlusOperationButton";
        PlusOperationButton.Size = new Size(114, 57);
        PlusOperationButton.TabIndex = 1;
        PlusOperationButton.Text = "+";
        PlusOperationButton.UseVisualStyleBackColor = true;
        PlusOperationButton.Click += OnOperationOrDigitButtonClick;
        // 
        // textBox1
        // 
        textBox1.DataBindings.Add(new Binding("Text", calculatorBindingSource, "result", true));
        textBox1.Location = new Point(243, 74);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(227, 25);
        textBox1.TabIndex = 1;
        // 
        // calculatorBindingSource
        // 
        calculatorBindingSource.DataSource = typeof(Calculator);
        // 
        // CalculatorForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Desktop;
        ClientSize = new Size(482, 560);
        Controls.Add(textBox1);
        Controls.Add(tableLayoutPanel1);
        Font = new Font("Cascadia Code SemiBold", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(500, 560);
        Name = "CalculatorForm";
        Text = "Calculator";
        tableLayoutPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)calculatorBindingSource).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel1;
    private Button button15;
    private Button button14;
    private Button NineDigitButton;
    private Button EightDigitButton;
    private Button SevenDigitButton;
    private Button SixDigitButton;
    private Button FiveDigitButton;
    private Button FourDigitButton;
    private Button ThreeDigitButton;
    private Button TwoDigitButton;
    private Button OneDigitButton;
    private Button ZeroDigitButton;
    private Button DivideOperationButton;
    private Button MultiplyOperationButton;
    private Button MinusOperationButton;
    private Button PlusOperationButton;
    private TextBox textBox1;
    private BindingSource calculatorBindingSource;
}