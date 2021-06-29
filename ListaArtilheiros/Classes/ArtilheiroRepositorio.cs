using System;
using System.Collections.Generic;
using ListaArtilheiros.Interface;

namespace ListaArtilheiros
{
    public class ArtilheiroRepositorio : IRepositorio<Artilheiro>
    {
        private List<Artilheiro> listaArtilheiro = new List<Artilheiro>();
        public void Atualiza(int id, Artilheiro objeto)
        {
            listaArtilheiro[id] = objeto;
        }

        public void Exclui(int Id)
        {
            listaArtilheiro[Id].Excluir();
        }

        public void Insere(Artilheiro objeto)
        {
            listaArtilheiro.Add(objeto);
        }

        public List<Artilheiro> Lista()
        {
            return listaArtilheiro;
        }

        public int proximoId()
        {
            return listaArtilheiro.Count;
        }

        public Artilheiro RetornaPorId(int id)
        {
            return listaArtilheiro[id];
        }
    }
}