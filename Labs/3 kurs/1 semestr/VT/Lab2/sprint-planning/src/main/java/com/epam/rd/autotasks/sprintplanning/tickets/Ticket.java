package com.epam.rd.autotasks.sprintplanning.tickets;

public class Ticket {
    public int id;
    public String name;
    public int estimate;
    public boolean isCompleted = false;

    public Ticket(int id, String name, int estimate) {
        this.id = id;
        this.name = name;
        this.estimate = estimate;
    }

    public int getId() {
        return this.id;
    }

    public String getName() {
        return this.name;
    }

    public boolean isCompleted() {
        return this.isCompleted;
    }

    public void complete() {
        this.isCompleted = true;
    }

    public int getEstimate() {
        return this.estimate;
    }
}
