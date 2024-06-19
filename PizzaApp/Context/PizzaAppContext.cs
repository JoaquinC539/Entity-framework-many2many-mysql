using Microsoft.EntityFrameworkCore;
using Models.Sauce;
using Models.Topping;

namespace PizzaApp.Context;

public class PizzaAppContext:DbContext
{


    public PizzaAppContext (DbContextOptions<PizzaAppContext> options):base(options)
    {}
    
    public DbSet<Sauce> Sauces =>Set<Sauce>();

    public DbSet<Topping> Toppings=>Set<Topping>();

}