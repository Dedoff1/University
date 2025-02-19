package com.epam.rd.autotasks.figures;

class Quadrilateral extends Figure{
    Point[] points = new Point[4];

    public Quadrilateral(Point p1, Point p2, Point p3, Point p4)
    {
        this.points[0] = p1;
        this.points[1] = p2;
        this.points[2] = p3;
        this.points[3] = p4;

        if (p1 == null || p2 == null || p3 == null || p4 == null || trArea(this.points[0], this.points[1], this.points[2]) == 0 || trArea(this.points[0], this.points[2], this.points[3]) == 0|| !isConvex())
            throw new IllegalArgumentException();
    }

    @Override
    public double area(){
        return trArea(this.points[0], this.points[1], this.points[2]) + trArea(this.points[0], this.points[2], this.points[3]);
    }

    private double trArea(Point p1, Point p2, Point p3){
        return Math.abs(p1.getX() * (p2.getY() - p3.getY())
                + p2.getX() * (p3.getY() - p1.getY())
                + p3.getX() * (p1.getY() - p2.getY())) / 2.0;
    }

    @Override
    public Point centroid(){
        double totalArea = area(); // Общая площадь
        double xSum = 0;
        double ySum = 0;

        // Площади треугольников
        double area1 = trArea(points[0], points[1], points[2]);
        double area2 = trArea(points[0], points[2], points[3]);

        // Центр масс для каждого треугольника
        double centroidX1 = (points[0].getX() + points[1].getX() + points[2].getX()) / 3;
        double centroidY1 = (points[0].getY() + points[1].getY() + points[2].getY()) / 3;

        double centroidX2 = (points[0].getX() + points[2].getX() + points[3].getX()) / 3;
        double centroidY2 = (points[0].getY() + points[2].getY() + points[3].getY()) / 3;

        // Расчет центра масс с учетом площадей
        xSum = area1 * centroidX1 + area2 * centroidX2;
        ySum = area1 * centroidY1 + area2 * centroidY2;

        // Вычисление координат центра масс
        double Cx = xSum / totalArea;
        double Cy = ySum / totalArea;

        return new Point(Cx, Cy);
    }

    @Override
    public boolean isTheSame(Figure figure){
        if (figure.getClass() != Quadrilateral.class)
            return false;

        if (figure.area() != area())
            return false;

        return true;
    }

    private double crossProduct(Point p1, Point p2, Point p3) {
        return (p2.getX() - p1.getX()) * (p3.getY() - p1.getY()) - (p2.getY() - p1.getY()) * (p3.getX() - p1.getX());
    }

    public boolean isConvex() {
        boolean sign = false;

        for (int i = 0; i < 4; i++) {
            double cross = crossProduct(
                    (i == 0) ? this.points[3] : (i == 1) ? this.points[0] : (i == 2) ? this.points[1] : this.points[2],
                    (i == 0) ? this.points[0] : (i == 1) ? this.points[1] : (i == 2) ? this.points[2] : this.points[3],
                    (i == 0) ? this.points[1] : (i == 1) ? this.points[2] : (i == 2) ? this.points[3] : this.points[0]
            );

            if (cross > 0) {
                if (sign == false) {
                    sign = true;
                }
            } else if (cross < 0) {
                if (sign == true) {
                    return false;
                }
            }
        }
        return true;
    }
}
