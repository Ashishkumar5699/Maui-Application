namespace Punjab_Ornaments.Presentation.CustomControls;

public partial class LabelButton : ContentView
{
    private int _placeholderFontSize = 18;
    private int _titleFontSize = 14;
    private int _topMargin = -32;
    //private bool IsLandscapeMode = false;

    public LabelButton()
	{
		InitializeComponent();
	}
    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create("Text", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null);
    public string Text
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    async void Handle_Focused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToTitle(true);
        }
    }
    async void Handle_Unfocused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrEmpty(Text))
        {
            await TransitionToPlaceholder(true);
        }
    }
    async Task TransitionToTitle(bool animated)
    {
        if (animated)
        {
            var t1 = LabelTitle.TranslateTo(0, _topMargin, 100);
            var t2 = SizeTo(_titleFontSize);
            await Task.WhenAll(t1, t2);
        }
        else
        {
            LabelTitle.TranslationX = 0;
            LabelTitle.TranslationY = -30;
            LabelTitle.FontSize = 14;
        }
    }
    async Task TransitionToPlaceholder(bool animated)
    {
        if (animated)
        {
            var t1 = LabelTitle.TranslateTo(10, 0, 100);
            var t2 = SizeTo(_placeholderFontSize);
            await Task.WhenAll(t1, t2);
        }
        else
        {
            LabelTitle.TranslationX = 10;
            LabelTitle.TranslationY = 0;
            LabelTitle.FontSize = _placeholderFontSize;
        }
    }
    public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(string), string.Empty, BindingMode.TwoWay, null, HandleBindingPropertyChangedDelegate);
    static async void HandleBindingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        var control = bindable as LabelButton;
        if (!control.EntryField.IsFocused)
        {
            if (!string.IsNullOrEmpty((string)newValue))
            {
                await control.TransitionToTitle(false);
            }
            else
            {
                await control.TransitionToPlaceholder(false);
            }
        }
    }
    void Handle_Tapped(object sender, EventArgs e)
    {
        EntryField.Focus();
    }

    public new void Focus()
    {
        EntryField.Focus();
    }
    Task SizeTo(int fontSize)
    {
        var taskCompletionSource = new TaskCompletionSource<bool>();

        // setup information for animation
        Action<double> callback = input => { LabelTitle.FontSize = input; };
        double startingHeight = LabelTitle.FontSize;
        double endingHeight = fontSize;
        uint rate = 5;
        uint length = 100;
        Easing easing = Easing.Linear;

        // now start animation with all the setup information
        LabelTitle.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

        return taskCompletionSource.Task;
    }
}