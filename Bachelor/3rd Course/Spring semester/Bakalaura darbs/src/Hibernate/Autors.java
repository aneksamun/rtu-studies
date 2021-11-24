package com.example.hibernate;

import java.util.Set;
import java.util.HashSet;

public class Autors {
    private int autoraID;
    private String vārds;
    private String uzvārds;
    private Set<Grāmata> grāmatas = new HashSet<Grāmata>();
    
    public int getAutoraID() {
        return autoraID;
    }
    
    public void setAutoraID(int autoraID) {
        this.autoraID = autoraID;
    }
    
    public String getVārds() {
        return vārds;
    }
    
    public void setVārds(String vārds) {
        this.vārds = vārds;
    }
    
    public String getUzvārds() {
        return uzvārds;
    }
    
    public void setUzvārds(String uzvārds) {
        this.uzvārds = uzvārds;
    }
    
    public Set<Grāmata> getGrāmatas() {
        return grāmatas;
    }

    public void setGrāmatas(Set<Grāmata> grāmatas) {
        this.grāmatas = grāmatas;
    }
    
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Autors)) return false;
        Autors autors = (Autors)o;
        if (!this.getVārds().equals(autors.getVārds()))
            return false;
        if (!this.getUzvārds().equals(autors.getUzvārds()))
            return false;
        return true;
    }
    
    public int hashCode() {
        int result = 17;
        result = 37 * result + getVārds().hashCode();
        result = 37 * result + getUzvārds().hashCode();
        return result;
    }
}
