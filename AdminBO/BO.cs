using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBO
{
    public class BO
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    public class CustBo
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        string service;

        public string Service
        {
            get { return service; }
            set { service = value; }
        }
        string ret;

        public string Ret
        {
            get { return ret; }
            set { ret = value; }
        }
        string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

    }
}
