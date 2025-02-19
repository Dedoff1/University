package edu.epam.fop.spring.injection;

public class PaymentBean implements Payment{

    private long amount=40;

    private String type = "52";

    @Override
    public long getAmount() {
        return amount;
    }

    @Override
    public String getType() {
        return type;
    }
}
