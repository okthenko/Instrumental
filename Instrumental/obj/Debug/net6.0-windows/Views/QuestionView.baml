   M S B A M L   `   `   `  ����G  CInstrumental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Instrumental.ViewsInstrumental.Views  5      %    Instrumental.Views.QuestionView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Instrumental.Views     5      .��5      �   � RowDefinitions  5   
   �� 5	      $
��auto �6   �� 5
      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��10q�6!   $��40(�6-    �� TextAlignment$ Center=�6;   $��
What am I?��6S   �� 5   
   $��1��6   $;��5pack://application:,,,/Resources/Images/staff_art.png��6   �� 5   
   $��2��6   $��20q�6H   $��Center=�6T   $��0q�6o   
������ ��6   �� *Question.Options+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��
IsSelected �� Value 63   ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=��� 5       � �� 5      �� 5       �� 
TargetType" ��6.   .R�5   "   �� 5      5      5      ��5      �� 5       .R�5!      	� $��20(�6�   $��Center=�6�   $��10q�6�   ��6"   �� *Text+ d� 	IsChecked 6;   �� $ 
IsSelected�$ TwoWay=�	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 ��6�   5"      5$      �� 5&   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��	0,0,10,10q�6W   .+�5'      �� $��10q�6   $��20(�6!   $��Replay��6/   ��6@   �� *ReplayCommand+�� 5(      $��10q�6   $��20(�6"   $��Submit��60   ��6A   �� *SubmitCommand+5)      r� 5*   
    r� Source 6   �� *#!Question.Instrument.SoundFileName+5,      5-      