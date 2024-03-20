using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vowels_and_Consonants {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }//end main window
        #region EVENTS
        private void btnVowelConsonant_Click(object sender, RoutedEventArgs e) {
            txtVowel.Visibility = Visibility.Visible;
            txtConsonant.Visibility = Visibility.Visible;
            labVowel.Visibility = Visibility.Visible;
            labConsonants.Visibility = Visibility.Visible;
            txtVowel.Text = FindVowel(txtMain.Text).ToString();
            txtConsonant.Text = HowManyConsonants(txtMain.Text).ToString();
        }//end event
        private void muiSave_Click(object sender, RoutedEventArgs e) {
            //create a save file dialog object
            SaveFileDialog sfdSave = new SaveFileDialog();
            //open th edialog and wait for the user to make a selection
            bool fileSelected = (bool)sfdSave.ShowDialog();
            if (fileSelected == true) {
                WriteTextToFile(sfdSave.FileName, txtMain.Text);
            }//end if
        }//end event
        #endregion
        // next section //
        #region METHODS/FUNCTION
        private void WriteTextToFile(string fileName, string text) {

            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }//end if

            FileStream outfile = new FileStream(fileName, FileMode.OpenOrCreate);


            char[] buffer = text.ToCharArray();
            char currentChar = '\0';
            byte writeData = 0;

            for (int index = 0; index < buffer.Length; index += 1) {
                currentChar = buffer[index];
                writeData = (byte)currentChar;
                outfile.WriteByte(writeData);
            }//end for
            outfile.Close();
        }//end function
        private int HowManyConsonants(string letter) {
            
            int numberOfVowels = 0;
            int numberOfConsonants = 0;
            for (int index = 0; index < letter.Length; index += 1) {
                numberOfVowels = FindVowel(letter);
            }//end for

                numberOfConsonants = letter.Length - numberOfVowels;

                if(numberOfConsonants <= 0) { 
                 return numberOfConsonants = 0;
            }//end if

            return numberOfConsonants;
        }//end function
        private int FindVowel(string letter) {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u'};
            char[] letters = letter.ToLower().ToCharArray();
            string vowel = "";

            for (int checkPosition = 0; checkPosition < letter.Length; checkPosition += 1) {
                for (int index = 0; index < vowels.GetLength(0); index += 1) {
                    if (letter.Length > checkPosition + index) {
                        char character1 = letters[checkPosition + index];
                        char character2 = vowels[index];

                        if (character2 == character1) {
                            vowel += character1;
                        }//end if
                    }//end if

                   
                }//end for
            }//end for
            return vowel.Length;
        }//end function
        #endregion
    }//end class
}//end namespace
