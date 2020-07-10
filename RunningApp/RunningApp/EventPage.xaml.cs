using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RunningApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        
        Image imLeft;
        Image imRight;

        public View portraitLayout;
        public View landscapeLayout;
        public EventPage()
        {
            InitializeComponent();
            
            for (int i = 0; i < 11; i++)
                mileMain.Items.Add(i.ToString());
            mileMain.SelectedIndex = 0;
            for (int j = 0; j < 60; j++)
                mileSecondary.Items.Add(j.ToString());
            mileSecondary.SelectedIndex = 0;
            for (int h = 0; h < 12; h++)
                hours.Items.Add(h.ToString());
            hours.SelectedIndex = 0;
            for (int m = 0; m < 60; m++)
                minutes.Items.Add(m.ToString());
            minutes.SelectedIndex = 21;
            lvActivities.ItemsSource = DB.conn.Table<Run>().ToList();

            /*StackLayout StackHorz = new StackLayout { Orientation = StackOrientation.Vertical };
            StackLayout StackVert = new StackLayout { Orientation = StackOrientation.Vertical };
            StackLayout stackTop = new StackLayout { Orientation = StackOrientation.Vertical };
            StackLayout stackMid = new StackLayout { Orientation = StackOrientation.Vertical };
            StackLayout stackBot = new StackLayout { Orientation = StackOrientation.Vertical };

            Grid grid = new Grid();
            grid.Children.Add(new Image { Aspect = Aspect.AspectFit, Source = "shoe.png", }, 1, 0);
            grid.Children.Add(new Image { Aspect = Aspect.AspectFit, Source = "stopwatch.jpg", }, 0, 0);
            grid.HorizontalOptions = LayoutOptions.CenterAndExpand;

            stackTop.Children.Add(stack1);
            stackTop.Children.Add(stack2);
            stackTop.Children.Add(stack3);
            stackMid.Children.Add(lvActivities);
            stackBot.Children.Add(grid);
            stackBot.Children.Add(add);
            stackBot.Children.Add(update);
            stackBot.Children.Add(delete);

            StackVert.Children.Add(stackTop);
            StackVert.Children.Add(stackMid);
            StackVert.Children.Add(stackBot);
            portraitLayout = StackVert;

            //StackHorz.Children.Add(stack1);
            //StackHorz.Children.Add(stack2);
            //StackHorz.Children.Add(stack3);
            //StackHorz.Children.Add(lvActivities);
            //StackHorz.Children.Add(add);
            //StackHorz.Children.Add(update);
            //StackHorz.Children.Add(delete);

            landscapeLayout = StackHorz;
            

            // Content = portraitLayout;
            */
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var unitPref = Xamarin.Essentials.Preferences.Get("val", "miles");
            distanceLabel.Text = "Distance " + unitPref;
        }

        private void distance_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ResetListViewSources()
        {
            lvActivities.ItemsSource = DB.conn.Table<Run>().ToList();
        }

        private void time_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddClicked(object sender, EventArgs e)
        {
            Run run = new Run
            {
                datePerformed = date.Date,
                Duration = new TimeSpan(Int32.Parse((string)hours.SelectedItem),
                                        Int32.Parse((string)minutes.SelectedItem), 0),
                distanceMile = Int32.Parse((string)mileMain.SelectedItem),
                distanceDec = Int32.Parse((string)mileSecondary.SelectedItem)
            };
            DB.conn.Insert(run);
            ResetListViewSources();
        }

        private void UpdateClicked(object sender, EventArgs e)
        {
            Run oldRun = lvActivities.SelectedItem as Run;
            Run newRun = new Run
            {
                datePerformed = date.Date,
                distanceMile = Int32.Parse((string)mileMain.SelectedItem),
                distanceDec = Int32.Parse((string)mileSecondary.SelectedItem),
                Duration = new TimeSpan(Int32.Parse((string)hours.SelectedItem),
                                        Int32.Parse((string)minutes.SelectedItem), 0)
            };
            newRun.Id = oldRun.Id;
            DB.conn.Update(newRun);
            ResetListViewSources();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            Run run = lvActivities.SelectedItem as Run;
            if (run != null)
            {
                int v = DB.conn.Delete(run);
                if (v > 0)
                {
                    lvActivities.SelectedItem = null;
                    ResetListViewSources();
                }
            }
        }

        private void lvActivities_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Run run = lvActivities.SelectedItem as Run;
            if (run != null)
            {
                date.Date = run.datePerformed;
                hours.SelectedItem = run.Duration.Hours.ToString();
                minutes.SelectedItem = run.Duration.Minutes.ToString();
                mileMain.SelectedItem = run.distanceMile.ToString();
                mileSecondary.SelectedItem = run.distanceDec.ToString();
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            bool isNowLandscape = width > height;
            if (isNowLandscape)
            {
                topStack.Orientation = StackOrientation.Horizontal;
                stack1.Orientation = StackOrientation.Vertical;
                stack2.Orientation = StackOrientation.Vertical;
                stack3.Orientation = StackOrientation.Vertical;
                bottomStack.Orientation = StackOrientation.Vertical;
                grid.Children.Add(shoe, 0, 0);
                grid.Children.Add(stopwatch, 0, 1);
            }
            else
            {
                topStack.Orientation = StackOrientation.Vertical;
                stack1.Orientation = StackOrientation.Horizontal;
                stack2.Orientation = StackOrientation.Horizontal;
                stack3.Orientation = StackOrientation.Horizontal;
                bottomStack.Orientation = StackOrientation.Vertical;
                grid.Children.Add(shoe, 0, 0);
                grid.Children.Add(stopwatch, 1, 0);
            }
        }
    }
}