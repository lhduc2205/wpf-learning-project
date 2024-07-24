using InventoryManagement.Core.Entity;
using System.Globalization;
using System.Windows.Data;

namespace InventoryManagement.Converter
{
    class HierarchyConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if (value is Department department)
            {
                return department?.ChildrenDepartments.Where(d => d.ParentDepartmentId == department.Id).OrderBy(d => d.Name).ToList();
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
