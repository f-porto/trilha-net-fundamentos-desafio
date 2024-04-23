namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private static string LerPlaca(string mensagem)
        {
            while (true)
            {
                Console.WriteLine(mensagem);
                string placa = Console.ReadLine().Trim().ToUpper();
                if (placa.Length > 0)
                {
                    return placa;
                }
                Console.WriteLine("Por favor digite a placa do veículo");
            }
        }

        public void AdicionarVeiculo()
        {
            string placa = LerPlaca("Digite a placa do veículo para estacionar:");
            if (veiculos.Any(v => v == placa))
            {
                Console.WriteLine("Essa placa já foi registrada");
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo com placa '{placa}' for adicionado");
            }
        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = LerPlaca("Digite a placa do veículo para remover:");

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                string entrada = Console.ReadLine().Trim();
                while (!int.TryParse(entrada, out horas) || horas < 0)
                {
                    Console.WriteLine($"'{entrada}' não é um valor válido");
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    entrada = Console.ReadLine().Trim();
                }
                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
