package com.epam.rd.autotasks;

import java.util.Arrays;

public class DecrementingCarouselWithLimitedRun extends DecrementingCarousel {
    private int actionLimit;

    public DecrementingCarouselWithLimitedRun(final int capacity, final int actionLimit) {
        super(capacity);
        this.actionLimit = actionLimit;
    }

    @Override
    public CarouselRun run() {
        CarouselRun run = super.run();
        if (run != null) {
            run.setCountCalls(this.actionLimit);
            run.isSimpleDec(false);
            return run;
        }
        return null;
    }
}
