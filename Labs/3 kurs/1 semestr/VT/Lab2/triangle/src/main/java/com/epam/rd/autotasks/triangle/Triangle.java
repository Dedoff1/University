package com.epam.rd.autotasks.triangle;

class Triangle {

    Point[] points = new Point[3];
    public Triangle(Point a, Point b, Point c) {
        this.points[0] = a;
        this.points[1] = b;
        this.points[2] = c;

        if (area() == 0)
            throw new IllegalArgumentException();
    }

    public double area() {
        return Math.abs(this.points[0].getX() * (this.points[1].getY() - this.points[2].getY())
                + this.points[1].getX() * (this.points[2].getY() - this.points[0].getY())
                + this.points[2].getX() * (this.points[0].getY() - this.points[1].getY())) / 2.0;

    }

    public Point centroid(){
        return new Point((this.points[0].getX() + this.points[1].getX() + this.points[2].getX()) / 3.0,
                (this.points[0].getY() + this.points[1].getY() + this.points[2].getY()) / 3.0);
    }

}
