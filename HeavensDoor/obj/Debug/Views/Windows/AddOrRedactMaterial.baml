   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor3   -HeavensDoor.Views.Windows.AddOrRedactMaterial   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   g	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     ? Title$*  $Работа с материалом??5   	   $	??290??6%   $	??348??61      MaterialDesignPaper#???   5
   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?6.    ?? BitmapScalingMode$ HighQuality=?6D    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6r   .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   $??15q?6,   .+?5      ?? $??0,0,0,10q?6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название??6?   $??16(?6i   $??40??6w      
IsFloating . ??6(   ?? *Name1+6?   ?? 5      $??0,0,0,10q?6-   $ Стоимость??6?   $??16(?6j   $??40??6x    . ??6   ?? *Cost1+6?   ?? 5      $??0,0,0,15q?6   $ Количество??6A   $??16(?6m   $??40??6{    . ??6(   ?? *	Amount1+6?   ?? 5      -   5         ??Name$ SaveMaterial??5        MaterialDesignRaisedButton#??[ 6+   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 10??6`   $??0,0,0,10q?6?   $??32??6?   $	??259??6?   .??5      ?? $ 
Horizontal=?6   $	??180??66   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 ContentSave=?6.   
???????$??Center=?6T   $??22??6o   $??29??6{   ?? 5      
???????$)??#Сохранить материал??63   $
??Left=?6M   $??Center=?6h   5      5      ?? 5      -   5        $ 	DelClient??5      $	 10??6(   #??[ 6V   $??32??6?   ???	#DD000000$	??259??6?   .??5      ?? $ 
Horizontal=?6   $	??180??66   .+?5        $
 DeleteForever=?6.   
???????$??Center=?6V   $??22??6q   $??29??6}   ?? 5      $%??Удалить материал??6    
???????$
??Left=?6K   $??Center=?6f   5      5      ?? 5      -   5        $
 Back??5      $	 10??6#   $??0,10,0,0q?6Q   $??Bottom=?6c   #??[ 6~   .??5       ?? $ 
Horizontal=?6   $	??180??66   .+?5!        $
 Close=?6.   $??Center=?6;   
???????$??Bottom=?6k   $??22??6?   $??29??6?   ?? 5"      $#??Отмена действия??6    $??Center=?67   
???????$??Center=?6g   5#      5$      5&      5(      5)      