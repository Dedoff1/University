package com.epam.rd.autotasks;

public class CountDownTask implements Task{
    private int value;

    public CountDownTask(int value) {
        this.value = value;
        if (value < 0)
            this.value = 0;
    }

    public int getValue() {
        return this.value;
    }

    @Override
    public void execute() {
        if (!isFinished())
            value--;
    }

    @Override
    public boolean isFinished() {
        if (value <= 0)
            return true;

        return false;
    }
}
