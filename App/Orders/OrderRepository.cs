﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrendLease_WebApp.App.Orders
{
    public class OrderRepository
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public string GetTransactionID(string username)
        {

            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"SELECT orderNum
                                FROM InfoUsers
                                WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int currOrder = (int)result;
                    string transactionID = $"C-{username}-{currOrder}";


                    // update the order number
                    command.CommandText = @"UPDATE InfoUsers
                                    SET orderNum = @newOrderNum
                                    WHERE username = @username";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@newOrderNum", currOrder + 1);
                    command.Parameters.AddWithValue("@username", username);
                    command.ExecuteNonQuery();


                    return transactionID;
                }
                else
                {
                    return "";
                }
            }
        }


        public void StorePaymentInfo(PaymentInfo payment)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"INSERT INTO PaymentInfo
                                        VALUES(@orderID, @username, @cardName, @cardNum)";
                command.Parameters.AddWithValue("orderID", payment.orderID);
                command.Parameters.AddWithValue("username", payment.username);
                command.Parameters.AddWithValue("cardName", payment.cardName);
                command.Parameters.AddWithValue("cardNum", payment.cardNum);

                command.ExecuteNonQuery();
            }
        }


        public void StoreOrderForm(OrderForm form)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"INSERT INTO OrderForm
                                        VALUES(@orderID, @username, @orderStatus, @orderTotal, @orderDate, @orderTime, @returnDate)";
                command.Parameters.AddWithValue("orderID", form.orderID);
                command.Parameters.AddWithValue("username", form.username);
                command.Parameters.AddWithValue("orderStatus", form.orderStatus);
                command.Parameters.AddWithValue("orderTotal", form.orderTotal);
                command.Parameters.AddWithValue("orderDate", form.orderDate);
                command.Parameters.AddWithValue("orderTime", form.orderTime);
                command.Parameters.AddWithValue("returnDate", form.returnDate);

                command.ExecuteNonQuery();
            }
        }


        public void StoreOrderItem(string transactionID, string username)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                // retrieve cart items
                command.CommandText = @"SELECT *
                                FROM CartItems
                                WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);

                using (var reader = command.ExecuteReader())
                {
                    List<OrderItems> orderItemsList = new List<OrderItems>();

                    while (reader.Read())
                    {
                        OrderItems orderItem = new OrderItems();
                        orderItem.orderID = transactionID; 
                        orderItem.prodID = reader["prodID"].ToString();
                        //orderItem.price = Convert.ToSingle(reader["price"]);

                        orderItemsList.Add(orderItem);
                    }

                    reader.Close();


                    // delete the data from the CartItems table
                    using (var deleteCommand = connection.CreateCommand())
                    {
                        deleteCommand.CommandText = @"DELETE FROM CartItems WHERE username = @username";
                        deleteCommand.Parameters.AddWithValue("@username", username);
                        deleteCommand.ExecuteNonQuery();
                    }


                    // store ordered items
                    foreach (var item in orderItemsList)
                    {
                        using (var insertCommand = connection.CreateCommand())
                        {
                            insertCommand.CommandText = @"INSERT INTO OrderItems (orderID, prodID, price)
                                                  VALUES (@orderID, @prodID, @price)";
                            insertCommand.Parameters.AddWithValue("@orderID", item.orderID);
                            insertCommand.Parameters.AddWithValue("@prodID", item.prodID);
                            insertCommand.Parameters.AddWithValue("@price", item.price);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        // get order forms 
        public IEnumerable<OrderForm> GetUserOrderForms(string username)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"SELECT * FROM OrderForm WHERE username = @username";
                command.Parameters.Add("username", username);


                List<OrderForm> orderForms = new List<OrderForm>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        TimeSpan orderTime = reader.GetTimeSpan(reader.GetOrdinal("orderTime"));

                        OrderForm orderForm = new OrderForm (
                            reader["orderID"].ToString(),
                            username,
                            reader["orderStatus"].ToString(),
                            Convert.ToDateTime(reader["orderDate"]),
                            Convert.ToDateTime(reader["returnDate"]),
                            reader.GetOrdinal("orderTotal"),
                            orderTime
                        );
                       

                        orderForms.Add(orderForm); 
                    }

                }

                return orderForms;

            }
           
        }



    }
}