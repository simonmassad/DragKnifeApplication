   M S B A M L   `   `   `  ���� O  KDragKnifeApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DragKnifeApplicationDragKnifeApplication  E'clr-namespace:DragKnifeApplication.ViewDragKnifeApplication.View  %    DragKnifeApplication.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:DragKnifeApplication     9views'clr-namespace:DragKnifeApplication.View       � Title$  Drag Knife Application��$	��800��$
��1080��
����İ�.��� $
��Left=�$	��Top=� � RowDefinitions �� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ��� $��60 ���  � ColumnDefinitions �� $	��100 ��� $	��200 ��� .+��� $��0��$��0��$��24(�
����  �$��2��.��DRAG KNIFE APPLICATION�� -   $��OpenDXF��$��40��$��80��$��Center=�$
��Left=�$��10q�$��0��$��1��.��
Open DXF�� $��14(�
����  �$
��Left=�$��Center=�$��1��$��1������ *
FileName+ �� UpdateSourceTrigger$ PropertyChanged=��� $��3��$��0��$��20��$��80�� �� SelectedIndex$ 6������ *BaudRateOptions+ �� SelectedItem �� *SelectedBaudRate+�� $��Select Baud Rate��$��14(�
����  �$
��Left=�$��Center=�$��3��$��1���� $��4��$��0��$��20��$��80��$ 0������ *ActivePorts+ �� *SelectedPort+�� $��Select Com Port��$��14(�
����  �$
��Left=�$��Center=�$��4��$��1���� -   $��	SendGCode��$��40��$��80��$��Center=�$
��Left=�$��10q�$��0��$��2��.��Send G-Code.   (DragKnifeApplication.View.DXFDisplayView  -     Name$ DXFDisplayViewControl��.   (DragKnifeApplication.View.DXFDisplayView   Loaded$ DisplayViewControl_Loaded��$��0��$��2��$��7��