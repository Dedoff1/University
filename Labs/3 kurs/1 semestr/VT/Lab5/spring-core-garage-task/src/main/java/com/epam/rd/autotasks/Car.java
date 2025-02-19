package com.epam.rd.autotasks;

import org.springframework.beans.factory.annotation.Autowired;

public class Car {

    private String model;

    @Autowired
    private Owner owner;

    private String year;

    public String getYear() {
        return year;
    }

    public void setYear(String year) {
        this.year = year;
    }

    public Owner getOwner() {
        return owner;
    }

    public void setOwner(Owner owner) {
        this.owner = owner;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public Car(){}

    public Car(Owner owner) {
        this.owner=owner;
    }







    // TODO: Modify this class for constructor injection.
}
