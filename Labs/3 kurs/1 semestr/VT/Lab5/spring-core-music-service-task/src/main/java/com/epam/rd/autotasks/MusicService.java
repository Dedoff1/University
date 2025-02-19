package com.epam.rd.autotasks;

import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import java.util.ArrayList;
import java.util.List;

public class MusicService {

    private List<Song> songs = new ArrayList<>();

    public List<Song> getSongs() {
        return songs;
    }

    public void setSongs(List<Song> songs) {
        this.songs = songs;
    }

    @PostConstruct
    public void init(){
        for(int i=0; i<3; i++)
            songs.add(new Song());
    }

    @PreDestroy
    public void destroy(){
        System.out.println("Music service is shutting down");
    }

    // TODO: Add your implementation here.
}
