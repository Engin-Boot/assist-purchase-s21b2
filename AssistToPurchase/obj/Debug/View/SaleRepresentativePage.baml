   M S B A M L   `   `   `  ����K  GAssistToPurchase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AssistToPurchase.ViewAssistToPurchase.View  5      2    ,AssistToPurchase.View.SaleRepresentativePage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:AssistToPurchase.View     5        N� Title$  SaleRepresentativePage��5	      .��5      ]� ��. .+�5   
   � $��20q�6   $
��Left=�6   
������� � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      $
��auto �6#   62   +�5      �� 5      $��12(�6   $
��Bold"�6*   $��0��6<   $��0��6I   Add new Sale Representative6v   �� 5      $��2q�6   
�������$��1��6=   $��0��6J   Id6^   �� 5      $��2q�6   
�������$��2��6=   $��0��6J   Name6`   �� 5      $��2q�6   
�������$��3��6=   $��0��6J   Department Region6m   �� 5      $��2q�6   
�������$��4��6=   $��0��6J   Email6a   �� 5       $��2q�63   $	��100��6>   $��1��6J   $��1��6W   ��6   ��  �� Path$ Id�6i   �� 5!      $��2q�65   $	��100��6@   $��2��6L   $��1��6Y   ��6   �� $
 Name�6k   �� 5"      $��2q�6A   $	��100��6L   $��3��6X   $��1��6e   ��6   �� $ DepartmentRegion�6w   �� 5#      $��2q�66   $	��100��6A   $��4��6M   $��1��6Z   ��6   �� $ Email�6l   �� 5%      $	��100��6   $��5��6%   $��0��62   $	��Add��6B   ��6P   �� $ AddSaleRepCommand�6}   �� 5&      $	��100��6   $��5��6%   $��1��62   $��Clear��6B   ��6R   �� $ ClearSaleRepCommand�6�   5(      �� 5*   
   
�������$��10q�6$   $
��Left=�61   $	��250��6G   ._�5+      ]� .+�5,      �� $	��Top=�6   $��10q�62   .+�5-      �� $��14(�6    $
��Bold"�6.   $��Center=�6@   Select Representatives6u   �� 5/      -   5         ��Name$ userListCombo��5/       �� DisplayMemberPath$
 Name��6l   ��66   �� $ SalesRepresentativesList� �� Text 6�   �� $ SalesRepName�6�   50      �� 52      $��Bottom=�6   $��10q�65   .+�53      �� $��14(�6    $
��Bold"�6.   List of Pending Requests6Z   �� 55      -   5        $ pendingRequestsListCombo��55      $ 	RequestId��6r   ��6A   �� $ PendingRequestsList� 6�   �� $ 	RequestId�6�   57      58      5:      �� 5;   
   $��10q�6   
�������._�5<      �� $
��auto��6   $
��auto��6'   $	��Top=�64   .+�5=      �� $��16(�6   $
��Bold"�6*   Repesnetative Details6S   �� 5@      -   5         ��Name$ UpdateDetails��5@   !      userDataModelDataTemplate#��[  5A   !   ��5@   8   ��  �� ElementName$ userListCombo��$ SelectedItem�5A   l   �� 5F      $��16(�6   $
��Bold"�6*   $��0,10,0,0q�6<   $��Center=�6N   Request Details6|   �� 5G      $��2q�6A   $	��100��6L   ��6   �� $ SalesRepName�6Z   �� 5H      $��2q�6F   $	��100��6Q   ��6   �� $ SalesRepresentativeId�6_   �� 5I      $��2q�6=   $	��100��6H   ��6   �� $ 	RequestId�6V   �� 5J      $	��100��6   ��6%   �� $ AcceptOrderCommand�.��6Q   Accept Order6_   5L      5O      5Q      5U      