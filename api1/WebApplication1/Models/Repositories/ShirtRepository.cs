using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repositories
{
    public static class ShirtRepository
    {
     private static List<Shirt> shirts=new List<Shirt>()
        {
            new Shirt{ShirtId=1,Brand ="brand1", Color= "Blue", Gender="Men", Size =55 },
            new Shirt{ShirtId=2,Brand ="brand2", Color= "Orange", Gender="WoMen" , Size =55 },
            new Shirt{ShirtId=3,Brand ="brand3", Color= "Rose", Gender="Women" , Size =55 },
            new Shirt{ShirtId=4,Brand ="brand4", Color= "Gray", Gender="Men" , Size =55}
        };

        public static bool ShirtExists(int Id)
        {
            return  shirts.Any(x => x.ShirtId==Id);
        }

        public static Shirt? GetShirtById(int id){
            return shirts.FirstOrDefault(x => x.ShirtId==id);
        }

        public static List<Shirt>? GetShirts(){
            return shirts;
        }
        public static void AddShirt(Shirt shirt){
            int maxId= shirts.Max(x => x.ShirtId);
            shirt.ShirtId=maxId +1;
            shirts.Add(shirt);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color,int? size )
        {
           return shirts.FirstOrDefault(x=>!string.IsNullOrWhiteSpace(brand)&& 
                                         !string.IsNullOrWhiteSpace(x.Brand)&& 
                                         x.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase)
                                         && !string.IsNullOrWhiteSpace(gender)&& 
                                         !string.IsNullOrWhiteSpace(x.Gender)&& 
                                         x.Gender.Equals(gender,StringComparison.OrdinalIgnoreCase)
                                         && !string.IsNullOrWhiteSpace(color)&& 
                                         !string.IsNullOrWhiteSpace(x.Color)&& 
                                         x.Color.Equals(color,StringComparison.OrdinalIgnoreCase)
                                         && size.HasValue 
                                         && x.Size.HasValue
                                          && size.Value==x.Size.Value
                                         );

        }

        public static void UpdateShirt(Shirt shirt) 
        {
            var shirtoUpdate= shirts.First(x=> x.ShirtId== shirt.ShirtId);
            shirtoUpdate.ShirtId = shirt.ShirtId;
            shirtoUpdate.Brand= shirt.Brand;
            shirtoUpdate.Gender= shirt.Gender;
            shirtoUpdate.Color= shirt.Color;
            shirtoUpdate.Size= shirt.Size;
            
        }

    }
}