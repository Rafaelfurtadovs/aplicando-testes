using FluentAssertions;
using Moq;

namespace ConsultaCredito.MockTests;

public class AnaliseCreditoTests
{
    [Fact]
    public void Analisar_DeveAprovarCredito_QuandoScoreForSuficienteEValorEstiverNoLimite()
    {
        var servicoConsultaCredito = new Mock<IServicoConsultaCredito>();
        servicoConsultaCredito
            .Setup(servico => servico.ConsultarScore("12345678900"))
            .Returns(720);
        var analiseCredito = new AnaliseCredito(servicoConsultaCredito.Object);

        var resultado = analiseCredito.Analisar("12345678900", 5000);

        resultado.Aprovado.Should().BeTrue();
        resultado.Motivo.Should().Be("Credito aprovado");
        resultado.Score.Should().Be(720);
        servicoConsultaCredito.Verify(servico => servico.ConsultarScore("12345678900"), Times.Once);
    }

    [Fact]
    public void Analisar_DeveReprovarCredito_QuandoScoreForInsuficiente()
    {
        var servicoConsultaCredito = new Mock<IServicoConsultaCredito>();
        servicoConsultaCredito
            .Setup(servico => servico.ConsultarScore("98765432100"))
            .Returns(420);
        var analiseCredito = new AnaliseCredito(servicoConsultaCredito.Object);

        var resultado = analiseCredito.Analisar("98765432100", 3000);

        resultado.Aprovado.Should().BeFalse();
        resultado.Motivo.Should().Be("Score insuficiente para aprovacao");
        resultado.Score.Should().Be(420);
        servicoConsultaCredito.Verify(servico => servico.ConsultarScore("98765432100"), Times.Once);
    }
}
