using DrinkApp.Models.Domains;
using DrinkApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DrinkApp.Models.Converters;
using DrinkApp.Models;
using System.Windows;

namespace DrinkApp
{
    public class Repository
    {
        public List<Group> GetGroups()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Groups.ToList();
            }
        }

        public List<DrinkWrapper> GetDrinks(int groupId)
        {
            using (var context = new ApplicationDbContext())
            {
                var drinks = context.Drinks
                    .Include(x => x.Group).Include(x => x.TypeDrink).AsQueryable();

                if (groupId != 0)
                    drinks = drinks.Where(x => x.GroupId == groupId);



                return drinks.ToList().Select(x => x.ToWrapper()).ToList();

            }
        }

        internal void DeleteDrink(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var drinkToDelete = context.Drinks.Find(id);
                context.Drinks.Remove(drinkToDelete);
                context.SaveChanges();
            }
        }

        public void UpdateDrink(DrinkWrapper drinkWrapper)
        {
            var drink = drinkWrapper.ToDao();
            var drinkTypes = drinkWrapper.ToTypeDao();

            using (var context = new ApplicationDbContext())
            {
                UpdateDrinkProperties(context, drink);

                var drinksQuantity = GetDrinkTypes(context, drink);

                UpdateDrink(drink, drinkTypes, context, drinksQuantity, Alcohol.Beer);
                UpdateDrink(drink, drinkTypes, context, drinksQuantity, Alcohol.Wine);
                UpdateDrink(drink, drinkTypes, context, drinksQuantity, Alcohol.Vodka);

                context.SaveChanges();
            }
        }

        private static List<TypeDrink> GetDrinkTypes(ApplicationDbContext context, Drink drink)
        {
           return context.TypeDrinks.Where(x => x.DrinkId == drink.Id).ToList();
        }

        private void UpdateDrinkProperties(ApplicationDbContext context, Drink drink)
        {
            var drinkToUpdate = context.Drinks.Find(drink.Id);
            drinkToUpdate.Name = drink.Name;
            drinkToUpdate.Weight = drink.Weight;
            drinkToUpdate.Score = drink.Score;
            drinkToUpdate.Sober = drink.Sober;
            drinkToUpdate.GroupId = drink.GroupId;
        }

        private static void UpdateDrink(Drink drink, List<TypeDrink> newQuantity, ApplicationDbContext context, List<TypeDrink> drinkquantity, Alcohol alcohol)
        {
            var alcoQuantity = drinkquantity.Where(x => x.DrinkId == (int)alcohol).Select(x => x.Quantity);

            var newAlcoQuantity = newQuantity.Where(x => x.DrinkId == (int)alcohol).Select(x => x.Quantity);

            var alcoQuantityToDelete = alcoQuantity.Except(newAlcoQuantity).ToList();
            var alcoQuantityToAdd = newAlcoQuantity.Except(alcoQuantity).ToList();

            alcoQuantityToDelete.ForEach(x =>
            {
                var TypesToDelete = context.TypeDrinks.First(y =>
                y.Quantity == x &&
                y.DrinkId == drink.Id
                && y.TypeDrinkId == (int)alcohol);

                context.TypeDrinks.Remove(TypesToDelete);
            });

            alcoQuantityToAdd.ForEach(x =>
            {
                var typesToAdd = new TypeDrink
                {
                    Quantity = x,
                    DrinkId = drink.Id,
                    TypeDrinkId = (int)alcohol
                };

                context.TypeDrinks.Add(typesToAdd);
            });
        }

        public void AddDrink(DrinkWrapper drinkWrapper)
        {
            var drink = drinkWrapper.ToDao();
            var types = drinkWrapper.ToTypeDao();

            using (var context = new ApplicationDbContext())
            {
                var dbDrink = context.Drinks.Add(drink);

                types.ForEach(x =>
                {
                    x.DrinkId = dbDrink.Id;

                    context.TypeDrinks.Add(x);
                });

                context.SaveChanges();


                
            }
            
        }
    }
}
