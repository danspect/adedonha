﻿// MIT License
// 
// Copyright (c) 2023 Daniel Aspect
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using adedonha.Data;
using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        // começando a cronometrar o tempo
        long stopwatch = Stopwatch.GetTimestamp();

        char[] alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var temas = new List<string>(){
            "profissôes","animais"  ,"cidades",
            "países"    ,"animais"  ,"comidas",
            "cores"     ,"marcas"   ,"carros",
            "planetas"  ,"personagens"
        };

        var data = new AppDbContext();
        // objeto que gera um número aleatório
        var rnd = new Random();
        // gerando uma letra aleatória
        var letraEscolhida = EscolherLetra(alfabeto, rnd);
        // escolhendo os temas
        var temasEscolhidos = EscolherTema(temas, rnd);

        Console.WriteLine($"Letra: {letraEscolhida}");
        Console.WriteLine($"Temas: {String.Join(", ", temasEscolhidos)}");
        // criando tabela no banco de dados (só criará se não existir)
        await data.CriarTabelaAsync();
        // inserindo dados na tabela
        await data.InserirAsync(temasEscolhidos, letraEscolhida);
        // imprimindo o tempo gasto para realisar as tarefas anteriores
        var tempoDecorrido = Stopwatch.GetElapsedTime(stopwatch);
        Console.WriteLine($"Tempo decorrido: {tempoDecorrido.Milliseconds}ms");
    }

    /// <summary>
    ///  Esta função seleciona uma letra para o jogo
    /// </summary>
    /// <param name="alfa">as letras possiveis</param>
    /// <param name="random">o objeto que gerará os "números aleatorios"</param>
    /// <returns>Um caractere (letra) aleatório</returns>

    static char EscolherLetra(char[] alfa, Random random)
    {
        char letra = alfa[random.Next(0, alfa.Length - 1)];
        return letra;
    }

    /// <summary>
    /// Esta função escolhe 4 temas para o jogo
    /// </summary>
    /// <param name="temas">os temas possiveis</param>
    /// <param name="random">o objeto que gerará os "números aleatorios"</param>
    /// <returns>Um array com 4 temas aleatorios</returns>

    static string[] EscolherTema(List<string> temas, Random random)
    {
        string[] temasSelecionados = new string[4];
        for(int i = 0; i < 4; i++)
        {
            temasSelecionados[i] = temas[random.Next(0, temas.Count - 1)];
        }
        return temasSelecionados;
    }
}