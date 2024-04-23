using System.Text.Json;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

string arquivoConfig = "config.json";
Valores valores;
if (!File.Exists(arquivoConfig))
{
    valores = new Valores();
    DefinirValores();
    string config = JsonSerializer.Serialize(valores);
    File.WriteAllText(arquivoConfig, config);
}
else
{
    string config = File.ReadAllText(arquivoConfig);
    valores = JsonSerializer.Deserialize<Valores>(config);
}

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(valores.PrecoInicial, valores.PrecoPorHora);

string arquivoVeiculos = "veiculos.txt";
if (File.Exists(arquivoVeiculos))
{
    es.CarregarVeiculos(arquivoVeiculos);
}

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Mudar configuração");
    Console.WriteLine("5 - Encerrar");

    string opcao = Console.ReadLine().Trim();
    switch (opcao)
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;
        
        case "4":
            DefinirValores();
            string config = JsonSerializer.Serialize(valores);
            File.WriteAllText(arquivoConfig, config);
            es.PrecoInicial = valores.PrecoInicial;
            es.PrecoPorHora = valores.PrecoPorHora;
            break;

        case "5":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadKey();
    Console.WriteLine();
}

es.SalvarVeiculos(arquivoVeiculos);
Console.WriteLine("O programa se encerrou");

void DefinirValores()
{
    Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                      "Digite o preço inicial:");
    valores.PrecoInicial = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Agora digite o preço por hora:");
    valores.PrecoPorHora = Convert.ToDecimal(Console.ReadLine());
}

struct Valores
{
    public decimal PrecoInicial { get; set; }
    public decimal PrecoPorHora { get; set; }
}
