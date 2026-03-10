using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceSystem.Models;
using ECommerceSystem.Services;
using ECommerceSystem.Repositories;
using ECommerceSystem.Payment;
using ECommerceSystem.Shipping;
using ECommerceSystem.Discounts;

namespace ECommerceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== E-Commerce Order System ===\n");

            var productRepository = new ProductRepository();
            var cartService = new ShoppingCartService();
            var orderService = new OrderService();

            SeedProducts(productRepository);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Browse Products");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Orders");
                Console.WriteLine("5. Exit");
                Console.Write("Select option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BrowseProducts(productRepository, cartService);
                        break;
                    case "2":
                        ViewCart(cartService);
                        break;
                    case "3":
                        PlaceOrder(cartService, orderService);
                        break;
                    case "4":
                        ViewOrders(orderService);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        static void SeedProducts(ProductRepository repository)
        {
            repository.Add(new Product(1, "Laptop", 999.99m, "High-performance laptop"));
            repository.Add(new Product(2, "Mouse", 29.99m, "Wireless mouse"));
            repository.Add(new Product(3, "Keyboard", 89.99m, "Mechanical keyboard"));
            repository.Add(new Product(4, "Monitor", 299.99m, "4K Monitor"));
        }

        static void BrowseProducts(ProductRepository productRepo, ShoppingCartService cartService)
        {
            var products = productRepo.GetAll();
            Console.WriteLine("\n=== Available Products ===");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} - ${product.Price:F2}");
                Console.WriteLine($"   {product.Description}\n");
            }

            Console.Write("Enter product ID to add to cart (0 to go back): ");
            if (int.TryParse(Console.ReadLine(), out int productId) && productId > 0)
            {
                var product = productRepo.GetById(productId);
                if (product != null)
                {
                    Console.Write("Enter quantity: ");
                    if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                    {
                        cartService.AddItem(product, quantity);
                        Console.WriteLine($"Added {quantity} x {product.Name} to cart!");
                    }
                }
                else
                {
                    Console.WriteLine("Product not found!");
                }
            }
        }

        static void ViewCart(ShoppingCartService cartService)
        {
            var cart = cartService.GetCart();
            Console.WriteLine("\n=== Shopping Cart ===");

            if (!cart.Items.Any())
            {
                Console.WriteLine("Cart is empty!");
                return;
            }

            foreach (var item in cart.Items)
            {
                Console.WriteLine($"{item.Product.Name} x {item.Quantity} - ${item.Subtotal:F2}");
            }
            Console.WriteLine($"Total: ${cart.Total:F2}");
        }

        static void PlaceOrder(ShoppingCartService cartService, OrderService orderService)
        {
            var cart = cartService.GetCart();
            if (!cart.Items.Any())
            {
                Console.WriteLine("Cannot place order: Cart is empty!");
                return;
            }

            Console.WriteLine("\n=== Place Order ===");
            Console.WriteLine("Select payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.Write("Choice: ");

            IPaymentProcessor paymentProcessor = null;
            string paymentChoice = Console.ReadLine();

            if (paymentChoice == "1")
                paymentProcessor = new CreditCardProcessor();
            else if (paymentChoice == "2")
                paymentProcessor = new PayPalProcessor();

            if (paymentProcessor == null)
            {
                Console.WriteLine("Invalid payment method!");
                return;
            }

            Console.WriteLine("\nSelect shipping method:");
            Console.WriteLine("1. Standard Shipping");
            Console.WriteLine("2. Express Shipping");
            Console.Write("Choice: ");

            IShippingCalculator shippingCalculator = null;
            string shippingChoice = Console.ReadLine();

            if (shippingChoice == "1")
                shippingCalculator = new StandardShipping();
            else if (shippingChoice == "2")
                shippingCalculator = new ExpressShipping();

            if (shippingCalculator == null)
            {
                Console.WriteLine("Invalid shipping method!");
                return;
            }

            IDiscountStrategy discount = new NoDiscount();
            if (cart.Total > 500)
            {
                discount = new PercentageDiscount(10);
            }

            var order = orderService.CreateOrder(cart, paymentProcessor, shippingCalculator, discount);
            Console.WriteLine($"\nOrder placed successfully! Order ID: {order.Id}");
            Console.WriteLine($"Total amount: ${order.TotalAmount:F2}");
            Console.WriteLine($"Payment status: {order.PaymentStatus}");

            cartService.ClearCart();
        }

        static void ViewOrders(OrderService orderService)
        {
            var orders = orderService.GetAllOrders();
            Console.WriteLine("\n=== Order History ===");

            if (!orders.Any())
            {
                Console.WriteLine("No orders found!");
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Order #{order.Id} - ${order.TotalAmount:F2} - {order.Status} - {order.PaymentStatus}");
                Console.WriteLine($"Date: {order.OrderDate}");
                Console.WriteLine($"Shipping: {order.ShippingMethod}");
                Console.WriteLine();
            }
        }
    }
}