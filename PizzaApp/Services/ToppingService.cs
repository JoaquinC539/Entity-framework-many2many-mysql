using Interfaces.IApiService;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Models.Toppings;
using PizzaApp.Context;

namespace Services.ToppingService;

public class ToppingService : IApiService<Topping, ToppingDto>
{
    private readonly PizzaAppContext _context;

    public ToppingService(PizzaAppContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var tp=_context.Toppings.SingleOrDefault(tp=>tp.Id == id);
       if (tp != null)
       {
            _context.Toppings.Remove(tp);
            _context.SaveChanges();
       }
    }

    public Topping? Edit(ToppingDto dto, int id)
    {
       var tp=_context.Toppings.SingleOrDefault(tp=>tp.Id == id);
       if (tp == null)
       {
            return null;
       }
       tp.Name = dto.Name;
       _context.SaveChanges();
       return tp;
    }

    public Topping? GetById(int id)
    {
        return _context.Toppings.SingleOrDefault(tp=>tp.Id == id);
    }

    public IEnumerable<Topping> Index(IDictionary<string, object> args)
    {
        return _context.Toppings                
        .ToList();
    }

    public Topping? Post(ToppingDto dto)
    {
        Topping tp=new Topping {Name=dto.Name};
        _context.Toppings.Add(tp);
        _context.SaveChanges();
        return tp;
    }
}