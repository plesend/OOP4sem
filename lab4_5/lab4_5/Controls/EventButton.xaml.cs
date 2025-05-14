using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab4_5.Controls
{
    public partial class EventButton : UserControl
    {


        // Создаем команду на основе RoutedUICommand
        public static readonly RoutedUICommand MyCustomCommand = new RoutedUICommand(
            "My Custom Command",    // Название команды
            "MyCustomCommand",      // Идентификатор команды
            typeof(EventButton)     // Тип класса, где эта команда будет использоваться
        );

        public EventButton()
        {
            InitializeComponent();
            // Добавляем обработчик команд
            CommandBindings.Add(new CommandBinding(MyCustomCommand, ExecuteMyCustomCommand, CanExecuteMyCustomCommand));
        }

        // Метод, который будет выполняться, когда команда активируется
        private void ExecuteMyCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("My Custom Command Executed!");
        }

        // Метод, который определяет, доступна ли команда для выполнения
        private void CanExecuteMyCustomCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            // В данном примере команда всегда доступна
            e.CanExecute = true;
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
        private void OnMouseLeftButtonUpHandler(object sender, MouseButtonEventArgs e)
        {
            // Direct-событие
            RaiseEvent(new RoutedEventArgs(IconClickEvent));
            MessageBox.Show("IconClick (Direct) in EventButton");
        }
    }
}
