   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5       aspectJ   aspectJ.codeWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      oMicrosoft_Windows_ThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     5      -   5          �Name$  Window��5       � Title$ 
codeWindow��5      $	��658��5      $	��496��6    � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency .  � WindowStyle$
 None=�6Z   ��6m   Z�  � 	Resources 5
         ButtonStyle3 �� 
TargetType �� Property �� Value	 �� 
TargetType
 � 	Resources  Key �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value �Name � Cursor A�Name J� Opacity ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value P� 
SourceName N� ExitActions �� BeginStoryboardName N� EnterActions ��Name  Storyboard1 �� 
TargetName  TextBoxBorder  �� EndPoint! � MappingMode" �� 
StartPoint# � Color$ � Offset  myScrollBarStyle% � RowDefinitions& ��Name  RepeatButtonStyle1' J� RenderTransformOrigin( F�Name) ]�Name* ]� Thumb+ n�Name  ThumbStyle1, ]� IncreaseRepeatButton ! SimpleScrollRepeatButtonStyle- ]� DecreaseRepeatButton  downRepeatButtonStyle. �� ScaleX/ :� RoutedEvent0 :� 
SourceName 	 
IncreaseOn 
 
decreaseOn  ScrollViewerStyle21 �� BasedOn2 � ColumnDefinitions3 �� CanContentScroll4 ��Name,5 �� %ComputedHorizontalScrollBarVisibility  SimpleScrollBar6 �� Orientation7 �� ViewportWidth8 �� ViewportSize9 � Minimum: �� ScrollableWidth; � Maximum< � Value= �� Mode> �� RelativeSource*? �� #ComputedVerticalScrollBarVisibility@ �� ViewportHeightA �� ScrollableHeight,   &Microsoft.Windows.Themes.ListBoxChromeB  NameC   BorderThicknessD   BorderBrushE ��NameF �� Triggers  RichTextBoxStyle1G �� 	ResourcesH �� ResourceKey  elementButtonStyle  SimpleButtonFocusVisual  NormalBrush  NormalBorderBrushI ��NameJ �� Padding��%|  &	        7  &	 �    &	 �    7 	 7 
 &	 H    '�� �    7  '�� �    &	 �    7��0�� 5�      "H ��6   1&	 g    �� 5      " ��6   .�5      ��  � �� 5      �� 5      "	 ��6   
 5      ���� 5   	   Storyboard1 .��5   
   �� $* $(Shape.Fill).(SolidColorBrush.Color)�6'   $ ellipse��6h   .g�5        $ 0��6   $ 	#FF878787��6+     5      $ 0:0:0.3��6   $ 	#FF878787��61   5      U� 5   
   $ (UIElement.Opacity)�6(   $ ellipse��6X   .\�5        $ 0��6    $ 0Q�6,     5      $ 0:0:0.3��6    $ 1Q�62   5      5   
   5   	   .R�5      � $
 grid��6   $ Arrow��6   .+�5   	   A� $ ellipse��6   
���   �$ 0Q�6/   $ Arrow��6;   �� 5   	   $ contentPresenter��6   #��z��64   ��. # z 6�   $��Stretch=�6�   $��x��6�   $��0,-5.01,0,0q�6�   $ Arrow��6  5   	    5      P� 5    	    �@J�	IsFocused . 6&   P� 5!   	    �@��IsDefaulted . 6(   P� 5"   	   $
 grid��65    �@J�IsMouseOver .  5#   
   �� 5$      $! Storyboard1_BeginStoryboard��6    5&   
   �� 5'      $! Storyboard1_BeginStoryboard��6   8��  6@   . �5)   
   �� $ ellipse��6#    �@�Cursor$ Arrow��68   5*   
   P� 5+   	    � �� . 6&   P� 5,   	    � {� .  6&   5.      50      51      �� 52      $
  0,20&�6.   $! Absolute=�6>   $	" 0,0&�6U   .��53      � $# #ABADB3��6   $
$ 0.05Q�6"   � 54      $# #E2E3EA��6   $
$ 0.07Q�6"   � 55      $# #E3E9EF��6   $$ 1Q�6"   56      �� 57      " ��6#   .�58      ��  �@��IsFlicksEnabled .  6.   �� 59       � ��# � ��6"   �� 5:       � �� 5;      �� 5<      "	 ��6   
 5=      ���� 5>   	   
decreaseOn .��5?   
   �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6'   $ DecreaseRepeat��6t   .g�5@        $ 0��6   $ 	#FF878787��6+     5A      $ 0:0:0.3��6   $ White��61   5B      5C   
   �� 5D   	   
IncreaseOn .��5E   
   �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6'   $ IncreaseRepeat��6t   .g�5F        $ 0��6   $ 	#FF878787��6+     5G      $ 0:0:0.3��6   $ White��61   5H      5I   
   5J   	   .R�5K      � $ GridRoot��6   #��� r�6   % 5L   	   �� 5M   
   $��18��6   �� 5N   
   $��0.00001* �6   �� 5O   
   $��18��6   .+�5R   	   �� $& DecreaseRepeat��6   #���  6.   $��ScrollBar.LineUpCommand��6[   ���	#FF878787$��Verdana)�6�   $��9.333(�6�   $��-4.75,0q�6�   $' 0.5,0.5&�6�   z�5S   
   V� 5T      .~�5U      �� �� 5V      �� 5W      T� 5X      5Y      .��5[   
   � .+�5\      F� $( DecreaseArrow��6   #��z��6'   $��1��6M   "����     	= � z  	= � 	=     	6a   5]      5^   
   ]� 5a   	   $) 
PART_Track��6   $��1��6   $��Vertical=�60   ��. * 5b   
   n� 5c      $+ thumb��6   #���  6    , 5e   
   �� 5f      $& PageUp��6   #���  6(   $��ScrollBar.PageDownCommand��6`   $y�	Collapsed=�6�   - 5h   
   �� 5i      $& PageDown��6   #���  6*   $��ScrollBar.PageUpCommand��6b   $y�	Collapsed=�6�   5k   
   �� 5m   	   $& IncreaseRepeat��6#   $��2��6   #���  6;   $��ScrollBar.LineDownCommand��6k   ���	#FF878787$��9.333(�6�   $��Verdana)�6�   $��-4.75,0q�6�   $' 0.5,0.5&�6�   z�5n   
   V� 5o      .~�5p      �� $. 1Q�6   �� 5q      �� 5r      T� 5s      5t      .��5v   
   � .+�5w      F� $( IncreaseArrow��6   #��z��6'   $��1��6M   "����        � 	=  	= � z     	6a   5x      5y   
   5z   	    5~      :� 5   	   $/ Mouse.MouseEnter��6   $0 IncreaseRepeat��65   .[�5�   
   �� $  IncreaseOn_BeginStoryboard��6   8��  6>   5�   
   :� 5�   	   $/ Mouse.MouseLeave��6   $0 IncreaseRepeat��65   .[�5�   
   �� $  IncreaseOn_BeginStoryboard��6   5�   
   :� 5�   	   $/ Mouse.MouseEnter��6   $0 DecreaseRepeat��65   .[�5�   
   �� $  decreaseOn_BeginStoryboard��6   8�� 6>   5�   
   :� 5�   	   $/ Mouse.MouseLeave��6   $0 DecreaseRepeat��65   .[�5�   
   �� $  decreaseOn_BeginStoryboard��6   5�   
   5�      5�      5�      �� 5�      " ��6%   1 6H   Z� .�5�      ��  � �� 5�      �� 5�      "	 ��6   .R�5�      � 2 5�   	   �� 5�   
   $��* �6   �� 5�   
   $
��Auto �6   % 5�   	   �� 5�   
   $��* �6   �� 5�   
   $
��Auto �6   .+�5�   	   �� $��0��6    $��0��60   $��0,0,4,0q�6=   #��z��6N   #��z��6r   #3 z��6�   �� 5�   	   $4 PART_HorizontalScrollBar��6u   #y�z5 6   $��0��6X   $��1��6h   #���  6�   $6 
Horizontal=�6�   #8 z7 6;  $9 0Q�6j  #; z: 6v  < 6�   �� *HorizontalOffset+$= OneWay=�> �� *TemplatedParent+6v  �� 5�   	   $4 PART_VerticalScrollBar��6s   #y�z? 6   $��1��6V   $��0��6f   #���  6�   $6 Vertical=�6�   #8 z@ 64  $9 0Q�6d  #; zA 6p  < 6�   �� *VerticalOffset+$= OneWay=�> �� *TemplatedParent+6p  5�   	   5�      5�      5�      �� 5�      " ��6:   1 6'   Z� .�5�      ��  � ��# � ��6"   �� 5�       � ��# � ��6"   �� 5�       � ��8   6#   �� 5�       � ��$ 1q�6'   �� 5�       � ��$ 1q�6   �� 5�       �@J�	AllowDrop . 6!   �� 5�       �@�FocusVisualStyle 6(   Z� �� 5�       �@��PanningMode$ VerticalFirst=�60   �� 5�       �@��IsFlicksEnabled .  6.   �� 5�       � �� 5�      �� 5�      "	 ��6   
 5�      ���� 5�   	   	OnLoaded1 6   5�   	   .R�5�        $B Bd��6/   #C z��6;    . D 6�   Z� ._�5�   	   �� $E PART_ContentHost��6   # z 60   #���  6l   5�   	    5�      P� 5�   	    � {� .  . �5�   
   �� $ Bd��6'   # � ��67    �@ 
Background�� 5�   
   # � ��6'    � ��5�   
   5�      5�      5�      �� 5�      " ��6%   .�5�      ��  � ��
 ��  �6"   �� 5�       �@��TextDecorations$ 	Underline{�6'   F 5�      P� 5�       �@��IsMouseOver . . �5�      ��  � ��
 �  ��6$   5�      P� 5�       �@��	IsEnabled .  . �5�      ��  � ��# � ��6$   5�      P� 5�       �@��	IsEnabled . . �5�      ��  �@�Cursor$
 Hand��6    5�      5�      �� 5�      " ��6$   G 5�      ���� 5�      '/�       " /�6*   .�5�      ��  �@�OverridesDefaultStyle . 6/   5�      �� 5�      '��       81   " ��6U   F 5�      P� 5�       �@��IsMouseOver . . �5�   	   ��  � ��
 ��  �6&   5�   	   P� 5�       �@��	IsEnabled .  . �5�   	   ��  � ��# � ��6&   5�   	   5�      5�      .�5�      ��  � ��$ 10��6    1 5�      2 5�      �� 5�      " ��6%   1 6B   Z� .�5�      ��  �@�FocusVisualStyle# �  6(   �� 5�       � ��# �  6"   �� 5�       � ��# �  6#   �� 5�       � �� 5�      �� 5�      "	 ��6   .R�5�      � $
 Grid��6   .+�5�   	   �� $I Border��6   #��z��6    #J z��6T   �� 5�   	   #��z��6   #��z��6]   #��z��6�   ��. 6�   5�   	   5�      5      5     5     .��5     � -   5        $ 
LayoutRoot��5     .+�5     �� ���	#FF181818$��8q�6   K �� RadiusY$K 6��6*   L �� RadiusX$L 6��66   $ 0.945Q�6B   �� 5     -   5        M ��Name$M richTextBox��5     $��8,42.157,8,39.665q�6%   "N �� VerticalScrollBarVisibility$
N Auto=�6m     RichTextBoxStyle2#���  6�   ���	#FFE9E9E9O �� 
CaretBrushO �	#FFE9E9E9��6@   Z� ��6V   Z� . �5     /� .T�5     J� .*�6   �� P � Language$P zh-cn�6   $� int myArray[];��6&   6@   J� 5	     .*�6   �� $P zh-cn�6   $� myArray=new int[10];��6&   6F   J� 5
     .*�6   �� $P zh-cn�6   $,�& System.out.println("Index\t\tValue");��6&   6a   J� 5     .*�6   �� $P zh-cn�6   $)�# for(int i=0; i<myArray.length;i++)��6&   6W   J� 5     .*�6   �� $P zh-cn�6   $0�* 	System.out.println(i+"\t\t"+myArray[i]);��6&   6i   J� 5     .*�6   �� $P zh-cn�6   $� myArray[10]=100; ��6&   6C   J� 5     .*�6   �� $P zh-cn�6   $� int myArray[];��6&   6@   J� 5     .*�6   �� $P zh-cn�6   $� myArray=new int[10];��6&   6F   J� 5     .*�6   �� $P zh-cn�6   $,�& System.out.println("Index\t\tValue");��6&   6a   J� 5     .*�6   �� $P zh-cn�6   $)�# for(int i=0; i<myArray.length;i++)��6&   6W   J� 5     .*�6   �� $P zh-cn�6   $0�* 	System.out.println(i+"\t\t"+myArray[i]);��6&   6i   J� 5     .*�6   �� $P zh-cn�6   $� myArray[10]=100; ��6&   6C   J� 5     .*�6   �� $P zh-cn�6   $� int myArray[];��6&   6@   J� 5     .*�6   �� $P zh-cn�6   $� myArray=new int[10];��6&   6F   J� 5     .*�6   �� $P zh-cn�6   $,�& System.out.println("Index\t\tValue");��6&   6a   J� 5     .*�6   �� $P zh-cn�6   $)�# for(int i=0; i<myArray.length;i++)��6&   6W   J� 5     .*�6   �� $P zh-cn�6   $0�* 	System.out.println(i+"\t\t"+myArray[i]);��6&   6i   J� 5     .*�6   �� $P zh-cn�6   $� myArray[10]=100; ��6&   6C   5     5     �� 5     -   5        Q ��Name$Q acceptButton��5     $��确定��6!   $
��Left=�6.   $��22.665��6I   $��162.667,0,0,13q�6Y     TextButtonStyle#���  6q   $��Bottom=�6�   $��79.333��6�   ���	#FF7070706�   �� 5     -   5        $Q cancelButton��5     $��取消��6!   $��Right=�6.   $��22.665��6J   $��
0,0,169,13q�6Z   #���  6n   $��Bottom=�6�   $��79.333��6�   6�   �� 5     $��切面代码插入��6
   $
��Left=�6   $��25.657��66   $��
8,12.5,0,0q�6F   $	��Top=�6Z   $��87��6r   
�������6}   5     5      