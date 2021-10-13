public enum Nodala {

	ADMINISTRATIVA(1),
	TIRZNIECIBAS(2),
	RAZOSANAS(3),
	PARVALDIBAS(4);

	private int value;

	Nodala(int value) {
		this.value = value;
	}

	public int getValue() {
		return value;
	}
}
