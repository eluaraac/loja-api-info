
using System;
using System.Collections.Generic;

namespace LojaApi.Model;

/* 
    Representa uma venda realizada pela aplicação.

    A entidade Venda concentra os dados principais
    da operação de venda e protege o estado do objeto
    por meio de propriedades com validação.

    Ela também mantém em memória a lista de itens
    associados à venda.

    Essa classe não executa comandos SQL
    e não acessa diretamente o banco de dados.
*/
public class Venda
{
    private int _idVenda;
    private DateTime _dataHora;
    private decimal _valorTotal;
    private bool _ativa;

    /*
        Armazena os itens associados à venda.

        List<ItemVenda> permite manter vários itens
        dentro de um único objeto Venda.
    */
    private readonly List<ItemVenda> _itens = new();

    /*
        Construtor utilizado para criar uma nova venda.
    */
    public Venda(decimal valorTotal)
    {
        this.DataHora = DateTime.Now;
        this.ValorTotal = valorTotal;
        this.Ativa = true;
    }

    /*
        Construtor utilizado para criar uma venda
        com dados que já existem no banco.
    */
    public Venda(
        int idVenda,
        DateTime dataHora,
        decimal valorTotal,
        bool ativa)
    {
        this.IdVenda = idVenda;
        this.DataHora = dataHora;
        this.ValorTotal = valorTotal;
        this.Ativa = ativa;
    }

    /*
        Identificador da venda.
    */
    public int IdVenda
    {
        get
        {
            return _idVenda;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "O identificador não pode ser negativo."
                );
            }

            _idVenda = value;
        }
    }

    /*
        Data e horário em que a venda foi registrada.
    */
    public DateTime DataHora
    {
        get
        {
            return _dataHora;
        }

        private set
        {
            if (value > DateTime.Now.AddMinutes(1))
            {
                throw new ArgumentException(
                    "A data da venda não pode ser futura."
                );
            }

            _dataHora = value;
        }
    }

    /*
        Valor total da venda.
    */
    public decimal ValorTotal
    {
        get
        {
            return _valorTotal;
        }

        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "O total deve ser maior que zero."
                );
            }

            _valorTotal = value;
        }
    }

    /*
        Indica se a venda está ativa.
    */
    public bool Ativa
    {
        get
        {
            return _ativa;
        }

        private set
        {
            _ativa = value;
        }
    }

    /*
        Disponibiliza os itens da venda
        apenas para consulta.
    */
    public IReadOnlyList<ItemVenda> Itens
    {
        get
        {
            return _itens.AsReadOnly();
        }
    }

    /*
        Adiciona um ItemVenda à venda.
    */
    public void AdicionarItem(ItemVenda item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(
                nameof(item),
                "O item da venda não pode ser nulo."
            );
        }

        _itens.Add(item);
    }
}
