using System.Data.Common;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private int quantidadeVagas = 255;
        private int contadorVagas = 0;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            if (contadorVagas < quantidadeVagas)
            {
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                string placa = Console.ReadLine();
                this.veiculos.Add(placa);
                this.contadorVagas += 1;
            }
            else
            {
                Console.WriteLine("O estacionamento esta cheio");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            Console.WriteLine("Digite a placa do veículo que deve ser removido:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                string numero = Console.ReadLine();
                int horas = Convert.ToInt32(numero);

                Console.WriteLine("Digite o preço por hora gasta no estacionamento: ");
                decimal valorTotal = precoInicial + precoPorHora * horas;

                
                this.veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                this.contadorVagas -= 1;
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
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Vaga: {i} Veiculo: {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ConsultarCapacidade()
        {
            if (veiculos.Any())
            {
                if (this.contadorVagas < this.quantidadeVagas)
                {
                    Console.WriteLine($" Total de vagas: {this.quantidadeVagas} Vagas ocupadas: {this.contadorVagas}");
                    Console.WriteLine($"Vagas disponiveis: {this.quantidadeVagas - this.contadorVagas}");
                }
                else
                {
                    Console.WriteLine("O estacionamento está cheio");
                }
            }
            else
            {
                Console.WriteLine("O estacionamento esta vazio");
            }
        }
    }
}
