using System;
using System.Collections.Generic;
using System.Text;

namespace Advanced_C__02.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public static List<Product> SearchProducts(List<Product> list, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (Product item in list)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        // Action delegate: Used for operations that perform a side effect without returning a value
        public static void PrintReport(List<Product> products, Action<Product> reportAction)
        {
            foreach (Product item in products)
            {
                reportAction(item);
            } 
        }
        // Func delegate: Used for operations that project/transform an input product into a output value
        public static List<TProduct> TransformProducts<TProduct>(List<Product> list, Func<Product, TProduct> transform)
        {
            List<TProduct> result = new List<TProduct>();
            foreach (Product item in list)
            {
                result.Add(transform(item));
            }
            return result;
        }
        // Predicate delegate: Used specifically for condition evaluation (returns boolean)
        public static List<Product> FilterProducts(List<Product> list, Predicate<Product> pred)
        {
            List<Product> result = new List<Product>();
            foreach (Product item in list)
            {
                if(pred(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
