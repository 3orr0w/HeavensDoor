   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor4   .HeavensDoor.Views.Windows.MaterialSelectedList   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   a	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5   	     ? Title$A  ;Список материалов для процедуры??5	   	   $	??430??61   $	??550??6>      MaterialDesignPaper#???   5
   	     MaterialDesignFont#???  5   	    ? 
ResizeMode$ NoResize=?6;    ?? BitmapScalingMode$ HighQuality=?6Q    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6   .??5      ??  ?? Orientation$ Vertical=?6   .+?5   
   ?? $ 
Horizontal=?6   $??5,0,5,0q?6.   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск??6   $??Center=?6~      
IsFloating . $??5q?6?   $??14(?6?   $??1??6?   $??4??6?   $	??535??6  ??6=   ?? *
SearchText+ ?? UpdateSourceTrigger$ PropertyChanged=?6  5      &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .  	   CanUserSortColumns	 .  
   
IsReadOnly
 . "   VerticalScrollBarVisibility$ Hidden=?6\   ???	#FF4CAF50$??3q?6?   $??5,0,5,0q?6?   $	??300??6   ?? SelectedItem 6?   ?? *SelectMaterial+??6?   ?? *FilteredMaterial+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Материал??5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      ?? *Name+5   '     5      $ Количество??5      $	 110 6)    5      ?? *CountMaterial+5   )     5      $ Стоимость??5      $	 140 6(    5      ?? *Cost+5   (    ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '        7 ?? 5      8   "  6Q   .?5      ??  ? ?? ?	#FF4CAF5063   ?? 5       ? ??
 ?????63   5       5!      5"      ?? 5#   
   $ 
Horizontal=?6   $??5q?6.   $??1??69   .+?5$      ?? -   5         ??Name$ AddMaterial??5$      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6*     MaterialDesignRaisedButton#??[ 6X   $	??210??6?   $??2??6?   .??5%      ?? $ 
Horizontal=?6   $	??180??66   .+?5&      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ Package=?6.   
???????$??22??6P   $??29??6\   ?? 5'      
???????$%??Выбрать материал??63   $??Center=?6K   $??Center=?6h   5(      5)      ?? 5*      -   5        $
 Back??5*      $ 10??6#   $??
115,00,0,0q?6Q   $??Bottom=?6e   #??[ 6?   .??5+      ?? $ 
Horizontal=?6   $	??180??66   .+?5,      	  $ Close=?6.   $??Center=?6;   
???????$??Bottom=?6k   $??22??6?   $??29??6?   ?? 5-      $#??Отмена действия??6    $??Center=?67   
???????$??Center=?6g   5.      5/      50      51      52      