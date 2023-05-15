using System.ComponentModel;

namespace SimpleCalculator;

/// <summary>
/// Class representing a Calculator for + - * / +/- operations.
/// </summary>
public class Calculator: INotifyPropertyChanged
{
    private const string _errorMessage = "Error";

    private readonly string[] _availableOperation = new string[] { "+", "-", "*", "/", "+/-"};

    private enum CalculatorStates
    {
        OperationHandling,
        TempValueHandling
    }

    private string _message = "0";

    private double _result = 0;
    private int _tempValue = 0;

    private CalculatorStates _state = CalculatorStates.TempValueHandling;

    private CalculatorOperation.Operations _operation = CalculatorOperation.Operations.Plus;

    /// <summary>
    /// Event for data binding with user.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Property that notifies of its change.
    /// </summary>
    public string Message
    {
        get => _message;

        private set
        {
            _message = _message == "-0" ? "0" : value;
            OnPropertyChanged("Message");
        }
    }

    /// <summary>
    /// Add digit to right operand of current operation.
    /// </summary>
    public void AddDigit(char digit)
    {
        if (!char.IsDigit(digit))
        {
            Message = _errorMessage;
        }

        if (_state == CalculatorStates.OperationHandling)
        {
            _state = CalculatorStates.TempValueHandling;
        }

        _tempValue = Math.Sign(_tempValue) >= 0 
            ? _tempValue * 10 + (digit - '0')
            : _tempValue * 10 - (digit - '0');
    }

    /// <summary>
    /// Adds a new operation and evaluates the previous one if it exists.
    /// </summary>
    public void AddOperation(string operation)
    {
        if (!_availableOperation.Contains(operation))
        {
            Message = _errorMessage;
        }

        else if (operation.Equals("+/-"))
        {
            if (_state == CalculatorStates.OperationHandling)
            {
                _result = CalculatorOperation.Calculate(CalculatorOperation.Operations.ChangeSign, _result);
                Message = Math.Round(_result, 5).ToString();
            }
            else
            {
                _tempValue = (int)CalculatorOperation.Calculate(CalculatorOperation.Operations.ChangeSign, _tempValue);

            }
        }
        else
        {
            if (_state == CalculatorStates.TempValueHandling)
            {
                try
                {
                    _result = CalculatorOperation.Calculate(_operation, _result, _tempValue);
                    _tempValue = 0;
                    Message = _result.ToString();
                }
                catch (DivideByZeroException)
                {
                    Message = _errorMessage;
                }
            }

            _state = CalculatorStates.OperationHandling;
            _operation = operation switch
            {
                "+" => CalculatorOperation.Operations.Plus,
                "-" => CalculatorOperation.Operations.Minus,
                "*" => CalculatorOperation.Operations.Multiply,
                "/" => CalculatorOperation.Operations.Divide,
                _   => CalculatorOperation.Operations.Plus
            };


        }
    }

    /// <summary>
    /// Calculates current operation
    /// </summary>
    public void Calculate()
    {
        try
        {
            _result = CalculatorOperation.Calculate(_operation, _result, _tempValue);
            Message = Math.Round(_result, 5).ToString();

            _tempValue = 0;
            _state = CalculatorStates.OperationHandling;
            _operation = CalculatorOperation.Operations.Plus;
        }
        catch (Exception ex) when (ex is ArgumentException ||
                                   ex is DivideByZeroException)
        {
            Message = _errorMessage;
        }

    }

    /// <summary>
    /// Returns the calculator to its initial state.
    /// </summary>
    public void Clear()
    {
        _result = 0;
        _tempValue = 0;

        _state = CalculatorStates.TempValueHandling;
        _operation = CalculatorOperation.Operations.Plus;

        Message = "0";
    }

    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}