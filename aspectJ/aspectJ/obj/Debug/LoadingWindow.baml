   M S B A M L   `   `   `  ����  aspectJ    aspectJ.LoadingWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   -   5          �Name$  Window��5       � Title$ LoadingWindow��5      $��982.253��5      $��729.955��6    � AllowsTransparency .  � WindowStyle$
 None=�6=    � WindowStartupLocation$ CenterScreen=�6f   ��6P   Z�  � 	Resources 5	         	OnLoaded1 �� TargetProperty �� 
TargetName g� RepeatBehavior9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value��%Y  &	        �� 5
      .��5      U� $ (UIElement.Opacity)�6#   $ ellipse��6S   $ Forever��6s   .\�5        $	 0��6   $
 0Q�6'     5      $	 0:0:0.3��6   $
 1Q�6-     5      $	 0:0:0.6��6   $
 1Q�6-     5      $	 0:0:0.9��6   $
 1Q�6-   5      U� 5      $ (UIElement.Opacity)�6#   $ ellipse2��6S   $ Forever��6t   .\�5        $	 0��6   $
 0Q�6'     5      $	 0:0:0.3��6   $
 0Q�6-     5      $	 0:0:0.6��6   $
 1Q�6-     5      $	 0:0:0.9��6   $
 1Q�6-   5      U� 5      $ (UIElement.Opacity)�6#   $ ellipse1��6S   $ Forever��6t   .\�5        $	 0��6   $
 0Q�6'     5      $	 0:0:0.3��6   $
 0Q�6-     5      $	 0:0:0.6��6   $
 0Q�6-     5      $	 0:0:0.9��6   $
 1Q�6-   5      5      5       � Triggers 5      :� 5        :� RoutedEvent$ FrameworkElement.Loaded��6   .��5#      � -   5         �Name$ 
LayoutRoot��5#      .+�5$      �� ���	#B13C3C3C �� RadiusY$	 4.5��5%       �� RadiusX$	 4.5��6#   $��8,22,7.172,15.625q�61   A� 5&      -   5         A�Name$ ellipse��5&      ���	#FF939393$��Right=�6.   $��0,363,411.253,360.955q�6J   $��6��6i    J� RenderTransformOrigin$ 1.147,-0.529&�6s   A� 5'      -   5        $ ellipse2��5'      ���	#FFC2C2C2$��Right=�6/   $��0,363,399.253,360.955q�6K   $��6��6j   $ 1.147,-0.529&�6t   A� 5(      -   5        $ ellipse1��5(      ���	#FFEBE9E9$��Right=�6/   $��0,363,387.253,360.955q�6K   $��6��6j   $ 1.147,-0.529&�6t   �� 5)      $
��Left=�6   $��359,320,0,344.955q�6)   $
��Wrap=�6D   $��44��6X   $��48(�6c   ���	#FFEBE9E9$��Segoe UI Light)�6�   �� 6�    � Language$ zh-cn�6�   $�L��6�   6�   �� 5*      $��388,320,375.253,344.955q�6   $
��Wrap=�6/   $��48(�6C   ���	#FF939393$��Segoe UI Light)�6h   �� 6�   $ zh-cn�6�   $�oading��6�   6�   5+      5,      