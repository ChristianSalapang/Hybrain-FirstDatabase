   M S B A M L   `   `   `  ����E  AUIActivity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:UIActivity
UIActivity  5   	       UIActivity.ViewDetails   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:UIActivity     5   	     � Title$  ViewDetails��5   	   $	��600��6   $
��1000��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $��* �6   .+�5   
   �� $��
First Name��6   $��1��6%   $��3q�62   �� 5   
   -   5         ��Name$ ShowFirstname��5      $�� ��6+   $��SemiBold"�63   $��16(�6I   $��2��6W   $��7q�6d   �� 5   
   $��Middle Name��6   $��3��6&   $��3q�63   �� 5   
   -   5        $ ShowMiddlename��5      $�� ��6,   $��SemiBold"�64   $��16(�6J   $��4��6X   $��7q�6e   �� 5   
   $��	Last Name��6   $��5��6$   $��3q�61   �� 5    
   -   5        $ ShowLastname��5       $�� ��6*   $��SemiBold"�62   $��16(�6H   $��6��6V   $��7q�6c   �� 5"   
   $��Birthday��6   $��7��6#   $��3q�60   �� 5#   
   -   5        $ ShowBirthday��5#      $�� ��6*   $��SemiBold"�62   $��16(�6H   $��8��6V   $��7q�6c   �� 5%   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10��6K   5(      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ 	dgDetails��5)      $��11��6&      CanUserAddRows .     Columns 5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+         CellTemplate 5,      �� 5-      .R�5.      �� $ 
Horizontal=�6)   50      51      53      55      56      57      