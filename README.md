AspectJ
=======

##软件体系架构与设计模式大作业

###备忘日志
**Sat Apr 26 10:33:15 CST 2014**
GetCalls中的Run方法的返回值改为int型，0表示成功，-1表示异常，因此在返回-1的情况下需弹窗“读取配置文件失败”

###Pointcut参数表

    * string returnValue:public/private
    * string pointcutName:切点名
    * string pointcutKind:切点的种类 call/execusion....
    * string regex:正则表达式

###Advice参数表

    * string pointcutName:所选择切点名
    * string before/after
