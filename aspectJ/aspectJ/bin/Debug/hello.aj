public aspect hello() {
	public pointcut hello(): Call(*main)
before : hello(){
System.out.println("Hello world!");
}
}
