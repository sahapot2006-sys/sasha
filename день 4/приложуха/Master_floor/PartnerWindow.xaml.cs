using System;
using System.Windows;

namespace Master_floor
{
    public partial class PartnerWindow : Window
    {
        TestBaseEntities db = new TestBaseEntities();
        Partner _current;

        public PartnerWindow(Partner partner)
        {
            InitializeComponent();
            _current = partner;

            if (_current != null)
            {
                tbName.Text = _current.Наименование_партнера;
                tbType.Text = _current.Тип_партнера;
                tbDirector.Text = _current.Директор;
                tbRating.Text = _current.Рейтинг.ToString().Replace("Рейтинг: ", "");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_current == null) // Создание
                {
                    Partner p = new Partner
                    {
                        Наименование_партнера = tbName.Text,
                        Тип_партнера = tbType.Text,
                        Директор = tbDirector.Text,
                        Рейтинг = double.Parse(tbRating.Text)
                    };
                    db.Partners.Add(p);
                }
                else // Редактирование
                {
                    var p = db.Partners.Find(_current.ID);
                    p.Наименование_партнера = tbName.Text;
                    p.Тип_партнера = tbType.Text;
                    p.Директор = tbDirector.Text;
                    p.Рейтинг = double.Parse(tbRating.Text);
                }

                db.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }
    }
}