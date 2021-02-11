namespace Series
{
    public abstract class Entidade
    {
        protected int Id { get; set; }
        protected bool IsExcluido { get; set; }
    
        public void SetExcluido()
        {
            IsExcluido = true;
        }

        public bool Excluido()
        {
            return IsExcluido;
        }
    }
}