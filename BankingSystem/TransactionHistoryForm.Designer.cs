
namespace BankingSystem
{
    partial class TransactionHistoryForm
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
            this.depositsList = new System.Windows.Forms.DataGridView();
            this.withdrawalsList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalDeposits = new System.Windows.Forms.Label();
            this.totalWithdrawals = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.depositsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdrawalsList)).BeginInit();
            this.SuspendLayout();
            // 
            // depositsList
            // 
            this.depositsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.depositsList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.depositsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.depositsList.Location = new System.Drawing.Point(31, 130);
            this.depositsList.Name = "depositsList";
            this.depositsList.RowHeadersWidth = 51;
            this.depositsList.RowTemplate.Height = 24;
            this.depositsList.Size = new System.Drawing.Size(525, 150);
            this.depositsList.TabIndex = 0;
            // 
            // withdrawalsList
            // 
            this.withdrawalsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.withdrawalsList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.withdrawalsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.withdrawalsList.Location = new System.Drawing.Point(591, 130);
            this.withdrawalsList.Name = "withdrawalsList";
            this.withdrawalsList.RowHeadersWidth = 51;
            this.withdrawalsList.Size = new System.Drawing.Size(525, 150);
            this.withdrawalsList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Deposits";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Total Deposits : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transactions History";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(586, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Withdrawals";
            // 
            // totalDeposits
            // 
            this.totalDeposits.AutoSize = true;
            this.totalDeposits.Location = new System.Drawing.Point(148, 311);
            this.totalDeposits.Name = "totalDeposits";
            this.totalDeposits.Size = new System.Drawing.Size(0, 17);
            this.totalDeposits.TabIndex = 6;
            // 
            // totalWithdrawals
            // 
            this.totalWithdrawals.AutoSize = true;
            this.totalWithdrawals.Location = new System.Drawing.Point(749, 311);
            this.totalWithdrawals.Name = "totalWithdrawals";
            this.totalWithdrawals.Size = new System.Drawing.Size(0, 17);
            this.totalWithdrawals.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(588, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total Withdrawals : ";
            // 
            // TransactionHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 400);
            this.Controls.Add(this.totalWithdrawals);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.totalDeposits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.withdrawalsList);
            this.Controls.Add(this.depositsList);
            this.Name = "TransactionHistoryForm";
            this.Text = "TransactionHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.depositsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdrawalsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView depositsList;
        private System.Windows.Forms.DataGridView withdrawalsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalDeposits;
        private System.Windows.Forms.Label totalWithdrawals;
        private System.Windows.Forms.Label label6;
    }
}