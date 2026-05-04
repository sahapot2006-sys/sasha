using System.Linq;
using System.Windows;

namespace Master_floor
{
    public partial class History : Window
    {
        TestBaseEntities db = new TestBaseEntities();

        public History(int partnerId)
        {
            InitializeComponent();
            var data = db.Partners_product
                .Where(pp => pp.ID_Partner == partnerId)
                .Select(pp => new
                {
                    ProductName = pp.Product.Наименование_продукции,
                    Count = pp.Количество_продукции,
                    Date = pp.Дата_продажи
                }).ToList();

            dgHistory.ItemsSource = data;
        }
    }
}