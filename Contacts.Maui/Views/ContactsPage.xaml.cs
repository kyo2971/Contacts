using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact= Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
	}

    //每用到此頁面就重整
    protected override void OnAppearing()
    {
        base.OnAppearing();

        var contacts = new ObservableCollection<Contact> (ContactReposity.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }
		//DisplayAlert("test","test","ok");
		//listContacts.SelectedItem = null;
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        //DisplayAlert("test", "test", "ok");
        listContacts.SelectedItem = null;
    }
}