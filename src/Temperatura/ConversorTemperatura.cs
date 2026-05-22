namespace Temperatura;

public static class ConversorTemperatura
{
    public static double FahrenheitParaCelsius(double fahrenheit)
    {
        return Math.Round((fahrenheit - 32) / 1.8, 2);
    }
}
