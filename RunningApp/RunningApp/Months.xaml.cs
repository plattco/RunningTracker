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
    public partial class Months : ContentPage
    {
        Color color1 = Color.Red;
        Color color2 = Color.Blue;
        Color color = Color.Blue;
        int height1, height2, height3, height4, height5, height6, height7, height8, height9, height10, height11, height12, heightTotal, bottom;
        public Months()
        {
            InitializeComponent();

            List<string> months = new List<string>();
            months.Add("January - 54 miles");
            months.Add("February - 70 miles");
            months.Add("March - 80 miles");
            months.Add("April - 65 miles");
            months.Add("May - 80 miles");
            months.Add("June - 72 miles");
            months.Add("July - 86 miles");
            months.Add("August - 64 miles");
            months.Add("September - 72 miles");
            months.Add("October - 86 miles");
            months.Add("November - 54 miles");
            months.Add("December - 72 miles");
            

            lvMonths.ItemsSource = months;
            NavigationPage.SetBackButtonTitle(this, "Back");
        }
        Weeks weeks;

        private async void lvMonths_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            weeks = new Weeks();
            await Navigation.PushAsync(weeks, true);
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
            height1 = 54 * 2;
            height2 = 70 * 2;
            height3 = 80 * 2;
            height4 = 65 * 2;
            height5 = 80 * 2;
            height6 = 72 * 2;
            height7 = 86 * 2;
            height8 = 64 * 2;
            height9 = 72 * 2;
            height10 = 86 * 2;
            height11 = 54 * 2;
            height12 = 72 * 2;

            heightTotal = height1 + height2;

            // view2.Height;

            canvas.DrawRect(30, bottom - height1, 30, height1, paint2);
            canvas.DrawRect(90, bottom - height2, 30, height2, paint2);
            canvas.DrawRect(150, bottom - height3, 30, height3, paint2);
            canvas.DrawRect(210, bottom - height4, 30, height4, paint2);
            canvas.DrawRect(270, bottom - height5, 30, height5, paint2);
            canvas.DrawRect(330, bottom - height6, 30, height6, paint2);
            canvas.DrawRect(390, bottom - height7, 30, height7, paint2);
            canvas.DrawRect(450, bottom - height8, 30, height8, paint2);
            canvas.DrawRect(510, bottom - height9, 30, height9, paint2);
            canvas.DrawRect(570, bottom - height10, 30, height10, paint2);
            canvas.DrawRect(630, bottom - height11, 30, height11, paint2);
            canvas.DrawRect(690, bottom - height12, 30, height12, paint2);
        }
    }
}