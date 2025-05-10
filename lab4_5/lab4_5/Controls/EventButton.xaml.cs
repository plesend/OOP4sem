using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab4_5.Controls
{
    public partial class EventButton : UserControl
    {
        public EventButton()
        {
            InitializeComponent();
        }

        // 🔽 **Tunneling**: PreviewMouseDown
        private void OnPreviewMouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            // Это событие будет срабатывать в самом начале, когда мы нажимаем на кнопку.
            MessageBox.Show("PreviewMouseDown (Tunneling) in EventButton");
        }

        // 🔼 **Bubbling**: MouseDown
        private void OnMouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            // Это событие срабатывает после PreviewMouseDown, когда событие "пузырится" вверх.
            MessageBox.Show("MouseDown (Bubbling) in EventButton");
        }

        // ➡️ **Direct**: событие Click
        public static readonly RoutedEvent IconClickEvent = EventManager.RegisterRoutedEvent(
            "IconClick", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(EventButton));

        public event RoutedEventHandler IconClick
        {
            add { AddHandler(IconClickEvent, value); }
            remove { RemoveHandler(IconClickEvent, value); }
        }

        // Событие срабатывает, когда пользователь отпускает кнопку.
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(IconClickEvent));  // Direct-событие
            base.OnMouseLeftButtonUp(e);
        }
    }
}
