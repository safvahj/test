   M S B A M L   `   `   `  ����K  GWPFindustrial411, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WPFindustrial411WPFindustrial411  5   	   !    WPFindustrial411.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:WPFindustrial411     5   	   -   5        $��Microsoft YaHei)�5   	   $��
ExtraLight"�6&     � Title$!  Ykx节能控制管理系统��5	   	   $	��750��6   $
��1300��6*    � WindowStyle$
 None=�5
   	    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�66    � WindowStartupLocation$ CenterScreen=�6U    � 	Resources 5       �� MergedDictionaries �� Source �� 
TargetType   Key	 �� Property
 �� Value �� 
TargetType �� CornerRadius � ColumnDefinitions
 � Tag �� Triggers P� Property P� Value�� 5   
    5      �� 5      $% Assets/Styles/ButtonStyles.xaml?�6%   �� 5      �� 5      " 	�6   NavTabButtonStyle  .�5      �� 	 � ��$
 15(�65   �� 5      	 � ��
 �#DDD67   �� 5      	 � ��$

 10,5q�64   �� 5      	 � ��$	
 5,0q�63   �� 5      	 � ��

 ���� 67   �� 5      	 � ��
 64   �� *TabChangedCommand+�� 5      	 � ��
 5      �� 5   "   " 	�62   .R�5   &   �� #��z��6-   $ 5,5,0,0��6W   ._�5   *   �  5   .   �� 5   2   $
��auto �6C   �� 5   2   .+�5!   .   �� #��z 68   $��Assets/Fonts/#iconfont)�6U   $��14(�5"   ,   $��Center=�6:   $��Center=�6U   $��10,0,0,0q�6r   �� 5#   .   $��1��6?   #��z��6O   #��z��5$   3   #��z��5%   3   5&   +   5'   '   5(   #   5*       5+      P� 5,       �@d�	IsChecked$
 TrueY�6;   . �5-   "   �� 	 � ��

 �����6?   �� 5.   "   	 � ��
 �#FF68006?   5/      51      52      %
   '	�       54      .��57      � ��58   
   
� 59       
� Center$ 0.5,0.7&�6"    
� GradientOrigin$ 0.5,0.7&�63    
� RadiusY$	 0.8Q�6L    
� RadiusX$	 0.8Q�6Z   .��5:      �  � Color$ 	#FFA4B3D3��6    � Offset$ 0.596Q�61   � 5;      $ 	#FF302C5D��6   $ 0.952Q�61   � 5<      $ 	#FF96AAD4��6   $ 0.306Q�61   5=       � RowDefinitions 5?   
   �� 5@      $	��100 �6   �� 5A      .+�5D   
   � .+�5E      �� $��55��6   $��50��6    $��	10,0,20,0q�6,   $
��Left=�6?   ��5F      �� 5G       �� ImageSource$ Assets/Images/Logo.jpg��6!   5I      �� 5J      $��Center=�6   .+�5K      �� $!��Ykx节能管理控制系统��6   
�������$��25(�6B   $��85,0,0,0q�6P   �� 5L      $��45��6   
������ ���#FF6800$��0,0,0,1q�6T   $
��10,0q�5M      ._�5N      ��  �� Orientation$ 
Horizontal=�6!   $��Bottom=�6:   $��70,0,0,0q�6U   .+�5O      	� $��系统监控��6&   $	 ��65     NavTabButtonStyle#��[ 6D    d� 	IsChecked$
 TrueY�6o   $>��8WPFindustrial411.exe|WPFindustrial411.View.SystemMonitor��5P   &   	� 5Q      $��实时曲线��6&   $	 ��65   #��[ 6D   	� 5R      $��历史曲线��6&   $	 ��65   #��[ 6D   	� 5S      $��控制策略��6&   $	 ��65   #��[ 6D   	� 5T      $��系统操作��6&   $	 ��65   #��[ 6D   	� 5U      $��报警管理��6&   $	 ��65   #��[ 6D   	� 5V      $��报表管理��6&   $	 ��65   #��[ 6D   5W      5X      5Y      �� 5\      $ 
Horizontal=�6   $	��Top=�62   $��Right=�6J   .+�5]      �� $	����6     IconButtonStyle#��[ 6,   $��14(�6U   �� 5^      $	����6   #��[ 6,   $��10(�6U   �� 5_      -   5        $	����5_      #��[ 6,   6U   5`      �� 5a      $ 
Horizontal=�6   $��Bottom=�62   $��Right=�6M   $��20,15q�5b      .+�5c      �� $��Jovan.Ye��6   
�������$��Center=�6?   $
��10,0q�6Z   �� 5d      $��30��6   $��30��6$   $ 15��60   $��1q�6B   
������� J� Effect 5e      3  -System.Windows.Media.Effects.DropShadowEffect  5f         
BlurRadius$ 5Q�6+      ShadowDepth$ 0Q�6:      	Direction$ 0Q�6J       Opacity$	  0.4Q�6X   !   Color$! White��6f   ��5h      �� 5i      $ Assets/Images/Avatar.png��6%   5k      5l      5m      �� 5o   
   $��1��6   ��6&   �� *MainContent+5p      5q      