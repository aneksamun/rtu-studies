
class Gen<T> {
    T ob;
    
    Gen(T o) {
        ob = o;
    }
    
    T getOb() {
        return ob;
    }
}

class Gen2<T> extends Gen<T> {

    Gen2(T o) {
        super(o);
    }
}