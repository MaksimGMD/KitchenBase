﻿#pragma checksum "..\..\..\Pages\DB_Configuration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B020B41F54D6986A63A25567F6046E019504D6864712F2FB946589EC0AD24B63"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KitchenBase.Pages;
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


namespace KitchenBase.Pages {
    
    
    /// <summary>
    /// DB_Configuration
    /// </summary>
    public partial class DB_Configuration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblServerName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbServerName;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDataBaseName;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDataBaseName;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btChecked;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btConnect;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\DB_Configuration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/KitchenBase;component/pages/db_configuration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\DB_Configuration.xaml"
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
            
            #line 8 "..\..\..\Pages\DB_Configuration.xaml"
            ((KitchenBase.Pages.DB_Configuration)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblServerName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cbServerName = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\Pages\DB_Configuration.xaml"
            this.cbServerName.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbServerName_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblDataBaseName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.cbDataBaseName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.btChecked = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\Pages\DB_Configuration.xaml"
            this.btChecked.Click += new System.Windows.RoutedEventHandler(this.btChecked_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btConnect = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\DB_Configuration.xaml"
            this.btConnect.Click += new System.Windows.RoutedEventHandler(this.btConnect_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btCancel = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Pages\DB_Configuration.xaml"
            this.btCancel.Click += new System.Windows.RoutedEventHandler(this.btCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
