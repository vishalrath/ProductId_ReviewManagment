using System;
using System.Collections.Generic;

namespace ProductReviewManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prodcut Review Management!!!!!!!!");
            Console.WriteLine("1:AddingProductReview 2:Retrieve Top Three Rating 3:Retrieve Records BasedOn Rating And ProductId 4:Counting ProductId 5:Retrieve Only  ProductId And Reviews  6:SkipTopFiveRecords 7:CreateDataTable  8:Avarege of rating");
            Console.WriteLine("Enter Option");
            int option = Convert.ToInt32(Console.ReadLine());
            //Creating a list for Product Review
            List<ProductReview> productReviews = new List<ProductReview>();
            switch (option)
            {
                case 1:
                    ReviewManagment.AddingProductReview(productReviews);
                    break;
                case 2:
                    ReviewManagment.RetrieveTopThreeRating(productReviews);
                    break;
                case 3:
                    ReviewManagment.RetrieveRecordsBasedOnRatingAndProductId(productReviews);
                    break;
                case 4:
                    ReviewManagment.CountingProductId(productReviews);
                    break;
                case 5:
                    ReviewManagment.RetrieveOnlyProductIdAndReviews(productReviews);
                    break;
                case 6:
                    ReviewManagment.SkipTopFiveRecords(productReviews);
                    break;
                case 7:
                    //ReviewManagment.AddingProductReview(productReviews);
                    ReviewManagment.CreateDataTable(productReviews);
                    break;

                case 8:
                    ReviewManagment.AverageOfRating();
                    ReviewManagment.ReturnsReviewMessageContainsGood();
                    break;

            }
        }
    }
    
}
