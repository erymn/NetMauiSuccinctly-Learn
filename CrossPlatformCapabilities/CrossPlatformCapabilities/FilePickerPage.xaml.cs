namespace CrossPlatformCapabilities;

public partial class FilePickerPage : ContentPage
{
	public FilePickerPage()
	{
		InitializeComponent();
	}

	private async Task<FileSelection> PickAndShowAsync(PickOptions options)
	{
		try
		{
			FileResult result = await FilePicker.PickAsync(options);
			FileSelection fileResult = new FileSelection();
			if(result != null)
			{
				fileResult.FileName = $"File Name: {result.FileName}";
				if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) 
					|| result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
				{
					var stream = await result.OpenReadAsync();
					fileResult.Image = ImageSource.FromStream(() => stream);
				}
			}
			return fileResult;
		}
        catch (Exception ex)
        {
			return null;
        }
}

    private async Task PickButton_Clicked(object sender, EventArgs e)
    {
		var result = await PickAndShowAsync(new PickOptions { PickerTitle = "Pick a file" });
		this.ImgLabelName.Text = result.FileName;
		this.PickedImage.Source = result.Image;
    }
}