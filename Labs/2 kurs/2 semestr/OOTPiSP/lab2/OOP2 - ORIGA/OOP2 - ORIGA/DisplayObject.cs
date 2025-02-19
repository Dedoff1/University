using System;

public class DisplayObject
{
    protected int x, y; // координаты точки привязки
    protected Color fillColor; // цвет заливки
    protected Color borderColor; // цвет рамки
    protected float borderWidth; // толщина рамки

    public DisplayObject(int x, int y, Color fillColor, Color borderColor, float borderWidth)
    {
        this.x = x;
        this.y = y;
        this.fillColor = fillColor;
        this.borderColor = borderColor;
        this.borderWidth = borderWidth;
    }

    public virtual void Draw(Graphics g)
    {
        // реализация рисования будет в наследуемых классах
    }
}
