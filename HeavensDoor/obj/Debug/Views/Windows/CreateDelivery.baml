   M S B A M L   `   `   `  ????F  BHeavensDoor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HeavensDoor.Views.WindowsHeavensDoor.Views.Windows  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5	   	   .    (HeavensDoor.Views.Windows.CreateDelivery   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:HeavensDoor.Views.Windows     5   	   g	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5	   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	     ? Title$+  %Оформление поставки??5   	   $	??617??6%   $	??480??62      MaterialDesignPaper#???   5   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?6.    ?? BitmapScalingMode$ HighQuality=?6D    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6r   .??5      ??  ?? Orientation$ Vertical=?6   $??15q?6(   .+?5   
   ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Поставщик??6    ?? DisplayMemberPath$
 Name??6>   $??72??6W   $??5q?6e   $??16(?5   5      
IsFloating . $??Bottom=?5      	 ?? SelectedItem	 5   p   ?? *	Suplier+??5      ?? *SuplierList+5      ?? 5   
   $* $Общая цена поставки??6\    . 
 ?? 
IsReadOnly
 . $??5,5,5,10q?6?   $??16(?6?   ??6   ?? *Price+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? Mode$ TwoWay=?6?   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6J   $	??300??6?   ???	#FF4CAF50$??3q?6?   ??6o   ?? *SelectedMaterialForDelivery+	 6?   ?? *SelectedMaterial+ ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '        7 ?? 5      8   "  6Q   .?5      ??  ? ?? ?	#FF4CAF5063   ?? 5       ? ??
 ?????63   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Материал??5         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6'   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      ?? *
NameM.Name+5   '     5      $ В поставке??5!      $ * 6)    5       ?? *Count+$ PropertyChanged=?$ TwoWay=?5!   )   5#      ?? 5$   
   $ Vertical=?6   .+?5%      ?? $ 
Horizontal=?6   $??5,10,5,0q?62   .+?5&      ?? -   5         ??Name$ SelectMaterial??5&        MaterialDesignRaisedButton#??[ 61   $??0,0,20,0q?6e   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6x   $??32??6?   $	??210??6?   .??5'      ?? $ 
Horizontal=?6!   $	??180??6:   .+?5(      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ PlusOutline=?62   
???????$??Center=?6X   $??22??6s   $??29??6   ?? 5)      
???????$'??!Добавить материал??67   $
??Left=?6P   $??Center=?6k   5*      5+      ?? 5,      -   5        $ DelMaterial??5,      #??[ 6.   $ 10??6b   $??32??6?   $	??210??6?   .??5-      ?? $ 
Horizontal=?6!   $	??180??6:   .+?5.      	  $ Minus=?62   
???????$??Center=?6R   $??22??6m   $??29??6y   ?? 5/      
???????$#??Убрать материал??67   $
??Left=?6N   $??Center=?6i   50      51      52      ?? 54      $ 
Horizontal=?6   $??5,20,0,5q?62   $??3??6D   $??2??6Q   .+?55      ?? -   5        $ SaveDelivery??55      #??[ 6/   $ 10??6d   $??32??6?   $	??210??6?   .??56      ?? $ 
Horizontal=?6!   $	??180??6:   .+?57      	  $ ContentSave=?62   
???????$??22??6X   $??29??6d   $??Stretch=?6o   ?? 58      
???????$'??!Оформить поставку??67   $
??Left=?6P   $??Center=?6k   59      5:      ?? 5;      -   5        $ 	DelClient??5;      $ 10??6,   #??[ 6Z   $??20,0,0,0q?6?   $??32??6?   $	??210??6?   .??5<      ?? $ 
Horizontal=?6!   $	??180??6:   .+?5=      	  $ DeleteForever=?62   
???????$??Center=?6Z   $??22??6u   $??29??6?   ?? 5>      $'??!Отменить поставку??6$   
???????$
??Left=?6P   $??Center=?6k   5?      5@      5B      ?? 5C      -   5        $
 Back??5C      $ 10??6#   $	??210??6Q   $??0,10,0,0q?6]   $??Bottom=?6o   #??[ 6?   .??5D      ?? $ 
Horizontal=?6   $	??180??66   .+?5E      	  $ Close=?6.   $??Center=?6;   
???????$??Bottom=?6k   $??22??6?   $??29??6?   ?? 5F      $#??Отмена действия??6    $??Center=?67   
???????$??Center=?6g   5G      5H      5J      5L      5M      