
public aspect CallInterceptor {
	pointcut allInterestingMethods():
		!within(CallInterceptor) && !within(CallLogger)
			&& execution(* * (..));
	
	before():allInterestingMethods(){
		CallLogger.INSTANCE.pushMethod(thisJoinPointStaticPart.getSignature());
		//CallLogger.INSTANCE.logCall();
	}
	
	after():allInterestingMethods(){
		CallLogger.INSTANCE.popMethod();
	}
}
