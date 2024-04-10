namespace Tours
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBtnTours = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBtnHotels = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBtnOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаДанныхToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(633, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBtnTours,
            this.tsmiBtnHotels,
            this.tsmiBtnOrders});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.базаДанныхToolStripMenuItem.Text = "База данных";
            // 
            // tsmiBtnTours
            // 
            this.tsmiBtnTours.Name = "tsmiBtnTours";
            this.tsmiBtnTours.Size = new System.Drawing.Size(113, 22);
            this.tsmiBtnTours.Text = "Туры";
            this.tsmiBtnTours.Click += new System.EventHandler(this.tsmiBtnTours_Click);
            // 
            // tsmiBtnHotels
            // 
            this.tsmiBtnHotels.Name = "tsmiBtnHotels";
            this.tsmiBtnHotels.Size = new System.Drawing.Size(180, 22);
            this.tsmiBtnHotels.Text = "Отели";
            this.tsmiBtnHotels.Click += new System.EventHandler(this.tsmiBtnHotels_Click);
            // 
            // tsmiBtnOrders
            // 
            this.tsmiBtnOrders.Name = "tsmiBtnOrders";
            this.tsmiBtnOrders.Size = new System.Drawing.Size(180, 22);
            this.tsmiBtnOrders.Text = "Заказы";
            this.tsmiBtnOrders.Click += new System.EventHandler(this.tsmiBtnOrders_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 252);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(633, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssLblStatus
            // 
            this.tssLblStatus.Name = "tssLblStatus";
            this.tssLblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 274);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Главная форма";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiBtnTours;
        private System.Windows.Forms.ToolStripMenuItem tsmiBtnHotels;
        private System.Windows.Forms.ToolStripMenuItem tsmiBtnOrders;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssLblStatus;
    }
}