namespace LojaApi.Model;

public class Produto
{
    private int _idProduto;
    private string _nome = "";
    private decimal _preco;
    private int _quantidadeEstoque;

    public Produto(
        int idProduto,
        string nome,
        decimal preco,
        int quantidadeEstoque)
    {
        this.IdProduto = idProduto;
        this.Nome = nome;
        this.Preco = preco;
        this.QuantidadeEstoque = quantidadeEstoque;
    }

    public int IdProduto
    {
        get
        {
            return _idProduto;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "O identificador deve ser maior que zero."
                );
            }

            _idProduto = value;
        }
    }

    public string Nome
    {
        get
        {
            return _nome;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 2)
            {
                throw new ArgumentException(
                    "O nome do produto deve possuir pelo menos dois caracteres."
                );
            }

            _nome = value.Trim();
        }
    }

    public decimal Preco
    {
        get
        {
            return _preco;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "O preço deve ser maior que zero."
                );
            }

            _preco = value;
        }
    }

    public int QuantidadeEstoque
    {
        get
        {
            return _quantidadeEstoque;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "A quantidade em estoque não pode ser negativa."
                );
            }

            _quantidadeEstoque = value;
        }
    }
}