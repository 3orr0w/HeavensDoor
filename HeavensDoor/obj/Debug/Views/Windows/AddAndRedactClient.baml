   M S B A M L   `   `   `  ????_  [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls  5   	    HeavensDoor2   ,HeavensDoor.Views.Windows.AddAndRedactClient   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   g	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     ? Title$&   Работа с клиентом??5   	   $	??487??6#   $	??290??60      MaterialDesignPaper#???   5
   	     MaterialDesignFont#???  5   	    ? WindowStartupLocation$ CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?6.    ?? BitmapScalingMode$ HighQuality=?6D    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6r   .??5      ??  ?? Orientation$ Vertical=?6   $??15q?6(   .+?5   
   ?? -   5         ??Name$ first??5      $??0,0,0,8q?6!   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Фамилия??6M   $??16(?6v      
IsFloating . ??62   ?? *	FirstName+6?   ?? 5   
   -   5        $ middle??5      $??0,0,0,8q?6?   $ Имя??6P   $??16(?6u    . ??6#   ?? *
MiddleName+6?   ?? 5   
   -   5        $
 last??5      $??0,0,0,8q?6    $ Отчество??6K   $??16(?6u    . ??61   ?? *
LastName+6?   ?? 5   
   $ Телефон??6   $??0,0,0,8q?6;   $??16(?6m    . ??6L   ?? *TelephoneClient+6|   ?? 5   
   -   5        $ email??5      $??0,0,0,8q?6!   $ 
Почта??6O   $??16(?6v    . ??62   ?? *EmailClient+6?   ?? 5   
   -   5        	 ??Name$		 sex??5      $??0,0,0,13q?6    $ Пол??62   $??16(?6?    . $??40??6?   
 ?? SelectedItem
 6W   ?? *	SexClient+??6z   ?? *Types+5      ?? 5   
   -   5         ??Name$ 
SaveClient??5        MaterialDesignRaisedButton#??[ 6%   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??6Z   $??0,0,0,10q?6?   .??5      ?? $	??180??6   $ 
Horizontal=?6%   .+?5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=?6*   
???????$??Center=?6P   $??22??6k   $??29??6w   ?? 5      
???????$'??!Сохранить клиента??6/   $
??Left=?6H   $??Center=?6c   5      5      ?? 5   
   -   5        $ 	DelClient??5      $ 10??6$   #??[ 6R   $??32??6?   ???	#DD000000.??5      ?? $	??180??6   $ 
Horizontal=?6%   .+?5        $ DeleteForever=?6*   
???????$??Center=?6R   $??22??6m   $??29??6y   ?? 5      $#??Удалить клиента??6   
???????$
??Left=?6F   $??Center=?6a   5       5!      ?? 5"   
   -   5        $
 Back??5"      $ 10??6   $??0,10,0,0q?6M   $??Bottom=?6_   #??[ 6z   .??5#      ?? $ 
Horizontal=?6   $	??180??62   .+?5$        $ Close=?6*   $??Center=?67   
???????$??Bottom=?6g   $??22??6?   $??29??6?   ?? 5%      $#??Отмена действия??6   $??Center=?63   
???????$??Center=?6c   5&      5'      5)      5*      