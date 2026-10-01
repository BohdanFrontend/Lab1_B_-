using System;

namespace Lab1_B_ТЗПО
{
    // Клас для представлення музичної композиції
    // Містить інформацію: Title, Artist, Album, Genre, Duration
    [Serializable]
    public class Track : IComparable<Track>
    {
        private string title;
        private string artist;
        private string album;
        private string genre;
        private TimeSpan duration;

        // Конструктор за замовчуванням
        public Track()
        {
            // Ініціалізація значень за замовчуванням
            title = string.Empty;
            artist = string.Empty;
            album = string.Empty;
            genre = string.Empty;
            duration = TimeSpan.Zero;
        }

        // Параметризований конструктор - використовує властивості для валідації
        public Track(string title, string artist, string album, string genre, TimeSpan duration)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Genre = genre;
            Duration = duration;
        }

        // Назва композиції
        // Перевіряємо, що рядок не порожній або не лише пробіли
        public string Title
        {
            get => title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title не може бути порожнім або містити лише пробіли.");
                title = value.Trim();
            }
        }

        // Виконавець композиції
        // Перевіряємо, що рядок не порожній
        public string Artist
        {
            get => artist;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Artist не може бути порожнім або містити лише пробіли.");
                artist = value.Trim();
            }
        }

        // Альбом композиції
        // Дозволяємо порожній альбом, але видаляємо зайві пробіли
        public string Album
        {
            get => album;
            set
            {
                album = value?.Trim() ?? string.Empty;
            }
        }

        // Жанр композиції
        // Перевіряємо, що жанр вказано
        public string Genre
        {
            get => genre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Genre не може бути порожнім або містити лише пробіли.");
                genre = value.Trim();
            }
        }

        // Тривалість композиції
        // Перевіряємо, що тривалість не від'ємна та не нульова
        public TimeSpan Duration
        {
            get => duration;
            set
            {
                if (value < TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException(nameof(Duration), "Duration не може бути від'ємною.");
                // Нульова тривалість вважаємо некоректною для музичної композиції
                if (value == TimeSpan.Zero)
                    throw new ArgumentOutOfRangeException(nameof(Duration), "Duration не може бути нульовою.");
                duration = value;
            }
        }

        // Зручне текстове представлення треку для відображення
        public override string ToString()
        {
            // Формат: Title — Artist (Album) [Genre] hh:mm:ss
            var albumPart = string.IsNullOrEmpty(Album) ? "" : $" ({Album})";
            return $"{Title} — {Artist}{albumPart} [{Genre}] {Duration:hh\\:mm\\:ss}";
        }

        // Порівняння за тривалістю (для сортування за Duration)
        public int CompareTo(Track? other)
        {
            if (other is null) return 1;
            return Duration.CompareTo(other.Duration);
        }
    }
}
