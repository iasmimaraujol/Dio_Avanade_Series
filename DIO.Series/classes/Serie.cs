using Dio.Series;
using System;

namespace DIO.Series{
    public class Serie : EntidadeBase{ //Serie vai herdar de EntidadeBase
        private genero genero{get; set;}
        private string titulo{get; set;}
        private string descricao {get; set;}
        private bool exclusao{get;set;}

        //construtor que é similar ao que é feito em java 
        public Serie(genero genero, string titulo, string descricao){
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.exclusao = false;
        }

        public override string ToString(){
            string retorno = "";
            retorno += "Gênero" + this.genero + Environment.NewLine;
            retorno += "Título" + this.titulo + Environment.NewLine;
            retorno += "Descrição" + this.descricao + Environment.NewLine;
            retorno += "Excluido" + this.exclusao;
            return retorno;
        }

        public string retornaTitulo(){
            return this.titulo;
        }
        
        public bool Exclusao(){
            return this.exclusao;
        }
        public int retornaId(){
            return this.Id;
        }
        public void exclusaoDado(){
            this.exclusao = true;
        }
    }
}