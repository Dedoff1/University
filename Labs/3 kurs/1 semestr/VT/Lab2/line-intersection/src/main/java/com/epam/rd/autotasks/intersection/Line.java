package com.epam.rd.autotasks.intersection;

public class Line {

    private int k;
    private  int b;

    public Line(int k, int b) {
        this.k = k;
        this.b = b;
    }

    public Point intersection(Line other) {
        if (this.k == other.k)
            return null;

        int x = (this.b - other.b) / (other.k - this.k);
        int y = this.k * x + this.b;
        return new Point(x,y);
    }

}
