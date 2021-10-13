public class Darbinieks {

	private java.lang.String vards; 
	private java.lang.String uzvards; 
	private Nodala nodala; 
	private java.util.Set<Pasutijums> pasutijumi;
	private NodalasVaditajs vaditajs;

	public Darbinieks() {}

	public Darbinieks(java.lang.String vards, java.lang.String uzvards, Nodala nodala) {
		this.vards = vards;
		this.uzvards = uzvards;
		this.nodala = nodala;
	}

	public void setVards(java.lang.String vards) {
		this.vards = vards;
	}

	public java.lang.String getVards() {
		return vards;
	}

	public void setUzvards(java.lang.String uzvards) {
		this.uzvards = uzvards;
	}

	public java.lang.String getUzvards() {
		return uzvards;
	}

	public void setNodala(Nodala nodala) {
		this.nodala = nodala;
	}

	public Nodala getNodala() {
		return nodala;
	}

	public void setPasutijumi(java.util.Set<Pasutijums> pasutijumi) {
		this.pasutijumi = pasutijumi; 
	}

	public java.util.Set<Pasutijums> getPasutijumi() {
		return pasutijumi;
	}

	public void setVaditajs(NodalasVaditajs vaditajs) {
		this.vaditajs = vaditajs; 
	}

	public NodalasVaditajs getVaditajs() {
		return vaditajs;
	}

	public void parceltUzNodalu() {

	}

	public void atlaist() {

	}
}
