// Updated by XamlIntelliSenseFileGenerator 26.05.2020 0:17:39
#pragma checksum "..\..\..\Pages\ProductsWeight.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "22D2139D2F1BF1326E05C0B5B3CDC9DC9CFC2A93E7F21C6843443C0BAA2675AA"
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


namespace KitchenBase.Pages
{


    /// <summary>
    /// ProductsWeight
    /// </summary>
    public partial class ProductsWeight : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 29 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btInsert;

#line default
#line hidden


#line 30 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btUpdate;

#line default
#line hidden


#line 31 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btDelete;

#line default
#line hidden


#line 35 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;

#line default
#line hidden


#line 38 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btSearch;

#line default
#line hidden


#line 39 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btFilter;

#line default
#line hidden


#line 40 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btCancel;

#line default
#line hidden


#line 42 "..\..\..\Pages\ProductsWeight.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgProductsWeight;

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
            System.Uri resourceLocater = new System.Uri("/KitchenBase;component/pages/productsweight.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Pages\ProductsWeight.xaml"
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
                    this.lblPosition = ((System.Windows.Controls.Label)(target));
                    return;
                case 2:
                    this.lblNamePostion = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.tbName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.btInsert = ((System.Windows.Controls.Button)(target));

#line 29 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btInsert.Click += new System.Windows.RoutedEventHandler(this.BtInsert_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btUpdate = ((System.Windows.Controls.Button)(target));

#line 30 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btUpdate.Click += new System.Windows.RoutedEventHandler(this.BtUpdate_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btDelete = ((System.Windows.Controls.Button)(target));

#line 31 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btDelete.Click += new System.Windows.RoutedEventHandler(this.BtDelete_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.tbSearch = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.btSearch = ((System.Windows.Controls.Button)(target));

#line 38 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btSearch.Click += new System.Windows.RoutedEventHandler(this.BtSearch_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.btFilter = ((System.Windows.Controls.Button)(target));

#line 39 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btFilter.Click += new System.Windows.RoutedEventHandler(this.BtFilter_Click);

#line default
#line hidden
                    return;
                case 10:
                    this.btCancel = ((System.Windows.Controls.Button)(target));

#line 40 "..\..\..\Pages\ProductsWeight.xaml"
                    this.btCancel.Click += new System.Windows.RoutedEventHandler(this.BtCancel_Click);

#line default
#line hidden
                    return;
                case 11:
                    this.dgProductsWeight = ((System.Windows.Controls.DataGrid)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Label lblProductWeight;
        internal System.Windows.Controls.Label lblProductWeightTitle;
        internal System.Windows.Controls.TextBox tbWeight;
    }
}

