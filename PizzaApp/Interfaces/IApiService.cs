namespace Interfaces.IApiService;
public interface IApiService<T,Y>
{
    public IEnumerable<T> Index(IDictionary<string,object> args);

    public T? GetById(int id);

    public T? Post (Y dto);

    public T? Edit (Y dto,int id);

    public void Delete (int id);
}