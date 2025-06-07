using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using LibraryManagement.Models;

public class AuthorSeeder : IDbSeeder
{
    public void Seed(LibraryDbContext context)
    {
        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                    new Author { FullName = "Ahmed Ali Hassan Omar", Email = "ahmed@example.com", Website = "https://ahmed.com", Bio = "Specializes in historical fiction." },
                    new Author { FullName = "Sara Mohamed Fathy Hamed", Email = "sara@example.com", Website = "https://sara.com", Bio = "Writes romance and adventure stories." },
                    new Author { FullName = "Youssef Adel Samir Ahmed", Email = "youssef@example.com", Website = "https://youssef.com", Bio = "Focuses on science fiction and futuristic tales." },
                    new Author { FullName = "Laila Hassan Mostafa Omar", Email = "laila@example.com", Website = "https://laila.com", Bio = "Author of popular children's books and educational material." },
                    new Author { FullName = "Khaled Mahmoud Saber Fathi", Email = "khaled@example.com", Website = "https://khaledwrites.com", Bio = "Expert in war novels and political thrillers." },
                    new Author { FullName = "Mariam Ehab Lotfy Nabil", Email = "mariam@example.com", Website = "https://mariamwrites.com", Bio = "Known for inspirational non-fiction writing." },
                    new Author { FullName = "Tamer Nabil Said Farid", Email = "tamer@example.com", Website = "https://tamerbooks.com", Bio = "Mystery novel writer with a psychological twist." },
                    new Author { FullName = "Huda Ibrahim Khalil Sami", Email = "huda@example.com", Website = "https://hudastories.com", Bio = "Writes about women's empowerment and social change." },
                    new Author { FullName = "Mohamed Gamal Rashad Zaki", Email = "mohamed@example.com", Website = "https://mohamedfiction.com", Bio = "Fiction writer blending Egyptian culture with fantasy." },
                    new Author { FullName = "Nourhan Tarek Mounir Adel", Email = "nourhan@example.com", Website = "https://nourhanbooks.com", Bio = "Creates young adult novels with strong female leads." },
                    new Author { FullName = "Ibrahim Fathy Zaki Samir", Email = "ibrahim@example.com", Website = "https://ibrahimzaki.com", Bio = "Specializes in crime thrillers and investigations." },
                    new Author { FullName = "Salma Hesham Hany Waleed", Email = "salma@example.com", Website = "https://salmawrites.com", Bio = "Author of modern love stories and poetry." },
                    new Author { FullName = "Ramy Wael Nasser Hamed", Email = "ramy@example.com", Website = "https://ramyfiction.com", Bio = "Science and AI-themed short story writer." },
                    new Author { FullName = "Dina Farouk Adel Tarek", Email = "dina@example.com", Website = "https://dinaadventures.com", Bio = "Adventure novels for teens and young readers." },
                    new Author { FullName = "Mostafa Adel Magdy Khalil", Email = "mostafa@example.com", Website = "https://mostafamagdy.com", Bio = "Explores spirituality and philosophical fiction." },
                    new Author { FullName = "Yasmin Sherif Tawfik Amir", Email = "yasmin@example.com", Website = "https://yasminstories.com", Bio = "Writes light-hearted comedies and slice-of-life books." },
                    new Author { FullName = "Osama Helmy Atef Hossam", Email = "osama@example.com", Website = "https://osamawrites.com", Bio = "Political satire and dark humor specialist." },
                    new Author { FullName = "Hanan Reda Youssef Farah", Email = "hanan@example.com", Website = "https://hananstories.com", Bio = "Focuses on family drama and emotional fiction." },
                    new Author { FullName = "Walid Ashraf Emad Samir", Email = "walid@example.com", Website = "https://walidbooks.com", Bio = "Writes spy thrillers and international crime novels." },
                    new Author { FullName = "Rania Sobhy Fouad Sami", Email = "rania@example.com", Website = "https://raniastories.com", Bio = "Children’s book author with a magical twist." },
                    new Author { FullName = "Nadine Hossam El-Din Sherif", Email = "nadine@example.com", Website = "https://nadinewrites.com", Bio = "Author of psychological thrillers and suspense novels." },
                    new Author { FullName = "Hossam Tarek Ezzat Fahmy", Email = "hossam@example.com", Website = "https://hossefiction.com", Bio = "Blends historical events with fictional narratives." },
                    new Author { FullName = "Manar Adel Ghoneim Omar", Email = "manar@example.com", Website = "https://manargwrites.com", Bio = "Known for short stories and social commentary." },
                    new Author { FullName = "Zeinab Magdy Lotfy Sherif", Email = "zeinab@example.com", Website = "https://zeinabbooks.com", Bio = "Writes folklore-inspired tales and fantasy epics." },
                    new Author { FullName = "Omar Fathy Kamel Said", Email = "omar@example.com", Website = "https://omarstories.com", Bio = "Creates fast-paced action and espionage novels." }
            );
            context.SaveChanges();
        }
    }
}
