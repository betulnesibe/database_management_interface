
namespace lawoffice_cet301final
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.programname_label = new System.Windows.Forms.Label();
            this.choosedb_btn = new System.Windows.Forms.Button();
            this.connection_panel = new System.Windows.Forms.Panel();
            this.connect_btn = new System.Windows.Forms.Button();
            this.databases_listbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.main_panel = new System.Windows.Forms.Panel();
            this.selecteddb_label = new System.Windows.Forms.Label();
            this.tables_label = new System.Windows.Forms.Label();
            this.tables_listbox = new System.Windows.Forms.ListBox();
            this.changedb_btn = new System.Windows.Forms.Button();
            this.changedisplay_panel = new System.Windows.Forms.Panel();
            this.ok_btn = new System.Windows.Forms.Button();
            this.execute_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.insert_btn = new System.Windows.Forms.Button();
            this.user_input = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contentdisplay_label = new System.Windows.Forms.Label();
            this.columndisplay_label = new System.Windows.Forms.Label();
            this.rowdisplay_label = new System.Windows.Forms.Label();
            this.connection_panel.SuspendLayout();
            this.main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // programname_label
            // 
            this.programname_label.AutoSize = true;
            this.programname_label.Font = new System.Drawing.Font("Broadway", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programname_label.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.programname_label.Location = new System.Drawing.Point(197, 41);
            this.programname_label.Name = "programname_label";
            this.programname_label.Size = new System.Drawing.Size(612, 58);
            this.programname_label.TabIndex = 0;
            this.programname_label.Text = "Law Office Database";
            // 
            // choosedb_btn
            // 
            this.choosedb_btn.Location = new System.Drawing.Point(390, 338);
            this.choosedb_btn.Name = "choosedb_btn";
            this.choosedb_btn.Size = new System.Drawing.Size(191, 110);
            this.choosedb_btn.TabIndex = 1;
            this.choosedb_btn.Text = "Choose Database";
            this.choosedb_btn.UseVisualStyleBackColor = true;
            // 
            // connection_panel
            // 
            this.connection_panel.Controls.Add(this.connect_btn);
            this.connection_panel.Controls.Add(this.databases_listbox);
            this.connection_panel.Controls.Add(this.label2);
            this.connection_panel.Location = new System.Drawing.Point(261, 233);
            this.connection_panel.Name = "connection_panel";
            this.connection_panel.Size = new System.Drawing.Size(520, 368);
            this.connection_panel.TabIndex = 2;
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(207, 305);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(113, 40);
            this.connect_btn.TabIndex = 2;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // databases_listbox
            // 
            this.databases_listbox.FormattingEnabled = true;
            this.databases_listbox.ItemHeight = 20;
            this.databases_listbox.Location = new System.Drawing.Point(115, 95);
            this.databases_listbox.Name = "databases_listbox";
            this.databases_listbox.Size = new System.Drawing.Size(291, 204);
            this.databases_listbox.TabIndex = 1;
            this.databases_listbox.SelectedIndexChanged += new System.EventHandler(this.Form1_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Available Databases";
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.selecteddb_label);
            this.main_panel.Controls.Add(this.tables_label);
            this.main_panel.Controls.Add(this.tables_listbox);
            this.main_panel.Controls.Add(this.changedb_btn);
            this.main_panel.Controls.Add(this.changedisplay_panel);
            this.main_panel.Controls.Add(this.ok_btn);
            this.main_panel.Controls.Add(this.execute_btn);
            this.main_panel.Controls.Add(this.delete_btn);
            this.main_panel.Controls.Add(this.update_btn);
            this.main_panel.Controls.Add(this.insert_btn);
            this.main_panel.Controls.Add(this.user_input);
            this.main_panel.Controls.Add(this.dataGridView1);
            this.main_panel.Controls.Add(this.contentdisplay_label);
            this.main_panel.Controls.Add(this.columndisplay_label);
            this.main_panel.Controls.Add(this.rowdisplay_label);
            this.main_panel.Location = new System.Drawing.Point(37, 115);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(940, 666);
            this.main_panel.TabIndex = 3;
            // 
            // selecteddb_label
            // 
            this.selecteddb_label.AutoSize = true;
            this.selecteddb_label.Location = new System.Drawing.Point(9, 21);
            this.selecteddb_label.Name = "selecteddb_label";
            this.selecteddb_label.Size = new System.Drawing.Size(146, 20);
            this.selecteddb_label.TabIndex = 14;
            this.selecteddb_label.Text = "Selected Database";
            // 
            // tables_label
            // 
            this.tables_label.AutoSize = true;
            this.tables_label.Location = new System.Drawing.Point(48, 346);
            this.tables_label.Name = "tables_label";
            this.tables_label.Size = new System.Drawing.Size(56, 20);
            this.tables_label.TabIndex = 13;
            this.tables_label.Text = "Tables";
            // 
            // tables_listbox
            // 
            this.tables_listbox.FormattingEnabled = true;
            this.tables_listbox.ItemHeight = 20;
            this.tables_listbox.Location = new System.Drawing.Point(10, 369);
            this.tables_listbox.Name = "tables_listbox";
            this.tables_listbox.Size = new System.Drawing.Size(148, 284);
            this.tables_listbox.TabIndex = 12;
            this.tables_listbox.SelectedIndexChanged += new System.EventHandler(this.tables_listbox_SelectedIndexChanged);
            // 
            // changedb_btn
            // 
            this.changedb_btn.Location = new System.Drawing.Point(23, 63);
            this.changedb_btn.Name = "changedb_btn";
            this.changedb_btn.Size = new System.Drawing.Size(105, 48);
            this.changedb_btn.TabIndex = 11;
            this.changedb_btn.Text = "Change Database";
            this.changedb_btn.UseVisualStyleBackColor = true;
            this.changedb_btn.Click += new System.EventHandler(this.changedb_btn_Click);
            // 
            // changedisplay_panel
            // 
            this.changedisplay_panel.Location = new System.Drawing.Point(280, 164);
            this.changedisplay_panel.Name = "changedisplay_panel";
            this.changedisplay_panel.Size = new System.Drawing.Size(461, 83);
            this.changedisplay_panel.TabIndex = 10;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(788, 181);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(109, 40);
            this.ok_btn.TabIndex = 9;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // execute_btn
            // 
            this.execute_btn.Location = new System.Drawing.Point(788, 59);
            this.execute_btn.Name = "execute_btn";
            this.execute_btn.Size = new System.Drawing.Size(109, 48);
            this.execute_btn.TabIndex = 8;
            this.execute_btn.Text = "Execute Select";
            this.execute_btn.UseVisualStyleBackColor = true;
            this.execute_btn.Click += new System.EventHandler(this.execute_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(615, 118);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(109, 40);
            this.delete_btn.TabIndex = 7;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.Location = new System.Drawing.Point(458, 118);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(109, 40);
            this.update_btn.TabIndex = 6;
            this.update_btn.Text = "Update";
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // insert_btn
            // 
            this.insert_btn.Location = new System.Drawing.Point(293, 118);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(109, 40);
            this.insert_btn.TabIndex = 5;
            this.insert_btn.Text = "Insert";
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // user_input
            // 
            this.user_input.Location = new System.Drawing.Point(280, 70);
            this.user_input.Name = "user_input";
            this.user_input.Size = new System.Drawing.Size(458, 26);
            this.user_input.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(186, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(751, 410);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // contentdisplay_label
            // 
            this.contentdisplay_label.AutoSize = true;
            this.contentdisplay_label.Location = new System.Drawing.Point(6, 223);
            this.contentdisplay_label.Name = "contentdisplay_label";
            this.contentdisplay_label.Size = new System.Drawing.Size(112, 20);
            this.contentdisplay_label.TabIndex = 2;
            this.contentdisplay_label.Text = "Content: None";
            // 
            // columndisplay_label
            // 
            this.columndisplay_label.AutoSize = true;
            this.columndisplay_label.Location = new System.Drawing.Point(9, 189);
            this.columndisplay_label.Name = "columndisplay_label";
            this.columndisplay_label.Size = new System.Drawing.Size(109, 20);
            this.columndisplay_label.TabIndex = 1;
            this.columndisplay_label.Text = "Column: None";
            // 
            // rowdisplay_label
            // 
            this.rowdisplay_label.AutoSize = true;
            this.rowdisplay_label.Location = new System.Drawing.Point(31, 153);
            this.rowdisplay_label.Name = "rowdisplay_label";
            this.rowdisplay_label.Size = new System.Drawing.Size(87, 20);
            this.rowdisplay_label.TabIndex = 0;
            this.rowdisplay_label.Text = "Row: None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1007, 825);
            this.Controls.Add(this.main_panel);
            this.Controls.Add(this.connection_panel);
            this.Controls.Add(this.choosedb_btn);
            this.Controls.Add(this.programname_label);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.connection_panel.ResumeLayout(false);
            this.connection_panel.PerformLayout();
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programname_label;
        private System.Windows.Forms.Button choosedb_btn;
        private System.Windows.Forms.Panel connection_panel;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.ListBox databases_listbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label rowdisplay_label;
        private System.Windows.Forms.Panel changedisplay_panel;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button execute_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button insert_btn;
        private System.Windows.Forms.TextBox user_input;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label contentdisplay_label;
        private System.Windows.Forms.Label columndisplay_label;
        private System.Windows.Forms.Button changedb_btn;
        private System.Windows.Forms.Label tables_label;
        private System.Windows.Forms.ListBox tables_listbox;
        private System.Windows.Forms.Label selecteddb_label;
    }
}

