using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DomainCommander
{
    public class PCNameTools : CommonTools
    {
        public void AddToPCNameList(string profile, string pcname, string listPath)
        {
            if (PcNameIsNotNullOrVoid(pcname) && !string.IsNullOrEmpty(profile) && pcname.Length > 0 && profile.Length > 0)
            {
                string filename = listPath + profile + ".txt";
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        writer.WriteLine(pcname + Environment.NewLine);
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                        MessageBox.Show("Added " + profile + " to PC Name List.");
                    }
                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
            }
        }

        public void UpdatePCNamesList(string pcListPath)
        {
            /*Takes PC names and profile names from comma delimited text file (csv)
             * in the format exported by managing qls-dc for example and exporting
             * shared folder sessions by clicking export list and choosing .csv not .txt
             * saves data to folder specified by (pcListPath) in the format of
             * files named (username.Text).txt containing (pcname.Text)
             * csv file must have username before first comma deliminator and pcname between first and second
             * anything after second comma is ignored.
             */
            string inputFilename;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((inputFilename = openFileDialog1.FileName) != null)
                    {
                        using (StreamReader reader = new StreamReader(inputFilename))
                        {
                            if (!reader.EndOfStream)
                            {
                                int i = 0;
                                List<String> pcNameLines = new List<String>();
                                string line;
                                while (!reader.EndOfStream)
                                {
                                    line = reader.ReadLine();
                                    if (!line.Contains("192.168") && !line.Contains("mh-ts") && !line.Contains("vm-ts") && !line.Contains("mail") && !line.Contains("qcmc-ts") && !line.Contains("qe-ts") && !line.Contains("mh-ts".ToUpper()) && !line.Contains("vm-ts".ToUpper()) && !line.Contains("mail".ToUpper()) && !line.Contains("qcmc-ts".ToUpper()) && !line.Contains("qe-ts".ToUpper()))
                                    {
                                        pcNameLines.Add(line);
                                    }
                                    i++;
                                }
                                foreach (string s in pcNameLines)
                                {
                                    string proName = s.Substring(0, s.IndexOf(","));
                                    string pcsub = s.Substring(s.IndexOf(",") + 1);
                                    string pc = pcsub.Substring(0, pcsub.IndexOf(","));
                                    string filename = pcListPath + proName + ".txt";
                                    if (pc.Contains("domain.local"))
                                    {
                                        pc = pc.Substring(0, pc.IndexOf("."));
                                    }
                                    //MessageBox.Show(pc);
                                    using (StreamWriter writer = new StreamWriter(filename))
                                    {
                                        writer.WriteLine(pc + Environment.NewLine);
                                        writer.Flush();
                                        writer.Close();
                                        //MessageBox.Show("Added " + pcNameFromFile + " to PC Name List.");
                                        writer.Dispose();
                                    }
                                }
                            }

                            reader.Close();
                            reader.Dispose();
                        }

                    }

                }
                catch (IOException ioe)
                {
                    MessageBox.Show(ioe.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    openFileDialog1.Dispose();
                }
            }
        }

    }
}
