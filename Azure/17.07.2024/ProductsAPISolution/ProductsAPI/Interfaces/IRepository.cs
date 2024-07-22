namespace ProductsAPI.Interfaces
{
    
        public interface IRepository<K, T> where T : class
        {

            public Task<T> Get(K key);
            public Task<IEnumerable<T>> Get();
        }
    
}
