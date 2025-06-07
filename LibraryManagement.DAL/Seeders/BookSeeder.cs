using LibraryManagement.DAL.Persistence;
using LibraryManagement.DAL.Seeders;
using LibraryManagement.Models;

public class BookSeeder : IDbSeeder
{
    public void Seed(LibraryDbContext context)
    {
        if (!context.Books.Any() && context.Authors.Any())
        {
            var firstAuthor = context.Authors.First();

            context.Books.AddRange(
                new Book
                {
                    Title = "The Mysterious Island",
                    Genre = Genre.Adventure,
                    Description = "A thrilling journey on a remote island.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Love in Cairo",
                    Genre = Genre.Romance,
                    Description = "A heartwarming love story.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Shadows of the Past",
                    Genre = Genre.Mystery,
                    Description = "Uncover dark secrets buried long ago.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Silent Threat",
                    Genre = Genre.Thriller,
                    Description = "A deadly secret hidden in plain sight.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Beyond the Stars",
                    Genre = Genre.SciFi,
                    Description = "An epic space voyage across the galaxy.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "The Forgotten Kingdom",
                    Genre = Genre.Fantasy,
                    Description = "A tale of magic, dragons, and lost realms.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Life of a Legend",
                    Genre = Genre.Biography,
                    Description = "The inspiring story of a great leader.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Empire of Sands",
                    Genre = Genre.History,
                    Description = "The rise and fall of an ancient empire.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Master Your Mind",
                    Genre = Genre.SelfHelp,
                    Description = "Techniques for personal growth and success.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Adventures of Timmy",
                    Genre = Genre.Children,
                    Description = "Fun stories for kids full of imagination.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "The Rising Star",
                    Genre = Genre.YoungAdult,
                    Description = "A coming-of-age story about dreams and challenges.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Whispers in the Wind",
                    Genre = Genre.Poetry,
                    Description = "A collection of soulful poems.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Family Ties",
                    Genre = Genre.Drama,
                    Description = "A touching story of love and conflict within a family.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Understanding Economics",
                    Genre = Genre.NonFiction,
                    Description = "An accessible guide to basic economic principles.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "The Lost Treasure",
                    Genre = Genre.Adventure,
                    Description = "A quest for a hidden treasure deep in the jungle.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Secrets of the Manor",
                    Genre = Genre.Mystery,
                    Description = "Unraveling clues in a haunted estate.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Chasing Shadows",
                    Genre = Genre.Thriller,
                    Description = "A suspenseful story of espionage and danger.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Galaxy Warriors",
                    Genre = Genre.SciFi,
                    Description = "Heroes battling evil in a futuristic universe.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "The Enchanted Forest",
                    Genre = Genre.Fantasy,
                    Description = "Magical creatures and epic battles in a mystical land.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Journey of a Visionary",
                    Genre = Genre.Biography,
                    Description = "Life story of a groundbreaking inventor.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Chronicles of the Pharaohs",
                    Genre = Genre.History,
                    Description = "A detailed history of ancient Egypt's rulers.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Mindset Reset",
                    Genre = Genre.SelfHelp,
                    Description = "Tools to transform your thinking and habits.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Luna’s Magical Journey",
                    Genre = Genre.Children,
                    Description = "A young girl's adventures in a magical world.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Breaking Free",
                    Genre = Genre.YoungAdult,
                    Description = "Teen struggles with identity and freedom.",
                    AuthorId = firstAuthor.Id
                },
                new Book
                {
                    Title = "Echoes of the Heart",
                    Genre = Genre.Poetry,
                    Description = "Poems about love, loss, and hope.",
                    AuthorId = firstAuthor.Id
                }


            );
            context.SaveChanges();
        }
    }
}
