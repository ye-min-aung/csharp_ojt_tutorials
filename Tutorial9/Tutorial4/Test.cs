using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial9
{
    internal class Test
    {

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
        }
        public void print()
        {
            List<int> name = new List<int> { 1, 2, 3, 4 };
            IEnumerable<int> list = from a in name where a > 2 select a;
            foreach (var n in list)
            {
                //MessageBox.Show(n.ToString());
            }

            var product = new List<Product>
            {
                new Product{ Id = 1, Name = "Mac", Description = "M3 max chip with 8 memory", Price = 1099},
                new Product{ Id = 2, Name = "Dell", Description = "i7 intel chip with 512 SSD", Price = 1399},
                new Product{ Id = 3, Name = "Lenovo", Description = "Ryzen 5 with 16GB memory", Price = 1199},
            };

            //var expensiveProduct = from p in product where p.Price >1100 select p;
            var expensiveProduct = product.OrderBy(p => p.Price);

            foreach (var n in expensiveProduct)
            {
                MessageBox.Show(n.Price.ToString());
            }
        }
    }
}
