   M S B A M L   `   `   `  ����D  @Reservoom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservoom.ViewsReservoom.Views  5      ;"clr-namespace:Reservoom.ViewModelsReservoom.ViewModels  6:   )    #Reservoom.Views.MakeRevervationView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservoom.Views     5      9
viewmodels"clr-namespace:Reservoom.ViewModels     6:   .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��5      $��24(�5      $��Make Reservation��5      � 5   
   $��1��6   $��5 50 0 0q�6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $
��Name��6%   �� 5      $��1��6   $��0 5 0 0q�6b   ��6#   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6b   5      � 5   
   $��2��6   $��5 10 0 0q�6    5      �� 5       $
��auto �6    �� 5!      $
��auto �6     � ColumnDefinitions 5#      �� 5$      $
��auto �6#    z� SharedSizeGroup$ Fristcolumn��60   �� 5%      $
��auto �6#   $ Secondcolumn��60   .+�5'      �� $��0��5(      $��0��5)      $��	Floor No.��5*      �� 5+      $��1��5,      $��0��5-      $��0 5 5 0q�5.      ��50      �� *
RoomNumber+$ PropertyChanged=��� 51      $��0��52      $��1��53      $��Room No.��54      $��5 0 0 0q�55      �� 56      $��1��57      $��1��58      $��5 5 0 0q�59      ��5:      �� *FloorNumber+$ PropertyChanged=�5;      � 5<   
   $��3��6   $��5 10 0 0q�6    5=      �� 5>      $
��auto �6    �� 5?      $
��auto �6     5A      �� 5B      $
��auto �6#   $ Fristcolumn��60   �� 5C      $
��auto �6#   $ Secondcolumn��60   .+�5E      �� $��0��5F      $��0��5G      $��
Start Date��5H      (  "System.Windows.Controls.DatePicker  5I      $��1��5J      $��0��5K      $��0 5 5 0q�5L         SelectedDate 5N      �� *	StartDate+$ PropertyChanged=��� 5O      $��0��5P      $��1��5Q      $��End Date��5R      $��5 0 0 0q�5S        5T      $��1��5U      $��1��5V      $��0 5 5 0q�5W       5Y      �� *	EndDate+$ PropertyChanged=�5Z      �� 5[   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��5 25 0 0q�6;   .+�5\      �� $��Submit��6   ��6&   �� *CommandSubmit+�� 5]      $��Cancel��6   $��5 0 0 0q�6H   ��6&   �� *CommandCancel+6H   5^      5_      5a      