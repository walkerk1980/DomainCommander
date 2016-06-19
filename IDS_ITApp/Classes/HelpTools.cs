using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DomainCommander
{
    public class HelpTools
    {
        public List<string> ShowChangelog()
        {
            List<string> changelogList = new List<string>();

            string inputFilename = System.Windows.Forms.Application.StartupPath.ToString() + "\\Text\\Changelog.txt";
            try
            {
                if (File.Exists(inputFilename))
                {
                    using (StreamReader reader = new StreamReader(inputFilename))
                    {
                        if (!reader.EndOfStream)
                        {
                            
                            List<String> pcNameLines = new List<String>();
                            string currentLine;
                            while (!reader.EndOfStream)
                            {
                                currentLine = reader.ReadLine();
                                changelogList.Add(currentLine);
                                
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

            }

            return changelogList;
        }
    }
}
