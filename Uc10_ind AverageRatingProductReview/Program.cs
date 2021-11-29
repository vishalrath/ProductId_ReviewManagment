using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Uc10_ind_AverageRatingProductReview
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
            //Console.WriteLine("Top 3 Records : ");
            //RetrieveTop3RecordsFromList(list);
            //Console.WriteLine("\n");
            //Console.WriteLine("Records based on rating and product id : ");
            //RetrieveRecordsBasedOnRatingAndProductId(list);
            //Console.WriteLine("\n");
            //Console.WriteLine("Counting Ech Product Id Present in List");
            //CountingProductId(list);
            //Console.WriteLine("\n");
            //Console.WriteLine("Retrive product ID and review present in the list");
            //RetrieveProductIDAndReview(list);
            //Console.WriteLine("\n");
            //Console.WriteLine("Skip Top 5 Record in  list");
            //SkipTop5RecordsFromList(list);
            //Console.WriteLine("\n");
            //Console.WriteLine("Retrive Only Product id Review all Record in  list");
            //RetrieveProductIDAndReviewAllRecord(list);
            //Console.WriteLine("\n");
            CreateDataTable();
            //CreateDataTable(ProductReviews);
            //RetrieveDataFromDataTable(ProductReviews);
            //  IterateTable(table);
            Console.WriteLine("\n");
            Console.WriteLine("Finding the average rating value");
           // AverageOfRating();



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
        //uc8
        //This method for create data table 
        public static void CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductID", typeof(int));
            table.Columns.Add("UserID", typeof(int));
            table.Columns.Add("Rating", typeof(int));
            table.Columns.Add("Review", typeof(string));
            table.Columns.Add("IsLike", typeof(bool));

            table.Rows.Add(1, 1, 15, "good", true);
            table.Rows.Add(2, 2, 5, "bad", false);
            table.Rows.Add(3, 5, 19, "good", true);
            table.Rows.Add(4, 7, 10, "average", true);
            table.Rows.Add(5, 2, 5, "bad", false);
            table.Rows.Add(6, 5, 20, "good", true);
            table.Rows.Add(7, 7, 13, "average", true);
            table.Rows.Add(8, 1, 7, "bad", false);

            RetrieveDataFromDataTable(table);
            RetrieveDataFromDataTables(table);
           
            
        }
        public static void RetrieveDataFromDataTable(DataTable table)
        {
            var result = (from product in table.AsEnumerable() select product.Field<int>("ProductID")).ToList();
            Console.WriteLine("Product ID are");
            foreach (var product in result)
            {
                Console.WriteLine(product);
            }
        }
        //UC-9
        //This method for retrieve records who's Islike value is true
        public static void RetrieveDataFromDataTables(DataTable table)
        {
            //AsEnumerable this obj can be use LinQ expression or method
            //Field provid strongly type access of each column value in the specify row
            var result = (from product in table.AsEnumerable() where product.Field<bool>("IsLike") == true select product.Field<int>("ProductID")).ToList();
            Console.WriteLine("Product Id of Who's Islike value is true are : ");
            foreach (var product in result)
            {
                Console.WriteLine("Product ID : " + product);
            }
        }
        // uc10 
        /// <summary>
        /// Finding the average rating value
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        //public static double AverageOfRating()
        //{
        //    List<ProductReviews> products = new List<ProductReviews>();
        //     DataTable table1 = CreateDataTable(products);
        //    double result = (double)table1.Select().Where(p => p["Rating"] != DBNull.Value).Select(c => Convert.ToDecimal(c["Rating"])).Average();
        //    Console.WriteLine(result);
        //    return result;
        //}
        //This method for Retrieve Only product id and review from list of all recoprds
        

    }
    
}
