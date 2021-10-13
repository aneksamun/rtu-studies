public enum Kategorija {

	AKSESUARI(1),
	BIROJAPRECES(2),
	GALDAPIEDERUMI(3),
	RAKSTAMPIEDERUMI(4);

	private int value;

	Kategorija(int value) {
		this.value = value;
	}

	public int getValue() {
		return value;
	}
}
