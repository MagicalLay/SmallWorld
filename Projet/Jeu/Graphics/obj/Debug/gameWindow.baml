   M S B A M L   `   `   `  ����C  ?Graphics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:GraphicsGraphics  5   	    
SmallWorld-%clr-namespace:Jeu;assembly=SmallWorldJeu 5   	       Graphics.gameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   (localclr-namespace:Graphics     5   	   4PM%clr-namespace:Jeu;assembly=SmallWorld     5   	   -   5          �Name$  WindowInGame��5   	    � Title$ 
gameWindow��5   	    � WindowStartupLocation$ Manual=�5   U    � WindowStyle$
 None=�6t    � 
ResizeMode$ NoResize=�6�    � WindowState$ 	Maximized=�6�   $
��1457��6�   $	��920��6�   .��5	      (� -   5         (�Name$
 main��5	      .��5
   
   � -   5         �Name$ mainGrid��5
       � 	Resources 5      &    Graphics.BoolVisibilityConverter   BoolVisibilityConverter��%   &	          5      60   5      	 � RowDefinitions	 5      �� 5      $
��70px �6    �� 5      $��750px �6    �� 5      $��100px �6    
 � ColumnDefinitions
 5      �� 5      $��400px �6#   �� 5      $��900px �6#   �� 5      $��400px �6#   .+�5      � -   5        $ VictoryPointsGrid��5      $��1��6.   $��2��6;   $��0��6L   .+�5      �� $	��400��6   $
��Left=�6(   $	��217��6C   $	��Top=�6P   5       �� 5!      -   5         ��Name$ lblP1��5!      $��Player 1��6'   $��25(�6:   ���	#FF910000$
��Left=�6_   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6z   $
��Bold"�6�   $��	95,41,0,0q�6�   $	��Top=�6�   �� 5"      -   5        $ lblVictoryPointsP1��5"      $��Victory Points :��64   $��20(�6O   ���	#FF910000$
��Left=�6t   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $��95,136,0,569q�6�   $
��Bold"�6�   �� 5#      -   5        $ 
lblTribeP1��5#      $��Tribe :��6,   $��25(�6>   ���	#FF910000$
��Left=�6c   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6~   $��95,86,0,619q�6�   $
��Bold"�6�   �� 5$      $	��217��6   $	��Top=�6)   $��	0,222,0,0q�6A   $	��400��6T   $
��Left=�6`   5(      �� 5)      -   5        $ lblP2��5)      $��Player 2��6'   $��25(�6:   ���	#FF910000$
��Left=�6_   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6z   $
��Bold"�6�   $��
95,277,0,0q�6�   $	��Top=�6�   �� 5*      -	   5        $ 
lblTribeP2��5*      $��Tribe :��6,   $��25(�6>   ���	#FF910000$
��Left=�6c   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6~   $��95,322,0,387q�6�   $
��Bold"�6�   �� 5+      -
   5        $ lblVictoryPointsP2��5+      $��Victory Points :��64   $��20(�6O   ���	#FF910000$��
95,368,0,0q�6t   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $��71��6�   $	��Top=�6�   $
��Bold"�6�   $
��Left=�6�   $	��295��6  5,      �� 5.      $��1��6   $��2��6(    J� IsHitTestVisible . $��Hidden=�6P   $��Visible=�6�   .��5/      �� -   5         ��Name$ listUnitGrid��5/       �� CanHorizontallyScroll .  .  �� CanVerticallyScroll . $��0,0,10,0q�6�   50      � 52      -   5        $ 	bgmapGrid��52      $��1��6&   $��875px��63   $��
10,5,15,95q�6A   $��1��6U   $��2��6e   
 53      �� 54      $��9* �6'   �� 55      $
��166* �6'   ��57      �� 58       �� Color$ Black��6&    �� Opacity$	 0.7Q�64   .+�5:      � -   5        $ mapGrid��5:      $��Center=�6(   $��1��6E   $��392.664,375,437,375q�6U   5;      � 5=      $��0��6   $��1��6    .+�5>      �� -   5        $ lblYourTurn��5>      $��It's your turn :��6-   $
��Left=�6H   $	��Top=�6c   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6{   $��30(�6�   ���	#FF910000$��	10,10,0,0q�6�   $
��Bold"�6�   �� 5?      -   5        $ lblCurrentPlayer��5?      $��Player1��62   $
��Left=�6D   $��
287,10,0,0q�6_   $	��Top=�6s   $��48��6�   $	��458��6�   $��30(�6�   ���	#FF910000$4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $
��Bold"�6  �� 5@      -   5         ��Name$ 
btnEndTurn��5@      $��End turn��6-   $��671,10,69,20q�6@   $	��160��6V   $��25(�6{   $��Center=�6�   ��5A      �� 5B      $ White��6*   $	 0.7Q�68   5D      5E      �� 5G      -   5        $ lblRemainingTurns��5G      $��Number of turns left��6/   $
��Left=�6N   $��	37,14,0,0q�6i   $	��Top=�6|   ���	#FF910000$��25(�6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $
��Bold"�6�   $��2��6  � 5I      -   5        $ 	pauseMenu��5I      $��3��6&   $��3��67   .+�5J      �� -   5         ��Name$ MenuRectangle��5J       K� ZIndex$ 4��63   
���   �
���   �$��0,0,0,0q�6`   {�.   J� Opacity$
 0.95Q�6�   $
��1700��6�   $	��920��6�   $��Center=�6�   $��Center=�6�   $y�	Collapsed=�6�   �� 5K      -   5        $ btnContinue��5K      $ 5��6.   $��Continue��6?   $��Center=�6l   $��	0,259,0,0q�6�   $	��Top=�6�   $	��171��6�   $��25(�6�   
�������$��60��6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6*  ��5L      �� 5M      $ Black��6*   $	 0.7Q�68   5O      �� 5P      -   5        $ btnSaveGame��5P      $ 5��6.   $��	Save Game��6?   $��Center=�6S   $��	0,410,0,0q�6p   $	��Top=�6�   $	��171��6�   $��25(�6�   
�������$��60��6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6*  ��5Q      �� 5R      $ Black��6*   $	 0.7Q�68   5T      �� 5U      -   5        $ btnQuit��5U      $ 5��6*   $��	Quit Game��6;   $��Center=�6O   $��	0,553,0,0q�6l   $	��Top=�6�   $	��171��6�   $��25(�6�   
�������$��60��6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6"  ��5V      �� 5W      $ Black��6*   $	 0.7Q�68   5Y      �� 5Z      -   5        $ lblGamePaused��5Z      $��Game paused��6/   $ 5��6E   $��
0,94,0,756q�6V   $��Center=�6j   
�������$
��Bold"�6�   $��24(�6�   $��50��6�   $	��192��6�   $��Center=�6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6)  5\      � 5^      $��3��6   $��3��6'   .+�5_      �� -   5        $ 
lblVictory��5_      $��Player has won !��6,   $��Center=�6G   $ 5��6k   
�������$
��Bold"�6�   $��72(�6�   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6�   $	��134��6  $��	0,200,0,0q�6  $
��1463��6"  $	��Top=�6/  �� 5`      -   5        $ btnBack��5`      $ 5��6*   $��	Quit Game��6;   $	��171��6O   $��25(�6[   
�������$��60��6|   $4��./WpfSmallWorld;component/Resources/#Trajan Pro)�6�   $y�	Collapsed=�6�   $��0q�6�   $��Center=�6�   ��5a      �� 5b      $ Black��6*   $	 0.7Q�68   5d      5e      5f      5h      5i      