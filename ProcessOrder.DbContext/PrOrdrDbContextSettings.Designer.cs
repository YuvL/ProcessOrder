﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProcessOrder.DbContext {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class PrOrdrDbContextSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PrOrdrDbContextSettings defaultInstance = ((PrOrdrDbContextSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PrOrdrDbContextSettings())));
        
        public static PrOrdrDbContextSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|DbFileInstedOf" +
            "SQLServer.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityF" +
            "ramework")]
        public string ConnectionString {
            get {
                return ((string)(this["ConnectionString"]));
            }
            set {
                this["ConnectionString"] = value;
            }
        }
    }
}
