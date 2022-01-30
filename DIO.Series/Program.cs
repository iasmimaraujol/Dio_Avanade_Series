using System;

namespace Dio.Series{
    class Program{
        static DIO.Series.Repositorios repositorio = new DIO.Series.Repositorios(); 
        static void Main(String[] args){
        int opcao = int.Parse(menUsers());
        //não sei quantas vezes vou precisar repetir

        while (opcao != 9){
            //da para usar o switch
            if (opcao == 1) Console.Clear();    
            if (opcao == 2) listaSerie();
            if (opcao == 3) Insere();
            if (opcao == 4) Atualiza();
            if (opcao == 5) Excluir();
            if(opcao < 0 || opcao > 5) throw new ArgumentOutOfRangeException();
            opcao = int.Parse(menUsers());   
        }
        Console.ReadLine();            
    }

    private static void Atualiza(){
        Console.Write("Digite o ");
        int entGenero = int.Parse(Console.ReadLine());
        foreach (int i in Enum.GetValues(typeof(DIO.Series.genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(DIO.Series.genero), i));
			}

        Console.Write("Digite o Titulo");
        string eTitulo = Console.ReadLine();

        Console.Write("Digite a descrição");
        string eDescricao = Console.ReadLine();

            DIO.Series.Serie atualizar = new DIO.Series.Serie(genero: (DIO.Series.genero)entGenero,
                                titulo: eTitulo,
                                descricao: eDescricao);
        repositorio.Atualiza(entGenero, atualizar);        
    }

    private static void listaSerie(){
        Console.WriteLine("Listar Series");
        var lista = repositorio.Lista();
        if(lista.Count == 0) {
            Console.WriteLine("Nenhuma cadastrada");
            return;
        }
        foreach (var serie in lista){
            var excluido = serie.Exclusao();            
            Console.WriteLine("ID {0}: -{1}{2}", serie.retornaId(), serie.retornaTitulo());            
        } 
    }

    private static void Insere(){
        Console.WriteLine("Inserir novo");
        foreach (int item in Enum.GetValues(typeof(DIO.Series.genero))){
            Console.WriteLine("{0}{1}", item, Enum.GetName(typeof(DIO.Series.genero)), item);
        }
        
        Console.Write("Digite o genero desejado");
        int entGenero = int.Parse(Console.ReadLine());
        
        Console.Write("Digite o Titulo");
        string eTitulo = Console.ReadLine();

        Console.Write("Digite a descrição");
        string eDescricao = Console.ReadLine();

            DIO.Series.Serie newSerie = new DIO.Series.Serie(genero: (DIO.Series.genero)entGenero,
                                titulo: eTitulo,
                                descricao: eDescricao);
        repositorio.Insere(newSerie);
    }

    private static void Excluir(){
        Console.Write("Digite o id: ");
        string val = Console.ReadLine();
        int indiceSerie = int.Parse(val);
        repositorio.Exclui(indiceSerie);        
    }
    public static string menUsers(){
        Console.WriteLine();
        Console.WriteLine("2- Listar opções");
        Console.WriteLine("3- Inserir nova opção");
        Console.WriteLine("4- Atualizar opções");
        Console.WriteLine("5- Excluir opção");
        Console.WriteLine("1- Limpar tela");
        Console.WriteLine("9- Sair");
        Console.WriteLine();
        string opcao = Console.ReadLine().ToUpper();
        Console.WriteLine();
        //int opcao = int.Parse(Console.ReadLine());
        return opcao;
        }       
    private static void Visualizar(){
        Console.Write("Digite: ");
        int ind = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(ind);
        Console.WriteLine(serie);
        }
    }
}