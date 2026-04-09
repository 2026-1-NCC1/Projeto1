using System;
using System.Threading;

public class Program

{
    static int pontos = 0;
    static int energia = 100;

    public static void Main()
    {
        Fase1();
    }

    public static void Fase1()
    {
        // pergunta 1
        Console.WriteLine("""
            1 - Quem foi a primeira pessoa a viajar no Espaço?
                [a] Yuri Gagarin
                [b] A cadela Laika
                [c] Neil Armstrong
            Digite sua resposta:
        """);
        string resposta = Console.ReadLine().ToLower();
        AtualizarPontuacaoEnergia("a", resposta);

        // pergunta 2
        Console.WriteLine("""
            2 - Quando tempo a luz do Sol demora para chegar na Terra?
                [a] 1 minuto
                [b] 5 minutos
                [c] 8 minutos
            Digite sua resposta:
        """);
        resposta = Console.ReadLine().ToLower();
        AtualizarPontuacaoEnergia("c", resposta);
    }
    
    public static void AtualizarPontuacaoEnergia(string respostaCerta, string respostaJogador)
    {
        if (respostaJogador != respostaCerta)
        {
            energia--;
        }
        else
        {
            pontos++;
        }

        MostrarPontuacaoEnergia();
    }
    public static void MostrarPontuacaoEnergia()
    {
        Console.WriteLine($"""
            Pontuação: {pontos}
            Energia: {energia}
        """);
    }
}