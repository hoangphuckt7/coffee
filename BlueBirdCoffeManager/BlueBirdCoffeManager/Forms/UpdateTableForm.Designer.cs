namespace BlueBirdCoffeManager.Forms
{
    partial class UpdateTableForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnResize = new System.Windows.Forms.RadioButton();
            this.btnMove = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddRec = new System.Windows.Forms.Button();
            this.btnAddElipse = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(776, 426);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(632, 411);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResize
            // 
            this.btnResize.AutoSize = true;
            this.btnResize.Location = new System.Drawing.Point(175, 415);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(111, 19);
            this.btnResize.TabIndex = 2;
            this.btnResize.TabStop = true;
            this.btnResize.Text = "Thay đổi kích cỡ";
            this.btnResize.UseVisualStyleBackColor = true;
            // 
            // btnMove
            // 
            this.btnMove.AutoSize = true;
            this.btnMove.Location = new System.Drawing.Point(292, 415);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(91, 19);
            this.btnMove.TabIndex = 3;
            this.btnMove.TabStop = true;
            this.btnMove.Text = "Dịch chuyển";
            this.btnMove.UseVisualStyleBackColor = true;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(389, 415);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(45, 19);
            this.rbDelete.TabIndex = 4;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Xóa";
            this.rbDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(713, 411);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddRec
            // 
            this.btnAddRec.Location = new System.Drawing.Point(611, 98);
            this.btnAddRec.Name = "btnAddRec";
            this.btnAddRec.Size = new System.Drawing.Size(123, 23);
            this.btnAddRec.TabIndex = 7;
            this.btnAddRec.Text = "Thêm bàn vuông";
            this.btnAddRec.UseVisualStyleBackColor = true;
            this.btnAddRec.Click += new System.EventHandler(this.btnAddRec_Click);
            // 
            // btnAddElipse
            // 
            this.btnAddElipse.Location = new System.Drawing.Point(611, 146);
            this.btnAddElipse.Name = "btnAddElipse";
            this.btnAddElipse.Size = new System.Drawing.Size(123, 23);
            this.btnAddElipse.TabIndex = 8;
            this.btnAddElipse.Text = "Thêm bàn tròn";
            this.btnAddElipse.UseVisualStyleBackColor = true;
            this.btnAddElipse.Click += new System.EventHandler(this.btnAddElipse_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(611, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 23);
            this.txtName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tên bàn";
            // 
            // UpdateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAddElipse);
            this.Controls.Add(this.btnAddRec);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.rbDelete);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pictureBox);
            this.Name = "UpdateTableForm";
            this.Text = "UpdateTableForm";
            this.Load += new System.EventHandler(this.UpdateTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox;
        private Button btnSave;
        private RadioButton btnResize;
        private RadioButton btnMove;
        private RadioButton rbDelete;
        private Button btnCancel;
        private Button btnAddRec;
        private Button btnAddElipse;
        private TextBox txtName;
        private Label label1;
    }
}