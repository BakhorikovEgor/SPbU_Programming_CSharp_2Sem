namespace CalculatorForm;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();

    public CalculatorForm()
    {
        InitializeComponent();
    }

    private void OnOperationOrDigitButtonClick(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var button = (Button)sender;
            calculator.AddOperandOrOperation(button.Text);

            if (calculator.IsResultExist)
            {
                result.Text = calculator.result.ToString();
            }
        }
    }
}