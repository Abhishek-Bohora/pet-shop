using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BusinessLogicLayer
{
    public class OrderDetailsBLL
    {
        public string username { get; set; }
        public int number { get; set; }
        public string address { get; set; }
        public int totalPrice { get; set; }
        public int petId { get; set; }
        public int breedId { get; set; }
    }
}
