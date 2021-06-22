using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelManagement.Controls
{
    /// <summary>
    /// Interaction logic for ItemListControl.xaml
    /// </summary>
    public partial class ItemListControl : UserControl
    {
        public ItemListControl()
        {
            InitializeComponent();
        }

        public IEnumerable<BaseModel> Itemss
        {
            get { return (IEnumerable<BaseModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Itemss", typeof(IEnumerable<BaseModel>), typeof(ItemListControl), new PropertyMetadata(new List<BaseModel>()));


    }
}
