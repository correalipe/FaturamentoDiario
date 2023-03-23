using System;
using Newtonsoft.Json;

public class Faturamento
{
    public int dia {get; set;}
    public double valor {get; set;}
}

class Program
{
    static void Main()
        //variables
    {
        double menorValor = 0, maiorValor = 0, mediaValor = 0, soma = 0;
        int diaSuperiorMedia = 0, menorDia = 0, maiorDia = 0, qtd = 0; 

        //Json Archive source and use
        string fileSource = @"C:\Users\SORAIA\source\repos\FaturamentoDiario\FaturamentoDiario\dados.json";
        string fileContent = File.ReadAllText(fileSource);

        var faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(fileContent);

        //task to find and show the lesser value, the greater value and the days that the value was greater than the average
        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor != 0)
            {
                if (menorValor == 0)
                {
                    menorValor = faturamento.valor;
                }
                else if (faturamento.valor < menorValor)
                {
                    menorValor = faturamento.valor;
                    menorDia = faturamento.dia;
                }

                if (maiorValor == 0)
                {
                    maiorValor = faturamento.valor;
                }
                else if (faturamento.valor > maiorValor)
                {
                    maiorValor = faturamento.valor;
                    maiorDia = faturamento.dia;
                }

                soma += faturamento.valor;
                qtd++;

            }

        }
        mediaValor = (soma / qtd);

        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor > mediaValor)
            {
                diaSuperiorMedia++;
            }
        }

        Console.WriteLine("\t\t\tCálculo de Faturamento\n\tMenor valor de faturamento: {0}, referente ao dia: {1}\n" +
            "\tMaior valor de faturamento: {2}, referente ao dia: {3}\n" +
            "\tQuantidade de dias em que o faturamento foi superior a média mensal: {4}", menorValor, menorDia, maiorValor, maiorDia, diaSuperiorMedia);

        Console.ReadLine();
    }
}
