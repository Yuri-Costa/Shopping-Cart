using System;
using System.Collections.Generic;

namespace Carrinho_de_Compra.classes
{
    public class Carrinho
    {
        List<Produto> carrinho = new List<Produto>();

        //----------------------------------------------------------------------------------------------------


        public void MostrarMenu()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------------");
            Console.WriteLine("------------MENU------------");
            Console.WriteLine("----------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CADASTRAR PRODUTO  ---> [1]");
            Console.WriteLine("LISTAR PRODUTO     ---> [2]");
            Console.WriteLine("REMOVER PRODUTO    ---> [3]");
            Console.WriteLine("SUBSTITUIR PRODUTO ---> [4]");
            Console.WriteLine("SAIR               ---> [0]");
            Console.WriteLine("--------------------------");
            int opcao = int.Parse(Console.ReadLine());



            switch (opcao)
            {
                case 1:
                    Cadastrarproduto();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta1 = Console.ReadLine();
                    if (resposta1 == "s")
                    {
                        MostrarMenu();
                    }
                    break;

                case 2:
                    MostrarLista();
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 == "s")
                    {
                        MostrarMenu();
                    }
                    break;

                case 3:
                    Remover();
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta3 = Console.ReadLine();
                    if (resposta3 == "s")
                    {
                        MostrarMenu();
                    }
                    break;

                     case 4:

                        AlterarItem();
                      
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta4 = Console.ReadLine();
                    if (resposta4 == "s")
                    {
                        MostrarMenu();
                    }
                    break;
                     case 0:    Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");

                    break;


                default:
                    break;
            }

        }


        public void AlterarItem(){
             //------------------------------------------------
             Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ok! vamos alterar seus produtos!");
            Console.WriteLine(" Para começar, digite o codigo produto que voce deseja alterar");
            int Acodigo = int.Parse(Console.ReadLine());
    
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Ótimo! agora insira o seu novo código");
             int NEWcodigo = int.Parse(Console.ReadLine());
            Console.WriteLine("agora insira o novo nome do seu produto");
            string NEWnome = Console.ReadLine();
            Console.WriteLine("agora insira o novo preço do seu produto");
            float NEWpreco = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Preço de [R${NEWcodigo}] cadastrado :)");
            Console.WriteLine($" Preço de [R${NEWnome}] cadastrado :)");
            Console.WriteLine($" Preço de [R${NEWpreco}] cadastrado :)");
         
            Produto newP = new Produto(NEWcodigo, NEWnome, NEWpreco);
            Substituir(Acodigo, newP);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ótimo! seu produto foi alterado com sucesso :)");
                    
                
            //------------------------------------------------
            
        }

        //----------------------------------------------------------------------------------------------------


        public void DarBoasVindas()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ola!");
            Console.WriteLine("Qual o seu nome?");
            string dbvNome = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Olá! {dbvNome}, seja muito Bem Vindo ao sistema de Produtos :)");
        }

        //----------------------------------------------------------------------------------------------------

        public void Cadastrarproduto()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ok! vamos cadastrar seus produtos!");
            Console.WriteLine(" Para começar, digite o codigo do seu produto");
            int CPcodigo = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Codigo [{CPcodigo}] cadastrado :)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("digite o nome do seu produto");
            string CPnome = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Nome [{CPnome}] cadastrado :)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("digite o Preço do seu produto");
            float CPpreco = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Preço de [R${CPpreco.ToString("n2")}] cadastrado :)");
            Produto p = new Produto(CPcodigo, CPnome, CPpreco);
            carrinho.Add(p);
            Console.WriteLine("Ótimo! seu produto foi cadastrado com sucesso :)");
        }



        //----------------------------------------------------------------------------------------------------

        public void Substituir(int _codigo, Produto newProduto)
        {
            
            carrinho.Find(x => x.Codigo == _codigo ).Nome = newProduto.Nome;
            carrinho.Find(x => x.Codigo == _codigo ).preco = newProduto.preco;


        }

        //----------------------------------------------------------------------------------------------------
        public void MostrarLista()
        {
            if (carrinho != null)
            {
                foreach (var lista in carrinho)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------------------------------------------");
                    Console.WriteLine($"-------------------------------{lista.Nome}------------------------------------");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("-------------------------------------------------------------------------------");
                    Console.WriteLine($"Código: {lista.Codigo} -||- Nome: {lista.Nome} -||- Preço: R${lista.preco.ToString("n2")}");
                    Console.WriteLine("-------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Opa! voce ainda não tem nenhum produto na lista :(");
            }

        }

        //----------------------------------------------------------------------------------------------------

        public void Remover()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("REMOVER UM PRODUTO           ---> [1]");
            Console.WriteLine("REMOVER TODOS OS PRODUTOS    ---> [2]");
            int opcaoREMOVE = int.Parse(Console.ReadLine());

            switch (opcaoREMOVE)
            {
                case 1:
                    Console.WriteLine("ok! vamos remover um produto :(");
                    Console.WriteLine("insira o Código do produto que voce deseja remover.");
                    int remo = int.Parse(Console.ReadLine());
                    foreach (var p in carrinho)
                    {
                        if (string.IsNullOrEmpty(p.Nome))
                        {

                            if (p.Codigo == remo)
                            {
                                carrinho.Remove(p);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"item {remo} removido!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.WriteLine("Codigo não encontrado");
                            }
                        }
                    }
                    break;


                case 2:
                    foreach (var produto in carrinho)
                    {
                        carrinho.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("todos os itens removidos");
                    }
                    break;
                default:
                    break;



            }
        }






    }
}