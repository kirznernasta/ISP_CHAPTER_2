namespace Project;

public partial class ProgressBarPage : ContentPage
{
    CancellationTokenSource tokenSource;

    public ProgressBarPage()
    {
        InitializeComponent();
    }

    async void OnStart(object sender, EventArgs e)
    {
        tokenSource = new CancellationTokenSource();

        ProcessLabel.Text = "Computing...";
        ResultLabel.Text = "";

        StartButton.IsEnabled = false;
        CancelButton.IsEnabled = true;

        try
        { 
            await Task.Run(() => CalculateIntegral(), tokenSource.Token);
        }
        catch (OperationCanceledException ex) {
            ProgressBarIndecator.Progress = 0;
            ProgressResult.Text = $"0%";
            ProcessLabel.Text = "Canceled!";
        }
        catch(Exception ex)
        {
            Console.WriteLine($"EXCEPTION: {ex.Message}");
        }

        StartButton.IsEnabled = true;
        CancelButton.IsEnabled = false;
    }


    void OnCanceled(object sender, EventArgs e)
    {
        tokenSource.Cancel();

        CancelButton.IsEnabled = false;
        StartButton.IsEnabled = true;
    }


    void CalculateIntegral()
    {

        double step = 0.00001; //0.00000001
        double result = 0;

        var temp = 1000 * 1000000;
        double progress = 0;

        for (double i = 0; i < 1; i += step)
        {
            if (tokenSource.Token.IsCancellationRequested)
            {
                tokenSource.Token.ThrowIfCancellationRequested();
            }

            for (int j = 1; j <= 100000; j++)
            {
                temp = 1000 * 1000000;
            }

            result += step * Math.Sin(i);
            progress = Math.Round(i, 2);

            MainThread.BeginInvokeOnMainThread(() =>
            {

                ProgressBarIndecator.Progress = progress;
                ProgressResult.Text = $"{Convert.ToInt32(progress * 100)}%";
            });


        }

        if (progress == 1)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ProcessLabel.Text = "Completed!";
                ResultLabel.Text = $"Integral from 0 to 1 of sin(x) is: {Math.Round(result, 4)}";
            });

        }

    }
}