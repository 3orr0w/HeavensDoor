﻿#pragma checksum "..\..\..\Views\AddOrRedactProcedure.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "591445CC545CE86263B8D8AE23C270136A16BFF573F6F1ACDB89CE186D6217FC"
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
using MaterialDesignExtensions.Controls;
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
    /// ProcedureInfo
    /// </summary>
    public partial class ProcedureInfo : MaterialDesignExtensions.Controls.MaterialWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\..\Views\AddOrRedactProcedure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectMaterial;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\AddOrRedactProcedure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelMaterial;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\AddOrRedactProcedure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveProcedure;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Views\AddOrRedactProcedure.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelClient;
        
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
            System.Uri resourceLocater = new System.Uri("/HeavensDoor;component/views/addorredactprocedure.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AddOrRedactProcedure.xaml"
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
            this.SelectMaterial = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Views\AddOrRedactProcedure.xaml"
            this.SelectMaterial.Click += new System.Windows.RoutedEventHandler(this.SelectMaterial_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DelMaterial = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Views\AddOrRedactProcedure.xaml"
            this.DelMaterial.Click += new System.Windows.RoutedEventHandler(this.DelMaterial_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SaveProcedure = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\Views\AddOrRedactProcedure.xaml"
            this.SaveProcedure.Click += new System.Windows.RoutedEventHandler(this.SaveProcedure_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DelClient = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

