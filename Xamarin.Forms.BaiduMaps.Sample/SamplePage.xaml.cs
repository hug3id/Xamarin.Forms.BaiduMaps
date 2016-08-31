using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.BaiduMaps;

namespace Xamarin.Forms.BaiduMaps.Sample
{
    public partial class SamplePage : ContentPage
	{
        //Map map;
        public SamplePage()
        {
            InitializeComponent();

            /*Content = new StackLayout {
                Children = { new Map { } }
            };*/

            /*map = new Map();
            RelativeLayout layout = new RelativeLayout();
            layout.Children.Add(
                map,
                Constraint.Constant(0),
                Constraint.Constant(0));
            //Constraint.Constant(UIScreen.),
            //Constraint.Constant(567));

            layout.Children.Add(
                Content,
                Constraint.Constant(0),
                Constraint.Constant(0));

            Content = layout;*/

            map.Loaded += MapLoaded;

            // 离线地图模块可单独使用
            OfflineMap offlineMap = DependencyService.Get<OfflineMap>();

            offlineMap.HasUpdate += (_, e) => {
                Debug.WriteLine("OfflineMap has update: " + e.CityID);
            };

            offlineMap.Downloading += (_, e) => {
                Debug.WriteLine("OfflineMap downloading: " + e.CityID);
            };

            var list = offlineMap.HotList;
            list = offlineMap.AllList;
            //offlineMap.Remove(131);
            var curr = offlineMap.Current;
            //offlineMap.Start(131);
            curr = offlineMap.Current;

            //InitControls();
        }

        public void MapLoaded(object sender, EventArgs x)
        {
            map.ShowScaleBar = true;
            InitLocationService();
            InitEvents();
        }

        public void InitControls()
        {
            /*RelativeLayout layout = new RelativeLayout();
            layout.Children.Add(map, Constraint.Constant(0), Constraint.Constant(0),
                                Constraint.Constant(375), Constraint.Constant(500));
            layout.Children.Add(new Button { Text = "aaaaa", WidthRequest = 70, HeightRequest = 30, BackgroundColor=Color.White, Opacity=0.5 },
                                Constraint.Constant(0),
                                Constraint.Constant(0),
                                Constraint.Constant(70),
                                Constraint.Constant(70));
            //map.
            this.Content = layout; */
        }

        private static bool moved = false;
        public void InitLocationService()
        {
            map.LocationService.LocationUpdated += (_, e) => {
                //Debug.WriteLine("LocationUpdated: " + ex.Coordinate);
                if (!moved) {
                    map.Center = e.Coordinate;
                    moved = true;
                }
            };

            map.LocationService.Failed += (_, e) => {
                Debug.WriteLine("Location failed: " + e.Message);
            };

            map.LocationService.Start();
        }

        public void InitEvents()
        {
            btnTrack.Clicked += (_, e) => {
                if (map.ShowUserLocation) {
                    map.UserTrackingMode = UserTrackingMode.None;
                    map.ShowUserLocation = false;
                }
                else {
                    map.UserTrackingMode = UserTrackingMode.FollowWithCompass;
                    map.ShowUserLocation = true;
                }
            };

            btnZoomIn.Clicked += (_, e) => {
                map.ZoomLevel++;
            };

            map.LongClicked += (_, e) => {
                AddPin(e.Coordinate);
            };

            map.StatusChanged += (_, e) => {
                Debug.WriteLine(map.Center + " @" + map.ZoomLevel);
            };
        }

        void AddPin(Coordinate coord)
        {
            Pin annotation = new Pin {
                Title = coord,
                Coordinate = coord,
                Animate = true,
                Draggable = true,
                Enabled3D = true,
                Image = XImage.FromStream(
                    typeof(SamplePage).GetTypeInfo().Assembly.GetManifestResourceStream("Sample.Images.pin_purple.png")
                )
            };
            map.Pins.Add(annotation);

            annotation.Drag += (_, e) => {
                annotation.Title = annotation.Coordinate;
                int i = map.Pins.IndexOf(annotation);

                if (map.Polylines.Count > 0 && i>-1) {
                    map.Polylines[0].Points[i] = annotation.Coordinate;
                }
            };
            annotation.Clicked += (_, e) => {
                Debug.WriteLine("clicked");
            };

            if (0 == map.Polylines.Count && map.Pins.Count > 1) {
                Polyline polyline = new Polyline {
                    Points = new ObservableCollection<Coordinate> {
                        map.Pins[0].Coordinate, map.Pins[1].Coordinate 
                    },
                    Width = 4,
                    Color = Color.Purple
                };

                map.Polylines.Add(polyline);
            }
            else if (map.Polylines.Count > 0) {
                map.Polylines[0].Points.Add(annotation.Coordinate);
            }
        }
    }
}

