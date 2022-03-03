using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using bookstore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bookstore.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }

        [JsonIgnore]
        public ISession Session { get; set; }


        public override void AddItem(Book bk, int qty, double price)
        {
            base.AddItem(bk, qty, price);
            Session.SetJson("Basket", this);
        }

        public override void RemoveItem(Book bk)
        {
            base.RemoveItem(bk);
            Session.SetJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
