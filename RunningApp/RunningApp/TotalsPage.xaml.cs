using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TotalsPage : ContentPage
    {
		Color color1 = Color.Red;
		Color color2 = Color.Blue;
		Color color = Color.Blue;
		int height1, height2, height3, heightTotal, bottom;
		public TotalsPage()
        {
            InitializeComponent();
            
            List<string> years = new List<string>();
            years.Add("2018 - 654 miles");
            years.Add("2019 - 702 miles");
            years.Add("2020 - 806 miles");

            lvTotals.ItemsSource = years;
            NavigationPage.SetBackButtonTitle(this, "Back");
            
        }

        Months months;

        private async void lvTotals_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            months = new Months();
            await Navigation.PushAsync(months, true);
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
			height1 = 65 * 2;
			height2 = 70 * 2;
			height3 = 80 * 2;
			heightTotal = height1 + height2;

			// view2.Height;

			canvas.DrawRect(30, bottom - height1, 30, height1, paint2);
			canvas.DrawRect(90, bottom - height2, 30, height2, paint2);
			canvas.DrawRect(150, bottom - height3, 30, height3, paint2);
		}
	}

}