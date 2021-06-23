using HotelManagement.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.Controls
{
    public class ItemListControl : Control
    {
        static ItemListControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ItemListControl), new FrameworkPropertyMetadata(typeof(ItemListControl)));
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable<BaseModel>), typeof(ItemListControl), new PropertyMetadata());

        public static readonly DependencyProperty SelectedItemProperty = 
            DependencyProperty.Register("SelectedItem", typeof(BaseModel), typeof(ItemListControl), new PropertyMetadata(OnSelectedItem));

        public static readonly DependencyProperty AddCommandProperty =
            DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(ItemListControl), new PropertyMetadata());

        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(ItemListControl), new PropertyMetadata());

        public static readonly DependencyProperty RemoveCommandProperty =
            DependencyProperty.Register("RemoveCommand", typeof(ICommand), typeof(ItemListControl), new PropertyMetadata());


        public IEnumerable<BaseModel> Items
        {
            get { return (IEnumerable<BaseModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public BaseModel SelectedItem
        {
            get { return (BaseModel)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            set { SetValue(EditCommandProperty, value); }
        }

        public ICommand RemoveCommand
        {
            get { return (ICommand)GetValue(RemoveCommandProperty); }
            set { SetValue(RemoveCommandProperty, value); }
        }

        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var control = Template.FindName("ItemsDataGrid", this);
            if (control is DataGrid)
            {
                var itemsDataGrid = (DataGrid)control;

                itemsDataGrid.SelectionChanged += (sender, e) =>
                {
                    SelectedItem = (BaseModel)itemsDataGrid.SelectedItem;
                };
            }
        }

        private static void OnSelectedItem(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var input = (ItemListControl)d;

            input.SelectedItem = e.NewValue as BaseModel;
        }
    }
}
