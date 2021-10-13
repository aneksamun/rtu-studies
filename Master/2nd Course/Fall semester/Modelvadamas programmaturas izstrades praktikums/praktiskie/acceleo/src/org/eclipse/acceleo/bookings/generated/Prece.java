public class Prece {

	private java.lang.String nosaukums; 
	private Kategorija kategorija; 
	private java.math.BigDecimal vienibasCena; 
	private PrecesVieniba precesVieniba;

	public Prece() {}

	public Prece(java.lang.String nosaukums, Kategorija kategorija, java.math.BigDecimal vienibasCena) {
		this.nosaukums = nosaukums;
		this.kategorija = kategorija;
		this.vienibasCena = vienibasCena;
	}

	public void setNosaukums(java.lang.String nosaukums) {
		this.nosaukums = nosaukums;
	}

	public java.lang.String getNosaukums() {
		return nosaukums;
	}

	public void setKategorija(Kategorija kategorija) {
		this.kategorija = kategorija;
	}

	public Kategorija getKategorija() {
		return kategorija;
	}

	public void setVienibasCena(java.math.BigDecimal vienibasCena) {
		this.vienibasCena = vienibasCena;
	}

	public java.math.BigDecimal getVienibasCena() {
		return vienibasCena;
	}

	public void setPrecesVieniba(PrecesVieniba precesVieniba) {
		this.precesVieniba = precesVieniba; 
	}

	public PrecesVieniba getPrecesVieniba() {
		return precesVieniba;
	}

	public void atjaunot() {

	}
}
