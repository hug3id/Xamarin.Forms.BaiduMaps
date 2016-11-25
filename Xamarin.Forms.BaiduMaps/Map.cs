using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xamarin.Forms.BaiduMaps
{
    public enum MapType
    {
        None,
        Standard,
        Satellite
    }

    public enum UserTrackingMode
    {
        None,
        Follow,
        FollowWithCompass
    }

    public class Map : View
	{
        public Map()
        {
            VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand;

            //pointAnnotations.CollectionChanged += AnnotationsCollectionChanged;
        }

        // MapType
        public static readonly BindableProperty MapTypeProperty = BindableProperty.Create(
            propertyName: nameof(MapType),
            returnType: typeof(MapType),
            declaringType: typeof(Map),
            defaultValue: MapType.Standard
        );
        
        public MapType MapType {
            get { return (MapType)GetValue(MapTypeProperty); }
            set { SetValue(MapTypeProperty, value); }
        }

        // UserTrackingMode
        public static readonly BindableProperty UserTrackingModeProperty = BindableProperty.Create(
            propertyName: nameof(UserTrackingMode),
            returnType: typeof(UserTrackingMode),
            declaringType: typeof(Map),
            defaultValue: UserTrackingMode.None
        );

        public UserTrackingMode UserTrackingMode
        {
            get { return (UserTrackingMode)GetValue(UserTrackingModeProperty); }
            set { SetValue(UserTrackingModeProperty, value); }
        }

        // ShowUserLocation
        public static readonly BindableProperty ShowUserLocationProperty = BindableProperty.Create(
            propertyName: nameof(ShowUserLocation),
            returnType: typeof(bool),
            declaringType: typeof(Map),
            defaultValue: true
        );

        public bool ShowUserLocation {
            get { return (bool)GetValue(ShowUserLocationProperty); }
            set { SetValue(ShowUserLocationProperty, value); }
        }

        // ShowCompass
        public static readonly BindableProperty ShowCompassProperty = BindableProperty.Create(
            propertyName: nameof(ShowCompass),
            returnType: typeof(bool),
            declaringType: typeof(Map),
            defaultValue: true
        );

        public bool ShowCompass
        {
            get { return (bool)GetValue(ShowCompassProperty); }
            set { SetValue(ShowCompassProperty, value); }
        }

        // CompassPosition
        public static readonly BindableProperty CompassPositionProperty = BindableProperty.Create(
            propertyName: nameof(CompassPosition),
            returnType: typeof(Point),
            declaringType: typeof(Map),
            defaultValue: new Point(40, 40)
        );

        public Point CompassPosition
        {
            get { return (Point)GetValue(CompassPositionProperty); }
            set { SetValue(CompassPositionProperty, value); }
        }

        // ZoomLevel
        public static readonly BindableProperty ZoomLevelProperty = BindableProperty.Create(
            propertyName: nameof(ZoomLevel),
            returnType: typeof(float),
            declaringType: typeof(Map),
            defaultValue: 11f
        );

        public float ZoomLevel
        {
            get { return (float)GetValue(ZoomLevelProperty); }
            set { SetValue(ZoomLevelProperty, value); }
        }

        // MinZoomLevel
        public static readonly BindableProperty MinZoomLevelProperty = BindableProperty.Create(
            propertyName: nameof(MinZoomLevel),
            returnType: typeof(float),
            declaringType: typeof(Map),
            defaultValue: 3f
        );

        public float MinZoomLevel
        {
            get { return (float)GetValue(MinZoomLevelProperty); }
            set { SetValue(MinZoomLevelProperty, value); }
        }

        // MaxZoomLevel
        public static readonly BindableProperty MaxZoomLevelProperty = BindableProperty.Create(
            propertyName: nameof(MaxZoomLevel),
            returnType: typeof(float),
            declaringType: typeof(Map),
            defaultValue: 22f
        );

        public float MaxZoomLevel
        {
            get { return (float)GetValue(MaxZoomLevelProperty); }
            set { SetValue(MaxZoomLevelProperty, value); }
        }

        // Center
        public static readonly BindableProperty CenterProperty = BindableProperty.Create(
            propertyName: nameof(Center),
            returnType: typeof(Coordinate),
            declaringType: typeof(Map),
            defaultValue: new Coordinate(28.693, 115.958)
        );

        public Coordinate Center
        {
            get { return (Coordinate)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        // ShowScaleBar
        public static readonly BindableProperty ShowScaleBarProperty = BindableProperty.Create(
            propertyName: nameof(ShowScaleBar),
            returnType: typeof(bool),
            declaringType: typeof(Map),
            defaultValue: true
        );

        public bool ShowScaleBar
        {
            get { return (bool)GetValue(ShowScaleBarProperty); }
            set { SetValue(ShowScaleBarProperty, value); }
        }

        // ShowZoomControl
        public static readonly BindableProperty ShowZoomControlProperty = BindableProperty.Create(
            propertyName: nameof(ShowZoomControl),
            returnType: typeof(bool),
            declaringType: typeof(Map),
            defaultValue: true
        );

        public bool ShowZoomControl
        {
            get { return (bool)GetValue(ShowZoomControlProperty); }
            set { SetValue(ShowZoomControlProperty, value); }
        }

        public ILocationService LocationService { get; internal set; }
        public IProjection Projection { get; internal set; }

        public IList<Pin> Pins => pins;
        private readonly ObservableCollection<Pin> pins = new ObservableCollection<Pin>();

        public IList<Polyline> Polylines => polylines;
        private readonly ObservableCollection<Polyline> polylines = new ObservableCollection<Polyline>();

        public IList<Polygon> Polygons => polygons;
        private readonly ObservableCollection<Polygon> polygons = new ObservableCollection<Polygon>();

        public IList<Circle> Circles => circles;
        private readonly ObservableCollection<Circle> circles = new ObservableCollection<Circle>();

        public event EventHandler<MapBlankClickedEventArgs> BlankClicked;
        internal void SendBlankClicked(Coordinate pos)
        {
            BlankClicked?.Invoke(this, new MapBlankClickedEventArgs(pos));
        }

        public event EventHandler<MapPoiClickedEventArgs> PoiClicked;
        internal void SendPoiClicked(Poi poi)
        {
            PoiClicked?.Invoke(this, new MapPoiClickedEventArgs(poi));
        }

        public event EventHandler<MapDoubleClickedEventArgs> DoubleClicked;
        internal void SendDoubleClicked(Coordinate pos)
        {
            DoubleClicked?.Invoke(this, new MapDoubleClickedEventArgs(pos));
        }

        public event EventHandler<MapLongClickedEventArgs> LongClicked;
        internal void SendLongClicked(Coordinate pos)
        {
            LongClicked?.Invoke(this, new MapLongClickedEventArgs(pos));
        }

        public event EventHandler<EventArgs> Loaded;
        internal void SendLoaded()
        {
            Loaded?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> StatusChanged;
        internal void SendStatusChanged()
        {
            StatusChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

