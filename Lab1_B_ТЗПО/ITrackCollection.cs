using System.Collections.Generic;

namespace Lab1_B_ТЗПО
{
    // Інтерфейс для колекції треків.
    // Забезпечує однаковий набір операцій для обох реалізацій (non-generic Stack і generic Stack<Track>).
    public interface ITrackCollection
    {
        // Додати трек у колекцію
        void Push(Track track);

        // Повернути всі треки як список для відображення/обробки
        List<Track> ToList();

        // Відсортувати колекцію за жанром (переважно за Genre, вторинно — за Duration)
        void SortByGenre();

        // Відсортувати колекцію за тривалістю
        void SortByDuration();

        // Повернути список треків вказаного виконавця
        List<Track> GetByArtist(string artist);

        // Серіалізувати колекцію у файл
        void SerializeToFile(string path);

        // Десеріалізувати колекцію з файлу (заміщує поточний вміст)
        void DeserializeFromFile(string path);
    }
}
