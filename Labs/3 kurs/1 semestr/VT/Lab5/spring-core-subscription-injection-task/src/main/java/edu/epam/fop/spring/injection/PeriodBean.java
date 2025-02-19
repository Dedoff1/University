package edu.epam.fop.spring.injection;

import java.time.Duration;
import java.time.LocalDate;

public class PeriodBean implements Period{

    private Duration duration = Duration.ZERO;

    private LocalDate localDate = LocalDate.MAX;

    @Override
    public Duration paymentPeriod() {
        return duration;
    }

    @Override
    public LocalDate endDate() {
        return localDate;
    }
}
