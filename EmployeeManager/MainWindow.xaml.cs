using System.Windows;

namespace EmployeeManager
{
    public partial class MainWindow : Window
    {
        // Konstruktor
        public MainWindow()
        {
            InitializeComponent(); // Lädt das XAML-Layout
        }

        // Beim Klick auf den "Abschicken" Button
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text; // Inhalt aus der Textbox wird ausgelesen
            string ageText = AgeTextBox.Text;

            // Überprüfen, ob der Name leer ist
            if (string.IsNullOrWhiteSpace(name))
                {
                ValidationMessage.Text = "Bitte geben Sie einen Namen ein.";
                return;
            }

            // Versuche, das Alter zu parsen
            if (!int.TryParse(ageText, out int alter) || alter <= 0)
            {
                ValidationMessage.Text = "Bitte geben Sie ein gültiges Alter ein.";
                return; // Stoppe die Ausführung, wenn die Eingabe ungültig ist
            }

            // Begrüßungsnachricht
            GreetingTextBlock.Text = $"Herzlich Willkommen, {name}! Ihr Alter ist {alter} Jahre.";
            ValidationMessage.Text = $"Die Daten wurden erfolgreich übermittelt.";
            NameTextBox.Text = string.Empty; // Textboxen werden geleert
            AgeTextBox.Text = string.Empty;
        }

        // Beim Klicken auf den "Beenden" Button
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            // Zeigt eine Bestätigungsnachricht an
            MessageBoxResult result = MessageBox.Show(
                "Möchten Sie die Anwendung wirklich beenden?",
                "Beenden bestätigen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            // Wenn der Benutzer auf "Ja" klickt, wird die Anwendung beendet
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(); // Beendet die Anwendung
            }
        } 
    }
}
