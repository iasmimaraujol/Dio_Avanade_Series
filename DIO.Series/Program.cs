using DIO.Series;

namespace Dio.Series{
    class Program{
        static Repositorios repositorio = new Repositorios(); 
        static void Main(String[] args){
        int opcao = menUsers();
        //não sei quantas vezes vou precisar repetir

        while (opcao != 9){
            //da para usar o switch
            if (opcao == 0) Console.Clear();    
            if (opcao == 1) listaSerie();
            if (opcao == 2) Insere();
            if (opcao == 3) Atualiza();
            if (opcao == 4) Excluir();
            if(opcao < 0 || opcao > 5) throw new ArgumentOutOfRangeException();
            opcao = menUsers();   
        }
        Console.ReadLine();            
    }

    private static void Atualiza(){
        Console.Write("Digite o ");
        int entGenero = int.Parse(Console.ReadLine());

        //foreach (int i in Enum.GetValues(typeof(genero))){
		//		Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
		//	}

        Console.Write("Digite o Titulo");
        string entTitulo = Console.ReadLine();

        Console.Write("Digite a descrição");
        string entDescricao = Console.ReadLine();

        Serie atualizar = new Serie(genero: (genero)entGenero,
                                titulo: entTitulo,
                                descricao: entDescricao);
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
        foreach (int item in Enum.GetValues(typeof(genero))){
            Console.WriteLine("{0}{1}", item, Enum.GetName(typeof(genero)), item);
        }
        
        Console.Write("Digite o genero desejado");
        int entGenero = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(genero))){
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(genero), i));
			}

        Console.Write("Digite o Titulo");
        string entTitulo = Console.ReadLine();

        Console.Write("Digite a descrição");
        string entDescricao = Console.ReadLine();


        Serie newSerie = new Serie(id: repositorio.ProximoId(),
                                genero: (genero)entGenero,
                                titulo: entTitulo,
                                descricao: entDescricao);
        repositorio.Insere(newSerie);
    }

    private static void Excluir(){
        Console.Write("Digite o id: ");
        string value = Console.ReadLine();
        int indiceSerie = int.Parse(value);
        repositorio.Exclui(indiceSerie);        
    }
    public static int menUsers(){
        Console.WriteLine();
        Console.WriteLine("1- Listar opções");
        Console.WriteLine("2- Inserir nova opção");
        Console.WriteLine("3- Atualizar opções");
        Console.WriteLine("4- Excluir opção");
        Console.WriteLine("0- Limpar tela");
        Console.WriteLine("9- Sair");
        Console.WriteLine();
        int opcao = int.Parse(Console.ReadLine());
        return opcao;
        }       
    private static void Visualizar(){
        Console.Write("Digite: ");
        int indice = int.Parse(Console.ReadLine());
        var serie = repositorio.RetornaPorId(indice);
        Console.WriteLine(serie);
    }
    }
}