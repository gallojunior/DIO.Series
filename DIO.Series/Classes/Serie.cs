using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Ativo { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Ativo = true;
        }

        public override string ToString()
        {
            return $"Gênero: {Genero}\nTítulo: {Titulo}\nDescrição: {Descricao}\nAno de Início: {Ano}\nAtivo: {(Ativo ? "Sim" : "Não")}";
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            this.Ativo = false;
        }

        public bool RetornaAtivo()
        {
            return Ativo;
        }

    }
}
