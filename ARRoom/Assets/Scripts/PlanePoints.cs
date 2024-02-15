using System.Collections.Generic;

public static class PlanePoints
{
    public static List<Point> Points { get; private set; } = new List<Point>();

    public static void AddPoint(Point point)
    {
        Points.Add(point);
    }
}
