using Interfaces.IApiService;
using Models.Sauces;
using PizzaApp.Context;

namespace Services.SauceService;

public class SauceService : IApiService<Sauce,SauceDto>
{
    private readonly PizzaAppContext _context;

    public SauceService(PizzaAppContext context)
    {
        _context = context;
    }

    public IEnumerable<Sauce> Index(IDictionary<string,object> args)
    {
        List<Sauce> sauces=_context.Sauces.ToList();
        return sauces;
    }
    public Sauce? GetById(int id)
    {
        var sauce=_context.Sauces.SingleOrDefault(s=>s.Id==id);
        return sauce;
    }
    public Sauce Post(SauceDto sauceDto)
    {
        // Sauce sauce= new Sauce {Name=sauceDto.Name};
        Sauce sauce = new Sauce {Name=sauceDto.Name};

        _context.Sauces.Add(sauce);
        _context.SaveChanges();
        return sauce;
    }
    public Sauce? Edit(SauceDto sauceDto,int id)
    {
        var sauce=_context.Sauces.Find(id);
        if(sauce==null)
        {
            return null;
        }else
        {
            sauce.Name=sauceDto.Name;
            _context.SaveChanges();
            return sauce;
        }
    }
    public void Delete(int id)
    {
        var sauce=_context.Sauces.SingleOrDefault(s=>s.Id == id);
        if(sauce!=null)
        {
            _context.Sauces.Remove(sauce);
            _context.SaveChanges();
        }
        
    }

}
