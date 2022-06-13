using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.ViewModels
{
    [QueryProperty("Item", "Item")]
	public partial class DetailViewModel : ObservableObject
	{
		public DetailViewModel()
		{
		}

		[ObservableProperty]
		string item;

        [ICommand]
		async Task GoBack()
        {
			await Shell.Current.GoToAsync("..");
        }
	}
}

