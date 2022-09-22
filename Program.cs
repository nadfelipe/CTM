using CadastroPessoaBET9.Classes;

PessoaFisica metodosPf = new PessoaFisica();
List<PessoaFisica> listaPf = new List<PessoaFisica>();


Console.Clear();
Console.WriteLine(@$"
=============================================
|   Bem vindo ao sistema de cadastro de     |
|       Pessoa Físicas e Juridícas          |
=============================================
");

Utils.BarraCarregamento("Carregando", 10, ".", 200);

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo       |
|-------------------------------------------|
|           1 - Pessoa Física               |
|           2 - Pessoa Juridíca             |
|                                           |
|           0 - Sair                        |
=============================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            string? opcaoPf;
            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=============================================
|       Escolha uma das opções abaixo       |
|-------------------------------------------|
|       1 - Cadastrar Pessoa Física         |
|       2 - Listar Pessoas Física           |
|                                           |
|       0 - Voltar ao menu anterior         |
=============================================
");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":
                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEndPf = new Endereco();

                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento Ex:DD/MM/AAAA");
                            string? dataNascimento = Console.ReadLine();

                            dataValida = novaPf.ValidarDataNasc(dataNascimento);

                            if (dataValida)
                            {
                                DateTime.TryParse(dataNascimento, out DateTime dataConvertida);
                                novaPf.dataNasc = dataConvertida;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data digitada inválida, por favor digite uma data válida");
                                Console.ResetColor();
                                Thread.Sleep(3000);
                            }

                        } while (!dataValida); // dataValida == false


                        Console.WriteLine($"Digite o numero do CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite o rendimento mensal (Digite somente numeros)");
                        novaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro");
                        novoEndPf.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEndPf.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento (Aperte ENTER para vazio)");
                        novoEndPf.complemento = Console.ReadLine();


                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEndPf.endComercial = true;
                        }
                        else
                        {
                            novoEndPf.endComercial = false;
                        }

                        novaPf.endereco = novoEndPf;

                        listaPf.Add(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"CAdastro realizado com sucesso");
                        Console.ResetColor();
                        Thread.Sleep(3000);

                        break;

                    case "2":

                        Console.Clear();

                        if (listaPf.Count > 0)
                        {

                            foreach (PessoaFisica cadaPf in listaPf)
                            {
                                Console.Clear();
                                Console.WriteLine(@$"
Nome: {cadaPf.nome}
Endereco: {cadaPf.endereco.logradouro}, {cadaPf.endereco.numero}
Data de Nascimento: {cadaPf.dataNasc.ToString("d")}
Imposto a ser pago: {metodosPf.CalcularImposto(cadaPf.rendimento).ToString("C")}
");

                                Console.WriteLine($"Aperte 'ENTER' para continuar");
                                Console.ReadLine();
                            }

                        }
                        else
                        {
                            Console.WriteLine($"Lista vazia");
                            Thread.Sleep(2000);
                        }

                        break;

                    case "0":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"Voltando ao menu anterior");
                        Console.ResetColor();
                        Thread.Sleep(2000);

                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        break;
                }



            } while (opcaoPf != "0");

            break;

        case "2":

            PessoaJuridica novaPj = new PessoaJuridica();
            Endereco novoEndPj = new Endereco();

            novaPj.nome = "Nome Pj";
            novaPj.razaoSocial = "Razão Social Pj";
            novaPj.cnpj = "62.401.115/0001-40";
            novaPj.rendimento = 6000.5f;

            novoEndPj.logradouro = "Rua Niteroi";
            novoEndPj.numero = 180;
            novoEndPj.complemento = "Senai informatica";
            novoEndPj.endComercial = true;

            novaPj.endereco = novoEndPj;

            Console.Clear();
            Console.WriteLine(@$"
Nome: {novaPj.nome}
Razão Social: {novaPj.razaoSocial}
CNPJ: {novaPj.cnpj} - Valido: {(novaPj.ValidarCnpj(novaPj.cnpj) ? "Sim" : "Não")}
");

            // condição ? "sim" : "nao"
            Console.WriteLine($"Aperte 'ENTER' para continuar");
            Console.ReadLine();


            break;

        case "0":
            Console.WriteLine($"Obrigado por utilizar nosso sistema");

            Utils.BarraCarregamento("Finalizando", 5, "+", 500);


            break;

        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Opção inválida, por favor digite uma opção válida");
            Console.ResetColor();
            Thread.Sleep(3000);
            break;
    }

} while (opcao != "0");




























// Console.WriteLine("Nome: " + novaPf.nome + " - CPF: " + novaPf.cpf);
// Console.WriteLine($"Nome: {novaPf.nome} - CPF: {novaPf.cpf}");


// float impostoPagar = novaPf.CalcularImposto(novaPf.rendimento);

// Console.WriteLine(impostoPagar);
// Console.WriteLine($"R$ {impostoPagar:0.00}");
// Console.WriteLine(impostoPagar.ToString("C"));


// == igualdade
// > maior que
// < menor que
// >= maior ou igual
// <= menor ou igual
// != diferente

// && 'e'
// V && V = V
// F && V = F
// V && F = F
// F && F = F

// || 'ou'
// V || V = V
// F || V = V
// V || F = V
// F || F = F