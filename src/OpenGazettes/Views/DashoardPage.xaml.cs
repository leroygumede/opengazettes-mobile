using Xamarin.Forms;

namespace OpenGazettes.Views
{
    public partial class DashoardPage : ContentPage
    {
        public DashoardPage()
        {
            InitializeComponent();
        }

        public void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyCollectionView.SelectedItem != null)
            {
                MyCollectionView.SelectedItem = null;
            }
        }
    }
}