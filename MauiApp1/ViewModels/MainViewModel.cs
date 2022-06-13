using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        IConnectivity _connectivity;
        public MainViewModel(IConnectivity connectivity)
        {
            Items = new ObservableCollection<string>();
            _connectivity = connectivity;
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [ICommand]
        async void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("F*CK", "You ain't got no internet cus!!", "Shit, aii.");
                return;
            }
            

            items.Add(Text);
            Text = string.Empty;
        }
        [ICommand]
        void Delete(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        [ICommand]
        async Task Tap(string item)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Item={item}");
            //await Shell.Current.GoToAsync($"{nameof(DetailPage)}",
            //    parameters: new Dictionary<string, object>
            //    {
            //        {"Item", item }
            //    });
        }
    }
}

