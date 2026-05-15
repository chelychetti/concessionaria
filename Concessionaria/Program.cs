using System;
using System.Collections.Generic;

namespace Concessionaria
{
    // ==================== CLASSES ====================

    class Cliente
    {
        public int Id;
        public string Nome;
        public string Telefone;
        public string Email;
    }

    class Veiculo
    {
        public int Id;
        public string Marca;
        public string Modelo;
        public int Ano;
        public double Preco;
        public string Categoria;
        public bool Disponivel = true;
    }

    class Venda
    {
        public int IdVenda;
        public Cliente Cliente;
        public Veiculo Veiculo;
        public double ValorTotal;
        public string FormaPagamento;
    }

    class TestDrive
    {
        public int Id;
        public Cliente Cliente;
        public Veiculo Veiculo;
        public string Data;
        public string Horario;
    }

    // ==================== PROGRAMA ====================

    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Veiculo> veiculos = new List<Veiculo>();
        static List<Venda> vendas = new List<Venda>();
        static List<TestDrive> testDrives = new List<TestDrive>();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("\n========== CONCESSIONÁRIA ==========");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Gerenciar Clientes");
                Console.WriteLine("3 - Cadastrar Veículo");
                Console.WriteLine("4 - Consultar Veículos");
                Console.WriteLine("5 - Atualizar Estoque");
                Console.WriteLine("6 - Comprar Veículo");
                Console.WriteLine("7 - Agendar Test Drive");
                Console.WriteLine("8 - Consultar Test Drives");
                Console.WriteLine("9 - Emitir Relatório");
                Console.WriteLine("0 - Sair");

                Console.Write("\nEscolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Digite apenas números.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarCliente();
                        break;

                    case 2:
                        GerenciarClientes();
                        break;

                    case 3:
                        CadastrarVeiculo();
                        break;

                    case 4:
                        ConsultarVeiculos();
                        break;

                    case 5:
                        AtualizarEstoque();
                        break;

                    case 6:
                        ComprarVeiculo();
                        break;

                    case 7:
                        AgendarTestDrive();
                        break;

                    case 8:
                        ConsultarTestDrives();
                        break;

                    case 9:
                        EmitirRelatorio();
                        break;

                    case 0:
                        Console.WriteLine("\nEncerrando sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }

            } while (opcao != 0);
        }

        // ==================== CLIENTES ====================

        static void CadastrarCliente()
        {
            Cliente cliente = new Cliente();

            cliente.Id = clientes.Count + 1;

            Console.Write("\nNome: ");
            cliente.Nome = Console.ReadLine();

            Console.Write("Telefone: ");
            cliente.Telefone = Console.ReadLine();

            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();

            clientes.Add(cliente);

            Console.WriteLine($"\nCliente cadastrado com sucesso! ID: {cliente.Id}");
        }

        static void GerenciarClientes()
        {
            Console.WriteLine("\n===== CLIENTES CADASTRADOS =====");

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"\nID: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Telefone: {cliente.Telefone}");
                Console.WriteLine($"Email: {cliente.Email}");
            }
        }

        // ==================== VEÍCULOS ====================

        static void CadastrarVeiculo()
        {
            Veiculo veiculo = new Veiculo();

            veiculo.Id = veiculos.Count + 1;

            Console.Write("\nMarca: ");
            veiculo.Marca = Console.ReadLine();

            Console.Write("Modelo: ");
            veiculo.Modelo = Console.ReadLine();

            Console.Write("Ano: ");
            veiculo.Ano = int.Parse(Console.ReadLine());

            Console.Write("Preço: ");
            veiculo.Preco = double.Parse(Console.ReadLine());

            Console.Write("Categoria: ");
            veiculo.Categoria = Console.ReadLine();

            veiculos.Add(veiculo);

            Console.WriteLine($"\nVeículo cadastrado com sucesso! ID: {veiculo.Id}");
        }

        static void ConsultarVeiculos()
        {
            Console.WriteLine("\n===== VEÍCULOS CADASTRADOS =====");

            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo cadastrado.");
                return;
            }

            foreach (Veiculo veiculo in veiculos)
            {
                Console.WriteLine($"\nID: {veiculo.Id}");
                Console.WriteLine($"Marca: {veiculo.Marca}");
                Console.WriteLine($"Modelo: {veiculo.Modelo}");
                Console.WriteLine($"Ano: {veiculo.Ano}");
                Console.WriteLine($"Preço: R$ {veiculo.Preco:F2}");
                Console.WriteLine($"Categoria: {veiculo.Categoria}");
                Console.WriteLine($"Disponível: {(veiculo.Disponivel ? "Sim" : "Não")}");
            }
        }

        static void AtualizarEstoque()
        {
            ConsultarVeiculos();

            Console.Write("\nDigite o ID do veículo: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Veiculo veiculo = veiculos.Find(v => v.Id == id);

            if (veiculo == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            Console.WriteLine("\n1 - Disponível");
            Console.WriteLine("2 - Indisponível");

            Console.Write("Escolha: ");

            int escolha = int.Parse(Console.ReadLine());

            if (escolha == 1)
            {
                veiculo.Disponivel = true;
            }
            else if (escolha == 2)
            {
                veiculo.Disponivel = false;
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return;
            }

            Console.WriteLine("\nEstoque atualizado com sucesso!");
        }

        // ==================== VENDAS ====================

        static void ComprarVeiculo()
        {
            if (clientes.Count == 0 || veiculos.Count == 0)
            {
                Console.WriteLine("\nCadastre clientes e veículos primeiro.");
                return;
            }

            GerenciarClientes();
            ConsultarVeiculos();

            Console.Write("\nDigite o ID do cliente: ");

            if (!int.TryParse(Console.ReadLine(), out int idCliente))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Console.Write("Digite o ID do veículo: ");

            if (!int.TryParse(Console.ReadLine(), out int idVeiculo))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Cliente clienteEncontrado = clientes.Find(c => c.Id == idCliente);
            Veiculo veiculoEncontrado = veiculos.Find(v => v.Id == idVeiculo);

            if (clienteEncontrado == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            if (veiculoEncontrado == null)
            {
                Console.WriteLine("Veículo não encontrado.");
                return;
            }

            if (!veiculoEncontrado.Disponivel)
            {
                Console.WriteLine("Veículo indisponível.");
                return;
            }

            Venda venda = new Venda();

            venda.IdVenda = vendas.Count + 1;
            venda.Cliente = clienteEncontrado;
            venda.Veiculo = veiculoEncontrado;
            venda.ValorTotal = veiculoEncontrado.Preco;

            Console.Write("Forma de pagamento: ");
            venda.FormaPagamento = Console.ReadLine();

            veiculoEncontrado.Disponivel = false;

            vendas.Add(venda);

            Console.WriteLine("\nCompra realizada com sucesso!");
        }

        // ==================== TEST DRIVE ====================

        static void AgendarTestDrive()
        {
            if (clientes.Count == 0 || veiculos.Count == 0)
            {
                Console.WriteLine("\nCadastre clientes e veículos primeiro.");
                return;
            }

            GerenciarClientes();
            ConsultarVeiculos();

            Console.Write("\nDigite o ID do cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            Console.Write("Digite o ID do veículo: ");
            int idVeiculo = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == idCliente);
            Veiculo veiculo = veiculos.Find(v => v.Id == idVeiculo);

            if (cliente == null || veiculo == null)
            {
                Console.WriteLine("Cliente ou veículo não encontrado.");
                return;
            }

            TestDrive testDrive = new TestDrive();

            testDrive.Id = testDrives.Count + 1;
            testDrive.Cliente = cliente;
            testDrive.Veiculo = veiculo;

            Console.Write("Data do Test Drive: ");
            testDrive.Data = Console.ReadLine();

            Console.Write("Horário: ");
            testDrive.Horario = Console.ReadLine();

            testDrives.Add(testDrive);

            Console.WriteLine("\nTest Drive agendado com sucesso!");
        }

        static void ConsultarTestDrives()
        {
            Console.WriteLine("\n===== TEST DRIVES AGENDADOS =====");

            if (testDrives.Count == 0)
            {
                Console.WriteLine("Nenhum test drive agendado.");
                return;
            }

            foreach (TestDrive testDrive in testDrives)
            {
                Console.WriteLine($"\nID: {testDrive.Id}");
                Console.WriteLine($"Cliente: {testDrive.Cliente.Nome}");
                Console.WriteLine($"Veículo: {testDrive.Veiculo.Marca} {testDrive.Veiculo.Modelo}");
                Console.WriteLine($"Data: {testDrive.Data}");
                Console.WriteLine($"Horário: {testDrive.Horario}");
            }
        }

        // ==================== RELATÓRIO ====================

        static void EmitirRelatorio()
        {
            Console.WriteLine("\n===== RELATÓRIO DE VENDAS =====");

            if (vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda realizada.");
                return;
            }

            foreach (Venda venda in vendas)
            {
                Console.WriteLine($"\nVenda ID: {venda.IdVenda}");
                Console.WriteLine($"Cliente: {venda.Cliente.Nome}");
                Console.WriteLine($"Veículo: {venda.Veiculo.Marca} {venda.Veiculo.Modelo}");
                Console.WriteLine($"Valor Total: R$ {venda.ValorTotal:F2}");
                Console.WriteLine($"Forma de Pagamento: {venda.FormaPagamento}");
            }
        }
    }
}