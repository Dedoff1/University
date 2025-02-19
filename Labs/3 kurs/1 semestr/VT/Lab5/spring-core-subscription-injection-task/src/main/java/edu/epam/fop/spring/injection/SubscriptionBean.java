package edu.epam.fop.spring.injection;

import org.springframework.beans.factory.annotation.Autowired;

public class SubscriptionBean implements  Subscription{

    private Account account;

    @Autowired
    public Payment payment;

    @Autowired
    private Period period;

    @Override
    public Account getUser() {
        return account;
    }

    @Override
    public Payment getPayment() {
        return payment;
    }

    @Override
    public Period getPeriod() {
        return period;
    }

    @Override
    public void setPeriod(Period period) {
        this.period=period;
    }

    public SubscriptionBean(Account account){
        this.account=account;
    }

    @Override
    public String toString(){
        return "("+account+", "+payment+", "+period+")";
    }
}
