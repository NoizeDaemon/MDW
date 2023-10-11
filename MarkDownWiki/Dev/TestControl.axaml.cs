using System;
using System.Diagnostics;
using System.Threading;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace MarkDownWiki.Dev;

public partial class TestControl : UserControl
{
    private TimeSpan _duration = TimeSpan.FromSeconds(5);
    private Animation _initialAnimation;
    private CancellationTokenSource _cancellationTokenSource;

    public TestControl()
    {
        InitializeComponent();

        _cancellationTokenSource = new CancellationTokenSource();

        _initialAnimation = new Animation()
        {
            Duration = _duration,
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Setters =
                    {
                        new Setter(ProgressBar.ValueProperty, 100.0d)
                    }
                },
                new KeyFrame()
                {
                    KeyTime = _duration,
                    Setters =
                    {
                        new Setter(ProgressBar.ValueProperty, 0.0d)
                    }
                }
            }
        };

        _initialAnimation.RunAsync(ProgressBarToAnimate, _cancellationTokenSource.Token);
    }


    private Animation GetContinueAnimation(double currentValue)
    {
        var remainingTime = TimeSpan.FromMicroseconds(_duration.TotalMicroseconds * (double)(currentValue / 100));

        return new Animation()
        {
            Duration = remainingTime,
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame()
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Setters =
                    {
                        new Setter(ProgressBar.ValueProperty, currentValue)
                    }
                },
                new KeyFrame()
                {
                    KeyTime = remainingTime,
                    Setters =
                    {
                        new Setter(ProgressBar.ValueProperty, 0.0d)
                    }
                }
            }
        };
    }

    private void StartAnimation()
    {
        _initialAnimation.RunAsync(ProgressBarToAnimate, _cancellationTokenSource.Token);
    }

    private void OnResetButtonClick(object? sender, RoutedEventArgs e)
    {
        StartAnimation();
    }

    private void OnPointerEnteredMessage(object? sender, PointerEventArgs e)
    {
        e.Handled = true;
        var currentValue = ProgressBarToAnimate.Value;
        Debug.WriteLine(currentValue);
        _cancellationTokenSource.Cancel();
        ProgressBarToAnimate.Value = currentValue;
        if (!_cancellationTokenSource.TryReset())
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }


    private void OnPointerExitedMessage(object? sender, PointerEventArgs e)
    {
        e.Handled = true;
        var newAnimation = GetContinueAnimation(ProgressBarToAnimate.Value);
        newAnimation.RunAsync(ProgressBarToAnimate, _cancellationTokenSource.Token);
    }
}