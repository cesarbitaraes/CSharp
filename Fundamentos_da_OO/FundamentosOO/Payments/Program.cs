
namespace Payments;

public class Program
{
    static void RealizarPagamento(double valor)
    {
        Console.WriteLine($"Pago o valor de {valor}.");
    }

    // Classes estáticas não podem ser instanciadas.
    static void Main(string[] args)
    {
        // O objeto (customer) é um tipo de referência. Armazena apenas o endereço. Fica armazenado na memória heap.
        // Tipos de valor são armazenados na memória stack, que é mais rápida.
        var customer = new Customer();

        var pagamentoBoleto = new PagamentoBoleto(DateTime.Today);
        pagamentoBoleto.Pagar("123456"); // Herança
        pagamentoBoleto.Vencimento = DateTime.Now; // Herança
        pagamentoBoleto.NumeroBoleto = "123456";

        // var pagamento = new Pagamento();
        // pagamento.Dispose();

        using (var pagamento = new Pagamento()) // É o mesmo que usar o Dispose acima.
        {
            Console.WriteLine("Processando o pagamento.");
        }

        var payment = new Payment();
        payment.PropriedadeA = "";
        payment.PropriedadeB = "";

        var pessoa = new Pessoa(1, "César");
        pessoa = new PessoaFisica(2, "André"); // Uma pessoa física também é uma pessoa. Isso é chamado Upcast.

        var pessoaFisica = new PessoaFisica(4, "João");
        pessoaFisica = (PessoaFisica)pessoa; // Downcast

        // Comparando objetos
        var pessoaA = new Pessoa(1, "André");
        var pessoaB = new Pessoa(1, "André");

        Console.WriteLine(pessoaA ==
                          pessoaB); // Falso, pois os objetos são tipos de referência. Os endereços são diferentes.
        Console.WriteLine(pessoaA.Equals(pessoaB)); // True depois da implementação da classe IEquatable.

        // Delegates (Anonymous Methods)
        var pagar = new NovoPagamento.Pagar(RealizarPagamento);
        pagar(25);

        Events.Main2(new[] { "" });

        // Listas

        // var payments = new List<Payment>(); // ICollection, IEnumerable. List é mais completo, tem mais módulos. IEnumerable é mais restrito.
        IList<NewPayment> payments = new List<NewPayment>();
        payments.Add(new NewPayment(1));
        payments.Add(new NewPayment(2));
        payments.Add(new NewPayment(3));
        payments.Add(new NewPayment(4));
        payments.Add(new NewPayment(5));

        foreach (var novoPagamento in payments)
        {
            Console.WriteLine(novoPagamento.Id);
        }

        var paidPayments = new List<NewPayment>();
        paidPayments.AddRange(payments);

        var buscaPagamento =
            payments.First(x => x.Id == 3); // Where traz um Enumerable. Para trazer um item pode-se usar o First.
        // First retorna erro caso não encontre. FirstOrDefault retorna nulla caso não encontre.

        payments.Remove(buscaPagamento);

        payments.Clear(); // Limpa a lista
        var exists = payments.Any(x => x.Id == 3); // Retorna true caso exista um pagamento com Id = 3.
        payments.Skip(1); // Pula 1 pagamento.
        payments.Take(3); // Pega 3 pagamentos.

        payments.AsEnumerable(); // Converte para IEnumerable. Para converter para lista usar o ToList().
    }
}


class Customer
{
    public string Name { get; set; }
}

public class Pagamento : IDisposable, IPagamento
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

    public Pagamento()
    {
        Console.WriteLine("Iniciando o pagamento.");
    }
    
    // Toda classe ou struct criados representam um novo tipo complexo.
    
    // Propriedades
    public DateTime Vencimento { get; set; } // get e set são chamados de acessores
    public void Pagar(double valor)
    {
    }

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

    public void Dispose()
    {
        Console.WriteLine("Finalizando o pagamento.");
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

// A classe estática será a mesma para todos os usuários da aplicação.
public static class Settings
{
    public static string API_URL { get; set; }
}

// Classes seladas (sealed): não podem ser extendidas, ninguém poderá herdar delas.
// Interfaces: são contratos.

public interface IPagamento
{
    DateTime Vencimento { get; set; }

    void Pagar(double valor);
}

// Classes abstratas não podem ser instanciadas. Quando eu tenho uma classe Pagamento e várias outras como PagamentoBoleto
// e PagamentoCartaoCredito que herdam dela, Pagamento deve ser uma classe abstrata. Classes bases podem ter implementações
// de métodos, diferente de interfaces.

public class Pessoa : IEquatable<Pessoa>
{
    public string Nome { get; set; }
    public int Id { get; set; }

    public Pessoa(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public bool Equals(Pessoa other)
    {
        return Nome == other.Nome && Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Pessoa)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nome, Id);
    }
}

public class PessoaFisica : Pessoa
{
    public string CPF { get; set; }
    public PessoaFisica(int id, string nome) : base(id, nome)
    {
    }
}

public class PessoaJuridica : Pessoa
{
    public string CNPJ { get; set; }

    public PessoaJuridica(int id, string nome) : base(id, nome)
    {
        
    }
}

// Delegates
public class NovoPagamento
{
    public delegate void Pagar(double valor);
}