package lab1.concepts;

public class Human {
    protected String name;
    protected String surname;
    
    public Human() {}
    
    public Human(String name, String surname) {
        this.name = name;
        this.surname = surname;
    }
    
    public Human(Human human) {
        this (human.name, human.surname);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSurname() {
        return surname;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    @Override
    public String toString() {
        return "Vārds: " + name + ", uzvārds: " + surname;
    }
}
