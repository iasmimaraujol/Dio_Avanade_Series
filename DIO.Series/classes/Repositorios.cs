using System;
using System.Collections.Generic;
using DIO.Series;

namespace DIO.Series{
    public class Repositorios : iRepositorio<Serie>{
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie obj){
               listaSerie[id] = obj;
            }
            
        public void Exclui(int id){
                listaSerie[id].exclusaoDado();
            }

        public void Insere(Serie entidade){
                listaSerie.Add(entidade);
            }

        public List<Serie> Lista(){
                return listaSerie;
            }

        public int ProximoId(){
                return listaSerie.Count;
            }

        public Serie RetornaPorId(int id){
                return listaSerie[id];
            }
    }
}