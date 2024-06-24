using Interfaces.IApiService;
using Microsoft.EntityFrameworkCore;
using Models.Pizzas;
using Models.Toppings;
using PizzaApp.Context;

namespace Services.PizzaService;

public class PizzaService : IApiService<Pizza, PizzaDto>
{
    private readonly PizzaAppContext _context;

    public PizzaService(PizzaAppContext context)
    {
        _context = context;
    }
    public void Delete(int id)
    {
        var pizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);
        if (pizza != null)
        {
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }
    }

    public Pizza? Edit(PizzaDto dto, int id)
    {
        var pizza = _context.Pizzas.SingleOrDefault(p => p.Id == id);
        if (pizza == null)
        {
            return null;
        }
        var sauce = _context.Sauces.SingleOrDefault(s => s.Id == dto.Sauce);
        if (sauce == null)
        {
            return null;
        }
    
        
        pizza.Name = dto.Name;
        pizza.Sauce = sauce;
        _context.SaveChanges();
        return pizza;
    }

    public Pizza? GetById(int id)
    {
        var pizza=_context.Pizzas
        .Include(p => p.Sauce)
        .Include(p=>p.Toppings)
        .SingleOrDefault(p => p.Id == id);
        if(pizza==null)
        {
            return null;
        }


        return pizza;
    }

    public IEnumerable<Pizza> Index(IDictionary<string, object> args)
    {
        List<Pizza> pizzas = _context.Pizzas
        .Include(p => p.Sauce)
        .Include(p=>p.Toppings)
        .ToList();

        

        return pizzas;
    }

    public Pizza? Post(PizzaDto dto)
    {
        var sauce = _context.Sauces.SingleOrDefault(s => s.Id == dto.Sauce);
        if (sauce == null)
        {
            return null;
        }
        Pizza pizza = new Pizza { Name = dto.Name, Sauce = sauce };


        var toppings=_context.Toppings.Where(tp=>dto.Toppings.Contains(tp.Id)).ToList();
        
        pizza.Toppings=toppings;

        _context.Pizzas.Add(pizza);


        
        _context.SaveChanges();
        
        
       
        return pizza;
    }
}