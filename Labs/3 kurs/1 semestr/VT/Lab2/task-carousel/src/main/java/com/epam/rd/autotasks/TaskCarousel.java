package com.epam.rd.autotasks;

import java.util.*;

public class TaskCarousel {
    private int capacity;
    private int nowCapacity = 0;

    private ArrayList<Task> arr = new ArrayList<Task>();
    private int index = 0;

    public TaskCarousel(int capacity) {
        this.capacity = capacity;
    }

    public boolean addTask(Task task) {
        if (task == null || task.isFinished() || this.isFull())
            return false;

        this.arr.add(task);
        int m = this.arr.size();
        this.nowCapacity++;

        return true;
    }

    public boolean execute() {
        if (this.arr.size() == 0)
            return false;

        Task task = this.arr.get(this.index);

        task.execute();

        if (task.isFinished()) {
            this.arr.remove(this.index);
            if (this.arr.size() != 0)
                this.index %= this.arr.size();
            return true;
        }
        this.arr.set(this.index, task);
        this.index = (this.index + 1) % this.arr.size();
        return true;
    }

    public boolean isFull() {
        if (this.arr.size() == this.capacity)
            return true;

        return false;
    }

    public boolean isEmpty() {
        if (this.arr.size() == 0)
            return true;

        return false;
    }

}
