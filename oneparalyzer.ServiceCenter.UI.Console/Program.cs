using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.DataAccess.Implementations;
using oneparalyzer.ServiceCenter.Domain.Entities;

using (var context = new ApplicationDbContext())
{
    context.Clients.Add(new Client("Андрей", "Юрьевич", "Пескишев"));
    context.Clients.Add(new Client("Антон", "Анатольевич", "Ишнев"));
    context.Spares.Add(new Spare("Аккумулятор", "Google Pixel 4a", 2000, 11));
    context.Spares.Add(new Spare("Дисплей", "Google Pixel 4a", 5000, 6));
    context.Services.Add(new Service("Замена аккумулятора", 1500));
    context.Services.Add(new Service("Замена дисплея", 2500));

    context.SaveChanges();

    

    context.SaveChanges();

    foreach (var item in context.Orders.Include(x => x.ServicesOrders).Include(x => x.SparesOrders))
    {
        Console.WriteLine($"{item.Id} - {item.Client.FirstName} {item.Client.LastName} {item.Client.Surname}");
        foreach (var i in item.SparesOrders)
        {
            Console.WriteLine($"{i.Spare.Title}");
        }
        foreach (var i in item.ServicesOrders)
        {
            Console.WriteLine($"{i.Service.Title}");
        }
    }

    
    
}




