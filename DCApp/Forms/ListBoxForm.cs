using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DomainCommander
{
    public class ListBoxForm
    {
        public static void ShowList(List<string> inputList, string caption)
        {
            Form listBoxForm = new Form();
            listBoxForm.Width = 640; listBoxForm.Height = 480;
            listBoxForm.Text = caption;
            ListBox listBox1 = new ListBox() { Left = 10, Top = 10};
            listBox1.Width = 600;
            listBox1.Height = 400;
            listBox1.HorizontalScrollbar = true;
            Button confirmation = new Button() { Text = "Ok", Left = 270, Width = 100, Top = 410 };
            confirmation.Click += (sender, e) => { listBoxForm.Close(); };
            listBox1.Items.AddRange(inputList.ToArray<string>());
            listBoxForm.Controls.Add(confirmation);
            listBoxForm.Controls.Add(listBox1);
            listBoxForm.Show();
        } 
    }
}
