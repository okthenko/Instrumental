   M S B A M L   `   `   `  ���� G  CInstrumental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Instrumental.ViewsInstrumental.Views  %    Instrumental.Views.QuestionView   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Instrumental.Views     .���   � RowDefinitions  �� $
��auto ��� $��* ��� $
��auto ��� $
��auto �.+��� $��0��$��10q�$��40(� �� TextAlignment$ Center=�$��
What am I?���� $��1��$;��5pack://application:,,,/Resources/Images/staff_art.png���� $��2��$��20q�$��Center=�$��0q�
������ ���� *Question.Options+����  �� 
TargetType" ��.���  �� Property �@��
IsSelected �� Value ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=���  � �� ��  �� 
TargetType" ��.R��� ���� .R�	� $��20(�$��Center=�$��10q����� *Text+ d� 	IsChecked �� $ 
IsSelected�$ TwoWay=�	 �� RelativeSource	 �� *FindAncestor+
 �� AncestorType"
 ���� $��3�� �� Orientation$ 
Horizontal=�$��Right=�$��	0,0,10,10q�.+��� $��10q�$��20(�$��Replay������ *ReplayCommand+�� $��10q�$��20(�$��Submit������ *SubmitCommand+r�  r� Source �� *#!Question.Instrument.SoundFileName+