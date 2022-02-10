using DrinkApp.Models.Domains;
using DrinkApp.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.Models.Converters
{
    public static class DrinkConverter
    {
        public static DrinkWrapper ToWrapper(this Drink model)
        {
            return new DrinkWrapper
            {
                Id = model.Id,
                Name = model.Name,
                Weight = model.Weight,
                Score = model.Score,
                Sober = model.Sober,
               
                Group = new GroupWrapper
                {
                    Id = model.Group.Id,
                    Name = model.Group.Name
                },

                Beer = string.Join(", ", model.TypeDrink.Where(y => y.TypeDrinkId == (int)Alcohol.Beer).Select(y => y.Quantity)),

                Wine = string.Join(", ", model.TypeDrink.Where(y => y.TypeDrinkId == (int)Alcohol.Wine).Select(y => y.Quantity)),

                Vodka = string.Join(", ", model.TypeDrink.Where(y => y.TypeDrinkId == (int)Alcohol.Vodka).Select(y => y.Quantity)),





        };
        }


        public static Drink ToDao(this DrinkWrapper model)
        {
            return new Drink
            {
                Id = model.Id,
                Name = model.Name,
                Weight = model.Weight,
                Score = model.Score,
                Sober = model.Sober,
              
                GroupId = model.Group.Id,
                
            };
        }



        public static List<TypeDrink> ToTypeDao(this DrinkWrapper model)
        {
            var types = new List<TypeDrink>();

            if (!string.IsNullOrWhiteSpace(model.Beer))
            
                model.Beer.Split(',').ToList().ForEach(x => types.Add(
                    new TypeDrink
                    {
                        Quantity = int.Parse(x),
                        DrinkId = model.Id,
                        TypeDrinkId = (int)Alcohol.Beer

                    }
                    )); // dodawanie Beer!

            

            if (!string.IsNullOrWhiteSpace(model.Wine))

                model.Wine.Split(',').ToList().ForEach(x => types.Add(
                    new TypeDrink
                    {
                        Quantity = int.Parse(x),
                        DrinkId = model.Id,
                        TypeDrinkId = (int)Alcohol.Wine
                    }
                    )); // dodawanie Wina

            

            if (!string.IsNullOrWhiteSpace(model.Vodka))

                model.Vodka.Split(',').ToList().ForEach(x => types.Add(
                    new TypeDrink
                    {
                        Quantity = int.Parse(x),
                        DrinkId = model.Id,
                        TypeDrinkId = (int)Alcohol.Vodka
                    }
                    )); // Dodawanie Wódka!

          
          

            



            return types;

        }

     

    }
}
