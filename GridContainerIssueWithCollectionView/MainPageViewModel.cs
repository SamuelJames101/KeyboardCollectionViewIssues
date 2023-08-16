using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GridContainerIssueWithCollectionView;

public class MainPageViewModel : INotifyPropertyChanged
{
    private ObservableCollection<string> itemSource = new();

    private string editorText;

    public MainPageViewModel()
    {
        this.FillCommand = new Command(this.Fill);
    }

    public Command FillCommand { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public Action<string> EditTextWorkAround {get;set;}

	public ObservableCollection<string> ItemSource
	{
		get => this.itemSource;
		set
		{
			this.itemSource = value;
			this.OnPropertyChanged();
		}
	}

    public string EditorText
    {
        get => this.editorText;
        set
        {
            if (!string.IsNullOrEmpty(value) && value.EndsWith('\n'))
            {
                this.ItemSource.Add(value.TrimEnd('\n'));
                value = string.Empty;
            }

            this.editorText = value;
            this.OnPropertyChanged();

            this.EditTextWorkAround?.Invoke(value);
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Fill()
    {
        for (int i = 12; i > 0; i--)
        {
            this.ItemSource.Add("I am number :" + i);
        }
    }
}

