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

        public static bool isExist (int id)
        {
            return shirts.Any(x => x.Id == id);
        }

        public static ShirtModel? GetShirtModelById (int id) { return shirts.FirstOrDefault(x=>x.Id==id); }
    }
}
