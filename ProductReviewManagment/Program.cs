using System;
using System.Collections.Generic;

namespace ProductReviewManagment
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
            RetrieveTop3RecordsFromList(list);
            Console.ReadLine();
        }
        //This method for retrieve top three records from list
        public static void RetrieveTop3RecordsFromList(List<ProductReviews> list)
        {
           
            foreach (ProductReviews product in list)
            {
                Console.WriteLine("ProductId : " + product.ProductId + " UserId : " + product.UserId + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
            }
        }
    }
    
}
