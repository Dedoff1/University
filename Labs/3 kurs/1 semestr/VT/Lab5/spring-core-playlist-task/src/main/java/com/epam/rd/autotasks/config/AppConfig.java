package com.epam.rd.autotasks.config;

import com.epam.rd.autotasks.Singer;
import com.epam.rd.autotasks.Song;
import org.springframework.beans.factory.config.ConfigurableBeanFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.Scope;

import java.util.Random;

@Configuration
public class AppConfig {

    private final Random r =new Random();

    @Bean
    @Scope(value = ConfigurableBeanFactory.SCOPE_SINGLETON)
    public Singer singer(){
        return new Singer("Elton John");
    }

    @Bean
    @Scope(value = ConfigurableBeanFactory.SCOPE_PROTOTYPE)
    public Song song(){
        return new Song(Double.toHexString(r.nextDouble()));
    }

    // TODO: Add your implementation here.
}
