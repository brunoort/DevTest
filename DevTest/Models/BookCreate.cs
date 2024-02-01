using System;
namespace DevTest.Models
{
	public class BookCreate
	{
        public string title { get; set; }
        public string description { get; set; }
        public string isbn { get; set; }
        public string publisher { get; set; }
        public string language { get; set; }
        public double price { get; set; }
    }
}

