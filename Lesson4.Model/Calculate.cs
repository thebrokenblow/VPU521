namespace Lesson4.Model;

public class Calculate
{
    private CancellationToken? _cancellationToken;
    private CancellationTokenSource? _cancellationTokenSource;

    public void CancelParallelSum()
    {
        _cancellationTokenSource?.Cancel();
    }

    public void CalculateParallelSumNumber(decimal value, Action<decimal> setResult)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;

        var thread = new Thread(() => CalculateSumNumber(value, setResult));
        thread.Start();
    }

    private void CalculateSumNumber(decimal value, Action<decimal> setResult)
    {
        try
        {
            var sum = 0m;
            for (decimal i = 1; i < value; i++)
            {
                _cancellationToken?.ThrowIfCancellationRequested();

                sum += value;
            }

            setResult.Invoke(sum);
        }
        catch (OperationCanceledException)
        {
            setResult.Invoke(0);
        }
    }
}