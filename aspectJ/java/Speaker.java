
public class Speaker {
	public void speak()
    {
        System.out.println("[Speaker] bla bla ...");
    }
	public void sleep(){
		System.out.println("[Speaker] zzzzzzzzz...");
		eat();
	}
	public void eat(){
		System.out.println("[Speaker] ba ji ba ji...");
	}
    public static void main(String[] args)
    {
        Speaker speaker = new Speaker();
        speaker.speak();
        speaker.sleep();
        speaker.eat();
        Sleeper.sleep();
    }

}
