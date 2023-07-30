namespace BaseSerializationProject
{
    public interface IRepository<T>
    {
        void Serialize(T entity);

        T Deserialize();
    }
}
