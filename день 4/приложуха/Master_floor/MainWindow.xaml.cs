using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Master_floor
{
    public partial class MainWindow : Window
    {
        TestBaseEntities db = new TestBaseEntities();

        public MainWindow()
        {
            InitializeComponent();
            tolist();
        }

        public void tolist()
        {
            var listpartners = new List<Partner>();
            var partnersFromDb = db.Partners.ToList();

            foreach (var a in partnersFromDb)
            {
                var sum = db.Partners_product
                            .Where(y => a.ID == y.ID_Partner)
                            .Sum(x => (double?)x.Количество_продукции) ?? 0;

                // Используем вынесенный метод для расчета скидки
                string sale = DiscountCalculator.CalculateDiscount(sum);

                listpartners.Add(new Partner 
                { 
                    ID = a.ID, 
                    Директор = a.Директор, 
                    Наименование_партнера = a.Наименование_партнера, 
                    Рейтинг = "Рейтинг: " + a.Рейтинг, 
                    Телефон_партнера = a.Телефон_партнера, 
                    Тип_партнера = a.Тип_партнера, 
                    Скидка = sale 
                });
            }

            listPartner.ItemsSource = listpartners;
        }

        private void btnAddPartner_Click(object sender, RoutedEventArgs e)
        {
            PartnerWindow pw = new PartnerWindow(null);
            if (pw.ShowDialog() == true) tolist();
        }

        private void listPartner_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listPartner.SelectedItem is Partner selected)
            {
                PartnerWindow pw = new PartnerWindow(selected);
                if (pw.ShowDialog() == true) tolist();
            }
        }

        private void btnDeletePartner_Click(object sender, RoutedEventArgs e)
        {
            if (listPartner.SelectedItem is Partner selected)
            {
                if (MessageBox.Show("Удалить выбранного партнера?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    var p = db.Partners.Find(selected.ID);
                    db.Partners.Remove(p);
                    db.SaveChanges();
                    tolist();
                }
            }
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            if (listPartner.SelectedItem is Partner selected)
            {
                History historyWindow = new History(selected.ID);
                historyWindow.ShowDialog();
            }
        }
    }
}