﻿namespace OPC_Client.NET
{
    partial class frmOPCClient
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
            this.lBoxOPCServers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lBoxTags = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.lblTagName = new System.Windows.Forms.Label();
            this.lblTagValue = new System.Windows.Forms.Label();
            this.btnRefreshServer = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lBoxOPCServers
            // 
            this.lBoxOPCServers.FormattingEnabled = true;
            this.lBoxOPCServers.Location = new System.Drawing.Point(12, 54);
            this.lBoxOPCServers.Name = "lBoxOPCServers";
            this.lBoxOPCServers.Size = new System.Drawing.Size(201, 147);
            this.lBoxOPCServers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available OPC Servers ";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 225);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(111, 37);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lBoxTags
            // 
            this.lBoxTags.FormattingEnabled = true;
            this.lBoxTags.Location = new System.Drawing.Point(307, 54);
            this.lBoxTags.Name = "lBoxTags";
            this.lBoxTags.Size = new System.Drawing.Size(226, 147);
            this.lBoxTags.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available Tags in Server";
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(307, 225);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(111, 37);
            this.btnAddTag.TabIndex = 5;
            this.btnAddTag.Text = "Add Tag";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // lblTagName
            // 
            this.lblTagName.AutoSize = true;
            this.lblTagName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagName.Location = new System.Drawing.Point(115, 306);
            this.lblTagName.Name = "lblTagName";
            this.lblTagName.Size = new System.Drawing.Size(0, 16);
            this.lblTagName.TabIndex = 7;
            // 
            // lblTagValue
            // 
            this.lblTagValue.AutoSize = true;
            this.lblTagValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagValue.Location = new System.Drawing.Point(401, 306);
            this.lblTagValue.Name = "lblTagValue";
            this.lblTagValue.Size = new System.Drawing.Size(0, 16);
            this.lblTagValue.TabIndex = 9;
            // 
            // btnRefreshServer
            // 
            this.btnRefreshServer.Location = new System.Drawing.Point(219, 54);
            this.btnRefreshServer.Name = "btnRefreshServer";
            this.btnRefreshServer.Size = new System.Drawing.Size(82, 37);
            this.btnRefreshServer.TabIndex = 10;
            this.btnRefreshServer.Text = "Refresh Server List";
            this.btnRefreshServer.UseVisualStyleBackColor = true;
            this.btnRefreshServer.Click += new System.EventHandler(this.btnRefreshServer_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(121, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(271, 150);
            this.dataGridView1.TabIndex = 11;
            // 
            // frmOPCClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 458);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRefreshServer);
            this.Controls.Add(this.lblTagValue);
            this.Controls.Add(this.lblTagName);
            this.Controls.Add(this.btnAddTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lBoxTags);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lBoxOPCServers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOPCClient";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OPC .NET Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOPCClient_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lBoxOPCServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ListBox lBoxTags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.Label lblTagName;
        private System.Windows.Forms.Label lblTagValue;
        private System.Windows.Forms.Button btnRefreshServer;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

