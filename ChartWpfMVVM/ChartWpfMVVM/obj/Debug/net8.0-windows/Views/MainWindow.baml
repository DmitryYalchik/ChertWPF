   M S B A M L   `   `   `  ����G  CChartWpfMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ChartWpfMVVMChartWpfMVVM  5      9!clr-namespace:ChartWpfMVVM.ModelsChartWpfMVVM.Models  5      A%clr-namespace:ChartWpfMVVM.ViewModelsChartWpfMVVM.ViewModels  5	          ChartWpfMVVM.MainWindow   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:ChartWpfMVVM     5      /m!clr-namespace:ChartWpfMVVM.Models     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4vm%clr-namespace:ChartWpfMVVM.ViewModels     5	        � Title$  
MainWindow��5
      $	��800��5      $	��450��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   c� .@�5      d� -   5        $��ZoomBothAtSameTime��5      $$��Zoom both X and Y at same time��5       � ToolTip$P J... or zoom only Y with ctrl + mouse wheel and mouse wheel only for x zoom��5      5      � 5   
   $��1��6    5      �� 5      $��* �6    �� 5       $��* �6    .+�5#      � $��0��6    � ColumnDefinitions 5$      �� 5%      $
��auto �6'   �� 5&      .+�5)      �� $��Center=�6   .+�5+      ��  �� Orientation$ 
Horizontal=�6!   .+�5,      �� $	��100��5-      $��20��5.      $��5q�5/      
���E��$��1��52      ��51      �� *AnalogChart1Command+52      �� 53      $��Center=�6$   ��6?   �� *TextValueAnalog1+54      �� 55      $ 
Horizontal=�6!   .+�56      �� $	��100��57      $��20��58      $��5q�59      
������$��2��5<      ��5;      �� *AnalogChart2Command+5<      �� 5=      $��Center=�6$   $��value:��6?   5>      �� 5?      $ 
Horizontal=�6!   .+�5@      �� $	��100��5A      $��20��5B      $��5q�5C      
����2��$��2��5F      ��5E      �� *AnalogChart3Command+5F      �� 5G      $��Center=�6$   $��value:��6?   5H      5I      � 5J      $��1��6    5L      �� 5M      �� 5N      $
��auto �6+    5Q      �� 5R      �� 5S      $
��auto �6(   .+�5V      (� $��0��5W      $��0��5X       (� Stretch$
 Fill=�5Y      .��5Z      �� -   5         ��Name$ AnalogCanvas��5[      $	��320��5\      $	��190��5]      5^      �� 5`      -   5        $��HorizScroll��5a      $��1��5b      $��0��5c      $��Stretch=�5d       �� Orientation$ 
Horizontal=�5e      �� 5g      -   5        $��
VertScroll��5h      $��0��5i      $��1��5j      $��Stretch=�5k      $ Vertical=�5l      5n      5r      5s      5t      5v      