   M S B A M L   `   `   `  ����M  IAirlineReservation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AirlineReservationAirlineReservation  5   	   #    AirlineReservation.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AirlineReservation     5   	   -   5          �Name$  wnd_MainWindow��5   	    � Title$ Flight Reservation��5   	   $	��466��6$   $	��801��61   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��109* �6   �� 5      $	��91* �6   .+�5   
   �� -   5         ��Name$ 
lbl_Flight��5      $��1��6$   $��Choose Flight��64   $
��Left=�6L   $��	40,17,0,0q�6g   $	��Top=�6z   $��41��6�   $	��102��6�   $��14(�6�   �� 5   
   -   5         ��Name$ cbx_PassengerList��5      $��1��6.   $
��Left=�6>   $��
152,66,0,0q�6Y   $	��Top=�6m   $	��147��6�   $��22��6�   ${�False��6�   �� 5   
   -   5        $ lbl_test��5      $�� ��6"   $
��Left=�6-   $��
133,48,0,0q�6H   $	��Top=�6\   $��26��6t   $��10��6�   �� 5   
   -   5        $ 
cbx_Flight��5      $��1��6'   $
��Left=�67   $��
152,21,0,0q�6R   $	��Top=�6f   $	��144��6~   $��22��6�   �� 5   
   -   5         ��Name$ cnv_Flight1��5      $��	0,0,0,133q�6&   $y�	Collapsed=�69   .+�5      �� -   5        $ lbl_flightNum1��5      $	��102��6,    �� Left$	 195��6:   
 �� Top$ 10��6L   $
��Bold"�6\   $��18(�6n   �� 5      -   5        $ lbl_f1_1��5      $�� 1��6&   $ 19��63   $ 47��6D   $
��Bold"�6T   $��25(�6f   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5      -	   5        $ lbl_f1_2��5      $�� 2��6&   $ 63��63   $ 47��6D   $
��Bold"�6T   $��25(�6f   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5      -
   5        $ lbl_f1_3��5      $�� 3��6&   $	 107��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5      -   5        $ lbl_f1_4��5      $�� 4��6&   $	 151��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $��Center=�6�   6�   �� 5      -   5        $ lbl_f1_6��5      $�� 6��6&   $	 285��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5      -   5        $ lbl_f1_7��5      $�� 7��6&   $	 329��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5      -   5        $ lbl_f1_5��5      $�� 5��6&   $	 241��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5      -   5        $ lbl_f1_8��5      $�� 8��6&   $	 373��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5      -   5        $ 	lbl_f1_10��5      $��10��6'   $ 63��64   $	 113��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5      -   5        $ 	lbl_f1_11��5      $��11��6'   $	 107��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5      -   5        $ 
lbl_f1_1_9��5      $�� 9��6(   $ 19��65   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5      -   5        $ 	lbl_f1_12��5      $��12��6'   $	 151��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5       -   5        $ 	lbl_f1_14��5       $��14��6'   $	 285��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5!      -   5        $ 	lbl_f1_15��5!      $��15��6'   $	 329��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5"      -   5        $ 	lbl_f1_13��5"      $��13��6'   $	 241��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5#      -   5        $ 	lbl_f1_16��5#      $��16��6'   $	 373��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5$      -   5        $ 	lbl_f1_18��5$      $��18��6'   $ 63��64   $	 177��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5%      -   5        $ 	lbl_f1_19��5%      $��19��6'   $	 107��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5&      -   5        $ 	lbl_f1_17��5&      $��17��6'   $ 19��64   $	 177��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5'      -   5        $ 	lbl_f1_20��5'      $��20��6'   $	 151��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5(      -   5        $ 	lbl_f1_22��5(      $��22��6'   $	 285��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5)      -   5        $ 	lbl_f1_23��5)      $��23��6'   $	 329��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5*      -   5        $ 	lbl_f1_21��5*      $��21��6'   $	 241��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5+      -   5        $ 	lbl_f1_24��5+      $��24��6'   $	 373��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5,      -    5        $ 	lbl_f1_26��5,      $��26��6'   $ 63��64   $	 241��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5-      -!   5        $ 	lbl_f1_27��5-      $��27��6'   $	 107��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5.      -"   5        $ 	lbl_f1_25��5.      $��25��6'   $ 19��64   $	 241��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 5/      -#   5        $ 	lbl_f1_28��5/      $��28��6'   $	 151��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 50      -$   5        $ 	lbl_f1_30��50      $��30��6'   $	 285��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 51      -%   5        $ 	lbl_f1_31��51      $��31��6'   $	 329��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 52      -&   5        $ 	lbl_f1_29��52      $��29��6'   $	 241��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   �� 53      -'   5        $ 	lbl_f1_32��53      $��32��6'   $	 373��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $	��Top=�6�   6�   54      �� 55   
   -(   5        $ cnv_Flight2��55      $��	0,0,0,133q�6&   $y�	Collapsed=�69   .+�56      �� -)   5        $ lbl_flightNum2��56      $	��412��6,   $	 198��6:   $ 10��6L   $��18(�6\   $
��Bold"�6j   $
��Left=�6|   $��Center=�6�   �� 57      -*   5        $ lbl_f2_1��57      $�� 1��6&   $ 10��63   $ 47��6D   $
��Bold"�6T   $��25(�6f   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 58      -+   5        $ lbl_f2_2��58      $�� 2��6&   $ 58��63   $ 47��6D   $
��Bold"�6T   $��25(�6f   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 59      -,   5        $ lbl_f2_3��59      $�� 3��6&   $	 131��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5:      --   5        $ lbl_f2_4��5:      $�� 4��6&   $	 175��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5;      -.   5        $ lbl_f2_6��5;      $�� 6��6&   $	 266��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��38��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5<      -/   5        $ lbl_f2_7��5<      $�� 7��6&   $	 340��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5=      -0   5        $ lbl_f2_5��5=      $�� 5��6&   $	 222��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��38��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5>      -1   5        $ lbl_f2_8��5>      $�� 8��6&   $	 387��63   $ 47��6E   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5?      -2   5        $ 	lbl_f2_10��5?      $��10��6'   $ 58��64   $	 113��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5@      -3   5        $ 	lbl_f2_11��5@      $��11��6'   $	 131��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5A      -4   5        $ lbl_f2_9��5A      $�� 9��6&   $ 10��63   $	 113��6D   $
��Bold"�6U   $��25(�6g   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5B      -5   5        $ 	lbl_f2_12��5B      $��12��6'   $	 175��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5C      -6   5        $ 	lbl_f2_14��5C      $��14��6'   $	 266��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5D      -7   5        $ 	lbl_f2_15��5D      $��15��6'   $	 340��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5E      -8   5        $ 	lbl_f2_13��5E      $��13��6'   $	 222��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5F      -9   5        $ 	lbl_f2_16��5F      $��16��6'   $	 387��64   $	 113��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $��Center=�6�   $��Center=�6�   6�   �� 5G      -:   5        $ 	lbl_f2_18��5G      $��18��6'   $ 58��64   $	 177��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5H      -;   5        $ 	lbl_f2_19��5H      $��19��6'   $	 131��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��40��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5I      -<   5        $ 	lbl_f2_17��5I      $��17��6'   $ 10��64   $	 177��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5J      -=   5        $ 	lbl_f2_20��5J      $��20��6'   $	 175��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5K      ->   5        $ 	lbl_f2_22��5K      $��22��6'   $	 266��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5L      -?   5        $ 	lbl_f2_23��5L      $��23��6'   $	 340��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5M      -@   5        $ 	lbl_f2_21��5M      $��21��6'   $	 222��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5N      -A   5        $ 	lbl_f2_24��5N      $��24��6'   $	 387��64   $	 177��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5O      -B   5        $ 	lbl_f2_26��5O      $��26��6'   $ 58��64   $	 241��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5P      -C   5        $ 	lbl_f2_27��5P      $��27��6'   $	 131��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5Q      -D   5        $ 	lbl_f2_25��5Q      $��25��6'   $ 10��64   $	 241��6E   $
��Bold"�6V   $��25(�6h   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5R      -E   5        $ 	lbl_f2_28��5R      $��28��6'   $	 175��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5S      -F   5        $ 	lbl_f2_30��5S      $��30��6'   $	 266��64   $	 242��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $	��Top=�6�   6�   �� 5T      -G   5        $ 	lbl_f2_31��5T      $��31��6'   $	 340��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5U      -H   5        $ 	lbl_f2_29��5U      $��29��6'   $	 222��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5V      -I   5        $ 	lbl_f2_32��5V      $��32��6'   $	 387��64   $	 241��6F   $
��Bold"�6W   $��25(�6i   ���	#FF0027FF$��49��6�   $��39��6�   $
��Left=�6�   $��Center=�6�   6�   5W      �� 5X   
   -J   5        $ lbl_Passenger��5X      $��1��6'   $��Choose Passneger��67   $
��Left=�6R   $��	25,63,0,0q�6m   $	��Top=�6�   $��14(�6�   �� 5Y   
   -K   5         ��Name$ txt_SeatNumber��5Y      $��1��6*   $
��Left=�6:   $��152,110,0,0q�6U   	 �� TextWrapping$
	 Wrap=�6j   $	��Top=�6~   $	��144��6�   ${�False��6�   
 �� 
IsReadOnly$

 True��6�   $��23��6�   �� 5Z   
   -L   5        $ lbl_Seat��5Z      $��1��6"   $��Passenger's Seat��62   $
��Left=�6M   $��
35,110,0,0q�6h   $	��Top=�6|   $��14(�6�   �� 5[   
   -M   5         ��Name$ cmd_ChangeSeat��5[      $��1��6)   $��Change Seat��69   $
��Left=�6O   $��204,153,0,0q�6j   $	��Top=�6   $��35��6�   $	��113��6�   ${�False��6�   �� 5\   
   -N   5        $ cmd_DeletePassenger��5\      $��1��6.   $��Delete Passenger��6>   $
��Left=�6Y   $��204,208,0,0q�6t   $	��Top=�6�   $��44��6�   $	��113��6�   ${�False��6�   �� 5]   
   -O   5        $ cmd_AddPassenger��5]      $��1��6+   $��Add Passenger��6;   $
��Left=�6S   $��
75,210,0,0q�6n   $	��Top=�6�   $��42��6�   $	��105��6�   ${�False��6�   6�   �� 5^   
   -P   5         ��Name$ gbx_SeatGuide��5^      $��1��6*   $��	Color Key��6:   $��
10,269,0,0q�6M   .��5_      �� .+�5`      �� -Q   5        $ lbl_SeatTaken��5`      $��Seat is Taken��6/   $ 90��6G   $ 10��6X   $
��Left=�6h   $	��Top=�6�   $
��Bold"�6�   $��16(�6�   �� 5a      -R   5        $ lbl_SeatEmpty��5a      $��Seat is empty��6/   $ 89��6G   $ 56��6X   $��16(�6h   $
��Bold"�6v   $
��Left=�6�   $��Center=�6�   �� 5b      -S   5        $ lbl_SelectedSeat��5b      $��Select Passenger Seat��62   $ 90��6R   $	 101��6c   $��16(�6t   $
��Bold"�6�   �� 5c      -T   5        $ lbl_ColorSeatTake��5c      $�� ��63   $ 31��6>   $ 5��6O   $��36��6^   $��40��6j   
���  ��$
��Left=�6�   $	��Top=�6�   �� 5d      -U   5        $ lbl_ColorSeatEmpty��5d      $�� ��64   $ 31��6?   $ 55��6P   $��36��6`   $��40��6l   ���	#FF0800FF$��Center=�6�   $	��Top=�6�   �� 5e      -V   5        $ lbl_ColorSeatTake_Copy��5e      $�� ��68   ���	#FF00FF56$��37��6Z   $ 31��6f   $ 99��6w   $��40��6�   5f      5g      5j      5k      