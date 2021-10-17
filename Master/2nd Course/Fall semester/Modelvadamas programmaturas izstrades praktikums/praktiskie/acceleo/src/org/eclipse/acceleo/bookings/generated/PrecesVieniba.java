public class PrecesVieniba {

    private int daudzums; 
    private Pasutijums pasutijums;
    private Prece prece;

    public PrecesVieniba() {}

    public PrecesVieniba(int daudzums) {
        this.daudzums = daudzums;
    }

    public void setDaudzums(int daudzums) {
        this.daudzums = daudzums;
    }

    public int getDaudzums() {
        return daudzums;
    }

    public void setPasutijums(Pasutijums pasutijums) {
        this.pasutijums = pasutijums; 
    }

    public Pasutijums getPasutijums() {
        return pasutijums;
    }

    public void setPrece(Prece prece) {
        this.prece = prece; 
    }

    public Prece getPrece() {
        return prece;
    }

    public java.math.BigDecimal sarekinatKopejoCenu() {
        throw new UnsupportedOperationException();
    }

    public java.math.BigDecimal noteiktCenuBezPVN() {
        throw new UnsupportedOperationException();
    }
}
