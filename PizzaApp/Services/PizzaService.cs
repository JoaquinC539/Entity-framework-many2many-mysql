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

        var toppingToDelete = _context.PizzaToppings
        .Where(pt => pt.PizzaId == pizza.Id)
        .ToList();

        _context.PizzaToppings.RemoveRange(toppingToDelete);
        List<Topping> toppingsToAdd=_context.Toppings
        .Where(tp=>dto.Toppings.Contains(tp.Id))
        .ToList();

        foreach(int topping_id in dto.Toppings)
        {
            PizzaTopping pt=new PizzaTopping {PizzaId=pizza.Id,ToppingId=topping_id};
            _context.PizzaToppings.Add(pt);
        }       
        
    
        
        pizza.Name = dto.Name;
        pizza.Sauce = sauce;
        _context.SaveChanges();
        pizza.Toppings=toppingsToAdd;
        return pizza;
    }

    public Pizza? GetById(int id)
    {
        var pizza=_context.Pizzas
        .Include(p => p.Sauce)
        .SingleOrDefault(p => p.Id == id);
        if(pizza==null)
        {
            return null;
        }

        var pts=_context.PizzaToppings
        .Where(pt=>pt.PizzaId==id)
        .ToList();

        var toppingIds=pts.Select(pt=>pt.ToppingId).ToList();

        var toppings=_context.Toppings
        .Where(tp=>toppingIds.Contains(tp.Id))
        .ToList();
        
        pizza.Toppings=toppings;


        return pizza;
    }

    public IEnumerable<Pizza> Index(IDictionary<string, object> args)
    {
        List<Pizza> pizzas = _context.Pizzas
        .Include(p => p.Sauce)
        .ToList();

        foreach(Pizza pizza in pizzas)
        {
            var pts=_context.PizzaToppings
            .Where(pt=>pt.PizzaId==pizza.Id)
            .ToList();

            var toppingIds=pts.Select(pt=>pt.ToppingId).ToList();

            var toppings=_context.Toppings
            .Where(tp=>toppingIds.Contains(tp.Id))
            .ToList();

            pizza.Toppings=toppings;
        }

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
        _context.Pizzas.Add(pizza);
        
        _context.SaveChanges();
        pizza.Toppings=new List<Topping>();
        foreach(var tpId in dto.Toppings)
        {
            var tp=_context.Toppings.SingleOrDefault(tp=>tp.Id==tpId);
            
            if(tp!=null)
            {
                pizza.Toppings.Add(tp);
                PizzaTopping pt=new PizzaTopping { PizzaId=pizza.Id, ToppingId=tpId};
                _context.PizzaToppings.Add(pt);
            }
        }
        
        _context.SaveChanges();
        return pizza;
    }
}