using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class TextBoxForm
    {
        public static void ShowText(string inputText, string caption)
        {
            Form listBoxForm = new Form();
            listBoxForm.Width = 640; listBoxForm.Height = 480;
            listBoxForm.Text = caption;
            TextBox textBox1 = new TextBox() { Left = 10, Top = 10};
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Width = 600;
            textBox1.Height = 400;
            Button confirmation = new Button() { Text = "Ok", Left = 270, Width = 100, Top = 410 };
            confirmation.Click += (sender, e) => { listBoxForm.Close(); };
            textBox1.Text = inputText;
            listBoxForm.Controls.Add(confirmation);
            listBoxForm.Controls.Add(textBox1);
            listBoxForm.Show();
        } 
    }
}
