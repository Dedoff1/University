using System.Drawing;

public class Circle : DisplayObject
{
    private int radius;

    public Circle(int x, int y, int radius, Color fillColor, Color borderColor, float borderWidth)
        : base(x, y, fillColor, borderColor, borderWidth)
    {
        this.radius = radius;
    }

    public override void Draw(Graphics g)
    {
        base.Draw(g);

        using (SolidBrush brush = new SolidBrush(fillColor))
        {
            g.FillEllipse(brush, x - radius, y - radius, radius * 2, radius * 2);
        }
        using (Pen pen = new Pen(borderColor, borderWidth))
        {
            g.DrawEllipse(pen, x - radius, y - radius, radius * 2, radius * 2);
        }
    }
}
