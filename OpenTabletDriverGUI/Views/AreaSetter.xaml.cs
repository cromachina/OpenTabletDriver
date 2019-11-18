using System;
using Avalonia;
using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Data;
using Avalonia.Markup.Xaml;

namespace OpenTabletDriverGUI.Views
{
    public class AreaSetter : UserControl
    {
        public AreaSetter()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            var ctrl = this.Find<Control>("AreaGrid");
            ctrl.PointerPressed += AreaPointerPressed;
            ctrl.PointerReleased += AreaPointerReleased;
            ctrl.PointerMoved += AreaPointerMoved;
            ctrl.PointerLeave += AreaLeave;
        }

        private bool IsDragging { set; get; }
        private Nullable<Point> LastPosition { set; get; }

        public void AreaPointerPressed(object sender, PointerPressedEventArgs e)
        {
            if (e.MouseButton == MouseButton.Left)
                IsDragging = true;
        }

        public void AreaPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            if (e.MouseButton == MouseButton.Left)
                IsDragging = false;
        }

        public void AreaLeave(object sender, PointerEventArgs e)
        {
            if (IsDragging)
                IsDragging = false;
        }

        public void AreaPointerMoved(object sender, PointerEventArgs e)
        {
            if (IsDragging)
            {
                if (LastPosition is Point lastPos)
                {
                    var currentPos = e.GetPosition(this);
                    var dX = lastPos.X - currentPos.X;
                    var dY = lastPos.Y - currentPos.Y;
                    AreaXOffset -= (float)dX;
                    AreaYOffset -= (float)dY;
                }
                LastPosition = e.GetPosition(this);
            }
            else if (LastPosition != null)
                LastPosition = null;
        }

        public static readonly StyledProperty<string> TitleProperty =
            AvaloniaProperty.Register<AreaSetter, string>(nameof(Title), defaultBindingMode: BindingMode.TwoWay);

        public string Title
        {
            set => SetValue(TitleProperty, value);
            get => GetValue(TitleProperty);
        }

        public static readonly StyledProperty<string> UnitProperty = 
            AvaloniaProperty.Register<AreaSetter, string>(nameof(MeasurementUnit), defaultBindingMode: BindingMode.TwoWay);

        public string MeasurementUnit
        {
            set => SetValue(UnitProperty, value);
            get => GetValue(UnitProperty);
        }

        public static readonly StyledProperty<float> AreaWidthProperty =
            AvaloniaProperty.Register<AreaSetter, float>(nameof(AreaWidth), defaultBindingMode: BindingMode.TwoWay);
        
        public float AreaWidth
        {
            set => SetValue(AreaWidthProperty, value);
            get => GetValue(AreaWidthProperty);
        }

        public static readonly StyledProperty<float> AreaHeightProperty =
            AvaloniaProperty.Register<AreaSetter, float>(nameof(AreaHeight), defaultBindingMode: BindingMode.TwoWay);

        public float AreaHeight
        {
            set => SetValue(AreaHeightProperty, value);
            get => GetValue(AreaHeightProperty);
        }

        public static readonly StyledProperty<float> AreaXOffsetProperty = 
            AvaloniaProperty.Register<AreaSetter, float>(nameof(AreaXOffset), defaultBindingMode: BindingMode.TwoWay);

        public float AreaXOffset
        {
            set => SetValue(AreaXOffsetProperty, value);
            get => GetValue(AreaXOffsetProperty);
        }

        public static readonly StyledProperty<float> AreaYOffsetProperty =
            AvaloniaProperty.Register<AreaSetter, float>(nameof(AreaYOffset), defaultBindingMode: BindingMode.TwoWay);

        public float AreaYOffset
        {
            set => SetValue(AreaYOffsetProperty, value);
            get => GetValue(AreaYOffsetProperty);
        }

        public static readonly StyledProperty<float> BackgroundWidthProperty = 
            AvaloniaProperty.Register<AreaSetter, float>(nameof(BackgroundWidth), defaultBindingMode: BindingMode.TwoWay);

        public float BackgroundWidth
        {
            set => SetValue(BackgroundWidthProperty, value);
            get => GetValue(BackgroundWidthProperty);
        }

        public static readonly StyledProperty<float> BackgroundHeightProperty = 
        AvaloniaProperty.Register<AreaSetter, float>(nameof(BackgroundHeight), defaultBindingMode: BindingMode.TwoWay);
        
        public float BackgroundHeight
        {
            set => SetValue(BackgroundHeightProperty, value);
            get => GetValue(BackgroundHeightProperty);
        }
    }
}