﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.BLL;
using SGFlooringCorp.UI.Workflows;
using SGFlooringCorp.Data;
using SGFlooringCorp.Models;
using SGFlooringCorp.UI.Utilities;


namespace SGFlooringCorp.UI.Workflows
{
    class DisplayOrderWorkflow
    {
        private List<Order> _currentOrder = new List<Order>();

        public void Execute()
        {
            DateTime date = UserInteractions.GetDateFromUser();

            DisplayAllOrdersForTheDay(date);
        }

       

        public void DisplayAllOrdersForTheDay(DateTime orderDate)
        {
            var ops = new OrderOperations();
            var response = ops.GetAllOrders(orderDate);

            Console.Clear();
            if (response.Success)
            {
                _currentOrder = response.Data;
                PrintOrderDetails(response);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Console.WriteLine(response.Message);
                UserInteractions.PressKeyToContinue();
            }
        }

        
        private void PrintOrderDetails(Response<List<Order>> response)
        {
            foreach (var item in response.Data)
            {
                Console.Write("Order #{0}: ", item.OrderNumber);
                Console.Write("{0}, ", item.CustomerName);
                Console.Write("{0}, ", item.ProductType);
                Console.Write("{0}, ", item.State);
                Console.Write("{0}, ", item.TaxRate);
                Console.Write("{0}, ", item.Area);
                Console.Write("{0} \n\n", item.Total);
                
            }
        }
       
    }
}