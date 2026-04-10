using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        Lore();

        int energia = 10;

        while (true)
        {
            int pontos = 0;
            int erros = 0;

            if (Desitir())
            {
                break;
            }

            // Pergunta 1
            Console.WriteLine("""

            [QUESTÃO 01]
            Quem foi a primeira pessoa a viajar ao Espaço?
                [a] Yuri Gagarin
                [b] A cadela Laika
                [c] Neil Armstrong
            """);
            string resposta = DefinirResposta();
            (pontos, erros) = AtualizarPontuacaoErros("a", resposta, pontos, erros);
            if (Desitir())
            {
                break;
            }

            // Pergunta 2
            Console.WriteLine("""

            [QUESTÃO 02]
            Quais são os respectivos valores de X e Y do Sistema de Equações abaixo?
                {𝑥 + 𝑦 =  20
                {2𝑥 − 𝑦 =  10
                
                [a] 𝑥 = 4, 𝑦 = 5
                [b] 𝑥 = 3, 𝑦 = 2/5
                [c] 𝑥 = 10, 𝑦 = 10
            """);
            resposta = DefinirResposta();
            (pontos, erros) = AtualizarPontuacaoErros("c", resposta, pontos, erros);
            if (Desitir())
            {
                break;
            }

            // Pergunta 3
            Console.WriteLine("""

            [QUESTÃO 03]
            A Luz do Sol demora quando tempo para chegar à Terra?
                [a] 1 minuto
                [b] 8 minutos
                [c] 5 minutos
            """);
            resposta = DefinirResposta();
            (pontos, erros) = AtualizarPontuacaoErros("b", resposta, pontos, erros);

            Console.WriteLine($"Você conseguiu {pontos}/3");

            // se o jogador acertar tudo, ele ganha e o programa acaba
            if (pontos == 3)
            {
                Console.WriteLine("[Fantasma] Parabéns, você conseguiu...Pode sair");
                break;
            }

            energia -= erros;

            // se a energia do jogador acabar, ele perde e o programa acaba
            if (energia <= 0)
            {
                Console.WriteLine("Sua energia acabou...");
                break;
            }

            Console.WriteLine($"""

            Você perdeu {erros} de energia
                Energia: {energia}
            """);
        }
    }

    // função para contabilizar pontos e erros do jogador
    public static (int, int) AtualizarPontuacaoErros(string respostaCerta, string respostaJogador, int pontos, int erros)
    {
        if (respostaJogador != respostaCerta)
        {
            erros++;
        }
        else
        {
            pontos++;
        }

        return (pontos, erros);
    }

    // função para verificar se o jogador deseja desistir
    public static bool Desitir()
    {
        Console.WriteLine("\nDeseja desistir?\n[1] Sim\nPressione qualquer outra tecla para continuar");
        string input = Console.ReadLine();

        if (input == "1")
        {
            Console.WriteLine("[Rádio] Você desistiu..Bom, boa sorte para passar a noite!");
            return true;
        }
        return false;
    }

    // função para apresentar o contexto ao jogador
    public static void Lore()
    {
        Console.WriteLine("[Você] ZzzzZzzzz...");
        Console.ReadLine();
        Console.WriteLine("[Rádio] EII, ACORDA!");
        Console.ReadLine();
        Console.WriteLine("[Você] 👀");
        Console.ReadLine();
        Console.Write("[Rádio] Parece que você dormiu no laboratório...Qual é o seu nome?");
        string nomeJogador = DefinirNomeJogador();
        Console.WriteLine($"[Rádio] Certo, {nomeJogador}...Como você pode perceber já anoiteceu. Para o seu azar, esse laboratório é assombrado pelo fantasma de um professor que tinha muito apego por esse lugar há muuuuitos anos. Só ele pode deixar você sair daí..");
        Console.ReadLine();
        Console.WriteLine($"[{nomeJogador}] E como que eu saio daqui?!");
        Console.ReadLine();
        Console.WriteLine($"[Rádio] Você tem que fazer uma prova, mas cuidado... A cada questão que você erra, ele suga pontos da sua energia vital até você ficar sem.. Se você acertar tudo, ele te deixa sair. Você pode tentar quantas vezes quiser, mas cuidado para não deixar ele sugar todos os pontos da sua energia.");
        Console.ReadLine();
        Console.WriteLine($"[{nomeJogador}] E se eu não souber nada?!");
        Console.ReadLine();
        Console.WriteLine($"[Rádio] Você pode desistir a qualquer momento da prova ou nem faze-la, mas você terá que esperar amanhecer o dia para alguém destrancar o laboratório. Bom, eu não recomendo desistir, você não gostaria de passar a noite com um fantasma te rodeando, mas enfim você quem sabe...");
    }

    // função para validar e definir nome do jogador
    public static string DefinirNomeJogador()
    {
        Console.Write("\nDigite seu nome: ");
        string nomeJogador = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeJogador) || nomeJogador.Any(char.IsDigit))
        {
            Console.Write("O nome não pode ser vazio ou conter números!\nDigite seu nome novamente: ");
            nomeJogador = Console.ReadLine();
        }

        return nomeJogador;
    }

    // função para validar e definir a resposta
    public static string DefinirResposta()
    {
        Console.Write("Escolha entre a, b ou c.\nDigite sua resposta: ");
        string resposta = Console.ReadLine().ToLower();

        string[] alternativasValidas = { "a", "b", "c" };
        while (!alternativasValidas.Contains(resposta))
        {
            Console.Write("\nResposta inválida! Escolha entre a, b ou c: ");
            resposta = Console.ReadLine().ToLower();
        }

        return resposta;
    }
}