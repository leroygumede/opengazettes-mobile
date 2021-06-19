using OpenGazettes.Models;
using Xamarin.Forms;

namespace OpenGazettes.Controls
{
    public partial class LoaderControl : StackLayout
    {
        public LoaderControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty EnableLoaderProperty = BindableProperty.Create(nameof(EnableLoader), typeof(bool), typeof(LoaderControl), false);

        public bool EnableLoader
        {
            get => (bool)GetValue(EnableLoaderProperty);
            set => SetValue(EnableLoaderProperty, value);
        }

        public static readonly BindableProperty EnableNoContentProperty = BindableProperty.Create(nameof(EnableNoContent), typeof(bool), typeof(LoaderControl), false);

        public bool EnableNoContent
        {
            get => (bool)GetValue(EnableNoContentProperty);
            set => SetValue(EnableNoContentProperty, value);
        }

        public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(LoadStatus), typeof(LoaderControl), LoadStatus.None, propertyChanged: StatusChanged);

        public LoadStatus Status
        {
            get => (LoadStatus)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }

        private static void StatusChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoaderControl)bindable;
            if (newValue != null)
            {
                var currentStatus = (LoadStatus)newValue;
                switch (currentStatus)
                {
                    case LoadStatus.None:
                        control.EnableLoader = false;
                        control.EnableNoContent = false;
                        break;

                    case LoadStatus.Loading:
                        control.EnableLoader = true;
                        control.EnableNoContent = false;
                        break;

                    case LoadStatus.Empty:
                        control.EnableLoader = false;
                        control.EnableNoContent = true;
                        break;

                    default:

                        break;
                }
            }
        }
    }
}