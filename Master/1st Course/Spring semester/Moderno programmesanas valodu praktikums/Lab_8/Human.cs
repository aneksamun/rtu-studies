namespace Lab8 {
    public class Human {
    
        public string Name { get; set; }
        public string Surname { get; set; }

        public Human() { }

        public Human(string name, string surname) {
            Name = name;
            Surname = surname;
        }

        public Human(Human human)
            : this(human.Name, human.Surname) {
        }

        public override string ToString() {
            return string.Format("Vārds: {0}, uzvārds: {1}", Name, Surname);
        }
    }
}
