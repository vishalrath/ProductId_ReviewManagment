using System;
using System.Collections.Generic;
using System.Linq;

namespace Uc7_RetriveOnlyProductId
{
    class Program
    {
        static void Main(string[] args)
        {
            //Collection intializer
            List<ProductReviews> list = new List<ProductReviews>()
            {
                new ProductReviews(){ ProductId=1,UserId=1,Review="good",Rating=17,IsLike=true},
                new ProductReviews(){ ProductId=2,UserId=3,Review="bad",Rating=1,IsLike=false},
                new ProductReviews(){ ProductId=3,UserId=5,Review="good",Rating=20,IsLike=true},
                new ProductReviews(){ ProductId=4,UserId=7,Review="average",Rating=10,IsLike=true},
                new ProductReviews(){ ProductId=5,UserId=1,Review="bad",Rating=5,IsLike=false},

              new ProductReviews() { ProductId = 6, UserId = 9, Review = "Bad", Rating = 6, IsLike = false },
             new ProductReviews() { ProductId = 7, UserId = 11, Review = "average", Rating = 6, IsLike = true }
        };
            Console.WriteLine("Top 3 Records : ");
            RetrieveTop3RecordsFromList(list);
            Console.WriteLine("\n");
            Console.WriteLine("Records based on rating and product id : ");
            RetrieveRecordsBasedOnRatingAndProductId(list);
            Console.WriteLine("\n");
            Console.WriteLine("Counting Ech Product Id Present in List");
            CountingProductId(list);
            Console.WriteLine("\n");
            Console.WriteLine("Retrive product ID and review present in the list");
            RetrieveProductIDAndReview(list);
            Console.WriteLine("\n");
            Console.WriteLine("Skip Top 5 Record in  list");
            SkipTop5RecordsFromList(list);
            Console.WriteLine("\n");
            Console.WriteLine("Retrive Only Product id Review all Record in  list");
            RetrieveProductIDAndReviewAllRecord(list);


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
        //uc3

        //This method for retrieve the records whose rating is greater than 3
        //and product id is either1 or 4 or 9
        public static void RetrieveRecordsBasedOnRatingAndProductId(List<ProductReviews> list)
        {
            //method syntax linq
            //where means using linq list
            var data = (list.Where(r => r.Rating > 3 && (r.ProductId == 1 || r.ProductId == 4 || r.ProductId == 9))).ToList();
            foreach (var element in data)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " Rating : " + element.Rating + " UserId : " + element.UserId + " Review : " + element.Review + " IsLike : " + element.IsLike);
            }
        }
        // uc4
        //counting each ID present the list
        public static void CountingProductId(List<ProductReviews> list)
        {
            // method syntax for Linq
            var data = list.GroupBy(p => p.ProductId).Select(x => new { ProductId = x.Key, count = x.Count() });
            foreach (var element in data)
            {
                Console.WriteLine("ProductId " + element.ProductId + "\t" + "Count" + element.count);
                Console.WriteLine("--------------");
            }

        }
        //UC-5
        //Retrive product ID and review present in the list
        public static void RetrieveProductIDAndReview(List<ProductReviews> list)
        {
            //using select method
            var p = list.Select(product => new { ProductId = product.ProductId, Review = product.Review }).ToList();
            foreach (var element in p)
            {
                Console.WriteLine("ProductId : " + element.ProductId + " \t " + "Review" + element.Review);
                Console.WriteLine("-----------------------");
            }
        }
        //UC6
        //This method for skip top 5 rcords and retrive other data
        public static void SkipTop5RecordsFromList(List<ProductReviews> list)
        {
            //Query syntax for LINQ 
            var result = (from product in list orderby product.Rating descending select product).Skip(5);
            var remainingRecords = result;
            foreach (ProductReviews product in remainingRecords)
            {
                Console.WriteLine("ProductId : " + product.ProductId + " UserId : " + product.UserId + " Rating : " + product.Rating + " Review : " + product.Review + " IsLike : " + product.IsLike);
            }
        }
        //UC-7
        //This method for Retrieve Only product id and review from list of all recoprds
        public static void RetrieveProductIDAndReviewAllRecord(List<ProductReviews> productReviewsList)
        {
            var p = productReviewsList.Select(product => new { productID = product.ProductId, review = product.Review });
            foreach (var element in p)
            {
                Console.WriteLine("ProductID: " + element.productID + "\t" + "Review:" + element.review);
            }
        }
    }
    
}
