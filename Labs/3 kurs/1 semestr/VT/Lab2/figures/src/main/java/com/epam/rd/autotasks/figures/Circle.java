package com.epam.rd.autotasks.figures;

class Circle extends Figure {
    public Point c;
    public double radius;
    public Circle(Point c, double radius)
    {
        this.c = c;
        this.radius = radius;
    }

    @Override
    public double area()
    {
        return Math.PI * radius * radius;
    }

    @Override
    public String pointsToString()
    {
        return "(" + c.getX() + "," + c.getY() + ")";
    }

    @Override
    public String toString(){
        return this.getClass().getSimpleName() + "[" + pointsToString() + radius + "]";
    }

    @Override
    public Point leftmostPoint()
    {
        return new Point(c.getX() - radius, c.getY());
    }

}
