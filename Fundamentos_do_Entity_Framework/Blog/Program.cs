using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
    // Create
    // var tag = new Tag
    // {
    //     Name = ".NET",
    //     Slug = "dotnet"
    // };
    // context.Tags.Add(tag);
    // context.SaveChanges();
    
    // Update
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
    // tag.Name = ".NET";
    // tag.Slug = "dotnet";
    // context.Update(tag);
    // context.SaveChanges();
    
    // Delete
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // context.Remove(tag);
    // context.SaveChanges();
    
    // Read
    // var tags = context.Tags.Where(x => x.Name.Contains(".NET")).ToList(); // Sempre adicionar o ToList no final da query
    // var tags = context.Tags.AsNoTracking().ToList(); // AsNoTracking não traz os metadados. Ganha muito em performance. Nunca utilizar em Update ou Delete.
    // foreach (var tag in tags)
    // {
    //     Console.WriteLine(tag.Name);
    // }
    
    var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 2);
    // var tag = context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == 2); // No single, caso tenha mais de um objeto com o mesmo ID, um erro é retornado.
    Console.WriteLine(tag?.Name);
}