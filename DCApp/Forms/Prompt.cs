using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class Prompt { 
        public static string ShowDialog(string text, string caption) {
            Form prompt = new Form();
            prompt.Width = 300; prompt.Height = 150;
            prompt.Text = caption; Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            textLabel.Width = 200;
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 75, Width = 100, Top = 80 };
            confirmation.Click += (sender, e) => { prompt.Close();};
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
            } 
    } 
}
