   M S B A M L   `   `   `  ????F  BHeavensDoor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:HeavensDoor.Views.WindowsHeavensDoor.Views.Windows  5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5	   	   .    (HeavensDoor.Views.Windows.ConductSession   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:HeavensDoor.Views.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   a	ExceptionQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5	   	      MaterialDesignPaper#???   5
   	     MaterialDesignFont#???  5   	     ? Title$'  !Проведение сеанса??5   	   $	??496??6#   $
??1287??60    ?? BitmapScalingMode$ HighQuality=?6=    ? Icon$- '/Resourses/Spa_icon-icons.com_60006.png??6k   .??5   
   ??  ?? Orientation$ Vertical=?6   $??20q?6,   .+?5      ?? )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Тип сеанса??6   $??72??6C    ?? DisplayMemberPath$ Status??6Q    ?? 
IsReadOnly . $??	10,0,10,0q?6~   $??14(?5   8      
IsFloating . $??Bottom=?5       ?? SelectedItem 5   ?   ?? *SelectedStatus+??5      ?? *StatusSessions+5      ?? 5      $ 
Horizontal=?6   $??	10,0,10,0q?62   .+?5      (  "System.Windows.Controls.DatePicker  -   5        	  Name$	 DateSession??5      {?.  $??14(?6c   $ Дата сеанса??6q    ( $MaterialDesignFloatingHintDatePicker#??[ 6?   $??Bottom=?6?   $	??210??6?   
   SelectedDate
 6@   ?? *	DateTimes+6?   )  #MaterialDesignThemes.Wpf.TimePicker  5      -   5          Name$ TimeSession??5   ?   {?.  $??14(?6]   $??40,0,0,0q?6k   $ Время сеанса??6}   $??Bottom=?6?   $??34??6?   $	??210??6?      SelectedTime 6(   ?? *	DateTimes+6?   ?? 5      $	??210??6   $??	40,0,40,0q?6"   {?.  $+ %Выбранный сотрудник??6f   $??14(?6?    ?? 
IsReadOnly .  . $??Center=?6?   $??Bottom=?6  ??65   ?? *CurrentStaff+6  ?? 5      $	??210??6   $??0,0,40,0q?6"   $% Выбранный клиент??6S   $??14(?6?    .  . $??Center=?6?   $??Bottom=?6?   ??64   ?? *CurrentClient+6?   ?? 5      $	??210??6   $??0,0,40,0q?6"   $+ %Выбранная процедура??6V   $??14(?6?    .  . $??Center=?6?   $??Bottom=?6?   ??64   ?? *CurrentProcedure+6?   5      ?? 5      $??10q?6   $ 
Horizontal=?6%   .+?5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6N      
IsReadOnly . $	??320??6?   ???	#FF4CAF50$??3q?6?   $	??460??6
  ??6?   ?? *	Materials+ 6?   ?? *SelectedMaterial+ ? 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '        7 ?? 5       8   "  6Y   .?5!      ??  ? ?? ?	#FF4CAF506;   ?? 5"       ? ??
 ?????6;   5#      5$         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Материал??5(         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6'   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 5'      ?? *Name+5(   '     5)      $ В центре??5+      $	 100 6'    5*      ?? *CountMaterial+5+   '   5-      ?? 5.      $ Vertical=?6   $??	40,0,40,0q?64   .+?5/      ?? -   5         ??Name$ Select??5/      +
  %MaterialDesignThemes.Wpf.ButtonAssist 
  CornerRadius$ 10??6-   $	??Top=?6[   $??0,50,0,0q?6s   $	??210??6?     MaterialDesignRaisedButton#??[ 6?   .??50      ?? $ 
Horizontal=?6%   $	??180??6>   .+?51      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ PageLast=?52      $??22??53      $??29??54      $??Center=?6    
???????6=   ?? 55      $%??Выбрать материал??6$   $??Center=?6<   
???????$??Center=?6l   56      57      ?? 58      -   5        $ 
BackSelect??58      $ 10??61   $	??Top=?6_   $??0,10,0,0q?6w   $	??210??6?   #??[ 6?   .??59      ?? $ 
Horizontal=?6%   $	??180??6>   .+?5:        $ 	PageFirst=?62   $??22??6C   $??29??6O   $??Center=?6Z   
???????6w   ?? 5;      $#??Убрать материал??6$   $??Center=?6;   
???????$??Center=?6k   5<      5=      ?? 5>      -   5        $ SaveSession1??5>      $ 10??63   $??Bottom=?6a   $??	0,130,0,0q?6|   $	??210??6?   #??[ 6?   .??5?      ?? $ 
Horizontal=?6%   $	??180??6>   .+?5@        $ ContentSave=?66   $
??Left=?6I   
???????$??Bottom=?6w   $??22??6?   $??29??6?   ?? 5A      $'??!Подтвердить сеанс??6(   $??Center=?6A   
???????$??Center=?6q   5B      5C      ?? 5D      -   5        $
 Back??5D      $ 10??6'   $??0,10,0,0q?6U   $??Bottom=?6g   #??[ 6?   .??5E      ?? $ 
Horizontal=?6!   $	??180??6:   .+?5F        $ Close=?62   $??Center=?6?   
???????$??Bottom=?6o   $??22??6?   $??29??6?   ?? 5G      $#??Отмена действия??6$   $??Center=?6;   
???????$??Center=?6k   5H      5I      5K        5L       .   .  $ Hidden=?6N   $	??320??6?   ???	#FF4CAF50$??3q?6?   $	??460??6
  ??6s   ?? *MaterialForConduct+ 6?   ?? *SelectedMaterialForCoduct+ 5M      ??%?   '        7 ?? 5N      8   "  6U   .?5O      ??  ? ?? ?	#FF4CAF5067   ?? 5P       ? ??
 ?????67   5Q      5R       5S        5T         
IsReadOnly . $ Материал??5V      $ * 6'    5U      ?? *
NameM.Name+5V   '     5W       .  $# Будет потрачено??5Y      $	 140 6.    5X      ?? *Count+5Y   .   5[      5]      5_      5b      