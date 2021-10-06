using System;

namespace Animes 
{
    public class Anime : EntidadeBase
    {
        private Categoria Categoria { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido {get; set;}

        public Anime(int id, Categoria categoria, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano Do Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido; 
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public int retornaId()
        {
            return this.Id;
        }

         public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir() {
            this.Excluido = true;
        }
    }
}