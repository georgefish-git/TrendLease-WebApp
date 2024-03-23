﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrendLease_WebApp.App.Carts;
using TrendLease_WebApp.App.Products;
using TrendLease_WebApp.App.Wishlists;

namespace TrendLease_WebApp
{
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string username = Request.QueryString["username"];
            string prodID = Request.QueryString["prodID"];

            Session["Username"] = username;
            Session["ProdID"] = prodID;

            SpecificProductDataBind();

        }

        public void SpecificProductDataBind()
        {
            ProductRepository repository = new ProductRepository();

            ViewProductRepeater.DataSource = repository.GetSpecificProduct(Request.QueryString["prodID"]);
            ViewProductRepeater.DataBind();

        }

        // add item to wishlist
        protected void wishlistBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            // Find the productName label within the current repeater item
            Label productName = (Label)item.FindControl("productName");
            string prodName = productName.Text;

            WishlistRepository repository = new WishlistRepository();


            if (repository.IsItemInWishlist(Request.QueryString["username"], Request.QueryString["prodID"]))
            {
                Response.Write($"<script>alert('Item {prodName} is already in your wishlist.');</script>");
            }
            else
            {
                Response.Write($"<script>alert('Item {prodName} added to wishlist.');</script>");
                repository.InsertWishlist(Request.QueryString["username"], Request.QueryString["prodID"]);
            }

            SpecificProductDataBind();

        }

        // add item to cart
        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            string username = Request.QueryString["username"];
            string prodID = Request.QueryString["prodID"];

            
            CartRepository repository = new CartRepository();

            bool itemExistsInCart = repository.ItemExistsInCart(username, prodID);

         
            if (!itemExistsInCart)
            {
                repository.InsertItemCart(username, prodID);
                Response.Write($"<script>alert('Success! Item is added to cart.');</script>");
            }
            else
            {
                Response.Write($"<script>alert('Item is already in the cart.');</script>");
            }
        }
    }
}