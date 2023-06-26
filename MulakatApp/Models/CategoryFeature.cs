namespace MulakatApp.Models
{
    public class CategoryFeature
    {
        public static List<Category>? Category { get; set; }

        public  async Task CategoryDoldurAsync()
        {
            HttpClient client = new HttpClient();
            List<string>? categories = await client.GetFromJsonAsync<List<string>>("https://dummyjson.com/products/categories");

            List<Category> category = new List<Category>();
            int id = 1;
            foreach (string item in categories!)
            {
                category.Add(new Category() { ID = id, CategoryName = item });
                id += 1;
            }
            Category = category;
        }
    }
}
