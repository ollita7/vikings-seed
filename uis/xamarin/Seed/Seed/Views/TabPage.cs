using Xamarin.Forms;

namespace Seed.Views
{
    public class TabPage : TabbedPage
    {
        public TabPage()
        {
            Children.Add(new MyPageA());
            Children.Add(new MyPageB());
        }
    }
}
