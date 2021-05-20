
namespace Cambios
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_valor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_origem = new System.Windows.Forms.ComboBox();
            this.cb_destino = new System.Windows.Forms.ComboBox();
            this.btn_converter = new System.Windows.Forms.Button();
            this.lbl_resultado = new System.Windows.Forms.Label();
            this.lbl_status = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            // 
            // tb_valor
            // 
            this.tb_valor.Location = new System.Drawing.Point(88, 27);
            this.tb_valor.Name = "tb_valor";
            this.tb_valor.Size = new System.Drawing.Size(368, 23);
            this.tb_valor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(37, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Moeda de origem:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(37, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Moeda de destino:";
            // 
            // cb_origem
            // 
            this.cb_origem.FormattingEnabled = true;
            this.cb_origem.Location = new System.Drawing.Point(166, 73);
            this.cb_origem.Name = "cb_origem";
            this.cb_origem.Size = new System.Drawing.Size(290, 23);
            this.cb_origem.TabIndex = 4;
            // 
            // cb_destino
            // 
            this.cb_destino.FormattingEnabled = true;
            this.cb_destino.Location = new System.Drawing.Point(166, 125);
            this.cb_destino.Name = "cb_destino";
            this.cb_destino.Size = new System.Drawing.Size(290, 23);
            this.cb_destino.TabIndex = 5;
            // 
            // btn_converter
            // 
            this.btn_converter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_converter.Location = new System.Drawing.Point(37, 174);
            this.btn_converter.Name = "btn_converter";
            this.btn_converter.Size = new System.Drawing.Size(121, 29);
            this.btn_converter.TabIndex = 6;
            this.btn_converter.Text = "Converter";
            this.btn_converter.UseVisualStyleBackColor = true;
            // 
            // lbl_resultado
            // 
            this.lbl_resultado.AutoSize = true;
            this.lbl_resultado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_resultado.Location = new System.Drawing.Point(166, 180);
            this.lbl_resultado.Name = "lbl_resultado";
            this.lbl_resultado.Size = new System.Drawing.Size(290, 17);
            this.lbl_resultado.TabIndex = 7;
            this.lbl_resultado.Text = "Escolha um valor, moeda de origem e destino";
            // 
            // lbl_status
            // 
            this.lbl_status.AutoSize = true;
            this.lbl_status.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_status.Location = new System.Drawing.Point(37, 236);
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(46, 17);
            this.lbl_status.TabIndex = 8;
            this.lbl_status.Text = "Status";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(166, 236);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(290, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 289);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.lbl_resultado);
            this.Controls.Add(this.btn_converter);
            this.Controls.Add(this.cb_destino);
            this.Controls.Add(this.cb_origem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_valor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Câmbios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_valor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_origem;
        private System.Windows.Forms.ComboBox cb_destino;
        private System.Windows.Forms.Button btn_converter;
        private System.Windows.Forms.Label lbl_resultado;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

