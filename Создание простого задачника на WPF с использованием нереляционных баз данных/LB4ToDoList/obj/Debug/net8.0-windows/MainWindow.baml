   M S B A M L   `   `   `  ����F  BLB4ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LB4ToDoListLB4ToDoList  5   	       LB4ToDoList.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LB4ToDoList     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ���#353647.+�5
   
   �� -   5        $��Scroll��5
      .��5      �� -   5         ��Name$
 Base��5      5      5      �� 5   
   $��Center=�6   ���#353647$
��Wrap=�6F   $D��>Приветствуем вас в нашем задчнике��6Z   $��16(�6�   $	��Top=�6�   $
��Bold"�6�   
�������6�   �� 5   
   -   5         ��Name$ AddTask��5      $#��Добавить задачу��6"   $��Right=�6<   $��0,0,0,0q�6X   $	��Top=�6i   $��45��6�   $	��115��6�   6�   �� 5   
   -   5         ��Name$ 
BorderTask��5      $y�Hidden=�6%   $��	0,26,0,74q�69    �� CornerRadius$ 30��6L   
������� �� Padding$ 0q�6q   $	��460��6}   $	��350��6�   $��Center=�6�   ._�5      � .+�5      �� -   5         ��Name$ NameT��5       �� TextWrapping$
 Wrap=�6)   $��20��6=   $#��Название Задачи��6I   $��30,28,150,271q�6`   �� 5      -   5        $ DiscT��5      $
 Wrap=�6)   $	��100��6=   $#��Описание Задачи��6J   $��30,80,150,176q�6a   �� 5      -   5        $ DeadT��5      $
 Wrap=�6)   $��20��6=   $��Дэдлайн��6I   $��30,180,150,136q�6X   �� 5      -   5        $ AddTaskThis��5      $#��Добавить задачу��6.   $��Right=�6H   $��	0,0,20,20q�6d   $��Bottom=�6w   $��45��6�   $	��115��6�   6�   5      5      5      5      