namespace Interfaces.IService;
public interface IService<T,Y>
{
    public ICollection<T> Index(IDictionary<string,object> args);

    public T? GetById(int id);

    public T Post (Y dto);

    public T? Edit (Y dto,int id);

    public void Delete (int id);
}