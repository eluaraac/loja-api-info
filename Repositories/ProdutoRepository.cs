using LojaApi.Data;
using LojaApi.Model;
using Npgsql;

namespace LojaApi.Repositories;

public class ProdutoRepository
{
    private readonly ConexaoBanco _conexaoBanco;

    public ProdutoRepository(ConexaoBanco conexaoBanco)
    {
        _conexaoBanco = conexaoBanco;
    }

    public async Task<List<Produto>> ListarAsync()
    {
        List<Produto> produtos = new();

        await using NpgsqlConnection conexao =
            await _conexaoBanco.CriarConexaoAsync();

        string sql = """
            SELECT
                id_produto,
                nome,
                preco,
                quantidade_estoque
            FROM produto
            ORDER BY nome;
            """;

        await using NpgsqlCommand comando =
            new NpgsqlCommand(sql, conexao);

        await using NpgsqlDataReader leitor =
            await comando.ExecuteReaderAsync();

        while (await leitor.ReadAsync())
        {
            Produto produto = new Produto(
                leitor.GetInt32(leitor.GetOrdinal("id_produto")),
                leitor.GetString(leitor.GetOrdinal("nome")),
                leitor.GetDecimal(leitor.GetOrdinal("preco")),
                leitor.GetInt32(leitor.GetOrdinal("quantidade_estoque"))
            );

            produtos.Add(produto);
        }

        return produtos;
    }
}