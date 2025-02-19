package com.epam.rd.autotasks;

public class CompleteByRequestTask implements Task {
    private boolean isFinished = false;
    private boolean isCalledMethodComplete = false;

    @Override
    public void execute() {
        if (this.isCalledMethodComplete)
            this.isFinished = true;
    }

    @Override
    public boolean isFinished() {
        return this.isFinished;
    }

    public void complete() {
        this.isCalledMethodComplete = true;
    }
}
