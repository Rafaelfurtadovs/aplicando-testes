namespace ConsultaCredito;

public class AnaliseCredito
{
    private readonly IServicoConsultaCredito _servicoConsultaCredito;

    public AnaliseCredito(IServicoConsultaCredito servicoConsultaCredito)
    {
        _servicoConsultaCredito = servicoConsultaCredito;
    }

    public ResultadoAnaliseCredito Analisar(string cpf, decimal valorSolicitado)
    {
        var score = _servicoConsultaCredito.ConsultarScore(cpf);

        if (score < 600)
        {
            return new ResultadoAnaliseCredito(false, "Score insuficiente para aprovacao", score);
        }

        if (valorSolicitado > 10000)
        {
            return new ResultadoAnaliseCredito(false, "Valor solicitado excede o limite automatico", score);
        }

        return new ResultadoAnaliseCredito(true, "Credito aprovado", score);
    }
}
