   M S B A M L   `   `   `  ����C  ?Graphics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GraphicsGraphics  5       System.WindowsG4clr-namespace:System.Windows;assembly=System.WindowsSystem.Windows 5          Graphics.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      (localclr-namespace:Graphics     5      Dvsm4clr-namespace:System.Windows;assembly=System.Windows     5        �� 	Resources  5         backgroundImage �� CreateOptions �� CacheOption �� 	UriSource  	FieldCell  MountainCell  
DesertCell  
ForestCell  	SpaceCell 	 Heart  Boot 	 Sword 
	 Shield 
 	DwarfIcon  ElfIcon  OrcIcon&    Graphics.BoolVisibilityConverter  BoolVisibilityConverter#   Graphics.EnumBooleanConverter  EnumToBooleanConverter  WindowColor  ContentAreaColorLight  ContentAreaColorDark  DisabledControlLightColor  DisabledControlDarkColor  DisabledForegroundColor  SelectedBackgroundColor  SelectedUnfocusedColor  ControlLightColor  ControlMediumColor  ControlDarkColor  ControlMouseOverColor  ControlPressedColor  
GlyphColor  GlyphMouseOver  BorderLightColor  BorderMediumColor   BorderDarkColor ! PressedBorderLightColor " PressedBorderDarkColor # DisabledBorderLightColor $ DisabledBorderDarkColor % DefaultBorderBrushDarkColor & HeaderTopColor "' DatagridCurrentCellBorderColor ( SliderTrackDarkColor ) NavButtonFrameColor * MenuPopupBrush �� EndPoint �� 
StartPoint � Color � Offset $+  ProgressBarIndicatorAnimatedFill , ScrollBarLineButton �� 
TargetType	 �� Property
 �� Value �� 
TargetType ��Name'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value F�Name �� RelativeSource �� Color - ScrollBarPageButton . ScrollBarThumb �� Opacity / VerticalScrollBar � RowDefinitions �� CornerRadius ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton 0 HorizontalScrollBar � ColumnDefinitions �� Triggers  P� Property! P� Value" g� Duration# R� KeyTime$ R� Value��%  &	        &	 a     &	 �     &	     &	 y    &	 �    &	     &	 l    &	 �    &		     &	
 z    &	 �    &	 .    &	 �    &	 �    &	 �    &	 �    &	 �    &	     &	 1    &	 R    &	 s    &	 �    &	 �    &	 �    &	 �    &	     &	 5    &	 V    &	 w    &	 �    &	 �    &	  �    &	!     &	" >    &	# _    &	$ �    &	% �    &	& �    &	' �    &	( �    &	)     &	* >    &	+ 	    &	, 1
    7  &	- �    &	. �    &	/ {    7 , 7 - 7 . 7 - 7 , &	0 p    7 , 7 - 7 . 7 - 7 , '�� �    7 0 7 / '� �    �� 5	   
   $ IgnoreImageCache=�6.   $ OnLoad=�6O   $ ./elements/background.jpg?�6d   �� 5
   
   $ IgnoreImageCache=�6(   $ OnLoad=�6I   $ ./textures/field.png?�6^   �� 5   
   $ IgnoreImageCache=�6+   $ OnLoad=�6L   $ ./textures/mountain.png?�6a   �� 5   
   $ IgnoreImageCache=�6)   $ OnLoad=�6J   $ ./textures/desert.png?�6_   �� 5   
   $ IgnoreImageCache=�6)   $ OnLoad=�6J   $ ./textures/forest.png?�6_   �� 5   
   $ IgnoreImageCache=�6(   $ OnLoad=�6I   �� 5   
   $ IgnoreImageCache=�6%   $ OnLoad=�6F   $ elements/coeur.png?�6[   �� 5   
   $ IgnoreImageCache=�6$   $ OnLoad=�6E   $ elements/boot.png?�6Z   �� 5   
   $ IgnoreImageCache=�6%   $ OnLoad=�6F   $ elements/sword.png?�6[   �� 5   
   $ IgnoreImageCache=�6&   $ OnLoad=�6G   $ elements/shield.png?�6\   �� 5   
   $ IgnoreImageCache=�6(   $ OnLoad=�6I   $ ./peoples/dwarf.png?�6^   �� 5   
   $ IgnoreImageCache=�6&   $ OnLoad=�6G   $ ./peoples/elf.png?�6\   �� 5   
   $ IgnoreImageCache=�6&   $ OnLoad=�6G   $ ./peoples/orc.png?�6\     5   
   6(     5   
   6%   ��5%   
   	#FFE8EDF9��6/   ��5&   
   	#FFC5CBF9��69   ��5'   
   	#FF7381F9��68   ��5)   
   	#FFE8EDF9��6=   ��5*   
   	#FFC5CBF9��6<   ��5+   
   	#FF888888��6;   ��5-   
   	#FFC5CBF9��6;   ��5.   
   	#FFDDDDDD��6:   ��50   
   	White��61   ��51   
   	#FF7381F9��66   ��52   
   	#FF211AA9��64   ��54   
   	#FF3843C4��69   ��55   
   	#FF211AA9��67   ��58   
   	#FF444444��6.   ��59   
   /+sc#1, 0.004391443, 0.002428215, 0.242281124��6T   ��5<   
   	#FFCCCCCC��64   ��5=   
   	#FF888888��65   ��5>   
   	#FF444444��63   ��5@   
   	#FF888888��6;   ��5A   
   	#FF444444��6:   ��5C   
   	#FFAAAAAA��6<   ��5D   
   	#FF888888��6;   ��5F   
   	Black��6;   ��5I   
   	#FFC5CBF9��62   ��5J   
   	Black��6>   ��5K   
   	#FFC5CBF9��68   ��5M   
   	#FF3843C4��67   �� 5O   
   $ 0.5,1&�5P      $ 0.5,0&�5Q      .��5R      � # �  6   $ 0Q�5S      � 5T      # �  6   $	 0.5Q�5U      � 5V      # �  6   $ 1Q�5W      5X      �� 5Z   
   $	 0,0&�5[      $	 1,0&�5\      ��5^      � � 5_      $ 	#000000FF��6#   $ 0Q�5`      � 5a      $ 	#600000FF��6#   $	 0.4Q�5b      � 5c      $ 	#600000FF��6#   $	 0.6Q�5d      � 5e      $ 	#000000FF��6#   $ 1Q�5f      5g      5i      �� 5p   
   " ��6,   .�5q      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5r      	 �@�OverridesDefaultStyle
 . 66   �� 5s      	 � |�
 .  6*   �� 5t      	 � ��
 5u      �� 5v      " ��6&   .R�5w      �� $ Border��6!   $��1q�5x      $��1q�5y      ��61   Z�  5�        5�   "   CommonStates��. 5�   &     
Normal��62     5�   &   	MouseOver��62     5�   &   Pressed��62     5�   &   Disabled��. 5�   *   �� .��5�   .   �� $ Arrow��6K   $* $(Shape.Fill).(SolidColorBrush.Color)�6i   .g�5�   2     $ 0��6F   8   6R   5�   /   5�   +   5�   '   5�   #   ._�5�      F� $ Arrow��6#   $��Center=�5�   !   $��Center=�5�   !   ��5�   !   �� *	Content+ �� *TemplatedParent+��5�   "   �� 5�   &   $
 Gray��66   5�      5�      5�      5�      5�      �� 5�   
   " ��6,   .�5�      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5�      	 �@�OverridesDefaultStyle
 . 66   �� 5�      	 � ��
 .  6*   �� 5�      	 � |�
 .  6*   �� 5�      	 � ��
 5�      �� 5�      " ��6&   .R�5�      �� 
������ 6!   5�      5�      5�      �� 5�   
   " n�6'   .�5�      �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5�      	 �@�OverridesDefaultStyle
 . 66   �� 5�      	 � ��
 .  6*   �� 5�      	 � |�
 .  6*   �� 5�      	 � ��
 5�      �� 5�      " n�6&   .R�5�      �� #��z��6!   $��1q�5�   !   ��5�      �� 5�   "   $ Black��62   $	 0.7Q�6@   5�      5�      5�      5�      �� 5�   
   " ��64   .R�5�      �  5�      �� 5�      $��18��6$   �� 5�      $��0.00001* �6$   �� 5�      $��18��6$   .+�5�      �� $��3��6   $ 2��5�      ��6&   Z� �� 5�      $��0��6   8��  $��18��5�      $��ScrollBar.LineUpCommand��5�      $��M 0 4 L 8 4 L 4 0 Z��5�      ]� 5�      $ 
PART_Track��6   $��1��5�      ��.  5�      �� 5�      8�� $��ScrollBar.PageUpCommand��6T    5�      n� 5�      8�� $��1,0,1,0q�6H   ��6Y   Z� ��6o   Z�  5�      �� 5�      8�� $��ScrollBar.PageDownCommand��6T   5�      �� 5�      $��3��6   8�� $��18��5�      $��ScrollBar.LineDownCommand��5�      $��M 0 0 L 4 4 L 8 0 Z��5�      5�      5�      �� 5�   
   " ��66   .R�5�      �  5�      �� 5�      $��18��6'   �� 5�      $��0.00001* �6'   �� 5�      $��18��6'   .+�5�      �� $��3��6   $ 2��6-   ���#F0F0F06>   �� 5�      $��0��6   8��  $��18��5�      $��ScrollBar.LineLeftCommand��5�      $��M 4 0 L 4 8 L 0 4 Z��5�      ]� 5�      $ 
PART_Track��6   $��1��5�      ��.   5�      �� 5�      8�� $��ScrollBar.PageLeftCommand��5�       5�      n� 5�      8�� $��0,1,0,1q�5�      ��5�      �� 5   "   $	 0,0&�66   $	 1,0&�5  "   ��5  *   � � 5  .   # �  6;   $	 0.0Q�5  !   � 5  .   # �   6;   $	 1.0Q�5  !   5  +   5
  #   ��5     �� 5  "   $	 0,0&�66   $	 0,1&�5  "   ��5  *   � � 5  .   # �  6;   $	 0.0Q�5  !   � 5  .   # �  6;   $	 1.0Q�5  !   5  +   5  #   5      5     �� 5     8�� $ ��ScrollBar.PageRightCommand��5      5"     �� 5#     $��3��6   8�� $��18��5%     $ ��ScrollBar.LineRightCommand��5&     $��M 0 0 L 4 4 L 0 8 Z��5'     5(     5)     �� 5+  
   " ��6+   .�5,     �� 	 �@J�SnapsToDevicePixels
 . 64   �� 5-     	 �@�OverridesDefaultStyle
 . 66    5.     P� 5/       �@��Orientation$! 
Horizontal=�61   . �50     �� 	 � ��$

 Auto��6.   �� 51     	 � ��$
 18��6/   �� 52     	 � ��8
   61   53     P� 54       �@��Orientation$! Vertical=�61   . �55     �� 	 � ��$
 18��6.   �� 56     	 � ��$

 Auto��6/   �� 57     	 � ��8
  61   58     5:     �� 5=  
   " �6-   .�5>     �� 	 � ��
 5?     �� 5@     " �6&   .R�5A     � $��10��6   $	��100��6.   #��z��6=    5B       5C  "   CommonStates��. 5D  &     Determinate��62     5E  &   Indeterminate��. 5F  *   �� .��5G  .   T� $" 00:00:00D�6L   $ PART_Indicator��5H  2   $ 
Background�5I  2   ..�5J  2   i� $# 00:00:00��6I   $ 5K  6   ��5L  :   Transparent��6W   5N  3   5O  /   5P  +   5Q  '   5R  #   .+�5T     �� $ 
PART_Track��6%   ��69   Z� �� 5U     $ PART_Indicator��6%   $
��Left=�5V  #   #��z��5W  #   $��0,-1,0,0q�5X  #   ��65   Z� 5Y     5Z     5\     �� 5]     	 � ��
 �	#FFC124246+   �� 5^     	 � ��
 �	#FF2397236+   5_     5a     5b     