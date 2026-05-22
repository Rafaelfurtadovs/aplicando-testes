using Temperatura;

namespace Temperatura.UnitTests;

public class ConversorTemperaturaTests
{
    [Theory]
    [InlineData(32, 0)]
    [InlineData(212, 100)]
    [InlineData(-40, -40)]
    [InlineData(98.6, 37)]
    public void FahrenheitParaCelsius_DeveConverterTemperaturas(double fahrenheit, double celsiusEsperado)
    {
        var resultado = ConversorTemperatura.FahrenheitParaCelsius(fahrenheit);

        Assert.Equal(celsiusEsperado, resultado);
    }
}
