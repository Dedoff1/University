package com.epam.rd.autotasks.figures;

class Circle extends Figure{
    public double radius;
    public Point center;

    public Circle(Point center, double d)
    {
        this.radius = d / 2.0;
        this.center = center;

        if (center == null || d < 0 || area() == 0)
            throw new IllegalArgumentException();
    }

    @Override
    public double area()
    {
        return Math.PI * radius * radius;
    }

    @Override
    public Point centroid()
    {
        return center;
    }

    @Override
    public boolean isTheSame(Figure figure)
    {
        if (figure.getClass() != Circle.class)
            return false;

        double delta = 1e-9;

        if (figure.centroid().getX() != centroid().getX() || figure.centroid().getY() != centroid().getY() || figure.area() != area()) {
            if (!isAlmostEqual(figure.centroid().getX(), centroid().getX(), delta))
                return false;
            else if (!isAlmostEqual(figure.centroid().getY(), centroid().getY(), delta))
                return  false;
            else if (!isAlmostEqual(figure.area(), area(), delta))
                return false;
        }


        return true;
    }

    private static boolean isAlmostEqual(double a, double b, double delta) {
        return Math.abs(a - b) <= delta;
    }
}
