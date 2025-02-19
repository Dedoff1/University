package com.epam.rd.autotasks.sprintplanning;

import com.epam.rd.autotasks.sprintplanning.tickets.Bug;
import com.epam.rd.autotasks.sprintplanning.tickets.Ticket;
import com.epam.rd.autotasks.sprintplanning.tickets.UserStory;

import java.util.Arrays;

public class Sprint {
    private int capacity;
    private int thicketsLimit;
    private Ticket[] ticket;
    private int index;
    private int generalEstimate;

    public Sprint(int capacity, int ticketsLimit) {
        this.capacity = capacity;
        this.thicketsLimit = ticketsLimit;
        this.ticket = new Ticket[ticketsLimit];
        this.index = 0;
        this.generalEstimate = 0;
    }

    public boolean addUserStory(UserStory userStory) {
        if (userStory == null || userStory.isCompleted() || (this.generalEstimate + userStory.getEstimate()) > this.capacity || this.index >= this.thicketsLimit) {
            return false;
        }
        for (UserStory us:
             userStory.getDependencies()) {
            if (!isExistInArray(us))
                return false;
        }
            this.generalEstimate += userStory.getEstimate();
            this.ticket[this.index] = userStory;
            this.index++;
            return true;
    }

    public boolean addBug(Bug bugReport) {
        if (bugReport == null || bugReport.isCompleted() || (this.generalEstimate + bugReport.getEstimate()) > this.capacity || this.index >= this.thicketsLimit){
            return false;
        }
        this.generalEstimate += bugReport.getEstimate();
        this.ticket[this.index] = bugReport;
        this.index++;
        return true;
    }

    public Ticket[] getTickets() {
        int i = 0;
        for (i = 0; i < this.thicketsLimit; i++){
            if (ticket[i] == null)
                break;
        }
        Ticket[] tmp = Arrays.copyOf(this.ticket, i);

        return tmp.clone();
    }

    public int getTotalEstimate() {
        return this.generalEstimate;
    }

    private boolean isExistInArray(UserStory us){
        for (Ticket t:
             ticket) {
            if (us == t)
                return true;
        }
        return false;
    }
}
