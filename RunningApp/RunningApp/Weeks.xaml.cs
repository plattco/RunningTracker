using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Weeks : ContentPage
    {
        Color color1 = Color.Red;
        Color color2 = Color.Blue;
        Color color = Color.Blue;
        int height1, height2, height3, height4, heightTotal, bottom;
        public Weeks()
        {
            InitializeComponent();
            List<string> weeks = new List<string>();
            weeks.Add("Week 1 - 13 miles");
            weeks.Add("Week 2 - 15 miles");
            weeks.Add("Week 3 - 11 miles");
            weeks.Add("Week 4 - 12 miles");

            lvWeeks.ItemsSource = weeks;
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
         Days days;

        private async void lvWeeks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            days = new Days();
            await Navigation.PushAsync(days, true);
        }

		void OnCanvas2ViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();
			SKPaint paint1 = new SKPaint
			{
				Style = SKPaintStyle.Fill,

				Color = color1.ToSKColor(),
				StrokeWidth = 3,
			};
			SKPaint paint2 = new SKPaint
			{
				Style = SKPaintStyle.Fill,
				Color = color2.ToSKColor(),
				StrokeWidth = 3,
			};
			bottom = info.Height - 50;
			height1 = 130 * 2;
			height2 = 150 * 2;
			height3 = 110 * 2;
			height4 = 120 * 2;
			heightTotal = height1 + height2;

			// view2.Height;

			canvas.DrawRect(30, bottom - height1, 30, height1, paint2);
			canvas.DrawRect(90, bottom - height2, 30, height2, paint2);
			canvas.DrawRect(150, bottom - height3, 30, height3, paint2);
			canvas.DrawRect(210, bottom - height4, 30, height4, paint2);
		}
	}
}