﻿#pragma checksum "..\..\..\Views\StaffList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "66C32970FBDEC9C24AACEA86960D40462A5F3400442979726BF82AFCE76F9930"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HeavensDoor.Views;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HeavensDoor.Views {
    
    
    /// <summary>
    /// StaffList
    /// </summary>
    public partial class StaffList : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 66 "..\..\..\Views\StaffList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddStaff;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\Views\StaffList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RedactStaff;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\Views\StaffList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Previous;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\Views\StaffList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Next;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HeavensDoor;component/views/stafflist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\StaffList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 61 "..\..\..\Views\StaffList.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_2);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 62 "..\..\..\Views\StaffList.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.RadioButton_Checked_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddStaff = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\Views\StaffList.xaml"
            this.AddStaff.Click += new System.Windows.RoutedEventHandler(this.AddStaff_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RedactStaff = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Views\StaffList.xaml"
            this.RedactStaff.Click += new System.Windows.RoutedEventHandler(this.RedactStaff_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Previous = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\Views\StaffList.xaml"
            this.Previous.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Next = ((System.Windows.Controls.Button)(target));
            
            #line 126 "..\..\..\Views\StaffList.xaml"
            this.Next.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

