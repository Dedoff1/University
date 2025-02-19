package com.epam.rd.autotasks.figures;

class Triangle extends Figure{
    Point[] points = new Point[3];
    public Triangle(Point p1, Point p2, Point p3)
    {
        this.points[0] = p1;
        this.points[1] = p2;
        this.points[2] = p3;
    }

    @Override
    public double area()
    {
        return Math.abs(this.points[0].getX() * (this.points[1].getY() - this.points[2].getY())
                + this.points[1].getX() * (this.points[2].getY() - this.points[0].getY())
                + this.points[2].getX() * (this.points[0].getY() - this.points[1].getY())) / 2.0;
    }

    @Override
    public String pointsToString() {
        String str = "";

        for (Point p: points) {
            str += "(" + p.getX() + "," + p.getY() + ")";
        }
        return str;
    }

    @Override
    public Point leftmostPoint(){
        Point leftPoint = new Point(Integer.MAX_VALUE, 0);
        for (Point p: points){
            if (leftPoint.getX() > p.getX())
                leftPoint = p;
        }
        return leftPoint;
    }
}
