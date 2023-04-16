namespace CalculatorForm;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();

    public CalculatorForm()
    {
        InitializeComponent();

        var resultBinding = new Binding("Text", calculator, "Message", true, DataSourceUpdateMode.OnPropertyChanged);
        result.DataBindings.Add(resultBinding);
    }

    public void OnDigitButtonClick(object sender, EventArgs e)
    {
        var digit = ((Button)sender).Text[0];
        calculator.AddDigit(digit);
    }

    public void OnOperationButtonClick(object sender, EventArgs e)
    {
        var operation = ((Button)sender).Text;
        calculator.AddOperation(operation);
    }

    public void OnCalculateButtonClick(object sender, EventArgs e)
        => calculator.Calculate();

    public void OnClearButtonClick(object sender, EventArgs e)
        => calculator.Clear();
}