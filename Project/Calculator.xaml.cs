namespace Project;

public partial class Calculator : ContentPage
{
    double firstValue = 0.0, secondValue = 0.0;
    string op;
    string entry = "";

    enum States
    {
        InputedFirstValue,
        InputedOperator,
        InputedSecondValue,
        InputedShowingResult
    };

    States state = States.InputedShowingResult;

    public Calculator()
    {
        InitializeComponent();
    }


    void OnDigitSelected(object sender, EventArgs e)
    {

        Button selectedButton = sender as Button;
        if (state == States.InputedShowingResult)
        {
            OperationLabel.Text = "";
            entry = "";

            firstValue = 0;
            secondValue = 0;
            op = "";

            state = States.InputedFirstValue;
        }
        else if (state == States.InputedOperator)
        {
            state = States.InputedSecondValue;
        }
        if (entry == "0" && selectedButton.Text != ",") entry = "";

        if (entry.Length < 10)
        {
            entry += selectedButton.Text;
            EntryAndResultLabel.Text = entry;
        }

    }


    void OnDelSelected(object sender, EventArgs e)
    {
        if (!(state == States.InputedOperator && entry == "") && state != States.InputedShowingResult)
        {
            if (entry.Length == 1)
            {
                entry = "0";
            }
            else
            {
                entry = entry.Substring(0, entry.Length - 1);
            }
            EntryAndResultLabel.Text = entry;
        }

    }


    void OnOperatorSelected(object sender, EventArgs e)
    {
        Console.WriteLine(firstValue);
        Console.WriteLine(secondValue);

        Button selectedButton = sender as Button;
        op = selectedButton.Text;

        if (state == States.InputedOperator)
        {
            OperationLabel.Text = OperationLabel.Text.Substring(0, OperationLabel.Text.Length - 1);
        }

        state = States.InputedOperator;

        OperationLabel.Text = entry + op;
        firstValue = Convert.ToDouble(entry);
        Console.WriteLine("ENTRY: " + entry);

        entry = "";

        Console.WriteLine(firstValue);
        Console.WriteLine(secondValue);

    }


    double _calculate(double first, double second, string op)
    {
        switch (op)
        {
            case "+":
                return first + second;
            case "-":
                return first - second;
            case "*":
                return first * second;
            case "/":
                return first / second;
            default: throw new NotImplementedException();
        }
    }


    void OnCalculateSelected(object sender, EventArgs e)
    {

        if (state == States.InputedFirstValue || state == States.InputedShowingResult && op == "")
        {
            OperationLabel.Text = entry;
        }
        else
        {
            if (state == States.InputedOperator)
            {
                OperationLabel.Text = firstValue.ToString() + op + firstValue.ToString();
                secondValue = firstValue;

            }
            else if (state == States.InputedSecondValue)
            {
                OperationLabel.Text += entry;
                secondValue = Convert.ToDouble(entry);
            }
            else
            {
                OperationLabel.Text = entry + op + secondValue.ToString("");

            }

            firstValue = _calculate(firstValue, secondValue, op);
            if (Math.Abs(firstValue - Convert.ToInt32(firstValue)) == 0)
            {
                entry = Convert.ToInt32(firstValue).ToString("F0");

            }
            else
            {
                entry = firstValue.ToString("F");

                if (entry[entry.Length - 1] == '0')
                {
                    while (entry.Length != 0 && entry[entry.Length - 1] == '0')
                    {
                        entry = entry.Substring(0, entry.Length - 1);
                    }
                }


            }


        }

        OperationLabel.Text += "=";
        state = States.InputedShowingResult;

        EntryAndResultLabel.Text = entry;
    }


    void OnCSelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue)
        {
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            OperationLabel.Text = "";
        }
        else if (state == States.InputedSecondValue)
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }
        else
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }

        entry = "0";
        EntryAndResultLabel.Text = "0";

    }


    void OnCESelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue)
        {
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator || state == States.InputedSecondValue)
        {
            state = States.InputedSecondValue;
        }
        else
        {
            firstValue = 0;
            state = States.InputedShowingResult;
            secondValue = 0;
            OperationLabel.Text = "";
        }

        entry = "0";
        EntryAndResultLabel.Text = "0";
    }


    void OnChangeSignSelected(object sender, EventArgs e)
    {

        if (entry.Length > 0 && entry[0] == '-')
        {
            entry = entry.Substring(1);
        }
        else
        {
            entry = "-" + entry;
        }
        EntryAndResultLabel.Text = entry;

        if (state == States.InputedShowingResult)
        {
            OperationLabel.Text = $"negate({entry})";
        }
    }


    void OnDivisionByXSelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "1/" + entry + "=";
            entry = (1 / Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = (1 / firstValue);

            entry = secondValue.ToString();

            EntryAndResultLabel.Text = entry;


            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = (1 / Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }

    }


    void OnSquareXSelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = entry + "^2=";
            entry = (Convert.ToDouble(entry) * Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = (firstValue * firstValue);

            entry = secondValue.ToString();

            EntryAndResultLabel.Text = entry;

            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Convert.ToDouble(EntryAndResultLabel.Text) * Convert.ToDouble(EntryAndResultLabel.Text);
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }

    }


    void OnSqrtXSelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "sqrt(" + entry + ")=";
            entry = Math.Sqrt(Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = Math.Sqrt(firstValue);

            entry = secondValue.ToString();

            EntryAndResultLabel.Text = entry;


            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Math.Sqrt(Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    void OnPercentSelected(object sender, EventArgs e)
    {
        if (state == States.InputedOperator)
        {
            secondValue = firstValue * firstValue / 100;
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
        else if (state == States.InputedSecondValue)
        {
            secondValue = Convert.ToDouble(entry) * firstValue / 100;
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }


    void OnTwoInXSelected(object sender, EventArgs e)
    {
        if (state == States.InputedFirstValue || state == States.InputedShowingResult)
        {
            OperationLabel.Text = "2^" + entry + "=";
            entry = Math.Pow(2, Convert.ToDouble(entry)).ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedShowingResult;
        }
        else if (state == States.InputedOperator)
        {
            secondValue = Math.Pow(2, firstValue);

            entry = secondValue.ToString();

            EntryAndResultLabel.Text = entry;


            state = States.InputedSecondValue;
        }
        else
        {
            secondValue = Math.Pow(2, Convert.ToDouble(EntryAndResultLabel.Text));
            entry = secondValue.ToString();
            EntryAndResultLabel.Text = entry;
            state = States.InputedSecondValue;
        }
    }
}