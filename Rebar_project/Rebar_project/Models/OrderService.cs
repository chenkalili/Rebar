using System;
using System.Collections.Generic;
using Rebar_project.DataAccess;
using Rebar_project.models;
using static Rebar_project.Models.ShakeOrder;

namespace Rebar_project.Models
{
    public class OrderService
    {
        private Order Order;
        private OrderDB OrderDB;

        public OrderService() { }

        public void InitData(ShakeOrder shakeOrder, ShakeMenu shakeMenu )
        {
            switch (shakeOrder.Size)
            {
                case ChooseSize.S:
                    shakeOrder.Price = shakeMenu.PriceSmall;
                    break;
                case ChooseSize.M:
                    shakeOrder.Price = shakeMenu.PriceMedium;
                    break;
                case ChooseSize.L:
                    shakeOrder.Price = shakeMenu.PriceLarge;
                    break;
                default:
                    break;
            }
            shakeOrder.Description = shakeMenu.Description;
        }
    }
}
