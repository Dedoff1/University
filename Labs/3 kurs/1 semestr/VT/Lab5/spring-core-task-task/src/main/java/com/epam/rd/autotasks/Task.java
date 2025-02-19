package com.epam.rd.autotasks;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;

public class Task {

    //description, assignee and reviewer

    private String description;

    @Autowired
    @Qualifier("assignee")
    private Employee assignee;

    @Autowired
    @Qualifier("reviewer")
    private Employee reviewer;

    public Employee getAssignee() {
        return assignee;
    }

    public void setAssignee(Employee assignee) {
        this.assignee = assignee;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Employee getReviewer() {
        return reviewer;
    }

    public void setReviewer(Employee reviewer) {
        this.reviewer = reviewer;
    }

    public Task(){

    }

    // TODO: Add your implementation here.
}
