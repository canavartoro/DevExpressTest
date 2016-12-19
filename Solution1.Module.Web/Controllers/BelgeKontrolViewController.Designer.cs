namespace Solution1.Module.Web.Controllers
{
    partial class BelgeKontrolViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.actionKontrol = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.parametrizedAction1 = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
            // 
            // actionKontrol
            // 
            this.actionKontrol.Caption = "Kontrol Et";
            this.actionKontrol.Category = "Windows";
            this.actionKontrol.ConfirmationMessage = null;
            this.actionKontrol.Id = "actionKontrol";
            this.actionKontrol.ImageName = "BO_Task";
            this.actionKontrol.Shortcut = null;
            this.actionKontrol.Tag = null;
            this.actionKontrol.TargetObjectsCriteria = null;
            this.actionKontrol.TargetViewId = null;
            this.actionKontrol.ToolTip = "Belgeleri Kontrol Et";
            this.actionKontrol.TypeOfView = null;
            this.actionKontrol.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionKontrol_Execute);
            // 
            // parametrizedAction1
            // 
            this.parametrizedAction1.Caption = null;
            this.parametrizedAction1.ConfirmationMessage = null;
            this.parametrizedAction1.Id = "b1fe1eb2-6516-4cf4-ae9e-1e273818db76";
            this.parametrizedAction1.ImageName = null;
            this.parametrizedAction1.NullValuePrompt = null;
            this.parametrizedAction1.ShortCaption = null;
            this.parametrizedAction1.Shortcut = null;
            this.parametrizedAction1.Tag = null;
            this.parametrizedAction1.TargetObjectsCriteria = null;
            this.parametrizedAction1.TargetViewId = null;
            this.parametrizedAction1.ToolTip = null;
            this.parametrizedAction1.TypeOfView = null;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionKontrol;
        private DevExpress.ExpressApp.Actions.ParametrizedAction parametrizedAction1;
    }
}
