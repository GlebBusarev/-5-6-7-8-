   M S B A M L   `   `   `  ����P  LElectronicShopBusarev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ElectronicShopBusarevElectronicShopBusarev  5   	   $    ElectronicShopBusarev.MenuPage   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ElectronicShopBusarev     5   	     � Title$  MenuPage��5   	   $	��450��6   $	��800��6'   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $��30 �6   �� 5      $��50 �6   �� 5      .+�5   
   �� $��Center=�6   $:��4Товары магазина электроники��61   �� 5   
   -   5        $��1��5   
   $��5q�5   
   $!��Добавить товар��5   
   �� 5   
   -   5         ��Name$ 	ProductLV��5   
   $��2��5   
    �� SelectionMode$ Single=�5   
   ��5      �� 5       �� DataType$# x:Type entities:ProductEntity��6   .R�5      �� .+�5      �� ��6$   �� *Id+ �� StringFormat$% Идентификатор: {0}���� 5      ��6$   �� *Title+$ Заголовок: {0}���� 5      ��6$   �� *Description+$ Описание: {0}���� 5       ��6$   �� *Amount+$ Осталось: {0}��5!      5"      5$      5%      5&      