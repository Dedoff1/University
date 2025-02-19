package edu.epam.fop.spring.injection.config;

import edu.epam.fop.spring.injection.*;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.stereotype.Component;

@Configuration
public class AppConfig {

    @Bean
    public Account account(){
        return new AccountBean("Vitaly");
    }

    @Bean
    public Payment payment(){
        return new PaymentBean();
    }

    @Bean
    public Period period(){
        return new PeriodBean();
    }

    @Bean
    public Subscription subscription(){
        AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(AppConfig.class);
        return new SubscriptionBean(context.getBean(AccountBean.class));
    }

    public static void main(String[] args){
        AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(AppConfig.class);
        Subscription subscription = context.getBean(Subscription.class);
        System.out.println(subscription);
    }

}
