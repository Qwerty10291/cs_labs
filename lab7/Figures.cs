namespace cs_labs.lab7;

public class Dot
{
    private double x, y;

    public double X
    {
        get => x;
        set => x = value;
    }

    public double Y
    {
        get => y;
        set => y = value;
    }

    public Dot()
    {
        x = 0;
        y = 0;
    }

    public Dot(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override string ToString()
    {
        return $"({x},{y})";
    }

    public double DistanceTo(Dot other)
    {
        return  Math.Sqrt( Math.Pow(other.x - x, 2) + Math.Pow(other.y - y, 2));
    }
}

public interface IFigure
{
    double BaseSurfaceArea();
    double BaseSurfaceLength();
    double SideSurfaceArea();
}

public class Cylinder : IFigure
{
    private Dot p1;
    private Dot p2;
    private double height;

    public Dot P1
    {
        get => p1;
        set => p1 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Dot P2
    {
        get => p2;
        set => p2 = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Height
    {
        get => height;
        set => height = value;
    }

    public Cylinder()
    {
        p1 = new Dot();
        p2 = new Dot();
        height = 0;
    }

    public Cylinder(Dot p1, Dot onCircle, double height)
    {
        this.p1 = p1;
        this.p2 = onCircle;
        this.height = height;
    }
    public override string ToString()
    {
        return $"({p1}, {p2}) {height}";
    }
    public virtual double BaseSurfaceArea()
    {
        return Math.Pow(p2.DistanceTo(p1), 2) * Math.PI;
    }

    public virtual double BaseSurfaceLength()
    {
        return 2 * p2.DistanceTo(p1) * Math.PI;
    }

    public virtual double SideSurfaceArea()
    {
        return height * BaseSurfaceLength();
    }
    
}

public class TrianglePrism: Cylinder
{
    private Dot p3;

    public Dot P3
    {
        get => p3;
        set => p3 = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public override string ToString()
    {
        return $"({P1}, {P2}, {P3}) {Height}";
    }
    
    public override double BaseSurfaceArea()
    {
        return TriangleArea(P1, P2, P3);
    }

    public override double BaseSurfaceLength()
    {
        return P1.DistanceTo(P2) + P2.DistanceTo(P3) + P3.DistanceTo(P1);
    }

    protected static double TriangleArea(Dot p1, Dot p2, Dot p3)
    {
        double a = p1.DistanceTo(p2);
        double b = p2.DistanceTo(p3);
        double c = p3.DistanceTo(p1);
        double p = (a + b + c) / 2;
        return Math.Sqrt( p * (p - a) * (p - b) * (p - c));
    }
}


public class QuadranglePrism : TrianglePrism
{
    private Dot p4;

    public Dot P4
    {
        get => p4;
        set => p4 = value ?? throw new ArgumentNullException(nameof(value));
    }
    
}