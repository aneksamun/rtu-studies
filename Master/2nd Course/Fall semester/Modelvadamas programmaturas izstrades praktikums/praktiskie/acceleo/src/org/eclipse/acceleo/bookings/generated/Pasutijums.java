public class Pasutijums {

	private int numurs; 
	private java.util.Date pasutisanasDatums; 
	private java.util.Date sanemsanasDatums; 
	private java.util.Date akceptesanasDatums; 
	private PasutijumaStatus status; 
	private Darbinieks darbinieks;
	private java.util.Set<PrecesVieniba> precesVieniba;

	public Pasutijums() {}

	public Pasutijums(int numurs, java.util.Date pasutisanasDatums, java.util.Date sanemsanasDatums, java.util.Date akceptesanasDatums, PasutijumaStatus status) {
		this.numurs = numurs;
		this.pasutisanasDatums = pasutisanasDatums;
		this.sanemsanasDatums = sanemsanasDatums;
		this.akceptesanasDatums = akceptesanasDatums;
		this.status = status;
	}

	public void setNumurs(int numurs) {
		this.numurs = numurs;
	}

	public int getNumurs() {
		return numurs;
	}

	public void setPasutisanasDatums(java.util.Date pasutisanasDatums) {
		this.pasutisanasDatums = pasutisanasDatums;
	}

	public java.util.Date getPasutisanasDatums() {
		return pasutisanasDatums;
	}

	public void setSanemsanasDatums(java.util.Date sanemsanasDatums) {
		this.sanemsanasDatums = sanemsanasDatums;
	}

	public java.util.Date getSanemsanasDatums() {
		return sanemsanasDatums;
	}

	public void setAkceptesanasDatums(java.util.Date akceptesanasDatums) {
		this.akceptesanasDatums = akceptesanasDatums;
	}

	public java.util.Date getAkceptesanasDatums() {
		return akceptesanasDatums;
	}

	public void setStatus(PasutijumaStatus status) {
		this.status = status;
	}

	public PasutijumaStatus getStatus() {
		return status;
	}

	public void setDarbinieks(Darbinieks darbinieks) {
		this.darbinieks = darbinieks; 
	}

	public Darbinieks getDarbinieks() {
		return darbinieks;
	}

	public void setPrecesVieniba(java.util.Set<PrecesVieniba> precesVieniba) {
		this.precesVieniba = precesVieniba; 
	}

	public java.util.Set<PrecesVieniba> getPrecesVieniba() {
		return precesVieniba;
	}

	public void akceptet() {

	}

	public void pasutit() {

	}

	public void sanemt() {

	}

	public void atcelt() {

	}
}
