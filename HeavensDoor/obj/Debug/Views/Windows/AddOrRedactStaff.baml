   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor0   *HeavensDoor.Views.Windows.AddOrRedactStaff   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   g	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignPaper#???   5	   	     MaterialDesignFont#???  5
   	     ? Title$,  &Работа с сотрудником??5   	   $	??290??6&   $	??774??62    ?? BitmapScalingMode$ HighQuality=?6?    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6m   .??5      ? .+?5   
   ??  ?? Orientation$ Vertical=?6   $??15q?6,   .+?5      ?? $??0,0,0,10q?6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия??6C   $??16(?6l      
IsFloating . ??6(   ?? *	FirstName+6{   ?? 5      $??0,0,0,10q?62   $ Имя??6D   $??16(?6i    . ??6   ?? *
MiddleName+6x   ?? 5      $??0,0,0,10q?6   $ Отчество??6B   $??16(?6l    . ??6(   ?? *
LastName+6{   ?? 5      $ Телефон??6   $??0,0,0,10q?6?   $??16(?6l    . ??6Q   ?? *	Telephone+6{   ?? 5      $??0,0,0,10q?6   $ 
Почта??6?   $??16(?6f    . ??6(   ?? *Email+6u   ?? 5      $??0,0,0,10q?6   $ 
Адрес??6@   $??16(?6g    . ??6(   ?? *Adress+6v   ?? 5      $??0,0,0,10q?6   $ Пол??6)   $??16(?6?    .  ?? SelectedItem 6N   ?? *Sex+??6k   ?? *Types+5      ?? 5      $??0,0,0,10q?6   $ Должность??6)    ?? DisplayMemberPath$
 Name??6?   $??16(?6?    .  6T   ?? *Post+??6r   ?? *PostStaffList+5      ?? 5      $??0,0,0,10q?6   $ Статус??6)   $
 Name??6?   $??16(?6?    .  6Q   ?? *Status+??6q   ?? *StatusStaffList+5      ?? 5      $??0,0,0,10q?6   $ 
Логин??6?   $??16(?6f    . ??6(   ?? *Login+6u   ?? 5      $??0,0,0,10q?6   $ Пароль??6B   $??16(?6j    . ??6(   ?? *
Password+6x   ?? 5      -   5         ??Name$ 	SaveSTAFF??5        MaterialDesignRaisedButton#??[ 6(   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 10??6]   $??0,0,0,15q?6?   $??32??6?   .??5       ?? $ 
Horizontal=?6   $	??180??66   .+?5!      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 AccountsCheck=?6.   
???????$??Center=?6V   $??22??6q   $??29??6}   ?? 5"      
???????$-??'Сохранить сотрудника??63   $
??Left=?6O   $??Center=?6j   5#      5$      ?? 5%      -   5        $ DelStaff??5%      $	 10??6'   #??[ 6U   $??32??6?   .??5&      ?? $ 
Horizontal=?6   $	??180??66   .+?5'        $
 AccountRemove=?6.   
???????$??Center=?6V   $??22??6q   $??29??6}   ?? 5(      $)??#Удалить сотрудника??6    
???????$
??Left=?6M   $??Center=?6h   5)      5*      ?? 5+      -   5        $
 Back??5+      $	 10??6#   $??0,10,0,0q?6Q   $??Bottom=?6c   #??[ 6~   .??5,      ?? $ 
Horizontal=?6   $	??180??66   .+?5-        $
 Close=?6.   $??Center=?6;   
???????$??Bottom=?6k   $??22??6?   $??29??6?   ?? 5.      $#??Отмена действия??6    $??Center=?67   
???????$??Center=?6g   5/      50      52      54      55      