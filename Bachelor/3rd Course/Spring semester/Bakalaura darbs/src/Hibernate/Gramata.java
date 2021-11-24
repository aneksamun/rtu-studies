package com.example.hibernate;

import java.util.Set;
import java.util.HashSet;

public class Grāmata {
    private int grāmatasID;
    private String nosaukums;
    private String izdevniecība;
    private Set<Autors> autori = new HashSet<Autors>();
    
    public Grāmata() {}
    
    public int getGrāmatasID() {
        return grāmatasID;
    }
    
    public void setGrāmatasID(int grāmatasID) {
        this.grāmatasID = grāmatasID;
    }
    
    public String getNosaukums() {
        return nosaukums;
    }
    
    public void setNosaukums(String nosaukums) {
        this.nosaukums = nosaukums;
    }
    
    public String getIzdevniecība() {
        return izdevniecība;
    }
    
    public void setIzdevniecība(String izdevniecība) {
        this.izdevniecība = izdevniecība;
    }
    
    public Set<Autors> getAutori() {
        return autori;
    }

    public void setAutori(Set<Autors> autori) {
        this.autori = autori;
    }
    
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Grāmata)) return false;
        Grāmata grāmata = (Grāmata)o;
        if (!this.getNosaukums().equals(grāmata.getNosaukums()))
            return false;
        if (!this.getIzdevniecība().equals(grāmata.getIzdevniecība()))
            return false;
        return true;
    }
    
    public int hashCode() {
        int result = 17;
        result = 37 * result + getNosaukums().hashCode();
        result = 37 * result + getIzdevniecība().hashCode();
        return result;
    }
}
