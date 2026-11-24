using LojaApi.Model;
using LojaApi.Repositories;

namespace LojaApi.Services;

public class ProdutoService
{
    private readonly ProdutoRepository _produtoRepository;

    public ProdutoService(ProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<List<Produto>> ListarAsync()
    {
        return await _produtoRepository.ListarAsync();
    }
}