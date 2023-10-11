namespace lab3;

interface ICalcMethod
{
    public int AddNumbers(params int[] array);
    public int SubtractNumbers(int numberForSubtract, params int[] array);
    public int MultiplicationNumbers(params int[] array);
    public double DivisionNumbers(double number1, double number2);
}

public class CalcService : ICalcMethod
{
    public int AddNumbers(params int[] array)
    {
        int result = 0;
        foreach (var value in array)
        {
            result += value;
        }
        return result;
    }

    public int SubtractNumbers(int numberForSubtract, params int[] array)
    {
        int result = numberForSubtract;
        foreach (var value in array)
        {
            result -= value;
        }
        return result;
    }

    public int MultiplicationNumbers(params int[] array)
    {
        int result = 1;
        foreach (var value in array)
        {
            result *= value;
        }

        return result;
    }

    public double DivisionNumbers(double number1, double number2)
    {
        if (number2 != 0)
        {
            return number1 / number2;
        }

        return -1;
    }
}