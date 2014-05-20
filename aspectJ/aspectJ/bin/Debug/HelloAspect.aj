public aspect HelloAspect {
	public pointcut allMethods(): execution(* * (..));
before (): allMethods(){
System.out.println("lalalalal...");
}
}
