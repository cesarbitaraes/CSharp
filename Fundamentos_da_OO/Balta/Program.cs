using Balta.ContentContext;
using Balta.NotificationContext;
using Balta.SubscriptionContext;

namespace Balta;

public class Program
{
    static void Main(string[] args)
    {
        var articles = new List<Article>();
        articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
        articles.Add(new Article("Artigo sobre C#", "csharp"));
        articles.Add(new Article("Artigo sobre .Net", "dotnet"));

        foreach (var article in articles)
        {
            Console.WriteLine(article.Id);
            Console.WriteLine(article.Title);
            Console.WriteLine(article.Url);
        }

        var courses = new List<Course>();
        var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
        var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");
        var courseAspNet = new Course("Fundamentos ASP.Net", "fundamentos-aspnet");
        courses.Add(courseOOP);
        courses.Add(courseCsharp);
        courses.Add(courseAspNet);
        

        var careers = new List<Career>();
        var careerDotnet = new Career("Especialista .Net", "especialista-dotnet");
        var careerItem2 = new CareerItem(2, "Aprenda OOP", "", null);
        var careerItem = new CareerItem(1, "Comece por aqui", "", courseCsharp);
        var careerItem3 = new CareerItem(3, "Aprenda .Net", "", courseAspNet);
        
        careerDotnet.Items.Add(careerItem2);
        careerDotnet.Items.Add(careerItem);
        careerDotnet.Items.Add(careerItem3);
        careers.Add(careerDotnet);

        foreach (var career in careers)
        {
            Console.WriteLine(career.Title);
            foreach (var item in career.Items.OrderBy(x=>x.Order))
            {
                Console.WriteLine($"{item.Order} - {item.Title}");
                Console.WriteLine(item.Course?.Title);
                Console.WriteLine(item.Course?.Level);

                foreach (var notification in item.Notifications)
                {
                    Console.WriteLine($"{notification.Property} - {notification.Message}");
                }
            }
        }

        var payPalSubscription = new Subscription();
        var student = new Student();
        student.CreateSubscription(payPalSubscription);
    }
}