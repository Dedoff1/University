package com.epam.rd.autotasks;

import java.util.Arrays;

public class DecrementingCarousel {
    private int capacity;
    private int nowCapacity;
    private boolean isRun;
    private int[] formArray = new int[1000];
    private int index = 0;

    public DecrementingCarousel(int capacity) {
        this.capacity = capacity;
        this.nowCapacity = 0;
        this.isRun = false;
    }

    public boolean addElement(int element){
        if (element <= 0 || this.nowCapacity >= this.capacity || this.isRun)
            return false;

        formArray[index] = element;
        this.nowCapacity++;
        index++;

        return true;
    }

    public CarouselRun run(){
       if (this.isRun)
           return null;

       this.isRun = true;

       int len = this.formArray.length;
       int i;
       for (i = 0; i < len && this.formArray[i] > 0; i++);
       int[] newArr = Arrays.copyOf(this.formArray, i);
       return new CarouselRun(newArr);
    }
}
