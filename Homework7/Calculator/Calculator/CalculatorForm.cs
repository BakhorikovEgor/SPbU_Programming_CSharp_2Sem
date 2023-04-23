namespace CalculatorForm;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();

    /// <summary>
    /// Initialize + data binding
    /// </summary>
    public CalculatorForm()
    {
        InitializeComponent();

        var resultBinding = new Binding("Text", calculator, "Message", true, DataSourceUpdateMode.OnPropertyChanged);
        result.DataBindings.Add(resultBinding);
    }

    private void OnDigitButtonClick(object sender, EventArgs e)
    {
        var digit = ((Button)sender).Text[0];
        calculator.AddDigit(digit);
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        var operation = ((Button)sender).Text;
        calculator.AddOperation(operation);
    }

    private void OnCalculateButtonClick(object sender, EventArgs e)
        => calculator.Calculate();

    private void OnClearButtonClick(object sender, EventArgs e)
        => calculator.Clear();
}