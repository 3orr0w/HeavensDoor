   M S B A M L   `   `   `  ????F  BHeavensDoor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:HeavensDoor.Views.PagesHeavensDoor.Views.Pages  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   5    /HeavensDoor.Views.Pages.ManagerPageMaterialInfo   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:HeavensDoor.Views.Pages     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	     N? Title$2  ,Информация о материалах??5	   	      MaterialDesignBody#???   5
   	     MaterialDesignPaper N? 
Background# ?  5   	     MaterialDesignFont N? 
FontFamily# ?  5   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??0* ?6   ?? 5      $
??471* ?6   ?? 5      $
??496* ?6   ?? 5      $
??233* ?6   ?? 5      $??0* ?6    ? RowDefinitions 5   
   ?? 5      $??86 ?6   ?? 5      .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $
??Left=?6I   $??5,0,0,0q?6d   $??1??6u   .+?5      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	DateStart??5      $??16(?6S   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$* $Дата начала периода??6a    ( $MaterialDesignFloatingHintDatePicker#??[ 6?   $??Bottom=?6?   $	??210??6?      SelectedDate 6,   ?? *DateTimeStart+6?     5      -   5        $ DateEnd??5      $??40,0,0,0q?6O   $??16(?6a   $( "Дата конца периода??6o   #??[ 6?   $??Bottom=?6?   $	??210??6?    6*   ?? *DateTimeEnd+6?   5      ?? 5   
   $??2??6   $??	0,28,0,21q?6%   .+?5      ?? -   5        	 ??Name$	 UpdateSchart??5      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10??6+   $	??210??6Y     MaterialDesignRaisedButton#??[ 6e   .??5       ?? $ 
Horizontal=?6   $	??180??66   .+?5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	Autorenew=?6.   
???????$??Center=?6R   $??22??6m   $??29??6y   ?? 5"      
???????$#??Обновить график??63   $??Center=?6J   $??Center=?6g   5#      5$      5&      ?? 5'   
   $ Vertical=?6   $??0,28,5,0q?6,   $	??Top=?6>   $??Right=?6V   $??3??6r   $??37??6?   $	??212??6?   .+?5(      ?? -   5        $	 CreatePDFMaterial??5(      $
 10??60   $??0,0,0,5q?6^   #??[ 6o   .??5)      ?? $ 
Horizontal=?6   $	??180??66   .+?5*        $ 	FileImage=?6.   
???????$??Center=?6R   $??22??6m   $??29??6y   ?? 5+      
???????$#??Составить отчет??63   $??Center=?6J   $??Center=?6g   5,      5-      5.      &   System.Windows.Controls.DataGrid  5/   
      AutoGenerateColumns .     CanUserSortColumns .  "   VerticalScrollBarVisibility$ Hidden=?6J      
IsReadOnly . $??1??6?   $??2??6?   $??5,0,0,0q?6?   ??6?   ?? *GraphicClassMaterials+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ Процедура??53   	      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 52   	   ?? *Procedure.Name+53        54      $ Количество??56   	   $ * 6    55   	   ?? *Count+56        57      $ Прибыль??59   	   $	 100 6    58   	   ?? *Cost+59       ? 	Resources 5;      =
  7System.Windows.Controls.Primitives.DataGridColumnHeader ?? BasedOn ?? 
TargetType ?? Property ?? Value??%?   '
        7
 ?? 5<      8   " 
 6Q   .?5=      ??  ? ?? ?	#FF4CAF5063   ?? 5>       ? ??
 ?????63   5?      5@      5A      ? 5B   
   $??2??6   $??5,0,10,0q?6   $??1??61   $??2??6>   .+?5C      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=?6E      Series 6!   ?? *SeriesCollection+   AxisY 5E        LiveCharts.Wpf.Axis     Title$+ %Количество процедур??6      MinValue$ 0Q?6;      LabelFormatter 6H   ?? *
YFormatter+   	Separator 5F        LiveCharts.Wpf.Separator  5G          Step$  1Q?6,   67   5I      !   AxisX! 5L        $ Дни??6    6+   ?? *DateTimeStartChart+ 6S   ?? *
XFormatter+5O      5Q      5R      5S      5T      