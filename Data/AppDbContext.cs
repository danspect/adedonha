// MIT License
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace adedonha.Data;

public class AppDbContext
{
    /// <summary>
    /// Caso não tiver nenhum banco de dados, esta função cria um banco
    /// de dados com uma tabela que armazena o resultado das partidas
    /// </summary>

    public async Task AsyncCriarTabela()
    {
        // criando conexão com o banco de dados
        using (var conexao = new SqliteConnection("Data Source=Data/partidas.db"))
        {
            await conexao.OpenAsync();

            var comando = conexao.CreateCommand();
            comando.CommandText =
            @"
                    CREATE TABLE IF NOT EXISTS Partidas(
                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Letra TEXT NOT NULL,
                    Temas TEXT NOT NULL
                    );
            ";
            await comando.ExecuteNonQueryAsync();
        }
    }

    /// <summary>
    /// Esta função insere os dados das partidas anteriores no banco de dados
    /// </summary>
    /// <param name="temas">os 4 temas selecionados</param>
    /// <param name="letra">a letra selecionada</param>

    public async Task AsyncInserir(string[] temas, char letra)
    {
        using (var conexao = new SqliteConnection("Data Source=Data/partidas.db"))
        {
            await conexao.OpenAsync();

            var comando = conexao.CreateCommand();
            comando.CommandText =
            @$"
                INSERT INTO Partidas (Letra, Temas)
                VALUES ($letra, $temas)
            ";
            comando.Parameters.AddWithValue("$letra", letra);
            comando.Parameters.AddWithValue("$temas", String.Join(", ", temas));
            await comando.ExecuteNonQueryAsync();
        }
    }
}