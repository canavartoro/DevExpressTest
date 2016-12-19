namespace Solution1.Module.Web.Controllers
{
    partial class BelgeleriAcViewController
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
            this.actionBelgeAc = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // actionBelgeAc
            // 
            this.actionBelgeAc.Caption = "Belgeleri Aç";
            this.actionBelgeAc.Category = "View";
            this.actionBelgeAc.ConfirmationMessage = null;
            this.actionBelgeAc.Id = "actionBelgeAc";
            this.actionBelgeAc.ImageName = "Action_Search";
            this.actionBelgeAc.Shortcut = null;
            this.actionBelgeAc.Tag = null;
            this.actionBelgeAc.TargetObjectsCriteria = "Belgeler.Count() > 0";
            this.actionBelgeAc.TargetViewId = null;
            this.actionBelgeAc.ToolTip = "Tüm Belgeleri Aç";
            this.actionBelgeAc.TypeOfView = null;
            this.actionBelgeAc.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.actionBelgeAc_Execute);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction actionBelgeAc;
    }
}
