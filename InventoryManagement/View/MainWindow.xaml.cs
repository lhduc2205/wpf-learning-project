using InventoryManagement.Core.Entity;
using InventoryManagement.ViewModel;
using System.Windows;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            DataContext = _viewModel;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Department department)
            {
                _viewModel.OnDepartmentTreeViewChanged(department);
            }
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}