using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Test.Views;

namespace Test
{
    public partial class MainPageViewModel : ObservableObject
    {
        int count;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        string navigateToCollectionText;

        public MainPageViewModel()
        {
            text = "Click here to start counter";
            NavigateToCollectionText = "Move to collection view";
        }

        [RelayCommand]
        void CounterIncrement()
        {
            count++;
            if (count == 1)
                Text = $"Clicked {count} time";
            else
                Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(Text);
        }

        [RelayCommand]
        async Task NavigateToCollection()
        {
            // Navigate to the new page
            await Shell.Current.GoToAsync(nameof(CollectionPage));
        }
    }
}
