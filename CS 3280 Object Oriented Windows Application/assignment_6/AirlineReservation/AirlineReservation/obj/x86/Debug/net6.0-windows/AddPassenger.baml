   M S B A M L   `   `   `  ����M  IAirlineReservation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AirlineReservationAirlineReservation  5   	   %    AirlineReservation.AddPassenger   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:AirlineReservation     5   	   -   5          �Name$  wnd_AddPassenger��5   	    � Title$ Add Passenger��5   	   $	��147��6   $	��465��6,   .��5	      � $��0,0,0,6q�6    � Cursor$  ��6   .+�5
   
   �� -   5         ��Name$ lbl_FirstName��5
      $��
First Name��6'   $
��Left=�6<   $��	10,21,0,0q�6W   $	��Top=�6j   �� 5   
   -   5         ��Name$ txt_FirstName��5      $
��Left=�6)   $��	98,25,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��120��6�    �� 	MaxLength$ 15��6�   �� 5   
   -   5        $ txt_LastName��5      $
��Left=�6(   $��
316,25,0,0q�6C   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   $ 15��6�   �� 5   
   -   5        $ lbl_lastName��5      $��	Last Name��6&   $
��Left=�6:   $��
230,21,0,0q�6U   $	��Top=�6i   �� 5   
   -   5         ��Name$ cmd_Save��5      $
��Save��6#   $
��Left=�62   $��	34,59,0,0q�6M   $	��Top=�6`   $��38��6x   $	��143��6�   6�   �� 5   
   -   5        $ 
cmd_Cancel��5      $��Cancle��6%   $
��Left=�66   $��
263,59,0,0q�6Q   $	��Top=�6e   $��38��6}   $	��148��6�   6�   5      5      