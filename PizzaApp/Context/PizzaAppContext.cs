using Microsoft.EntityFrameworkCore;
using Models.Pizzas;
using Models.Sauces;
using Models.Toppings;

namespace PizzaApp.Context;

public class PizzaAppContext:DbContext
{


    public PizzaAppContext (DbContextOptions<PizzaAppContext> options):base(options)
    {}
    
    public DbSet<Sauce> Sauces =>Set<Sauce>();



    public DbSet<Pizza> Pizzas=>Set<Pizza>();

    public DbSet<Topping> Toppings=>Set<Topping>();

    // public DbSet<PizzaTopping> PizzaToppings=>Set<PizzaTopping>();

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    // }

}