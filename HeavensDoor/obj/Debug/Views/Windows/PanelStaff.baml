   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor1   +HeavensDoor.Views.Windows.StaffAutorization   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   g	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#???   5
   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	     ? Title$'  !Панель сотрудника??6;    ?? BitmapScalingMode$ HighQuality=?6U    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6?   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??0* ?6   ?? 5      $
??482* ?6   ?? 5      $
??485* ?6   ?? 5      $
??233* ?6   ?? 5      $??0* ?6    ? RowDefinitions 5   
   ?? 5      $??86 ?6   ?? 5      $
??269* ?6   ?? 5      $??55 ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $??2??6I   $
??Left=?6]   $??1??6x   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??6   $??16(?6=   $??	10,0,10,0q?6K   $??Bottom=?6?      
IsFloating . $	??230??6?   ??6^   ?? *Search+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5      $ Фильтрация??5      $??	10,0,10,0q?5       . $??Bottom=?5!      $	??233??5"      $??16(?5#      	 ?? SelectedItem	 5      ?? *
SelectType+??5       ?? *
ListType+??5%      ?? 5&      .R?5'      $? 5(      5*      ?? 5+      $ Сортировка??5,      
 ?? DisplayMemberPath$
 Title??5-      $??72??5.      $??	10,0,10,0q?5/      $??16(?6$    . $	??275??52   =   $??Bottom=?53       J? RenderTransformOrigin$ 0.325,0.413&?6,   	 50      ?? *
SelectSort+??51      ?? *ListSortSession+54      ?? 55      $ Vertical=?6   $??0,5,0,0q?60   $??Bottom=?6A   $??Center=?6\   .+?56      	? -   5        $#??По возврастанию??56      $??16(?68    d? 	IsChecked$
 TrueY?6d   $??0,0,0,5q?6u   $??3??6?   $??2??6?   	? 57      -   5        $??По убыванию??57      $??16(?64   $??Bottom=?6B   $
??Left=?6]   6x   58      59      ?? 5:   
   $ Vertical=?6   $??0,8,5,0q?6,   $	??Top=?6=   $??Right=?6U   $??3??6q   .+?5;      ?? -   5         ??Name$ 	AddClient??5;      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6(   $??0,0,0,5q?6V     MaterialDesignRaisedButton#??[ 6g   .??5=      ?? $ 
Horizontal=?6   $	??180??66   .+?5>      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Check=?6.   
???????$??Center=?6N   $??22??6i   $??29??6u   ?? 5?      
???????$!??Провести сеанс??63   $??Center=?6I   $??Center=?6f   5@      5A      ?? 5B      -   5        $
 Exit??5B      $	??230??6#   $ 10??62   #??[ 6`   $??1??6?   .??5C      ?? $ 
Horizontal=?6   $	??180??66   .+?5D        $ 	ExitToApp=?6.   
???????$??Center=?6R   $??22??6m   $??29??6y   ?? 5E      
???????$??
Выйти??63   $??Center=?6@   $??Center=?6]   5F      5G      5H      ?? 5I   
    ?? CornerRadius$ 5??6   ???	#FF4CAF50$??2q?6:   $??4??6N   $??5,0,5,0q?6b   $??1??6s   ._?5J      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6N      
IsReadOnly . $??2??6?   $??5??6?   ??6?   ?? *FilteredSessions+	 6?   ?? *SelectSession+   Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Процедура??5N   	      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   	   ?? *NameProcedures+5N        5O      $ Клиент??5Q   	   $	 250 6    5P   	   ?? *	FIOClient+5Q        5S      $ Дата заказа??5U   	   $ * 6    5T   	   ?? *	DateOrder+5U        5V      $# Дата проведения??5X   	   $ * 6"    5W   	   ?? *
DateTime+5X   "     5Y      $ Стоимость??5[   	   $	 100 6    5Z   	   ?? *PriceProcedures+5[        5\      $ Статус??5^   	   $	 100 6    5]   	   ?? *StatusSession+5^       ? 	Resources 5`      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '	        7	 ?? 5a      8   " 	 6U   .?5b      ??  ? ?? ?	#FF4CAF5067   ?? 5c       ? ??
 ?????67   5d      5e      5f      5h      ?? 5i   
   $ 
Horizontal=?6   $??Center=?6.   $
??Left=?6I   $??2??6d   $??50,0,0,0q?6q   $??2??6?   .+?5j      ?? -   5        $ 20??5j      $??Center=?6C   #??[ 6^   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5k        $ 	PageFirst=?5l      $??30??5m      $??30??5n      $??-5q?6    $??Center=?6,   
???????6I   5o      ?? 5p      $??5,0,5,0q?6   $??Center=?6F   $??22??6a   $??29??6m   $??16(?6x   ??6)   ?? *DisplayPage+6x   ?? 5q      -   5        $ 20??5q      $??Center=?6Z   #??[ 6u   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5r        
???????$ PageLast=?6=   $??30??6M   $??30??6Y   $??-5q?6d   $??Center=?6p   $??Center=?6?   5s      5t      5u      5v      