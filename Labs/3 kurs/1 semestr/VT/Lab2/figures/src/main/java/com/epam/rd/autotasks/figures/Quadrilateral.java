package com.epam.rd.autotasks.figures;

class Quadrilateral extends Figure {
    public Point[] points = new Point[4];
    public Quadrilateral(Point p1, Point p2, Point p3, Point p4)
    {
        this.points[0] = p1;
        this.points[1] = p2;
        this.points[2] = p3;
        this.points[3] = p4;
    }

    @Override
    public double area(){
        Point[] trP1 = {this.points[1], this.points[2], this.points[3]};
        Point[] trP2 = {this.points[3], this.points[0], this.points[1]};
        double tr1 = getTrArea(trP1);
        double tr2 = getTrArea(trP2);
        return tr1 + tr2;
    }

    private double getTrArea(Point[] points){
        return Math.abs(points[0].getX() * (points[1].getY() - points[2].getY())
            + points[1].getX() * (points[2].getY() - points[0].getY())
            + points[2].getX() * (points[0].getY() - points[1].getY())) / 2.0;
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
