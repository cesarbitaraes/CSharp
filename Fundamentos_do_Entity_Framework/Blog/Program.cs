using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
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
            
            // var tag = context.Tags.AsNoTracking().FirstOrDefault(x => x.Id == 2);
            // var tag = context.Tags.AsNoTracking().SingleOrDefault(x => x.Id == 2); // No single, caso tenha mais de um objeto com o mesmo ID, um erro é retornado.
            // Console.WriteLine(tag?.Name);

            // var user = new User
            // {
            //     Name = "André Baltieri",
            //     Slug = "andrebaltieri",
            //     Email = "andre@balta.io",
            //     Bio = "9x Microsoft MVP",
            //     Image = "https://balta.io",
            //     PasswordHash = "123098457"
            // };
            //
            // var category = new Category
            // {
            //     Name = "Backend",
            //     Slug = "backend"
            // };
            //
            // var post = new Post
            // {
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello world</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste artigo vamos aprender EF core",
            //     Title = "Começando com EF Core",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now,
            // };
            //
            // context.Posts.Add(post);
            // context.SaveChanges();

            // var posts = context
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x=>x.Author)
            //     .Include(x=>x.Category)
            //          //.ThenInclude() -> refere-se a Category. É um subselect.
            //     //.Where(x=>x.AuthorId == 1)
            //     .OrderByDescending(x=>x.LastUpdateDate)
            //     .ToList();
            //
            // foreach (var post in posts)
            //     Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
            
            // var post = context
            //     .Posts
            //     .Include(x=>x.Author)
            //     .Include(x=>x.Category)
            //     .OrderByDescending(x=>x.LastUpdateDate)
            //     .FirstOrDefault();
            //
            // post.Author.Name = "Teste";
            // context.Posts.Update(post);
            // context.SaveChanges();

            // context.Users.Add(new User
            // {
            //     Name = "César Bitarães",
            //     Slug = "cesar-bitaraes",
            //     Email = "cesar@balta.io",
            //     Bio = "9x Microsoft MVP",
            //     Image = "https://cesar.io",
            //     PasswordHash = "123098457"
            // });
            var user = context.Users.Where(x => x.Name.Equals("César Bitarães")).FirstOrDefault();
            var post = new Post
            {
                Author = user,
                Body = "Meu artigo",
                Category = new Category
                {
                    Name = "Frontend",
                    Slug = "frontend"
                },
                CreateDate = DateTime.Now,
                Slug = "meu-artigo",
                Summary = "Este é meu novo artigo",
                Title = "Meu-artigo"
            };
            context.Posts.Add(post);
            context.SaveChanges();
            
            // AsNoTracking(): usamos quando não vamos alterar, incluir ou excluir essas informações buscadas no banco.
            // Lazy loading: aconteceu quando definimos propriedades como virtual. Só vai carregar essa propriedade quando acessada explicitamente.
            // Eager loading: modo padrão. Precisamos usar o Include para obter as propriedades de outras tabelas (join).

            var posts = context.Posts
                .Include(x => x.Author)
                .ThenInclude(x => x.Roles); // ThenInclude é referente ao Author (User). Executa um subselect. Não é recomendado.

            var postsWithTags = context.PostWithTagsCounts.ToList();
            foreach (var item in postsWithTags)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Count);
            }

        }
    }

    public static List<Post> GetPosts(BlogDataContext context, int skip = 0, int take = 25)
    {
        // skip e take fazem a paginação do retorno.
        var posts = context
            .Posts
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .ToList();
        return posts;
    }
    
    
}

