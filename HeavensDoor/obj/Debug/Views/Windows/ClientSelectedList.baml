   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor2   ,HeavensDoor.Views.Windows.ClientSelectedList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   a	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5   	     ? Title$7  1Список клиентов для сеанса??5   	   $	??430??6,   $	??550??69      MaterialDesignPaper#???   5	   	     MaterialDesignFont#???  5
   	    ? 
ResizeMode$ NoResize=?6;    ?? BitmapScalingMode$ HighQuality=?6Q    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6   .??5      ??  ?? Orientation$ Vertical=?6   .+?5   
   ?? $ 
Horizontal=?6   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??6   $??Center=?6~      
IsFloating . $??5q?6?   $??14(?6?   $??1??6?   $??4??6?   $	??535??6  ??6=   ?? *
SearchText+ ?? UpdateSourceTrigger$ PropertyChanged=?6  5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .  	   CanUserSortColumns	 .  "
   VerticalScrollBarVisibility$
 Hidden=?6J      
IsReadOnly . ???	#FF4CAF50$??3q?6?   $??5,0,5,0q?6?   $	??300??6   ?? SelectedItem 6?   ?? *SelectedClient+??6?   ?? *FilteredClient+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО??5   	      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   	   ?? *FIO+5        5      $ Пол??5   	   $	 160 6    5   	   ?? *Sex+5       ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '        7 ?? 5      8   "  6Q   .?5      ??  ? ?? ?	#FF4CAF5063   ?? 5       ? ??
 ?????63   5      5      5      ?? 5    
   $ 
Horizontal=?6   $??5q?6.   $??1??69   .+?5!      ?? -   5         ??Name$ SelectClient??5!      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6+     MaterialDesignRaisedButton#??[ 6Y   $	??210??6?   $??2??6?   .??5"      ?? $ 
Horizontal=?6   $	??180??66   .+?5#      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ Package=?6.   
???????$??22??6P   $??29??6\   ?? 5$      
???????$#??Выбрать клиента??63   $??Center=?6J   $??Center=?6g   5%      5&      ?? 5'      -   5        $
 Back??5'      $??	115,0,0,0q?6#   $ 10??66   $??Bottom=?6d   #??[ 6   .??5(      ?? $ 
Horizontal=?6   $	??180??66   .+?5)      	  $ Close=?6.   $??Center=?6;   
???????$??Bottom=?6k   $??22??6?   $??29??6?   ?? 5*      $#??Отмена действия??6    $??Center=?67   
???????$??Center=?6g   5+      5,      5-      5.      5/      