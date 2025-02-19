package com.epam.rd.autotasks;

public class GraduallyDecreasingCarousel extends DecrementingCarousel{

    public GraduallyDecreasingCarousel(final int capacity) {
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
