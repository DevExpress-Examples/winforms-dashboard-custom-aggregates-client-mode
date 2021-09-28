using System;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.Linq;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Globalization;

namespace Dashboard_StringConcatAggregate {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Office 2019 Colorful");
            CriteriaOperator.RegisterCustomFunction(new StringConcatFunction());
            Application.Run(new Form1());      
        }
    }
}
