using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using static System.Console;

namespace Carrinho_de_Compra.classes
{
    public class Carrinho
    {
        private const string V = "[]";
        List<Produto> carrinho = new List<Produto>();

        //----------------------------------------------------------------------------------------------------


        public void MostrarMenu()
        {

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------");
            Console.WriteLine("--------------MENU------------");
            Console.WriteLine("------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("CADASTRAR PRODUTO     ---> [1]");
            Console.WriteLine("CARRINHO              ---> [2]");
            Console.WriteLine("REMOVER PRODUTO       ---> [3]");
            Console.WriteLine("SUBSTITUIR PRODUTO    ---> [4]");
            Console.WriteLine("PARABÉNS PARA VOCÊ :) ---> [5]");
            Console.WriteLine("SAIR                  ---> [0]");
            Console.WriteLine("______________________________");
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
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");
                    }
                    break;

                case 2:
                    MostrarLista();
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 == "s")
                    {
                        MostrarMenu();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");
                    }
                    break;

                case 3:
                    Remover();
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta3 = Console.ReadLine();
                    if (resposta3 == "s")
                    {
                        MostrarMenu();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");
                    }
                    break;

                     case 4:

                        AlterarItem();
                      
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta4 = Console.ReadLine();
                    if (resposta4 == "s")
                    {
                        MostrarMenu();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");
                    }
                    break;
                     case 0:    Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");

                    break;

                     case 5:  
                      Musiquinha();
                    Console.WriteLine("deseja voltar para o menu? s/n");
                    string resposta5 = Console.ReadLine();
                    if (resposta5 == "s")
                    {
                        MostrarMenu();
                    }else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ATÉ A PROXIMA! :)");
                    }
                    break;


                default:
                    break;
            }

        }


        public void AlterarItem(){
             //------------------------------------------------
             if (carrinho.Count != 0)
            {
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
            Console.WriteLine($" Código [{NEWcodigo}] cadastrado :)");
            Console.WriteLine($" Nome [{NEWnome}] cadastrado :)");
            Console.WriteLine($" Preço de [R${NEWpreco}] cadastrado :)");
         
            Produto newP = new Produto(NEWcodigo, NEWnome, NEWpreco);
            Substituir(Acodigo, newP);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ótimo! seu produto foi alterado com sucesso :)");
            }else
            {   Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opa! voce não possui nenhum produto no carrinho :(");
                Console.WriteLine("Cadastre um produto primeiro para altera-lo:(");
                Console.ResetColor();
            }
                    
                
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
            if (carrinho.Count != 0)
            {
            carrinho.Find(x => x.Codigo == _codigo ).Nome = newProduto.Nome;
            carrinho.Find(x => x.Codigo == _codigo ).preco = newProduto.preco;
            carrinho.Find(x => x.Codigo == _codigo ).Codigo = newProduto.Codigo;
        }else
        {   Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("opa! voce não tem nenhum produto no carrinho para alterar!");
            Console.WriteLine("Cadastre um produto primeiro para altera-lo:(");
            Console.ResetColor();
        }
        }

        //----------------------------------------------------------------------------------------------------
        public void MostrarLista()
        {
            if (carrinho.Count == 0)

            {   Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Opa! voce não tem nenhum produto no carrinho :(");
            }
            else
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
                            if (p.Codigo == remo)
                            {
                                carrinho.Remove(p);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"item {remo} removido!");
                                Console.ResetColor();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Codigo não encontrado");
                            }
                    }
                    break;


                case 2:
                    foreach (var produto in carrinho)
                    {
                        carrinho.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("todos os itens removidos");
                        break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Musiquinha(){
             Grasshoper();
        }
        private static void Grasshoper()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("happy birthday! :)");
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
    
        
        
    }
}