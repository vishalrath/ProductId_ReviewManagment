using System;
using System.Collections.Generic;
using System.Linq;

namespace Uc3_Retrive_all_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 st method
            //List<ProductReview> list = new List<ProductReview>();
            //list.Add(new ProductReview() { ProductId = 1, UserId = 1, Review = "good", Rating = 17, IsLike = true });

            //2 nd method
            //Collection intializer
            List<ProductReviews> list = new List<ProductReviews>()
            {
                new ProductReviews(){ ProductId=1,UserId=1,Review="good",Rating=17,IsLike=true},
                new ProductReviews(){ ProductId=2,UserId=3,Review="bad",Rating=1,IsLike=false},
                new ProductReviews(){ ProductId=3,UserId=5,Review="good",Rating=20,IsLike=true},
                new ProductReviews(){ ProductId=4,UserId=7,Review="average",Rating=10,IsLike=true},
                new ProductReviews(){ ProductId=5,UserId=1,Review="bad",Rating=5,IsLike=false}
            };
            Console.WriteLine("Top 3 Records : ");
            RetrieveTop3RecordsFromList(list);
            Console.WriteLine("\n");
            RetrieveRecordsBasedOnRatingAndProductId(list);

        }
        //This method for retrieve top three records from list
        public static void RetrieveTop3RecordsFromList(List<ProductReviews> list)
        {
            //Query syntax for LINQ 
            var result = from product in list orderby product.Rating descending select product;
            var topThreeRecords = result.Take(3);
            foreach (ProductReviews product in topThreeRecords)
            {
                Console.WriteLine("ProductId : " + product.ProductId + " UserId : " + product.UserId + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
            }
        }
        //This method for retrieve the records based on rating and product identifier.      
        public static void RetrieveRecordsBasedOnRatingAndProductId(List<ProductReviews> list)
        {
            //where means using linq list
            var data = (list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9))).ToList();
            foreach (var element in data)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " Rating : " + element.Rating + " UserId : " + element.UserId + " Review : " + element.Review + " IsLike : " + element.IsLike);
            }
        }
    }
    
}
