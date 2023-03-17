
namespace Payments;

public class Program
{
    static void Main(string[] args)
    {
        // Todo objeto (customer) é um tipo de referência. Armazena apenas o endereço. Fica armazenado na memória heap.
        // Tipos de valor são armazenados na memória stack, que é mais rápida.
        var customer = new Customer();

        var pagamentoBoleto = new PagamentoBoleto(DateTime.Today);
        pagamentoBoleto.Pagar("123456"); // Herança
        pagamentoBoleto.Vencimento = DateTime.Now; // Herança
        pagamentoBoleto.NumeroBoleto = "123456";
    }
    
}

class Customer
{
    public string Name { get; set; }
}

class Pagamento
{ 
    /* Pilares da OO:
     Encapsulamento (primeiro pilar): agrupar o que faz sentido estar junto. Nesse caso é criar tudo o que é de pagamento dentro da sua classe.
     Abstração (segundo pilar): esconder tudo aquilo que a gente não precisa saber sobre o nosso objeto. Métodos privados são um exemplo.
     Herança (terceiro pilar): capacidade de um objeto herdar propriedades, métodos e eventos de outro objeto. C# não possui herança múltipla.
     Polimorfismo (quarto pilar): sobreescrita, sobrecarga de métodos (virtual no pai e override no filho). Capacidade do mesmo método se comportar
     de maneiras diferentes de acordo com o objeto.*/
    
    /*
     Modificadores de acesso:
     private: visível apenas dentro da classe. Quando não informado toda classe, propriedade ou método são privados;
     protected: visível apenas dentro da classe e em todos que a herdarem (filhos da classe);
     internal: visível apenas dentro do mesmo namespace, assembly;
     public: visível para todos.
    */
    public Pagamento(DateTime vencimento) // Construtor é um método que não retorna nada.
    {
        Console.WriteLine("Iniciando o pagamento.");
        DataPagamento = DateTime.Now;
    }
    
    // Toda classe ou struct criados representam uma novo tipo complexo.
    
    // Propriedades
    public DateTime Vencimento { get; set; } // get e set são chamados de acessores
    private Address BillingAddress;

    private DateTime _dataPagamento;
    public DateTime DataPagamento
    {
        get
        {
            Console.WriteLine("Lendo o valor");
            return _dataPagamento.AddDays(1);
        }

        set
        {
            Console.WriteLine("Atribuindo o valor.");
            _dataPagamento = value; // value: palavra reservada do set.
        }
    }

    // Métodos
    public virtual void Pagar(string numero) // virtual: sobreescrita de métodos
    {
        Console.WriteLine("Pagar");
    }

    // Sobrecarga de métodos: mesmo método mas com assinaturas diferentes.
    public void Pagar(string numero, DateTime vencimento, bool pagarAposVencimento = false)
    {
    }
    

    public override string ToString() //Polimorfismo
    {
        return Vencimento.ToString("MM/dd/yyyy");
    }

    private void ConsultarSaldoDoCartao()
    {
    }
}

class PagamentoBoleto : Pagamento
{
    public PagamentoBoleto(DateTime vencimento) : base(vencimento)
    {
        DataPagamento = DateTime.Now;
    }
    public string NumeroBoleto { get; set; }
    public override void Pagar(string numero) // Sobreescrita do método.
    {
        base.Pagar(numero);
        Console.WriteLine("Pagar boleto");
    }
}

class Address
{
    private string ZipCode;
}