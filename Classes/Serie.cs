namespace Series
{
    public class Serie : Entidade
    {
        private Genero _genero { get; set; }
        private string _titulo { get; set; }
        private string _descricao { get; set; }
        private int _ano { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            IsExcluido = false;
            _genero = genero;
            _titulo = titulo;
            _descricao = descricao;
            _ano = ano;
        }

        public override string ToString()
        {
            return $"Título: {_titulo}\nDescrição: {_descricao}\nAno: {_ano} - Gênero: {_genero}";
        }

        public string GetTitulo()
        {
            return _titulo;
        }

        internal int GetId()
        {
            return Id;
        }
    }
}