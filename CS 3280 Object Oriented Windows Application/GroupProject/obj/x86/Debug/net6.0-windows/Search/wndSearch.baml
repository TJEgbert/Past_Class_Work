   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GroupProject.SearchGroupProject.Search  5   	   #    GroupProject.Search.wndSearch   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GroupProject.Search     5   	     � Title$  	wndSearch��5   	   $	��450��6   $	��800��6(   .��5	      � ���	#FF5A5858.+�5   
   �� -   5         ��Name$ cBoxInvoiceNumber��5      $
��Left=�6.   $��	44,53,0,0q�6I   $	��Top=�6\   $	��120��6t   �� 5   
   -   5        $ cBoxInvoiceDate��5      $
��Left=�6,   $��
246,53,0,0q�6G   $	��Top=�6[   $	��120��6s   �� 5   
   -   5        $ cBoxTotalCharge��5      $
��Left=�6,   $��
453,53,0,0q�6G   $	��Top=�6[   $	��120��6s   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dGridInvoices��5      $��10,98,227,10q�6U   5      �� 5   
   -   5         ��Name$ 
bttnCancel��5      $��Cancel��6%   $
��Left=�66   $��
654,98,0,0q�6Q   $	��Top=�6e   $��88��6}   $	��111��6�    J� RenderTransformOrigin$ 0.49,-0.148&�6�   6�   �� 5   
   -   5        $ 
bttnSelect��5      $��Select Invoice��6%   $
��Left=�6>   $��654,217,0,0q�6Y   $	��Top=�6n   $��94��6�   $	��111��6�   6�   �� 5   
   -   5         ��Name$ 
lblInvoice��5      $��Invoice��6$   $
��Left=�66   $��	87,22,0,0q�6Q   $	��Top=�6d   �� 5   
   -   5        $ lblDate��5      $
��Date��6!   $
��Left=�60   $��
287,17,0,0q�6K   $	��Top=�6_   �� 5   
   -	   5        $ lblTotalCharge��5      $��Total Charge��6(   $
��Left=�6?   $��
486,22,0,0q�6Z   $	��Top=�6n   $��87��6�   5      5      