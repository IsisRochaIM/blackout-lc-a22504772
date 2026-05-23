using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Blackout
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Pergunta ao jogador qual a dificuldade do jogo
            Console.WriteLine("Qual é o nivel de dificuldade do jogo ?");
            int dificuldade = Convert.ToInt32(Console.ReadLine());

            //Cria 3 arrays consoante a dificuldade escolhida
            int[][] lists1 = new int[4][];
            int[][] lists2 = new int[5][];
            int[][] lists3 = new int[6][];


            //Conforme a dificuldade escolhida ele preenche o array
            //Tecnicamente podia fazer isso sem os iffs, preencher todos mas dps so usar o certo
            if(dificuldade == 0)
            {
                int[] list1 = new int[4] {0,0,0,0};
                int[] list2 = new int[4] {0,0,0,0};
                int[] list3 = new int[4] {0,0,0,0};
                int[] list4 = new int[4] {0,0,0,0};

                lists1 = new int[][] {  list1 ,  list2 ,  list3 ,  list4  };
            }
            else if(dificuldade == 1)
            {
                int[] list1 = new int[5] {0,0,0,0,0};
                int[] list2 = new int[5] {0,0,0,0,0};
                int[] list3 = new int[5] {0,0,0,0,0};
                int[] list4 = new int[5] {0,0,0,0,0};
                int[] list5 = new int[5] {0,0,0,0,0};

                lists2 = new int[][] {  list1 ,  list2 ,  list3 ,  list4 , list5 };
            }
            else if(dificuldade == 2)
            {
                int[] list1 = new int[6] {0,0,0,0,0,0};
                int[] list2 = new int[6] {0,0,0,0,0,0};
                int[] list3 = new int[6] {0,0,0,0,0,0};
                int[] list4 = new int[6] {0,0,0,0,0,0};
                int[] list5 = new int[6] {0,0,0,0,0,0};
                int[] list6 = new int[6] {0,0,0,0,0,0};

                lists3 = new int[][] {  list1 ,  list2 ,  list3 ,  list4, list5, list6  };
            }








            //
            //Estepedaço de codigo basicamente altera a posiçao que o jogador selecionou
            //Assim como todas as peças em torno dela
            //No final conta quantas peças estão ativas
            //Só quando todas elas tiverem ativas é que sai do while
            //
            int numerofinal = 0;
            while(numerofinal != 16)
            {
                
                //Mostrar o tabuleiro:
                foreach(int[] lista in lists1)
                {
                    foreach(int estado in lista)
                    {
                        Console.Write(estado);
                    }
                    Console.WriteLine();
                }

                //Reseta a conagem de peças, para não somar as da jogada anterior
                numerofinal = 0;


                //Pede as cordenadas da peça
                Console.WriteLine("Coloca o X que desejas alterar");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Coloca o Y que desejas alterar");
                int y = Convert.ToInt32(Console.ReadLine());


                //
                //Estes trys todos basicamente vão verificar se a peça está ativa ou não
                //Tanto a peça selecionada com as em volta
                //Dependendo de como estiver, ele inverte o estado
                //Caso a peça não exista, ele simplesmente não faz nada (por isso os trys)
                //
                try
                {
                    if(lists1[x][y] == 0)
                    {
                        lists1[x][y] = 1;
                    }
                    else
                    {
                        lists1[x][y] = 0;
                    }
                }
                catch
                {
                    
                }

                try
                {
                    if(lists1[x+1][y] == 0)
                    {
                        lists1[x+1][y] = 1;
                    }
                    else
                    {
                        lists1[x+1][y] = 0;
                    }
                }
                catch
                {
                    
                }


                try
                {
                    if(lists1[x-1][y] == 0)
                    {
                        lists1[x-1][y] = 1;
                    }
                    else
                    {
                        lists1[x-1][y] = 0;
                    }
                }
                catch
                {
                    
                }


                try
                {
                    if(lists1[x][y+1] == 0)
                    {
                        lists1[x][y+1] = 1;
                    }
                    else
                    {
                        lists1[x][y+1] = 0;
                    }
                }
                catch
                {
                    
                }


                try
                {
                    if(lists1[x][y-1] == 0)
                    {
                        lists1[x][y-1] = 1;
                    }
                    else
                    {
                        lists1[x][y-1] = 0;
                    }
                }
                catch
                {
                    
                }
                

                //Conta quantas peças estão ativas
                //Serve para caso estejam todas, ele sair dps do while
                foreach(int[] teste in lists1)
                {
                    foreach(int testinho in teste)
                    {
                        numerofinal += testinho;
                    }
                }

            }

            //So vem para aqui quando ganha
            //Mostra que ganhou
            Console.WriteLine("Parabens");
            
        }
    }
}
