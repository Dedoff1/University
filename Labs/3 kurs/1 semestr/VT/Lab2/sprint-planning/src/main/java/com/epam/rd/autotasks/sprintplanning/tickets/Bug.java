package com.epam.rd.autotasks.sprintplanning.tickets;

public class Bug extends Ticket {
    private int id;
    private String name;
    private int estimate;
    private UserStory userStory;

    private Bug(int id, String name, int estimate, UserStory userStory) {
        super(id, name, estimate);
        this.id = id;
        this.name = name;
        this.estimate = estimate;
        this.userStory = userStory;
    }

    public static Bug createBug(int id, String name, int estimate, UserStory userStory) {
        if (userStory == null || !userStory.isCompleted())
            return null;

        return new Bug(id, name, estimate, userStory);
    }

    @Override
    public String toString() {
        return "[Bug " + this.id + "] " + this.userStory.getName() + ": " + this.name;
    }
}
