package com.epam.rd.autotasks.config;

import com.epam.rd.autotasks.Employee;
import com.epam.rd.autotasks.Task;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class AppConfig {

    @Bean
    public Employee assignee(){
        return new Employee("John Doe", "Junior Software Engineer");
    }

    @Bean
    public Employee reviewer(){
        return new Employee("Emily Brown", "Senior Software Engineer");
    }

    @Bean
    public Task task(){
        Task t = new Task();
        t.setDescription("New feature");
        return t;
    }

    // TODO: Add your implementation here.
}
