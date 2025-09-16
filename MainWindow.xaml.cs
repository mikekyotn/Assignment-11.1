using Assignment_11._1.Data;
using Assignment_11._1.Models;
using Assignment_11._1.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_11._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PetContext context;
        ICRUD crud;
        PetEvent newEvent = new PetEvent();
        //petId used to instantiate a new PetEvent(petId) for adding a new event.
        //This will ensure the FOREIGN KEY which is petId is added to the newEvent.
        int petId; 
        public MainWindow(PetContext _context, ICRUD _crud)
        {
            InitializeComponent();
            context = _context;
            crud = _crud;
            btnSaveEdit.IsEnabled = false;
            btnAdd.IsEnabled = false;
            foreach (var pet in crud.GetAllPets())
            {
                PetListCombo.Items.Add(pet.PetName);
            }
            
        }
                
        private void GetPetById(object sender, RoutedEventArgs e)
        {
            petId = PetListCombo.SelectedIndex + 1;
            UpdateDataGrid(petId);
            btnAdd.IsEnabled = true;
            newEvent = new PetEvent(petId); //create new event with Key and Foreign Key
            AddorUpdateEventGrid.DataContext = newEvent;
        }

        private void UpdateEvent(object sender, RoutedEventArgs e)
        {
            PetEvent updatedEvent = (sender as FrameworkElement).DataContext as PetEvent;
            crud.UpdateEvent(updatedEvent);
            btnSaveEdit.IsEnabled = false;
            btnAdd.IsEnabled = true;
            newEvent = new PetEvent(petId);
            AddorUpdateEventGrid.DataContext = newEvent;
        }
        private void AddEvent(object sender, RoutedEventArgs e)
        {
            crud.AddEvent(newEvent);
            UpdateDataGrid(petId);
            MessageBox.Show("Product Added Successfully");
            newEvent = new PetEvent(petId);
            AddorUpdateEventGrid.DataContext = newEvent;
        }
        private void DeleteEvent(object sender, RoutedEventArgs e)
        {
            PetEvent selectedEvent = (sender as FrameworkElement).DataContext as PetEvent;
            crud.DeleteEvent(selectedEvent);
            UpdateDataGrid(petId);
        }
        private void UpdateEventforEdit(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = false;
            btnSaveEdit.IsEnabled = true;
            PetEvent selectedEvent = (sender as FrameworkElement).DataContext as PetEvent;
            AddorUpdateEventGrid.DataContext = selectedEvent;
        }

        public void UpdateDataGrid (int petId)
        {
            SelectPetGrid.DataContext = crud.GetPetById(petId);
            List<PetEvent> filtered = crud.GetAllEventsByPet(petId);
            EventDG.ItemsSource = filtered;
        }
    }
}