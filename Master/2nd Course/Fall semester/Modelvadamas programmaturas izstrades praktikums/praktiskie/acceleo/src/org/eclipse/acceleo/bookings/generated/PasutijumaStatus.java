public enum PasutijumaStatus {

    PASUTITS(1),
    AKCEPTETS(2),
    SANEMTS(3),
    ATCELTS(4);

    private int value;

    PasutijumaStatus(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
