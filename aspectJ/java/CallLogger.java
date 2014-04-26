package callgraph;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.util.Stack;
//import java.util.HashSet;
//import java.util.Set;
 
import org.aspectj.lang.Signature;

public class CallLogger {
	public static CallLogger INSTANCE = new CallLogger();
    private Stack<String> callStack = new Stack<String>();
//    private Set<String> callLog = new HashSet<String>();
    private Writer writer;
    public CallLogger() {
        try {
            writer = new BufferedWriter(new FileWriter("./calls.txt"));
            //writer.write("digraph{" + "\n");
        } catch (IOException e) {
            throw new RuntimeException("Cannot open 'calls.txt' for writing.", e);
        }
    }
 
    public void pushMethod(Signature s) {
        String type = s.getDeclaringType().getName();
        String method = type.substring(type.lastIndexOf('.') + 1) + "." + s.getName();
        callStack.push(method);
        String call = top(0) + " 1";
        write(call);
    }
    public void popMethod() {
        String call = top(0) + " 0";
    	callStack.pop();
        write(call);
    }
 
//    public void logCall() {
//        if(callStack.size() < 2)
//            return;
//        String call = "\"" + top(1) + "\" -> \"" + top(0) +"\"";
//        if(!callLog.contains(call)) {
//            write(call);
//            callLog.add(call);
//        }
//    }
    private String top(int i) {
        return callStack.get(callStack.size() - (i + 1));
    }
 
    private void write(String line) {
        try {
            writer.write(line + "\n");
            writer.flush();
        } catch(Exception e) {
            throw new RuntimeException(e);
        }
    }
}
