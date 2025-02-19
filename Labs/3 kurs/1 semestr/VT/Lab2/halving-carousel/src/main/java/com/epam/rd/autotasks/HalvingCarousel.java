package com.epam.rd.autotasks;

import java.util.Arrays;

public class HalvingCarousel extends DecrementingCarousel {

    public HalvingCarousel(final int capacity) {
        super(capacity);
    }

    @Override
    public CarouselRun run(){
        CarouselRun run = super.run();
        if (run != null){
            run.isDec(false);
            return run;
        }
        return null;
    }

}
