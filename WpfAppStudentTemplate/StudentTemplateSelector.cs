using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppStudentTemplate
{
    class StudentTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is Student student)
            {
                if (student.JeZapsany == true)
                    return element.FindResource("StudentTemplateGreen") as DataTemplate;
                else
                    return  element.FindResource("StudentTemplateRed") as DataTemplate;
            }

            return null;

        }
    }
}
