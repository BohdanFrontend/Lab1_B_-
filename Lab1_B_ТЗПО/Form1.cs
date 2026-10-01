using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Lab1_B_ТЗПО
{
    // Головна форма додатку — інтерфейс для вводу треків, сортування, відображення та серіалізації.
    public partial class Form1 : Form
    {
        private readonly ITrackCollection nonGenericCollection;
        private readonly ITrackCollection genericCollection;

        public Form1()
        {
            InitializeComponent();

            // Ініціалізація двох колекцій — non-generic і generic
            nonGenericCollection = new TrackCollectionStack();
            genericCollection = new TrackCollectionStackGeneric();

            // За замовчуванням показуємо non-generic колекцію (як вказано в завданні)
            rdoNonGeneric.Checked = true;

            // Заповнюємо тестовими даними для швидкої перевірки
            LoadTestData();

            RefreshTrackList();
        }

        // Завантажити тестові треки для демонстрації
        private void LoadTestData()
        {
            try
            {
                var testTracks = new List<Track>
                {
                    new Track("Bohemian Rhapsody", "Queen", "A Night at the Opera", "Rock", new TimeSpan(0, 5, 55)),
                    new Track("Imagine", "John Lennon", "Imagine", "Pop", new TimeSpan(0, 3, 3)),
                    new Track("Stairway to Heaven", "Led Zeppelin", "Led Zeppelin IV", "Rock", new TimeSpan(0, 8, 2)),
                    new Track("Hey Jude", "The Beatles", "Hey Jude", "Pop", new TimeSpan(0, 7, 11)),
                    new Track("One", "Metallica", "...And Justice for All", "Metal", new TimeSpan(0, 4, 29))
                };

                foreach (var track in testTracks)
                {
                    nonGenericCollection.Push(track);
                    genericCollection.Push(track);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час завантаження тестових даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Допоміжний метод: оновити відображення у ListBox відповідно до вибраної колекції
        private void RefreshTrackList()
        {
            try
            {
                lstTracks.Items.Clear();
                var list = GetSelectedCollection().ToList();
                // Відображаємо у тому порядку, в якому ToList повертає (верхній елемент перший)
                foreach (var t in list)
                {
                    lstTracks.Items.Add(t.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час оновлення відображення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Повертає поточну обрану колекцію (за RadioButton-ами)
        private ITrackCollection GetSelectedCollection()
        {
            return rdoNonGeneric.Checked ? nonGenericCollection : genericCollection;
        }

        // Обробка кнопки "Додати композицію"
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Зчитуємо дані з текстових полів
                string title = txtTitle.Text;
                string artist = txtArtist.Text;
                string album = txtAlbum.Text;
                string genre = txtGenre.Text;
                string durationText = txtDuration.Text;

                // Парсимо Duration — підтримуємо формат hh:mm:ss, mm:ss, або просто число хвилин
                TimeSpan duration = ParseDurationInput(durationText);

                // Створюємо трек (викликаються властивості з валідацією)
                var track = new Track(title, artist, album, genre, duration);

                // Додаємо в обидві колекції одночасно
                nonGenericCollection.Push(track);
                genericCollection.Push(track);

                // Очищаємо поля вводу
                txtTitle.Clear();
                txtArtist.Clear();
                txtAlbum.Clear();
                txtGenre.Clear();
                txtDuration.Clear();

                RefreshTrackList();
                MessageBox.Show("Композиція успішно додана!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Усі помилки показуємо через MessageBox, застосунок не падає
                MessageBox.Show($"Не вдалося додати композицію: {ex.Message}", "Помилка додавання", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Допоміжний метод для парсингу введеної тривалості
        // Підтримує hh:mm:ss, mm:ss, або просто число (інтерпретується як хвилини)
        private TimeSpan ParseDurationInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Duration не може бути порожнім.");

            input = input.Trim();

            // Якщо містить ':' — пробуємо стандартний TimeSpan.Parse
            if (input.Contains(":"))
            {
                if (TimeSpan.TryParse(input, CultureInfo.InvariantCulture, out var ts))
                {
                    return ts;
                }
                else
                {
                    throw new FormatException("Неправильний формат Duration. Використайте hh:mm:ss або mm:ss.");
                }
            }

            // Якщо просто число — вважаємо хвилини
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var numeric))
            {
                if (numeric <= 0) throw new ArgumentOutOfRangeException(nameof(input), "Duration має бути додатньою.");
                return TimeSpan.FromMinutes(numeric);
            }

            throw new FormatException("Неможливо розпізнати Duration. Використайте hh:mm:ss, mm:ss або число хвилин.");
        }

        // Кнопка "Сортувати за жанром"
        private void btnSortGenre_Click(object sender, EventArgs e)
        {
            try
            {
                var col = GetSelectedCollection();
                col.SortByGenre();
                RefreshTrackList();
                MessageBox.Show("Композиції відсортовані за жанром.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при сортуванні за жанром: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Сортувати за тривалістю"
        private void btnSortDuration_Click(object sender, EventArgs e)
        {
            try
            {
                var col = GetSelectedCollection();
                col.SortByDuration();
                RefreshTrackList();
                MessageBox.Show("Композиції відсортовані за тривалістю.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при сортуванні за тривалістю: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Показати композиції виконавця"
        private void btnShowArtist_Click(object sender, EventArgs e)
        {
            try
            {
                string artist = txtSearchArtist.Text;
                if (string.IsNullOrWhiteSpace(artist))
                {
                    MessageBox.Show("Будь ласка, введіть імя виконавця для пошуку.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var col = GetSelectedCollection();
                var list = col.GetByArtist(artist);

                lstTracks.Items.Clear();
                if (list.Count == 0)
                {
                    MessageBox.Show($"Композицій виконавця '{artist}' не знайдено.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (var t in list)
                    {
                        lstTracks.Items.Add(t.ToString());
                    }
                    MessageBox.Show($"Знайдено {list.Count} композицій виконавця '{artist}'.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при фільтрації за виконавцем: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Зберегти" — серіалізація поточної колекції у файл
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";
                    dlg.DefaultExt = "dat";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        GetSelectedCollection().SerializeToFile(dlg.FileName);
                        MessageBox.Show("Колекцію збережено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при збереженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка "Завантажити" — десеріалізація колекції з файлу для поточної колекції
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Binary files (*.dat)|*.dat|All files (*.*)|*.*";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        GetSelectedCollection().DeserializeFromFile(dlg.FileName);
                        RefreshTrackList();
                        MessageBox.Show("Колекцію завантажено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при завантаженні: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обробка зміни вибору колекції — просто оновлюємо відображення
        private void rdoCollection_CheckedChanged(object sender, EventArgs e)
        {
            RefreshTrackList();
        }
    }
}
