using System.ComponentModel;

namespace SimpleCalculator;

public class Calculator: INotifyPropertyChanged
{
    private enum CalculatorStates
    {
        OperationHanding,
        TempValueHandling
    }

    private double _result = 0;
    private int _tempValue = 0;
    private CalculatorStates _state = CalculatorStates.TempValueHandling;
    private CalculatorOperation.Operations _operation = CalculatorOperation.Operations.Plus;

    public event PropertyChangedEventHandler? PropertyChanged;

    public double Result
    {
        get => _result;

        set
        {
            _result = value;
            OnPropertyChanged(nameof(Result));
        }
    }

    public void AddDigit(char digit)
    {
        if (!char.IsDigit(digit))
        {
            throw new ArgumentException("Argument must be a digit !");
        }

        _tempValue = _tempValue * 10 + digit - '0';

        if (_state == CalculatorStates.OperationHanding)
        {
            _state = CalculatorStates.TempValueHandling;
        }
    }

    public void AddOperation(string operation)
    {
        if (operation.Equals("+/-"))
        {
            if (_state == CalculatorStates.OperationHanding)
            {
                Result = CalculatorOperation.Calculate(CalculatorOperation.Operations.ChangeSign, _result);
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
                Result = CalculatorOperation.Calculate(_operation, _result, _tempValue);
                _tempValue = 0;
            }

            _operation = operation switch
            {
                "+" => CalculatorOperation.Operations.Plus,
                "-" => CalculatorOperation.Operations.Minus,
                "*" => CalculatorOperation.Operations.Multiply,
                "/" => CalculatorOperation.Operations.Divide,
                _   => throw new ArgumentException("Operation  must be one of these: +, -, *, /, +/-")
            };
        }
    }

    public void Calculate()
    {
        if (_state == CalculatorStates.OperationHanding)
        {
            Result = CalculatorOperation.Calculate(_operation, _result, _result);
        }
        else
        {
            Result = CalculatorOperation.Calculate(_operation, _result, _tempValue);
            _tempValue = 0;
            _state = CalculatorStates.OperationHanding;
        }

        _operation = CalculatorOperation.Operations.Plus;
    }

    public void Clear()
    {
        Result = 0;
        _tempValue = 0;

        _state = CalculatorStates.TempValueHandling;
        _operation = CalculatorOperation.Operations.Plus;
    }

    private void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
