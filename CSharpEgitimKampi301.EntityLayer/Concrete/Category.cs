using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set;}
    }
}

/* 
  eğer ki değişken direkt sınıfın içine tanımlanırsa mesela int x; field
 Eğer ki sonuna get set alıyorsa Property
metotun içine tanımlanırsa değişken */


//int x; //field
//public int emir { get; set; } // Property

// void test()
//{
//    int z; //Değişken
//}