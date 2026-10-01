using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab1_B_ТЗПО
{
    // Обгортка для НЕузагальненого System.Collections.Stack
    // Використовує об'єкти типу Track (збереження як object у Stack)
    // Увага: у .NET сучасних версій BinaryFormatter застарілий та небезпечний;
    // тут він використаний за вимогою методички. Як альтернативу в production-рішеннях
    // слід використовувати наприклад XmlSerializer або System.Text.Json.
    public class TrackCollectionStack : ITrackCollection
    {
        private Stack internalStack;

        public TrackCollectionStack()
        {
            internalStack = new Stack();
        }

        // Додати композицію у Stack
        public void Push(Track track)
        {
            if (track == null) throw new ArgumentNullException(nameof(track));
            internalStack.Push(track);
        }

        // Повернути всі треки як List<Track>
        public List<Track> ToList()
        {
            // Stack.ToArray повертає масив object[] (останній pushed елемент перший в масиві)
            var arr = internalStack.ToArray();
            var list = new List<Track>(arr.Length);
            foreach (var obj in arr)
            {
                if (obj is Track t) list.Add(t);
            }
            return list;
        }

        // Сортування за жанром (Genre, потім Duration)
        public void SortByGenre()
        {
            var list = ToList();
            list.Sort((a, b) =>
            {
                int genreComp = string.Compare(a.Genre, b.Genre, StringComparison.OrdinalIgnoreCase);
                if (genreComp != 0) return genreComp;
                return a.Duration.CompareTo(b.Duration);
            });

            // Оскільки Stack має LIFO-порядок, щоб верхній елемент бути останнім у списку,
            // пушимо елементи у зворотному порядку від відсортованого списку.
            var newStack = new Stack();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                newStack.Push(list[i]);
            }
            internalStack = newStack;
        }

        // Сортування за тривалістю (використовує Track.CompareTo)
        public void SortByDuration()
        {
            var list = ToList();
            list.Sort(); // використовується IComparable<Track>
            var newStack = new Stack();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                newStack.Push(list[i]);
            }
            internalStack = newStack;
        }

        // Повернути треки певного виконавця (регістро-незалежно)
        public List<Track> GetByArtist(string artist)
        {
            if (string.IsNullOrWhiteSpace(artist)) return new List<Track>();
            var lower = artist.Trim().ToLowerInvariant();
            return ToList().Where(t => t.Artist.ToLowerInvariant().Contains(lower)).ToList();
        }

        // Серіалізація у файл за допомогою BinaryFormatter (застосовано попередження щодо застарілості)
        public void SerializeToFile(string path)
        {
#pragma warning disable SYSLIB0011
            // BinaryFormatter застосовано згідно з вимогою лабораторної роботи.
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, internalStack);
            }
#pragma warning restore SYSLIB0011
        }

        // Десеріалізація з файлу (перезаписує internalStack)
        public void DeserializeFromFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Файл не знайдено", path);
#pragma warning disable SYSLIB0011
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(fs);
                if (obj is Stack s)
                {
                    internalStack = s;
                }
                else
                {
                    throw new InvalidDataException("Файл не містить очікуваної колекції Stack.");
                }
            }
#pragma warning restore SYSLIB0011
        }
    }
}
