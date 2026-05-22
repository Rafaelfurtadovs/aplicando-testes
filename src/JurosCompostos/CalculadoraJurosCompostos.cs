namespace JurosCompostos;

public static class CalculadoraJurosCompostos
{
    public static decimal Calcular(decimal valorInicial, decimal taxaMensalPercentual, int meses)
    {
        var taxa = 1 + (double)(taxaMensalPercentual / 100);
        var montante = (double)valorInicial * Math.Pow(taxa, meses);

        return Math.Round((decimal)montante, 2);
    }
}
