using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab1_B_ТЗПО
{
    // Обгортка для узагальненого System.Collections.Generic.Stack<Track>
    // Має той самий набір методів, що й TrackCollectionStack.
    public class TrackCollectionStackGeneric : ITrackCollection
    {
        private Stack<Track> internalStack;

        public TrackCollectionStackGeneric()
        {
            internalStack = new Stack<Track>();
        }

        // Додати композицію
        public void Push(Track track)
        {
            if (track == null) throw new ArgumentNullException(nameof(track));
            internalStack.Push(track);
        }

        // Повернути всі треки як List<Track>
        public List<Track> ToList()
        {
            // Stack<T>.ToArray повертає масив де верхній елемент перший
            var arr = internalStack.ToArray();
            return new List<Track>(arr);
        }

        // Сортування за жанром (Genre потім Duration)
        public void SortByGenre()
        {
            var list = ToList();
            list.Sort((a, b) =>
            {
                int genreComp = string.Compare(a.Genre, b.Genre, StringComparison.OrdinalIgnoreCase);
                if (genreComp != 0) return genreComp;
                return a.Duration.CompareTo(b.Duration);
            });

            var newStack = new Stack<Track>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                newStack.Push(list[i]);
            }
            internalStack = newStack;
        }

        // Сортування за тривалістю
        public void SortByDuration()
        {
            var list = ToList();
            list.Sort(); // використовує IComparable<Track>
            var newStack = new Stack<Track>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                newStack.Push(list[i]);
            }
            internalStack = newStack;
        }

        // Повернути треки певного виконавця
        public List<Track> GetByArtist(string artist)
        {
            if (string.IsNullOrWhiteSpace(artist)) return new List<Track>();
            var lower = artist.Trim().ToLowerInvariant();
            return ToList().Where(t => t.Artist.ToLowerInvariant().Contains(lower)).ToList();
        }

        // Серіалізація у файл (BinaryFormatter використано за вимогою; див. застереження)
        public void SerializeToFile(string path)
        {
#pragma warning disable SYSLIB0011
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, internalStack);
            }
#pragma warning restore SYSLIB0011
        }

        // Десеріалізація з файлу
        public void DeserializeFromFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Файл не знайдено", path);
#pragma warning disable SYSLIB0011
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(fs);
                if (obj is Stack<Track> s)
                {
                    internalStack = s;
                }
                else
                {
                    throw new InvalidDataException("Файл не містить очікуваної колекції Stack<Track>.");
                }
            }
#pragma warning restore SYSLIB0011
        }
    }
}
