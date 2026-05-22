using System.Globalization;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace JurosCompostos.SpecFlowTests.Steps;

[Binding]
public sealed class JurosCompostosSteps
{
    private decimal _valorInicial;
    private decimal _taxaMensal;
    private decimal _montanteFinal;

    [Given(@"que o valor inicial e (.*)")]
    public void DadoQueOValorInicialE(string valorInicial)
    {
        _valorInicial = ConverterDecimal(valorInicial);
    }

    [Given(@"que a taxa mensal e (.*)")]
    public void DadoQueATaxaMensalE(string taxaMensal)
    {
        _taxaMensal = ConverterDecimal(taxaMensal);
    }

    [When(@"calcular os juros por (.*) meses")]
    public void QuandoCalcularOsJurosPorMeses(int meses)
    {
        _montanteFinal = CalculadoraJurosCompostos.Calcular(_valorInicial, _taxaMensal, meses);
    }

    [Then(@"o montante final deve ser (.*)")]
    public void EntaoOMontanteFinalDeveSer(string montanteEsperado)
    {
        _montanteFinal.Should().Be(ConverterDecimal(montanteEsperado));
    }

    private static decimal ConverterDecimal(string valor)
    {
        return decimal.Parse(valor, CultureInfo.InvariantCulture);
    }
}
