using CommunityToolkit.Mvvm.Input;
using InventoryManagement.Core.Entity;
using InventoryManagement.Core.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace InventoryManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        private readonly INotificationService _notificationService;

        private ObservableCollection<Employee> _employees = [];
        private Employee? _selectedEmployee;
        #endregion

        #region Properties
        public ObservableCollection<Department> DepartmentList { get; set; } = [];

        public Department? SelectedDepartment;
        public Employee? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private RelayCommand? _refreshCommand;
        private RelayCommand? _saveCommand;
        private RelayCommand? _openProductWindowCommand;
        private RelayCommand? _moveDownCommand;

        public ICommand RefreshCommand => _refreshCommand ??= new RelayCommand(Refresh);

        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save);

        public ICommand OpenProductWindowCommand => _openProductWindowCommand ??= new RelayCommand(OpenProductWindow);
        public ICommand MoveDownCommand => _moveDownCommand ??= new RelayCommand(MoveEmployeeRowDown);
        #endregion

        #region Constructors
        public MainViewModel(IEmployeeService employeeService, IDepartmentService departmentService, INotificationService notificationService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
            _notificationService = notificationService;

            InitialSetup();
        }

        private void InitialSetup()
        {
            LoadData();
        }
        #endregion

        private void LoadData()
        {
            DepartmentList = [.. _departmentService.GetRootDepartments()];
            SelectedDepartment = DepartmentList.First();
            _employees = [.. SelectedDepartment.Employees];
        }

        public void OnDepartmentTreeViewChanged(Department nextDepartment)
        {
            SelectedDepartment = nextDepartment;
            Employees = [.. _employeeService.GetEmployeesByDepartmentId(SelectedDepartment.Id)];
        }

        private void Refresh()
        {
            if (SelectedDepartment is not null)
            {
                Employees = [.. _employeeService.GetEmployeesByDepartmentId(SelectedDepartment.Id)];
                _notificationService.PushInfo("Refreshed", "The application has been refreshed!");
            }
            else
            {
                LoadData();
            }
        }

        private void Save()
        {
            try
            {
                _employeeService.SaveEmployee(_employees);

                _notificationService.PushInfo("Saved", "Your changes have been saved successfully!");
            }
            catch (Exception ex)
            {
                //System.Windows.MessageBox.Show("Save Failed", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MoveEmployeeRowDown()
        {
            if (SelectedEmployee is null)
            {
                return;
            }

            int index = Employees.ToList().FindIndex(e => e.Id == SelectedEmployee.Id);

            if (index == Employees.Count - 1)
            {
                return;
            }

            SwapEmployeesInList(index, index + 1);
        }

        private void SwapEmployeesInList(int currentIndex, int desiredIndex)
        {
            (Employees[desiredIndex], Employees[currentIndex]) = (Employees[currentIndex], Employees[desiredIndex]);
            SelectedEmployee = Employees[desiredIndex];
        }

        private void OpenProductWindow()
        {
            //ProductWindow productView = new ProductWindow();
            //productView.ShowDialog();
        }
    }
}
