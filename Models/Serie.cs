

namespace APP_SERIES.Models
{
    public class Serie : EntityBase
    {
        
        private Genero genero { get; set; }

        private string titulo { get; set; }

        private string descricao { get; set; }

        private int ano { get; set; }

        private bool excluido { get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano) {

            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;

        }

        public override string ToString(){

            string _return = "";

            _return += "Gênero: " + this.genero + Environment.NewLine;
            _return += "Título: " + this.titulo + Environment.NewLine;
            _return += "Descrição: " + this.descricao + Environment.NewLine;
            _return += "Ano: " + this.ano + Environment.NewLine;
             _return += "Excluido: " + this.excluido + Environment.NewLine;

            return _return;
        
        }


        public string getTitulo(){
            
            return titulo;

        }
        public bool getExcluido(){
            
            return this.excluido;

        }

        public int getId(){

            return this.id;

        }

        public void remove(){
            this.excluido = true;
        }

    }
}