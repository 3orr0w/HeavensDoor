// Updated by XamlIntelliSenseFileGenerator 15.06.2022 22:52:16
#pragma checksum "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "156F64F9E2ADAEE52712A430F551F14788327A4408F0B61ABD87681A28688218"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace HeavensDoor.Views.Windows
{


    /// <summary>
    /// AddOrRedactMaterial
    /// </summary>
    public partial class AddOrRedactMaterial : MaterialDesignExtensions.Controls.MaterialWindow, System.Windows.Markup.IComponentConnector
    {


#line 19 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveMaterial;

#line default
#line hidden


#line 25 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DelClient;

#line default
#line hidden


#line 31 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HeavensDoor;component/views/windows/addorredactmaterial.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.SaveMaterial = ((System.Windows.Controls.Button)(target));

#line 19 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
                    this.SaveMaterial.Click += new System.Windows.RoutedEventHandler(this.SaveMaterial_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.DelClient = ((System.Windows.Controls.Button)(target));

#line 25 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
                    this.DelClient.Click += new System.Windows.RoutedEventHandler(this.DelClient_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.Back = ((System.Windows.Controls.Button)(target));

#line 31 "..\..\..\..\Views\Windows\AddOrRedactMaterial.xaml"
                    this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox CountMaterialInForm;
    }
}
