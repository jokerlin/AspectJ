   M S B A M L   `   `   `  ����  aspectJ    aspectJ.addAdvice   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   -   5          �Name$  Window��5       � Title$ 	addAdvice��5      $	��446��5      $	��334��6    � AllowsTransparency .  � WindowStyle$
 None=�65    � WindowStartupLocation$ CenterOwner=�6^   ��6H   Z� .��5
      � -   5         �Name$ 
LayoutRoot��5
      .+�5      �� ���	#FF181818$��8q�6    �� RadiusY$ 6��6*    �� RadiusX$ 6��66    J� Opacity$ 0.945Q�6B   �� 5      $��添加 advice��6
   $
��Left=�6   $��25.657��69   $��8,8,0,0q�6I   $	��Top=�6Z   $��87��6r   
�������6}   �� 5      -   5        	 ��Name$	 richTextBox��5      $��8,81,8,44.665q�6%   "
 �� VerticalScrollBarVisibility$

 Auto=�6i      RichTextBoxStyle2#���   6�   ���	#FFE9E9E9 �� 
CaretBrush �	#FFE9E9E9$y�Hidden=�6�   ��6<   Z� ��6R   Z� . �5      /� 5      �� 5      -   5         ��Name$ pointCutComboBox��5      $
��27.5��6'     ComboBoxStyle1#���  65   $	��Top=�6^   ���	#FFCDCDCD$��76.013,38.322,171.654,0q�6�   �� 5   
   $��选择切点��6   $��28.165��6   $��16.013,37.657,0,0q�6/   $	��Top=�6J   
�������$
��Left=�6u   $��56��6�   $��10.667(�6�   �� 5      -   5        $ kindComboBox��5      $
��27.5��6#   #���  61   $	��Top=�6Z   ���	#FFCDCDCD$��0,38.987,18.987,0q�6�   $��Right=�6�   $��76.333��6�   .@�5      �� $��before��6     ComboBoxItemStyle1#���  6#   �� 5      $��after��6   #���  6"   5      �� 5      $��选择位置��6
   $��28.165��6   $��0,38.322,100.994,0q�6)   $	��Top=�6E   
�������$��10.667(�6p   $��Right=�6�   $��56��6�   �� 5      -   5         ��Name$ acceptButton��5      $��确定��6!   $��22.665��6.   $��109.68,0,0,13q�6>     TextButtonStyle#���  6U   $��Bottom=�6   ���	#FF707070$
��Left=�6�   $��79.333��6�   6�   �� 5      -   5        $ cancelButton��5      $��取消��6!   $��Right=�6.   $��22.665��6J   $��0,0,100.994,13q�6Z   #���  6r   $��Bottom=�6�   $��79.333��6�   6�   �� 5      -   5         ��Name$ textBox��5       �� AcceptsReturn . $

 Auto=�63   $��16.013,103,10.154,44.665q�6V     TextBoxStyle1#���  6x    �� TextWrapping$
 Wrap=�6�   ���	#FF282828���	#FF595959���	#FFBEBEBE6�   c� 5      $
��Left=�6   $��365,70.487,0,0q�6'   $	��Top=�6?   $��31��6W   $��81��6c     ToolBarStyle1#���  6�   ��6n   Z� .@�5      �� -	   5        $ 
undoButton��5      $
��Undo��6    $�� ��60   $
��Left=�6;   $��25��6V     undoButtonStyle#���  6b   $	��Top=�6�   $��27��6�   |�.  ��6�   Z� ��5      �� 5       �� ImageSource$ images/undoButton.png��6   5      �� 5       -
   5        $
 redo��5       $
��Redo��6   $�� ��6)   $
��Left=�64   $��25��6O     redoButtonStyle#���  6[   $	��Top=�6�   $��27��6�   |�.   J� RenderTransformOrigin$ 
2.53,0.276&�6�   ��6�   Z� ��5!      �� 5"      $" images/redoButtonDisable.png��6   5$      5%      5&      5'      