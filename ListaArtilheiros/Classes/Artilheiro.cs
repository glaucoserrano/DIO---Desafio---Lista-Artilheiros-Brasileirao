using System;
namespace ListaArtilheiros
{
    public class Artilheiro : EntidadeBase
    {
        public Time Time { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int Gols { get; set;}
        public bool Excluido { get; set; }
        public Artilheiro(int id, Time time, string nome, int ano, int gols)
        {
            this.Id = id;
            this.Nome = nome;
            this.Ano = ano;
            this.Gols = gols;
            this.Excluido = false;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Time: " + this.Time + Environment.NewLine;
            retorno += "Gols: " + this.Gols + Environment.NewLine;
            retorno += "Excluido: "  + this.Excluido;

            return retorno;
        }
        public string retornaNome()
        {
            return this.Nome;
        }
        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
    
}