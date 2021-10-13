public class NodalasVaditajs extends Darbinieks {

	private java.util.Set<Darbinieks> darbinieki;

	public NodalasVaditajs() {}

	public NodalasVaditajs(java.lang.String vards, java.lang.String uzvards, Nodala nodala) {
		super(vards, uzvards, nodala);
	}

	public void setDarbinieki(java.util.Set<Darbinieks> darbinieki) {
		this.darbinieki = darbinieki; 
	}

	public java.util.Set<Darbinieks> getDarbinieki() {
		return darbinieki;
	}

	public void parceltUzNodalu() {

	}

	public void atlaist() {

	}

	public org.eclipse.emf.common.util.EList<Pasutijums> iegutAkceptetosPasutijumus() {
		throw new UnsupportedOperationException();
	}

	public org.eclipse.emf.common.util.EList<Pasutijums> iegutPasutijumusAkceptam() {
		throw new UnsupportedOperationException();
	}
}
