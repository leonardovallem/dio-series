using System.Collections.Generic;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> _series = new List<Serie>();
        
        public List<Serie> Listar()
        {
            return _series;
        }

        public Serie Recuperar(int id)
        {
            return _series[id];
        }

        public void Inserir(Serie objeto)
        {
            _series.Add(objeto);
        }

        public void Excluir(int id)
        {
            _series[id].SetExcluido();
        }

        public void Atualizar(Serie objeto)
        {
            _series[objeto.GetId()] = objeto;
        }

        public int ProximoId()
        {
            return _series.Count;
        }
    }
}