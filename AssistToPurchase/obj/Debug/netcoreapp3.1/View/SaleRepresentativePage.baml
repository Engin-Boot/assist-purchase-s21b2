   M S B A M L   `   `   `  ����K  GAssistToPurchase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:AssistToPurchase.ViewAssistToPurchase.View  5      I)clr-namespace:AssistToPurchase.ConvertersAssistToPurchase.Converters  5      2    ,AssistToPurchase.View.SaleRepresentativePage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:AssistToPurchase.View     5      @
converters)clr-namespace:AssistToPurchase.Converters     5        N� Title$  SaleRepresentativePage��5
       � 	Resources 5      H  BAssistToPurchase.Converters.SalesRepresentativeObjectToIdConverter !  SalesRepresentativeObjectToId�� 5   
   %   &	          5      6h   5      .��5      ]� $
��True��6   .+�5   
   � $��20q�6   $
��Left=�6   
������� � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $
��auto �6#   62   �� 5      $
��auto �6#   62   +�5      �� 5       $��12(�6   $
��Bold"�6*   $��0��6<   $��0��6I   Add new Sale Representative6v   �� 5!      $��2q�6   
�������$��1��6=   $��0��6J   Id6^   �� 5"      $��2q�6   
�������$��2��6=   $��0��6J   Name6`   �� 5#      $��2q�6   
�������$��3��6=   $��0��6J   Department Region6m   �� 5$      $��2q�6   
�������$��4��6=   $��0��6J   Email6a   �� 5%      $��2q�63   $	��100��6>   $��1��6J   $��1��6W   ��6   ��  �� Path$ Id�6i   �� 5&      $��2q�65   $	��100��6@   $��2��6L   $��1��6Y   ��6   �� $
 Name�6k   �� 5'      $��2q�6A   $	��100��6L   $��3��6X   $��1��6e   ��6   �� $ DepartmentRegion�6w   �� 5(      $��2q�66   $	��100��6A   $��4��6M   $��1��6Z   ��6   �� $ Email�6l   �� 5*      $	��100��6   $��5��6%   $��0��62   $	��Add��6B   ��6P   �� $ AddSaleRepCommand�6}   �� 5+      $	��100��6   $��5��6%   $��1��62   $��Clear��6B   ��6R   �� $ ClearSaleRepCommand�6�   5-      �� 5/   
   
�������$��10q�6$   $
��Left=�61   $	��250��6G   ._�50      ]� .+�51      �� $	��Top=�6   $��10q�62   .+�52      �� $��14(�6    $
��Bold"�6.   $��Center=�6@   Select Representatives6u   �� 54      -   5         ��Name$ userListCombo��54       �� DisplayMemberPath$
 Name��56      ��55      �� $ SalesRepresentativesList� �� Text 57      �� $ SalesRepName� �� SelectedItem 58      �� $ SalesRepresentativeId�	 �� 	Converter#	 [  
 �� Mode$
 OneWayToSource=�59      5:      �� 5<      $��Bottom=�6   $��10q�65   .+�5=      �� $��14(�6    $
��Bold"�6.   List of Pending Requests6Z   �� 5?      -   5        $ pendingRequestsListCombo��5?      $ 	RequestId��6r   ��6A   �� $ PendingRequestsList� 6�   �� $ 	RequestId�6�   5A      5B      5D      �� 5E   
   $��10q�6   
�������._�5F      �� $
��auto��6   $
��auto��6'   $	��Top=�64   .+�5G      �� $��16(�6   $
��Bold"�6*   Repesnetative Details6S   �� 5J      -   5         ��Name$ UpdateDetails��5J   !     userDataModelDataTemplate#��[ 5K   !   ��5J   8   ��  �� ElementName$ userListCombo��$ SelectedItem�5K   l   �� 5P      $��16(�6   $
��Bold"�6*   $��0,10,0,0q�6<   $��Center=�6N   Request Details6|   �� 5Q      $��2q�6A   $	��100��6L   ��6   �� $ SalesRepName�6Z   �� 5R      $��2q�6�   $	��100��6�   ��6   �� $ userListCombo��$ SelectedItem�#	 [  6�   �� 5S      $��2q�6=   $	��100��6H   ��6   �� $ 	RequestId�6V   �� 5T      $	��100��6   ��6%   �� $ AcceptOrderCommand�.��6Q   Accept Order6_   5V      5Y      5[      5_      