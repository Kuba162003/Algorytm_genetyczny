namespace Algorytm_genetyczny
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
            GeneratorBTN = new Button();
            InstanceBox = new TextBox();
            errors_label = new Label();
            label_k = new Label();
            label_maxLenght = new Label();
            textBox_maxLength = new TextBox();
            textBox_k = new TextBox();
            textBox_errors = new TextBox();
            Solution_label = new Label();
            minDistance_label = new Label();
            textBox_minDistance = new TextBox();
            comboBox_dlugosc = new ComboBox();
            SuspendLayout();
            // 
            // GeneratorBTN
            // 
            GeneratorBTN.Location = new Point(261, 203);
            GeneratorBTN.Name = "GeneratorBTN";
            GeneratorBTN.Size = new Size(94, 29);
            GeneratorBTN.TabIndex = 0;
            GeneratorBTN.Text = "Generuj";
            GeneratorBTN.UseVisualStyleBackColor = true;
            GeneratorBTN.Click += GeneratorBTN_Click;
            // 
            // InstanceBox
            // 
            InstanceBox.Location = new Point(12, 269);
            InstanceBox.Name = "InstanceBox";
            InstanceBox.Size = new Size(776, 27);
            InstanceBox.TabIndex = 1;
            // 
            // errors_label
            // 
            errors_label.AutoSize = true;
            errors_label.Location = new Point(40, 173);
            errors_label.Name = "errors_label";
            errors_label.Size = new Size(112, 20);
            errors_label.TabIndex = 3;
            errors_label.Text = "Liczba błędów: ";
            // 
            // label_k
            // 
            label_k.AutoSize = true;
            label_k.Location = new Point(40, 84);
            label_k.Name = "label_k";
            label_k.Size = new Size(70, 20);
            label_k.TabIndex = 4;
            label_k.Text = "Długość: ";
            // 
            // label_maxLenght
            // 
            label_maxLenght.AutoSize = true;
            label_maxLenght.Location = new Point(40, 114);
            label_maxLenght.Name = "label_maxLenght";
            label_maxLenght.Size = new Size(154, 20);
            label_maxLenght.TabIndex = 5;
            label_maxLenght.Text = "Maksymalna długość: ";
            // 
            // textBox_maxLength
            // 
            textBox_maxLength.Location = new Point(230, 111);
            textBox_maxLength.Name = "textBox_maxLength";
            textBox_maxLength.Size = new Size(125, 27);
            textBox_maxLength.TabIndex = 6;
            // 
            // textBox_k
            // 
            textBox_k.Location = new Point(230, 81);
            textBox_k.Name = "textBox_k";
            textBox_k.Size = new Size(125, 27);
            textBox_k.TabIndex = 7;
            // 
            // textBox_errors
            // 
            textBox_errors.Location = new Point(230, 170);
            textBox_errors.Name = "textBox_errors";
            textBox_errors.Size = new Size(125, 27);
            textBox_errors.TabIndex = 8;
            // 
            // Solution_label
            // 
            Solution_label.AutoSize = true;
            Solution_label.Location = new Point(12, 321);
            Solution_label.Name = "Solution_label";
            Solution_label.Size = new Size(50, 20);
            Solution_label.TabIndex = 9;
            Solution_label.Text = "label1";
            // 
            // minDistance_label
            // 
            minDistance_label.AutoSize = true;
            minDistance_label.Location = new Point(40, 144);
            minDistance_label.Name = "minDistance_label";
            minDistance_label.Size = new Size(152, 20);
            minDistance_label.TabIndex = 10;
            minDistance_label.Text = "Minimalne odległości";
            // 
            // textBox_minDistance
            // 
            textBox_minDistance.Location = new Point(230, 141);
            textBox_minDistance.Name = "textBox_minDistance";
            textBox_minDistance.Size = new Size(125, 27);
            textBox_minDistance.TabIndex = 11;
            // 
            // comboBox_dlugosc
            // 
            comboBox_dlugosc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_dlugosc.FormattingEnabled = true;
            comboBox_dlugosc.Items.AddRange(new object[] { "instancji", "rozwiązania" });
            comboBox_dlugosc.Location = new Point(104, 81);
            comboBox_dlugosc.Name = "comboBox_dlugosc";
            comboBox_dlugosc.Size = new Size(106, 28);
            comboBox_dlugosc.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox_dlugosc);
            Controls.Add(textBox_minDistance);
            Controls.Add(minDistance_label);
            Controls.Add(Solution_label);
            Controls.Add(textBox_errors);
            Controls.Add(textBox_k);
            Controls.Add(textBox_maxLength);
            Controls.Add(label_maxLenght);
            Controls.Add(label_k);
            Controls.Add(errors_label);
            Controls.Add(InstanceBox);
            Controls.Add(GeneratorBTN);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GeneratorBTN;
        private TextBox InstanceBox;
        private Label errors_label;
        private Label label_k;
        private Label label_maxLenght;
        private TextBox textBox_maxLength;
        private TextBox textBox_k;
        private TextBox textBox_errors;
        private Label Solution_label;
        private Label minDistance_label;
        private TextBox textBox_minDistance;
        private ComboBox comboBox_dlugosc;
    }
}
