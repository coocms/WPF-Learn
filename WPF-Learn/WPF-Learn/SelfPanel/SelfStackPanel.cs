using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Learn.SelfPanel
{
    internal class SelfStackPanel:Panel
    {
        /// <summary>
        /// 测量
        /// 计算出 渲染这个控件时候的size
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        /// 
        protected override Size MeasureOverride(Size availableSize)
        {
            double height = 0;
            foreach (FrameworkElement item in this.InternalChildren)
            {
                item.Measure(availableSize);

                height += item.DesiredSize.Height;
                
            }
            return new Size(availableSize.Width, height);
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            double height = 0;
            var r = InternalChildren.OfType<UIElement>().OrderBy(o => GetIndex(o)).ToList();
            foreach (FrameworkElement item in InternalChildren.OfType<UIElement>().OrderBy(o => GetIndex(o)))
            {
                item.Arrange(new Rect(0, height, finalSize.Width, item.DesiredSize.Height));
                height += item.DesiredSize.Height;

            }
            return finalSize;
        }






        public static int GetIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(IndexProperty);
        }

        public static void SetIndex(DependencyObject obj, int value)
        {
            obj.SetValue(IndexProperty, value);
        }

        // Using a DependencyProperty as the backing store for Index.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.RegisterAttached("Index", typeof(int), typeof(int), new PropertyMetadata(0));







    }
}
