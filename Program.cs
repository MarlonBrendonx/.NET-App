using System;
using static System.Console;
using APP_SERIES.Models;
using APP_SERIES;

public class Program{

    static SerieRepositorio listserie = new SerieRepositorio();

    public static int Menu(){
       
       string menu= "";

       menu+="--------------------Menu-----------------\n";
       menu+="[1] - Listar séries. \n";
       menu+="[2] - Inserir nova série. \n";
       menu+="[3] - Atualizar série. \n";
       menu+="[4] - Excluir série. \n";
       menu+="[5] - Visualizar série. \n";
       menu+="[0] - Sair. \n";
       menu+="Opção :> \n";
       System.Console.WriteLine(menu);

       int op = Int32.Parse(ReadLine());
       
       return op;

    }

    public static void updateSerie(){

        WriteLine("Infome o id da serie: ");
        int id = Int32.Parse(ReadLine());

        int genero=0;
        string titulo=null;
        int ano=0;
        string descricao=null;

        Fields(ref genero,ref  titulo, ref ano,ref descricao);

         Serie serie_updated = new Serie(listserie.nextId(),(Genero)genero, titulo, descricao, ano);

         listserie.update(id,serie_updated);
    }

    public static void removeSerie(){

        WriteLine("Infome o id da serie: ");
        int id = Int32.Parse(ReadLine());

         listserie.remove(id);
    }

    public static void viewSerie(){

        WriteLine("Infome o id da serie: ");
        int id = Int32.Parse(ReadLine());

        var serie = listserie.getById(id);

         WriteLine(serie);
    }

    public static void listSerie(){

        WriteLine("--------Series------------\n");

        var list = listserie.listSeries();

        if( list.Count > 0 ){
            
            WriteLine("-----------Séries--------\n");
            foreach (var item in list)
            {

                var excluido=item.getExcluido();

                WriteLine("#ID {0} {1} {2}", item.getId(), item.getTitulo(), (excluido ? "*Excluído*" : "") );
            }
        
        }else{

            WriteLine("Não há séries cadastradas ! \n");

        }

    }

    public static void Fields(ref int genero, ref string titulo,ref int ano,ref string descricao){

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            WriteLine($"[{i}] - {Enum.GetName(typeof(Genero),i)}");            
        }

        WriteLine("Infome o gênero: ");
        genero = Int32.Parse(ReadLine());

        WriteLine("Infome o título: ");
        titulo = ReadLine();

        WriteLine("Infome o ano: ");
        
        string ano_ = ReadLine();
    
        while( ! Int32.TryParse(ano_, out ano))
        {
            Console.WriteLine("Não é um número, tente novamente.");
            ano_ = ReadLine();
        }

        WriteLine("Infome a descrição: ");
        descricao = ReadLine();

    }

    public static void insertSerie(){
        
        WriteLine("--------Nova Série------------\n");

        int genero=0;
        string titulo=null;
        int ano=0;
        string descricao=null;

        Fields(ref genero,ref  titulo, ref ano,ref descricao);

        Serie novaserie = new Serie(listserie.nextId(),(Genero)genero, titulo, descricao, ano);

        listserie.set(novaserie);

    }

    public static void Main(){

        int op;

        do{

            op = Menu();

            switch(op){
                
                case 0:
                    Environment.Exit(0);
                break;
                case 1:
                   listSerie();
                break;
                case 2:
                   insertSerie(); 
                break;
                case 3:
                   updateSerie();
                break;
                case 4:
                   removeSerie();
                break;
                case 5:
                    viewSerie();
                break;


                default:
                    throw new ArgumentOutOfRangeException("Opção inválida !");

            }


        }while( op != 0);

       


    }

}
