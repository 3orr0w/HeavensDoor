   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5	   	    HeavensDoor-   'HeavensDoor.Views.Windows.ProcedureInfo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   a	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5	   	     ? Title$*  $Работа с процедурой??5   	   $	??450??6%   $	??799??61      MaterialDesignPaper#???   5
   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?6.    ?? BitmapScalingMode$ HighQuality=?6D    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6r   .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   .+?5      ?? $ Vertical=?6   $??5q?60   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название??62      
IsFloating . $??5q?6?   $??16(?6?    ?? AcceptsReturn . ??6   ?? *Name1+6?   ?? 5      $ Цена??61    . $??5q?6?   $??16(?6?   ??6   ?? *Price+6?   ?? 5      $ 
Время??61   $??5q?6X    . $??16(?6?   ??6   ?? *Time+6?   ?? 5      $4 .Должность для выполнения??6   $??72??6U   	 ?? DisplayMemberPath$
	 Name??6c   $??5q?6|   $??16(?5   2    . $??Bottom=?5      
 ?? SelectedItem
 5   ?   ?? *SelectedPost+??5      ?? *
PostList+5      ?? 5       . $??5q?6c    . $ Описание??6?   $??60??6?   $??16(?6?    ?? TextWrapping$
 Wrap=?6?   ??6   ?? *Description+6?   5      &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6N      
IsReadOnly . $	??300??6?   ???	#FF4CAF50$??3q?6?   $??5,15,5,0q?6
  ??6?   ?? *	Materials+
 6?   ?? *SelectedMaterial+ ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '        7 ?? 5      8   "  6U   .?5      ??  ? ?? ?	#FF4CAF5067   ?? 5       ? ??
 ?????67   5      5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Материал??5$         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5#      ?? *Name+5$   '     5%      $ В центре??5'      $ * 6'    5&      ?? *CountMaterial+5'   '   5*      ?? 5+      $ Vertical=?6   .+?5,      ?? $ 
Horizontal=?6   $??5,10,5,0q?66   .+?5-      ?? -   5         ??Name$ SelectMaterial??5-        MaterialDesignRaisedButton#??[ 65   $??0,0,20,0q?6i   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6|   $??32??6?   $	??210??6?   .??5.      ?? $ 
Horizontal=?6%   $	??180??6>   .+?5/      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ PlusOutline=?66   
???????$??Center=?6\   $??22??6w   $??29??6?   ?? 50      
???????$'??!Добавить материал??6;   $
??Left=?6T   $??Center=?6o   51      52      ?? 53      -   5        $ DelMaterial??53      #??[ 62   $ 10??6f   $??32??6?   $	??210??6?   .??54      ?? $ 
Horizontal=?6%   $	??180??6>   .+?55      	  $ Minus=?66   
???????$??Center=?6V   $??22??6q   $??29??6}   ?? 56      
???????$#??Убрать материал??6;   $
??Left=?6R   $??Center=?6m   57      58      59      ?? 5;      $ 
Horizontal=?6   $??5,20,0,5q?66   $??3??6H   $??2??6U   .+?5<      ?? -   5        $ SaveProcedure??5<      #??[ 64   $ 10??6i   $??32??6?   $	??210??6?   .??5=      ?? $ 
Horizontal=?6%   $	??180??6>   .+?5>      	  $ ContentSave=?66   
???????$??22??6\   $??29??6h   $??Stretch=?6s   ?? 5?      
???????$+??%Сохранить процедуру??6;   $
??Left=?6V   $??Center=?6q   5@      5A      ?? 5B      -   5        $ 	DelClient??5B      $ 10??60   #??[ 6^   $??20,0,0,0q?6?   $??32??6?   $	??210??6?   .??5C      ?? $ 
Horizontal=?6%   $	??180??6>   .+?5D      	  $ DeleteForever=?66   
???????$??Center=?6^   $??22??6y   $??29??6?   ?? 5E      $'??!Удалить процедуру??6(   
???????$
??Left=?6T   $??Center=?6o   5F      5G      5H      ?? 5I      -   5        $
 Back??5I      $ 10??6'   $??0,10,0,0q?6U   $??Bottom=?6g   $	??210??6?   #??[ 6?   .??5J      ?? $ 
Horizontal=?6!   $	??180??6:   .+?5K      	  $ Close=?62   $??Center=?6?   
???????$??Bottom=?6o   $??22??6?   $??29??6?   ?? 5L      $#??Отмена действия??6$   $??Center=?6;   
???????$??Center=?6k   5M      5N      5P      5R      5S      5T      