   M S B A M L   `   `   `  ????  HeavensDoor'    !HeavensDoor.Views.Pages.StaffList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#???   5	   	     MaterialDesignPaper  N? 
Background#  ?  5
   	     MaterialDesignFont N? 
FontFamily# ?  5   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??0* ?6   ?? 5      $
??482* ?6   ?? 5      $
??485* ?6   ?? 5      $
??233* ?6   ?? 5      $??0* ?6    ? RowDefinitions 5   
   ?? 5      $??86 ?6   ?? 5      $
??269* ?6   ?? 5      $??55 ?6   .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $??2??6I   $
??Left=?6]   $??1??6x   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??6   $??16(?6=   $??	10,0,10,0q?6K   $??Bottom=?6?      
IsFloating . $	??230??6?   ??6^   ?? *Search+ ?? UpdateSourceTrigger$ PropertyChanged=?6?   ?? 5      $ Фильтрация??5      $??	10,0,10,0q?5       . $??Bottom=?5       $	??233??5!      $??16(?5"       ?? SelectedItem 5      ?? *
SelectType+??5      ?? *
ListType+??5$      ?? 5%      .R?5&      $? 5'      5)      ?? 5*      $ Сортировка??5+      	 ?? DisplayMemberPath$	 Title??5,      $??72??5-      $??	10,0,10,0q?5.      $??16(?6$    . $	??275??51   =   $??Bottom=?52      
 J? RenderTransformOrigin$
 0.325,0.413&?6,    5/      ?? *
SelectSort+??50      ?? *ListSortStaff+53      ?? 54      $ Vertical=?6   $??0,5,0,0q?60   $??Bottom=?6A   $??Center=?6\   .+?55      	? -   5        $#??По возврастанию??55      $??16(?68    d? 	IsChecked$
 TrueY?6d   $??0,0,0,5q?6u   $??3??6?   $??2??6?   	? 56      -   5        $??По убыванию??56      $??16(?64   $??Bottom=?6B   $
??Left=?6]   6x   57      58      ?? 59   
   $ Vertical=?6   $??0,8,5,0q?6,   $	??Top=?6=   $??Right=?6U   $??3??6q   .+?5:      ?? -   5         ??Name$ 	AddClient??5:      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6(   $??0,0,0,5q?6V     MaterialDesignRaisedButton#??[ 6g   .??5<      ?? $ 
Horizontal=?6   $	??180??66   .+?5=      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=?6.   
???????$??Center=?6P   $??22??6k   $??29??6w   ?? 5>      
???????$+??%Добавить сотрудника??63   $??Center=?6N   $??Center=?6k   5?      5@      ?? 5A      -   5        $ RedactClient??5A      $	??230??6+   $ 10??6:   #??[ 6h   $??1??6?   .??5B      ?? $ 
Horizontal=?6   $	??180??66   .+?5C        $ PencilCircle=?6.   
???????$??Center=?6U   $??22??6p   $??29??6|   ?? 5D      
???????$+??%Изменить сотрудника??63   $??Center=?6N   $??Center=?6k   5E      5F      5G      ?? 5H   
    ?? CornerRadius$ 5??6   ???	#FF4CAF50$??2q?6:   $??4??6N   $??5,0,5,0q?6b   $??1??6s   ._?5I      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6N      
IsReadOnly . $??2??6?   $??5??6?   ??6?   ?? *FilteredStaff+ 6?   ?? *SelectStaff+   Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО??5M   	      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   	   ?? *Fio+5M        5N      $ Пол??5P   	   $ 60 6    5O   	   ?? *Sex+5P        5Q      $ Должность??5S   	   $ * 6    5R   	   ?? *	PostStaff+5S        5T      $ Адресс??5V   	   $ * 6    5U   	   ?? *Adress+5V        5W      $ Телефон??5Y   	   $ * 6    5X   	   ?? *	Telephone+5Y        5Z      $ 
Почта??5\   	   $	 170 6    5[   	   ?? *Email+5\        5]      $ Статус??5_   	   $	 170 6    5^   	   ?? *StatusStaff+5_       ? 	Resources 5a      =	  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value)
  #System.Windows.Controls.DataGridRow??%?   '	        7	 '
  {     ?? 5b      8   " 	 6U   .?5c      ??  ? ?? ?	#FF4CAF5067   ?? 5d       ? ??
 ?????67   5e      ?? 5f      " 
 6   .?5g      -   5        5h      5i      5j      5l      ?? 5m   
   $ 
Horizontal=?6   $??Center=?6.   $
??Left=?6I   $??2??6d   $??50,0,0,0q?6q   $??2??6?   .+?5n      ?? -   5        $ 20??5n      $??Center=?6C   #??[ 6^   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5o        $ 	PageFirst=?5p      $??30??5q      $??30??5r      $??-5q?6    $??Center=?6,   
???????6I   5s      ?? 5t      $??5,0,5,0q?6   $??Center=?6F   $??22??6a   $??29??6m   $??16(?6x   ??6)   ?? *DisplayPage+6x   ?? 5u      -   5        $ 20??5u      $??Center=?6Z   #??[ 6u   $??50??6?   $??50??6?   ???	#DD000000$??2??6?   .??5v        
???????$ PageLast=?6=   $??30??6M   $??30??6Y   $??-5q?6d   $??Center=?6p   $??Center=?6?   5w      5x      5y      5z      