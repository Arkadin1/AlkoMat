using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DrinkApp.Models.Wrappers
{
    public class DrinkWrapper : IDataErrorInfo
    {


        public DrinkWrapper()
        {
            Group = new GroupWrapper();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Weight { get; set; }

        public string Beer { get; set; }

        public string Wine { get; set; }

        public string Vodka { get; set; }

       

        public int Score {
            get
            {
                var BeerToString = Beer;
                var BeerToInt = int.Parse(BeerToString);

                var WineToString = Wine;
                var WineToInt = int.Parse(WineToString);

                var VodkaToString = Vodka;
                var VodkaToInt = int.Parse(VodkaToString);

               

                var Score = (BeerToInt + WineToInt + VodkaToInt)*10;
                var Scor2e = (BeerToInt + WineToInt + VodkaToInt) * 10;

               


                return Score;

                
                
            }

            set
            {
               
            }
            
          
        }


        public bool Sober {
            get
            {
                
                if (Score == 0)
                {
                    return Sober = true;
                    
                }
                else
                {
                 
                    return Sober = false;
                }

            }
            set
            {
                
            }

        }


       

        public GroupWrapper Group { get; set; }


        private bool _IsNameValid;
        private bool _IsWeightValid;



        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Error = "Pole Nazwa jest wymagane";
                            _IsNameValid = false;

                        }
                        else
                        {
                            Error = string.Empty;
                            _IsNameValid = true;
                        }
                        break;
                    case nameof(Weight):
                        if (string.IsNullOrWhiteSpace(Weight))
                        {
                            Error = "Pole Waga jest wymagane";
                            _IsWeightValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _IsWeightValid = true;
                        }
                        break;

                    default:
                        
                        break;
                }

               

                return Error;
                
            }

           
        }



        public string Error { get; set; }

        public bool IsValid
        {
            get
            {
                return _IsNameValid && _IsWeightValid && Group.IsValid;
               
            }
        }

      
    }


}
