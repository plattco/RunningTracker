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
    public partial class Days : ContentPage
    {
        Color color1 = Color.Red;
        Color color2 = Color.Blue;
        Color color = Color.Blue;
        int height1, height2, height3, height4, height5, height6, height7, heightTotal, bottom;
        public Days()
        {
            InitializeComponent();
            List<string> days = new List<string>();
            days.Add("Monday - 2 miles");
            days.Add("Tuesday - 1 miles");
            days.Add("Wednesday - 0 miles");
            days.Add("Thursday - 2 miles");
            days.Add("Friday - 1 miles");
            days.Add("Saturday - 0 miles");
            days.Add("Sunday - 87 miles");

            lvDays.ItemsSource = days;
        }

        private void lvWeeks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

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
            height1 = 200 * 2;
            height2 = 100 * 2;
            height3 = 0 * 2;
            height4 = 200 * 2;
            height5 = 100 * 2;
            height6 = 0 * 2;
            height7 = 800 * 2;

            heightTotal = height1 + height2;

            // view2.Height;

            canvas.DrawRect(30, bottom - height1, 30, height1, paint2);
            canvas.DrawRect(90, bottom - height2, 30, height2, paint2);
            canvas.DrawRect(150, bottom - height3, 30, height3, paint2);
            canvas.DrawRect(210, bottom - height4, 30, height4, paint2);
            canvas.DrawRect(270, bottom - height5, 30, height5, paint2);
            canvas.DrawRect(330, bottom - height6, 30, height6, paint2);
            canvas.DrawRect(390, bottom - height7, 30, height7, paint2);
        }
    }
}