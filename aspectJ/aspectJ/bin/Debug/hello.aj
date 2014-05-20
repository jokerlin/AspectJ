public aspect hello() {
	public pointcut hello(): Execution(*main)
before : hello(){
 System.out.println("Hello World!");
}
}
