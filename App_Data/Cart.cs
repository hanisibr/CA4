using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA4_10385012
{
    public class Cart
    {
        public Cart()
        {

        }

        List<Products> ProdLine;

        public List<Products> GetTheCart()
        {
            //retrieve products from this cart
            ProdLine = (List<Products>)HttpContext.Current.Session["Cart"];

            //Check list whether is empty or otherwise
            if(ProdLine == null)
            {
                ProdLine = new List<Products>();
            }
            return ProdLine;
        }

        public void SaveTheCart()
        {
            HttpContext.Current.Session["Cart"] = ProdLine;
        }
        
        public void AddProd(Products products)
        {
            //Get the same cart
            ProdLine = GetTheCart();

            //Add products to the same cart
            ProdLine.Add(products);

            //Update the session
            SaveTheCart();
        }

        public int GetProductAmount()
        {
            int ProdAmt = 0;
            ProdLine = GetTheCart();
            ProdAmt = ProdLine.Count();
            return ProdAmt;
        }

        public decimal GetProductTotal()
        {
            decimal total = 0;
            ProdLine = GetTheCart();

            foreach (var i in ProdLine)
            {
                total = total + i.Price;
            }
            return total;
        }

        public void EmptyTheCart()
        {
            ProdLine = (List<Products>)HttpContext.Current.Session["Cart"];

            //Check whether the list is empy or otherwise
            if (ProdLine != null)
            {
                //Create a blank/new list
                ProdLine = new List<Products>();
            }
            SaveTheCart();
        }

        public void DeleteFromCart(Products products)
        {
            //Retrieve the same cart
            ProdLine = GetTheCart();

            var ToRemove = ProdLine.FindIndex(i => i.ProductID == products.ProductID);

            ProdLine.RemoveAt(ToRemove);

            SaveTheCart();

        }

    }
}