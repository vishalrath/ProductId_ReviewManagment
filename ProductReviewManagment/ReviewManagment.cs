using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagment
{
    class ReviewManagment
    {
        // <summary>
        /// UC1-Adding a values in a list
        /// </summary>
        /// <param name="products"></param>
        public static int AddingProductReview(List<ProductReview> products)
        {
            products.Add(new ProductReview() { productId = 1, userId = 1, review = "Good", rating = 14, isLike = true });
            products.Add(new ProductReview() { productId = 1, userId = 1, review = "Very Good", rating = 19, isLike = true });
            products.Add(new ProductReview() { productId = 2, userId = 6, review = "Average", rating = 10, isLike = true });
            products.Add(new ProductReview() { productId = 4, userId = 7, review = "Good", rating = 15, isLike = true });
            products.Add(new ProductReview() { productId = 9, userId = 8, review = "Average", rating = 11, isLike = true });
            products.Add(new ProductReview() { productId = 3, userId = 9, review = "Bad", rating = 6, isLike = false });


            IterateThroughList(products);
            return products.Count;
        }
        /// <summary>
        /// Display the details in list
        /// </summary>
        /// <param name="products"></param>
        public static void IterateThroughList(List<ProductReview> products)
        {
            foreach (ProductReview product in products)
            {
                Console.WriteLine("ProductId:{0}\t UserId:{1}\t Review:{2}\tRating:{3}\tIsLike:{4}\t", product.productId, product.userId, product.review, product.rating, product.isLike);
            }
        }
        /// <summary>
        /// UC2--->Retrieve Top Three Records Whose Rating is High
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static int RetrieveTopThreeRating(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n-------------Retrieving Top Three Records Based On Rating--------------");
            var res = (from product in products orderby product.rating descending select product).Take(3).ToList();
            IterateThroughList(res);
            return res.Count;
        }
        /// <summary>
        /// UC3-->Retrieve  records from list based on productid and rating > 3  
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static int[] RetrieveRecordsBasedOnRatingAndProductId(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n-----------Retrieve Records Based On Rating and Product Id-----------");
            var res = (from product in products where product.rating > 3 && (product.productId == 1 || product.productId == 4 || product.productId == 9) select product.productId).ToArray();
            return res;
        }
        /// <summary>
        ///  UC4-->Retrived the count of productId
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static string CountingProductId(List<ProductReview> products)
        {
            string res = null;
            AddingProductReview(products);
            var data = products.GroupBy(x => x.productId).Select(a => new { ProductId = a.Key, count = a.Count() });
            Console.WriteLine(data);
            foreach (var ele in data)
            {
                Console.WriteLine("ProductId " + ele.ProductId + " " + "Count " + " " + ele.count);
                Console.WriteLine("-------------");
                res += ele.ProductId + " " + ele.count + " ";
                Console.WriteLine(res);
            }
            return res;
        }
        /// <summary>
        /// UC5 and UC7---->Retrieving the product id in list
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static string RetrieveOnlyProductIdAndReviews(List<ProductReview> products)
        {
            string result = null;
            AddingProductReview(products);
            var res = products.Select(product => new { ProductId = product.productId, Review = product.review }).ToList();
            foreach (var ele in res)
            {
                Console.WriteLine("ProductId " + ele.ProductId + " " + "Review " + " " + ele.Review);
                result += ele.ProductId + " ";
            }
            return result;
        }
        /// <summary>
        /// UC6--->Skip Top five records
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public static int SkipTopFiveRecords(List<ProductReview> products)
        {
            AddingProductReview(products);
            Console.WriteLine("\n----------Skip Top Five records in list");
            var res = (from product in products orderby product.rating descending select product).Skip(5).ToList();
            IterateThroughList(res);
            return res.Count;
        }
        /// <summary>
        /// UC8-->Using DataTable 
        /// </summary>
        /// <param name="products"></param>
        public static DataTable CreateDataTable(List<ProductReview> products)
        {
            AddingProductReview(products);
            DataTable dt = new DataTable();
            dt.Columns.Add("productId");
            dt.Columns.Add("userId");
            dt.Columns.Add("rating");
            dt.Columns.Add("review");
            dt.Columns.Add("isLike", typeof(bool));

            foreach (var data in products)
            {
                dt.Rows.Add(data.productId, data.userId, data.rating, data.review, data.isLike);
            }
            //IterateTable(dt);
            return dt;
        }
        /// <summary>
        /// Iterate Thorugh Table
        /// </summary>
        /// <param name="table"></param>
        public static void IterateTable(DataTable table)
        {
            foreach (DataRow p in table.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
            }
        }
        /// <summary>
        /// UC9-retrieve the records whose column islike has true using (DataTable)
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static int ReturnsOnlyIsLikeFieldAsTrue()
        {
            List<ProductReview> products = new List<ProductReview>();
            DataTable table = CreateDataTable(products);
            int count = 0;
            var res = from t in table.AsEnumerable() where t.Field<bool>("isLike") == true select t;
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
                count++;
            }
            return count;
        }
        /// <summary>
        ///UC-10 Finding the average rating value
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static double AverageOfRating()
        {
            List<ProductReview> products = new List<ProductReview>();
            DataTable table1 = CreateDataTable(products);
            double result = (double)table1.Select().Where(p => p["rating"] != DBNull.Value).Select(c => Convert.ToDecimal(c["rating"])).Average();
            Console.WriteLine(result);
            return result;
        }
        //UC-11
        public static int ReturnsReviewMessageContainsGood()
        {
            List<ProductReview> products = new List<ProductReview>();
            DataTable table = CreateDataTable(products);
            int count = 0;
            var res = from t in table.AsEnumerable() where t.Field<string>("review") == "Good" select t;
            foreach (var p in res)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} ", p["productId"], p["userId"], p["rating"], p["review"], p["isLike"]);
                count++;
            }
            return count;
        }
    }
}
