   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5      &     FlightSimulator.Views.ManuelView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5views#clr-namespace:FlightSimulator.Views     5      
�������.��5	      � .+�5
   
   �� $��
35,100,0,0q�6h   $��15(�6|   ��6   �� *VM_throttle+  �� UpdateSourceTrigger$  PropertyChanged=� �� StringFormat$ N2��6|   ]� 5   
   .+�5      �� $
��Left=�6    �� Orientation$ 
Horizontal=�6/   $��Center=�6H   $	��179��6c   $��0,146,0,175q�6p   $��70��6�   .+�5      �� $��← throttle →��6   $��20(�61   $��30��6?   $
��Left=�6K   $��Center=�6f   $��	0,0,-26,0q�6�   $	��118��6�    � LayoutTransform 5      �� 5       �� Angle$	 -90Q�6*   5      �� 5       �� Orientation$ Vertical=�68   $��
40,0,0,0.2q�6P    �� IsSnapToTickEnabled .  �� TickFrequency$	 0.1Q�6�    � Maximum$ 1Q�6�   	 � Minimum$	 -1Q�6�   
 �� TickPlacement$
 TopLeft=�6�   $��22��6�    � Value 6   �� *VM_throttle+6�   5      �� 5      $��Right=�6   $ 
Horizontal=�60   $��Center=�6I   $	��150��6d   .+�5      �� $��← elevator →��6   $��20(�61   $��30��6?   $
��Left=�6K   $��Center=�6f   $��10,0,0,0q�6�    5      �� 5      $ 90Q�6*   5      �� 5      $��-35,-60,0,0q�6o   $��15(�6�   ��6   �� *VM_elevator+$  PropertyChanged=�$ N2��6�   5       �� 5!      $��Bottom=�6   $ 
Horizontal=�61   $��Center=�6J   $��53��6e   $��99.2,0,13.4,0q�6q   .+�5"      �� $��	0,-11,0,0q�66   $	��Top=�6I    . $	 0.1Q�6|   $ 1Q�6�   $	 -1Q�6�   $
 BottomRight=�6�   $	��219��6�   $��38��6�    J� RenderTransformOrigin$ 	0.5,0.685&�6�    6   �� *	VM_rudder+6�   �� 5%      $��25,5,0,0q�6m   $��15(�6   $��38��6�   ��6   �� *	VM_rudder+$  PropertyChanged=�$ N2��6�   �� 5&      $��← rudder →��6   $��20(�6.   $��Bottom=�6<   $��-370,0,0,-0.2q�6X   $	��104��6o   5'      �� 5(      $	��Top=�6   $ 
Horizontal=�6.   $��Center=�6G   $��39��6b   $��
0,0,-0.4,0q�6n   .+�5)      �� $��← aileron →��6   $��20(�6/   $��150,10,0,0.2q�6=   �� 5*      $��50,5,0,0q�6n   $��15(�6�   ��6   �� *
VM_aileron+$  PropertyChanged=�$ N2��6�   5+      $   FlightSimulator.Views.Joystick  5,      $	��342��5-   G   $��
0,18.8,0,0q�6S   $	��354��6g   $	��Top=�6t   $ 0.5,0.5&�6�      Elevator 5,      �� *VM_elevator+ �� Mode$ TwoWay=�   Aileron 5-      �� *
VM_aileron+$ TwoWay=�z�5.      V� 5/      .~�50      �� �� 51      �� 52      $	 270Q�6*   T� 53      54      56      57      59      5:      