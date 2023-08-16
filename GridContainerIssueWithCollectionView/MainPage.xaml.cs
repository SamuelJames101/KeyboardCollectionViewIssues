namespace GridContainerIssueWithCollectionView;

public partial class MainPage : ContentPage
{
	MainPageViewModel vm;

	public MainPage()
	{
		InitializeComponent();

		this.BindingContext = this.vm = new MainPageViewModel();

		this.vm.EditTextWorkAround += (text) =>
		{
			this.myEditor.Text = text;
		};
	}
}


