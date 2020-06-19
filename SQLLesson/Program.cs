using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {


                var group = new Group()
                {
                    Name = "Rammstein",
                    Year = 1994
                };

                var group2 = new Group()
                {
                    Name = "Linking Park"
                };

                context.Groups.Add(group); //добавляем группу
                context.Groups.Add(group2);
                context.SaveChanges(); //сохранение из локального хранилища в базу данных

                var songs = new List<Song>()
                {
                    new Song() { Name = "In the end", GroupId = group2.Id},
                    new Song() { Name = "Numb", GroupId = group2.Id},
                    new Song() { Name = "Mutter", GroupId = group.Id}
                };
                context.Songs.AddRange(songs);
                context.SaveChanges();

                var s = context.Groups.Single(x => x.Id == group.Id); 
                s.Name = "1111"; //меняем значение группы
                context.SaveChanges();

                foreach(var song in songs)
                {
                    Console.WriteLine($"Song name: {song.Name}, Group name: {song.Group?.Name}");
                }
                Console.WriteLine($"id: {group.Id}, name: {group.Name}, year: {group.Year}");
                Console.ReadLine();
            }
        }
    }
}
