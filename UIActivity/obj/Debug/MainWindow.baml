   M S B A M L   `   `   `  ����E  AUIActivity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UIActivity
UIActivity  5   	       UIActivity.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:UIActivity     5   	     � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� $��
First Name��6   $��3q�6%   �� 5   
   -   5         ��Name$ txtFirstname��5      $��1��6(   $��3q�65   �� 5   
   $��Middle Name��6   $��2��6&   $��3q�63   �� 5   
   -   5        $ txtMiddlename��5      $��3��6)   $��3q�66   �� 5   
   $��	Last Name��6   $��4��6$   $��3q�61   �� 5   
   -   5        $ txtLastname��5      $��5��6'   $��3q�64   �� 5!   
   $��	Birthdate��6   $��6��6$   $��3q�61   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ dtpBirthday��5"      $��7��6*   $��3q�67   �� 5$   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10��6K   .+�5%      �� -   5         ��Name$ btnSave��5%      $
��Save��6&   $��3q�65   $	��100��6@   6L   �� 5'      -   5        $ 	btnUpdate��5'      $��Update��6(   $��3q�69   $	��100��6D   6P   �� 5)      -   5        $ 
btnConnect��5)      $��Connect��6)   $��3q�6;   $	��100��6F   6R   �� 5+      -   5        $ 
btnRefresh��5+      $��Refresh Data��6)   $��3q�6@   $	��100��6K   6W   5,      &   System.Windows.Controls.DataGrid  5-   
   -	   5          Name$ 	dgDetails��5-      $��11��6&      CanUserAddRows .     Columns 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      	   CellTemplate	 50      �� 51      .R�52      �� $ 
Horizontal=�6)   .+�53   "   �� $ btnEdit��6)   -
   5        $
��Edit��53   :   6I   �� 54   "   $ 	btnDelete��6)   -   5        $��Delete��54   <   6M   �� 55   "   $ btnAddGuardian��6)   -   5        $��Add Guardian��55   A   6X   �� 56   "   $ btnView��6)   -   5        $��View Details��56   :   6Q   57      58      5:      5<      5=      5>      