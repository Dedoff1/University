package edu.epam.fop.spring.injection;

public class AccountBean implements Account{

    private String name;

    @Override
    public String getName() {
        return name;
    }

    public AccountBean(String name){
        this.name=name;
    }
}
