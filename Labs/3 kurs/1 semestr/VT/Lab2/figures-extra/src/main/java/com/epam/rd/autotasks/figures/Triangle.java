package com.epam.rd.autotasks.figures;

class Triangle extends Figure{
    Point[] points = new Point[3];

    public Triangle(Point p1, Point p2, Point p3)
    {
        this.points[0] = p1;
        this.points[1] = p2;
        this.points[2] = p3;

        if (p1 == null || p2 == null || p3 == null || area() == 0)
            throw new IllegalArgumentException();
    }

    @Override
    public double area(){
        return Math.abs(this.points[0].getX() * (this.points[1].getY() - this.points[2].getY())
                + this.points[1].getX() * (this.points[2].getY() - this.points[0].getY())
                + this.points[2].getX() * (this.points[0].getY() - this.points[1].getY())) / 2.0;
    }

    @Override
    public Point centroid(){
        return new Point ((this.points[0].getX() + this.points[1].getX() + this.points[2].getX()) / 3.0,
                (this.points[0].getY() + this.points[1].getY() + this.points[2].getY()) / 3.0);
    }

    @Override
    public boolean isTheSame(Figure figure){
        if (figure.getClass() != Triangle.class)
            return false;

        if (figure.area() != area())
            return false;

        return true;
    }

}
