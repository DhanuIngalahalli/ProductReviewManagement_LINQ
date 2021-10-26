﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement_LINQ
{
    public class Management
    {
        public readonly DataTable datatable = new DataTable();
        /// <summary>
        ///   UC2
        /// </summary>
        /// <param name="listProductReview"></param>
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                     + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }

        /// <summary>
        ///   UC3
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProducID == 1 || productReviews.ProducID == 4 || productReviews.ProducID == 9)
                               && productReviews.Rating > 3
                               select productReviews;
            Console.WriteLine(recordedData);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                    + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }

        }

        /// <summary>
        ///   UC4
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(y => y.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });


            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "--------" + list.Count);

            }
        }
        /// <summary>
        ///   UC5
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductID_Review(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { ProductID = x.ProducID, ProductReview = x.Review });
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProductID + " " + "Review:- " + list.ProductReview);
            }
        }
        /// <summary>
        ///   UC6
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {

            var recordedData = (from productReviews in listProductReview select productReviews).Skip(5).ToList(); ;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                     + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
    }
}
