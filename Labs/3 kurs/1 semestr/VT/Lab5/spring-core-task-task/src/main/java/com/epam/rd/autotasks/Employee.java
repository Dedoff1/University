package com.epam.rd.autotasks;

public class Employee {

    private String name;

    private String position;

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public String getPosition() {
        return position;
    }

    public Employee(){}

    public Employee(String name, String position){
        this.name=name;
        this.position=position;
    }

    // TODO: Add your implementation here.
}
