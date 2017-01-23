using System;
using System.Diagnostics;

using CoreLocation;
using Xamarin.Forms.Platform.iOS;

using BMapBinding;

namespace Xamarin.Forms.BaiduMaps.iOS
{
    public partial class MapRenderer : ViewRenderer<Map, BMKMapView>
    {
        private class MapViewDelegate : BMKMapViewDelegate
        {
            private MapRenderer map { get; }
            public MapViewDelegate(MapRenderer map)
            {
                this.map = map;
            }

            public override BMKAnnotationView ViewForAnnotation(BMKMapView mapView, BMKAnnotation annotation)
            {
                if (typeof(BMKPointAnnotation) == annotation.GetType())
                {
                    Pin ann = map.Map.Pins.Find(annotation);
                    if (null != ann) {
                        BMKPinAnnotationView annotationView = new BMKPinAnnotationView(annotation, "myAnnotation");
                        annotationView.PinColor = BMKPinAnnotationColor.Purple;
                        annotationView.AnimatesDrop = ann.Animate;
                        annotationView.Draggable = ann.Draggable;
                        // 开启后动态设置Image会导致pin图片拉伸
                        //annotationView.Enabled3D = ann.Enabled3D;

                        // 防止空白气泡弹出
                        annotationView.CanShowCallout = !string.IsNullOrEmpty(ann.Title);

                        if (null != ann.Image) {
                            annotationView.Image = ann.Image.ToNative();
                        }

                        return annotationView;
                    }
                }

                Debug.WriteLine("MapViewViewForAnnotation: " + annotation.GetType());
                return null;
            }

            public override BMKOverlayView ViewForOverlay(BMKMapView mapView, BMKOverlay overlay)
            {
                if (typeof(BMKPolyline) == overlay.GetType()) {
                    Polyline poly = map.Map.Polylines.Find(overlay);
                    if (null != poly) {
                        BMKPolylineView view = new BMKPolylineView(overlay);
                        view.StrokeColor = poly.Color.ToUIColor();
                        view.LineWidth = poly.Width;

                        return view;
                    }
                }
                else if (typeof(BMKPolygon) == overlay.GetType()) {
                    Polygon poly = map.Map.Polygons.Find(overlay);
                    if (null != poly) {
                        BMKPolygonView view = new BMKPolygonView(overlay);
                        view.StrokeColor = poly.Color.ToUIColor();
                        view.FillColor = poly.FillColor.ToUIColor();
                        view.LineWidth = poly.Width;

                        return view;
                    }
                }
                else if (typeof(BMKCircle) == overlay.GetType()) {
                    Circle circle = map.Map.Circles.Find(overlay);
                    if (null != circle) {
                        BMKCircleView view = new BMKCircleView(overlay);
                        view.StrokeColor = circle.Color.ToUIColor();
                        view.FillColor = circle.FillColor.ToUIColor();
                        view.LineWidth = circle.Width;

                        return view;
                    }
                }

                Debug.WriteLine("MapViewViewForOverlay: " + overlay.GetType());
                return null;
            }

            public override void OnClickedMapBlank(BMKMapView mapView, CLLocationCoordinate2D coordinate)
            {
                map.Map.SendBlankClicked(coordinate.ToUnity());
            }

            public override void OnClickedMapPoi(BMKMapView mapView, BMKMapPoi mapPoi)
            {
                Poi poi = new Poi {
                    Coordinate = mapPoi.Pt.ToUnity(),
                    Description = mapPoi.Description
                };

                map.Map.SendPoiClicked(poi);
            }

            public override void OnClickedBMKOverlayView(BMKMapView mapView, BMKOverlayView overlayView)
            {
                //Debug.WriteLine("点击Overlay: " + coordinate.ToCoordinate());
            }

            public override void OnDoubleClick(BMKMapView mapView, CLLocationCoordinate2D coordinate)
            {
                map.Map.SendDoubleClicked(coordinate.ToUnity());
            }

            public override void OnLongClick(BMKMapView mapView, CLLocationCoordinate2D coordinate)
            {
                map.Map.SendLongClicked(coordinate.ToUnity());
            }

            public override void DidSelectAnnotationView(BMKMapView mapView, BMKAnnotationView view)
            {
                Pin annotation = map.Map.Pins.Find(view.Annotation);
                view.SetSelected(false, true);
                annotation?.SendClicked();
            }

            public override void DidDeselectAnnotationView(BMKMapView mapView, BMKAnnotationView view)
            {
                //Pin annotation = Map.Pins.Find(view.Annotation);
                //annotation?.SendDeselected();
            }

            public override void AnnotationViewDidChangeDragState(
                BMKMapView mapView, BMKAnnotationView view,
                BMKAnnotationViewDragState newState, BMKAnnotationViewDragState oldState)
            {
                //Debug.WriteLine(oldState + " => " + newState);
                // None => Starting
                // Starting => Dragging
                // Dragging => Dragging
                // Dragging => Ending
                Pin annotation = map.Map.Pins.Find(view.Annotation);
                if (BMKAnnotationViewDragState.Starting == newState) {
                    annotation?.SendDrag(AnnotationDragState.Starting);
                    return;
                }

                if (BMKAnnotationViewDragState.Dragging == newState
                    && null != annotation)
                {
                    map.pinImpl.NotifyUpdate(annotation);
                    annotation.SendDrag(AnnotationDragState.Dragging);
                    return;
                }

                if (BMKAnnotationViewDragState.Ending == newState
                    && null != annotation)
                {
                    map.pinImpl.NotifyUpdate(annotation);
                    annotation.SendDrag(AnnotationDragState.Ending);
                }
            }

            public override void DidFinishLoading(BMKMapView mapView)
            {
                mapView.CompassPosition = new CoreGraphics.CGPoint(5, 20);
                mapView.ShowMapScaleBar = map.Map.ShowScaleBar;
                mapView.ViewWillAppear();
                map.Map.Projection = new ProjectionImpl(mapView);
                map.Map.SendLoaded();
            }

            public override void MapStatusDidChanged(BMKMapView mapView)
            {
                bool changed = false;

                Coordinate center = mapView.CenterCoordinate.ToUnity();
                if (Math.Abs(map.Map.Center.Latitude - center.Latitude) > 0.0001 ||
                    Math.Abs(map.Map.Center.Longitude - center.Longitude) > 0.0001)
                {
                    map.Map.SetValueSilent(Map.CenterProperty, center);
                    changed = true;
                }

                float zoom = mapView.ZoomLevel;
                if (Math.Abs(map.Map.ZoomLevel - zoom) > 0.001) {
                    map.Map.SetValueSilent(Map.ZoomLevelProperty, zoom);
                    changed = true;
                }

                if (changed) {
                   map.Map.SendStatusChanged();
                }
            }
        }
    }
}
