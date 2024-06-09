
using UnderstandingLINQ.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace UnderstandingLINQ
{
    internal class Program
    {
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.Key);
        //        Console.WriteLine(" - " + book.TitleCount);
        //    }
        //}
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }


        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }
        //Print the TitleId and the same Quantity and order id for every title
        void PrintTitleIdQuantityAndOrderId()
        {
            pubsContext context = new pubsContext();
            var sales = context.Sales
                        .GroupBy(s => s.TitleId, s => s, (tid, sale) => new { Key = tid, Quantity = sale.Sum(s => s.Qty), OrderIds = sale.Select(s => s.OrdNum).ToList() });

            foreach (var sale in sales)
            {
                Console.Write("TitleId: " + sale.Key);
                Console.WriteLine(" - Quantity: " + sale.Quantity);
                Console.WriteLine("OrderIds");
                foreach (var orderId in sale.OrderIds)
                {
                    Console.WriteLine(orderId);
                }
            }
        }

        void PrintOrderForEachTitle()
        {
            pubsContext pubsContext = new pubsContext();
            var orders = pubsContext.Sales
                            .GroupBy(s => s.TitleId, s => s, (tid, sale) => new { Id = tid, OrderDetails = sale.ToList() });
            foreach (var order in orders)
            {
                Console.WriteLine("Title id");
                Console.WriteLine(order.Id);

                Console.WriteLine("Order details are ");
                foreach (var item in order.OrderDetails)
                {
                    Console.WriteLine(item.OrdNum);
                    Console.WriteLine(item.Qty);
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintOrderForEachTitle();
        }
    }
}
