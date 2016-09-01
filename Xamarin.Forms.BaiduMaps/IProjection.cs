using System;

namespace Xamarin.Forms.BaiduMaps
{
    public interface IProjection
    {
        Point ToScreen(Coordinate p);
        Coordinate ToCoordinate(Point p);
    }
}

