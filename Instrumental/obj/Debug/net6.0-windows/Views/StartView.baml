   M S B A M L   `   `   `  ����G  CInstrumental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:InstrumentalInstrumental  5      "    Instrumental.Views.StartView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Instrumental     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��20,10,60,10q�6(   $��Center=�6=   $��40(�6Z   $��Welcome��6h   �� 5      $��1��6   $��70��6$   $��10q�60   $��Right=�6<   $;��5pack://application:,,,/Resources/Images/veena_art.jpg��6X   5      � 5   
   $��1��6     5      �� 5      $
��auto �6    �� 5      $
��auto �6     5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5       �� $��0��6   $��2��6!   $��0��63   $	��200��6C   $��10q�6P   $?��9pack://application:,,,/Resources/Images/saxophone_art.png��6\   �� 5!      $��0��6   $��1��6%   $��10q�65   $��18(�6A    �� TextAlignment$ Center=�6O   $
��Wrap=�6f   $����This is an application designed to test your knowledge of different musical instruments. You will here a short audio clip and your job is to guess what kind of instrument is playing. Good luck!��6z   �� 5"      $��1��6   $��1��6"   $��
10,0,10,10q�62   $��Center=�6F   $��Center=�6c   $��20(�6~   $��Start��6�   ��6�   �� *StartCommand+5#      5$      5%      