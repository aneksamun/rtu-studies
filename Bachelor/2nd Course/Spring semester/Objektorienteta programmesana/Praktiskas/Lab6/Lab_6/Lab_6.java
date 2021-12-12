
class Settlement {

    private final static long defaultCitizensAmount = 0;
    private final static short defaultAreaCode = (short) 0;
    private final static String defaultSettlementName = "Unknown";
    
    private String settlementName;
    private long citizensAmount;
    private short areaCode;

    public Settlement() {
        areaCode = defaultAreaCode;
        settlementName = defaultSettlementName;
        citizensAmount = defaultCitizensAmount;
    }
    
    public Settlement(String name, short code, long amount) {
        this.areaCode = code;
        this.settlementName = name;
        this.citizensAmount = amount;
    }
    
    public String getSettlementName() {
        return this.settlementName;
    }
    
    public long getCitizensAmount() {
         return this.citizensAmount;
    }
    
    public short getAreaCode() {
        return this.areaCode;
    }
    
    public void setAreaCode(short code) {
        this.areaCode = code;
    }
    
    public void setCitizensAmount(long amount) {
        this.citizensAmount = amount;
    }
    
    public void setSettlementName(String name) {
        this.settlementName = name;
    }
    
    public String toString() {
        return "Settlement name: " + settlementName + ", area code: " + areaCode + ", citizens amount: " + citizensAmount + ".";
    }
}

public class Lab_6 {

    public static void main(String[] args) {
        Settlement s1 = new Settlement("Rožupe", (short)150, 3145), s2 = new Settlement();
        
        System.out.println(s1.toString());
        System.out.println(s1);
        System.out.println(s2);

        s2.setSettlementName("Vārkava");
        s2.setAreaCode((short)3175);
        s2.setCitizensAmount(548);
        
        System.out.println(s2);
        System.out.println("\nPress \"Enter\" to finish program... ");
        
        try {
            System.in.read();
        }
        catch(java.io.IOException e) {
            System.out.println("Input/output exception.");
        }
    }
}
