﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Services.Mapping;

namespace WebStoreGB.Services
{
    public class CartService : ICartService
    {
        private readonly ICartStore _CartStore;
        private readonly IProductData _ProductData;

        public CartService(ICartStore CartStore, IProductData ProductData)
        {
            _CartStore = CartStore;
            _ProductData = ProductData;
        }
        public void Add(int Id)
        {
            var cart = _CartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == Id);
            if (item is null)
                cart.Items.Add(new CartItem { ProductId = Id, Quantity = 1 });
            else
                item.Quantity++;
            _CartStore.Cart = cart;
        }

        public void Clear()
        {
            var cart = _CartStore.Cart;
            cart.Items.Clear();
            _CartStore.Cart = cart;
        }

        public void Decrement(int Id)
        {
            var cart = _CartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == Id);
            if (item is null) return;

            if (item.Quantity > 0) item.Quantity--;

            if (item.Quantity <= 0) cart.Items.Remove(item);

            _CartStore.Cart = cart;
        }

        public CartViewModel GetViewModel()
        {
            var products = _ProductData.GetProducts(new Domain.ProductFilter()
            {
                Ids = _CartStore.Cart.Items.Select(item => item.ProductId).ToArray()
            });

            var products_view = products.Products.ToView().ToDictionary(p => p.Id);

            return new CartViewModel
            {
                Items = _CartStore.Cart.Items
                .Where(item => products_view.ContainsKey(item.ProductId))
                .Select(item => (products_view[item.ProductId], item.Quantity))
            };
        }

        public void Remove(int Id)
        {
            var cart = _CartStore.Cart;

            var item = cart.Items.FirstOrDefault(x => x.ProductId == Id);
            if (item is null) return;
            cart.Items.Remove(item);

            _CartStore.Cart = cart;
        }
    }
}

