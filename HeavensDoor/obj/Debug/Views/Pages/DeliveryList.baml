   M S B A M L   `   `   `  ????F  BHeavensDoor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HeavensDoor.Views.PagesHeavensDoor.Views.Pages  5   	   *    $HeavensDoor.Views.Pages.DeliveryList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HeavensDoor.Views.Pages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     N? Title$#  Список поставок??5   	      MaterialDesignBody#???   5
   	     MaterialDesignPaper N? 
Background# ?  5   	     MaterialDesignFont N? 
FontFamily# ?  5   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??0* ?6   ?? 5      $
??482* ?6   ?? 5      $
??485* ?6   ?? 5      $
??233* ?6   ?? 5      $??0* ?6    ? RowDefinitions 5   
   ?? 5      $??86 ?6   ?? 5      $
??269* ?6   ?? 5      $??55 ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $??2??6I   $
??Left=?6]   $??1??6x   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??6   $??16(?6=   $??	10,0,10,0q?6K   $??Bottom=?6?      
IsFloating . $	??230??6?   ??6^   ?? *
SearchText+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5      $ Фильтрация??5      $??	10,0,10,0q?5       . $??Bottom=?5!      $	??233??5"      $??16(?5#      	 ?? SelectedItem	 5      ?? *
SelectType+??5       ?? *
ListType+??5%      ?? 5&      .R?5'      $? 5(      5*      ?? 5+      $ Сортировка??5,      
 ?? DisplayMemberPath$
 Title??5-      $??72??5.      $??	10,0,10,0q?5/      $??16(?6$    . $	??275??52   =   $??Bottom=?53       J? RenderTransformOrigin$ 0.325,0.413&?6,   	 50      ?? *
SelectSort+??51      ?? *
ListSort+54      ?? 55      $ Vertical=?6   $??0,5,0,0q?60   $??Bottom=?6A   $??Center=?6\   .+?56      	? -   5        $#??По возврастанию??56      $??16(?68    d? 	IsChecked$
 TrueY?6b   $??0,0,0,5q?6s   $??3??6?   $??2??6?   	? 57      -   5        $??По убыванию??57      $??16(?64   $??Bottom=?6B   $
??Left=?6]   6x   58      59      ?? 5:   
   $ Vertical=?6   $??0,8,5,0q?6,   $	??Top=?6=   $??Right=?6U   $??3??6q   .+?5;      ?? -   5         ??Name$ AddDelivery??5;      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6*   $??0,0,0,5q?6X     MaterialDesignRaisedButton#??[ 6i   .??5=      ?? $ 
Horizontal=?6   $	??180??66   .+?5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ DeliveryDining=?6.   
???????$??Center=?6W   $??22??6r   $??29??6~   ?? 5?      
???????$'??!Оформить поставку??63   $??Center=?6L   $??Center=?6i   5@      5A      ?? 5B      -   5        $ 
GoDelivery??5B      $	??230??6)   $ 10??68   #??[ 6f   $??1??6?   .??5C      ?? $ 
Horizontal=?6   $	??180??66   .+?5D        $ Check=?6.   
???????$??Center=?6N   $??22??6i   $??29??6u   ?? 5E      
???????$%??Принять поставку??63   $??Center=?6K   $??Center=?6h   5F      5G      5H      ?? 5I   
    ?? CornerRadius$ 5??6   ???	#FF4CAF50$??2q?6:   $??4??6N   $??5,0,5,0q?6b   $??1??6s   ._?5J      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6N      
IsReadOnly . $??2??6?   $??5??6?   ??6?   ?? *FilteredProducts+	 6?   ?? *SelectDelivery+   Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Сотрудник??5N   	      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   	   ?? *
FioStaff+5N        5O      $ Дата заказа??5Q   	   $	 180 6    5P   	   ?? *	DateOrder+5Q        5R      $ Дата поставки??5T   	   $	 180 6     5S   	   ?? *DateDelivery+5T         5U      $ Поставщик??5W   	   $ * 6    5V   	   ?? *
Supplier+5W        5X      $ Статус??5Z   	   $	 170 6    5Y   	   ?? *Status+5Z        5[      $ Артикул??5]   	   $	 150 6    5\   	   ?? *	Articul+5]       ? 	Resources 5_      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value)
  #System.Windows.Controls.DataGridRow??%?   '	        7	 '
  {     ?? 5`      8   " 	 6U   .?5a      ??  ? ?? ?	#FF4CAF5067   ?? 5b       ? ??
 ?????67   5c      ?? 5d      " 
 6   .?5e      -   5        5f      5g      5h      5j      ?? 5k   
   $ 
Horizontal=?6   $??Center=?6.   $
??Left=?6I   $??2??6d   $??50,0,0,0q?6q   $??2??6?   .+?5l      ?? -   5        $ 20??5l      $??Center=?6C   #??[ 6^   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5m        $ 	PageFirst=?5n      $??30??5o      $??30??5p      $??-5q?6    $??Center=?6,   
???????6I   5q      ?? 5r      $??5,0,5,0q?6   $??Center=?6F   $??22??6a   $??29??6m   $??16(?6x   ??6)   ?? *DisplayPage+6x   ?? 5s      -   5        $ 20??5s      $??Center=?6Z   #??[ 6u   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5t        
???????$ PageLast=?6=   $??30??6M   $??30??6Y   $??-5q?6d   $??Center=?6p   $??Center=?6?   5u      5v      5w      5x      