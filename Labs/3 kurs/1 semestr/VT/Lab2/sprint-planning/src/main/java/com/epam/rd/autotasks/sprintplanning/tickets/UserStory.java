package com.epam.rd.autotasks.sprintplanning.tickets;

public class UserStory extends Ticket {
    public int id;
    public String name;
    public int estimate;
    public UserStory[] dependsOn;
    public boolean isCompleted = false;

    public UserStory(int id, String name, int estimate, UserStory... dependsOn) {
        super(id, name, estimate);
        this.id = id;
        this.name = name;
        this.estimate = estimate;
        this.dependsOn = dependsOn;
    }

    @Override
    public void complete() {
        for (UserStory us:
             dependsOn) {
            if (!us.isCompleted())
                return;
        }
        this.isCompleted = true;
    }

    public UserStory[] getDependencies() {
        return this.dependsOn.clone();
    }

    @Override
    public String toString() {
        return "[US " + id + "] " + this.name;
    }

    @Override
    public boolean isCompleted() {
        return this.isCompleted;
    }
}
