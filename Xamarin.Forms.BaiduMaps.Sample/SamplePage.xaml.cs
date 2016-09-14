using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace Xamarin.Forms.BaiduMaps.Sample
{
    public partial class SamplePage : ContentPage
	{
        public SamplePage()
        {
            InitializeComponent();
            map.Loaded += MapLoaded;

            IOfflineMap offlineMap = DependencyService.Get<IOfflineMap>();
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
            //offlineMap.Start(27);
            //offlineMap.Start(75);
            curr = offlineMap.Current;

            // 计算
            ICalculateUtils calc = DependencyService.Get<ICalculateUtils>();
            Debug.WriteLine(calc.CalculateDistance(
                new Coordinate(40, 116),
                new Coordinate(41, 117)
            ));//139599.429229778 in iOS, 139689.085961837 in Android
        }

        public void MapLoaded(object sender, EventArgs x)
        {
            map.ShowScaleBar = true;
            InitLocationService();
            InitEvents();

            Coordinate[] coords = new Coordinate[] {
                new Coordinate(40.044, 116.391),
                new Coordinate(39.861, 116.284),
                new Coordinate(39.861, 116.468)
            };

            map.Polygons.Add(new Polygon {
                Points = new ObservableCollection<Coordinate>(coords),
                Color = Color.Blue,
                FillColor = Color.Red.MultiplyAlpha(0.7),
                Width = 2
            });

            map.Circles.Add(new Circle {
                Coordinate = map.Center,
                Color = Color.Green,
                FillColor = Color.Yellow.MultiplyAlpha(0.2),
                Radius = 200,
                Width = 2
            });

            Task.Run(() => {
                for (;;) {
                    Task.Delay(1000).Wait();

                    var p = map.Polygons[0].Points[0];
                    p = new Coordinate(p.Latitude + 0.002, p.Longitude);
                    map.Polygons[0].Points[0] = p;

                    map.Circles[0].Radius += 100;
                }
            });

            // 坐标转换
            IProjection proj = map.Projection;
            var coord = proj.ToCoordinate(new Point(100, 100));
            Debug.WriteLine(proj.ToScreen(coord));
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
                Debug.WriteLine(e.Satellites);
            };

            map.LocationService.Failed += (_, e) => {
                Debug.WriteLine("Location failed: " + e.Message);
            };

            //map.LocationService.Start();
        }

        public void InitEvents()
        {
            btnTrack.Clicked += (_, e) => {
                if (map.ShowUserLocation) {
                    map.UserTrackingMode = UserTrackingMode.None;
                    map.ShowUserLocation = false;
                }
                else {
                    map.UserTrackingMode = UserTrackingMode.Follow;
                    map.ShowUserLocation = true;
                }
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

            annotation.Drag += (o, e) => {
                Pin self = o as Pin;
                self.Title = null;//self.Coordinate;
                int i = map.Pins.IndexOf(self);

                if (map.Polylines.Count > 0 && i>-1) {
                    map.Polylines[0].Points[i] = self.Coordinate;
                }
            };
            annotation.Clicked += (_, e) => {
                Debug.WriteLine("clicked");
                //await Navigation.PushAsync(new TestPage());
                ((Pin)_).Image = XImage.FromStream(
                    typeof(SamplePage).GetTypeInfo().Assembly.GetManifestResourceStream("Sample.Images.10660.png")
                );
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

