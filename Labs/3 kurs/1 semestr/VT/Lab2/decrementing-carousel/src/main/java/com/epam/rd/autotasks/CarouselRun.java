package com.epam.rd.autotasks;

public class CarouselRun {
    private int[] elements;
    private int index = 0;

    public CarouselRun(int[] elements){
        this.elements = elements;
    }

    public int next() {
        if (isFinished())
            return -1;

        int len = this.elements.length;
        int ret = this.elements[this.index];
        this.elements[this.index]--;
        int i = 0;
        do {
            i++;
            this.index = (this.index + 1) % len;
        } while (this.elements[this.index]  <= 0 && i < len);

        return ret;
    }

    public boolean isFinished() {
        int len = this.elements.length;

        boolean isZeroArr = true;
        for (int i = 0; i < len; i++)
            if (this.elements[i] > 0 )
                isZeroArr = false;

        return isZeroArr;
    }
}
