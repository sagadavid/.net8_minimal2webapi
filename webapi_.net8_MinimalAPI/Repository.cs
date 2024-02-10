using Microsoft.AspNetCore.Http.HttpResults;

namespace webapi_.net8_MinimalAPI
{
    public static class Repository
    {
        private static List<ShirtModel> shirts = new List<ShirtModel>()
        {
        new ShirtModel { Id = 1, Brand = "Matsumi", Color="Greenish", Gender="Female", Price=21, Size=5},
         new ShirtModel { Id = 2, Brand = "Takusaki", Color="Purple", Gender="Male", Price=21, Size=6},
          new ShirtModel { Id = 3, Brand = "Finsuta", Color="Blue", Gender="Male", Price=21, Size=9},
           new ShirtModel { Id = 4, Brand = "Komansi", Color="Yellowish", Gender="Female", Price=21, Size=4}
        };

        public static bool shirtExists(int id)
        {
            return shirts.Any(x => x.Id == id);
        }

        public static ShirtModel? GetShirtModelById(int id) { return shirts.FirstOrDefault(x => x.Id == id); }

        public static List<ShirtModel> GetShirtModel() { return shirts; }

        public static void AddShirts(ShirtModel shirt)
        {
            var maxId = shirts.Max(x => x.Id);
            shirt.Id = maxId + 1;
            shirts.Add(shirt);
        }

        public static ShirtModel? GetShirtByProperties
            (string? brand, string? color, string? gender, int? size)
        {
            return shirts.FirstOrDefault
                (x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)
            &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
            &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
            &&
            size.HasValue && x.Size.HasValue &&
            size.Value == x.Size.Value);
        }

        public static void UpdateShirt(ShirtModel shirt)
        { 
        var shirtToUpdate = shirts.First(x=> x.Id == shirt.Id); 
        shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Size = shirt.Size;
            
        
        }
    }
}
