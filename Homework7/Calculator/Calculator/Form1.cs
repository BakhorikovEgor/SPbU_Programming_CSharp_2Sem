namespace CalculatorForm;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();

    public CalculatorForm()
    {
        InitializeComponent();
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            var button = (Button)sender;
            calculator.Calculate(button.Text);
        }
    }
}