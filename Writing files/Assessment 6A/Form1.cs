using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Assessment_6A
{
    public partial class WritingFilesRandom : Form
    {

        public WritingFilesRandom()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //declare vaiables
                int startRange;
                int endRange;
                int quantityOfNumbers;
                //test if entries are empty
                if (txtBoxEndRange.Text == "" || txtBoxQuantityOfNumbers.Text == "" || txtBoxStartRange.Text == "")
                {
                    MessageBox.Show("Please enter a value! The text boxes can not be empty.");
                    txtBoxStartRange.Focus();
                    txtBoxEndRange.Focus();
                    txtBoxQuantityOfNumbers.Focus();
                }
                //if the textbox start range is not integer
                else if (!int.TryParse(txtBoxStartRange.Text, out startRange))
                {
                    MessageBox.Show("Please enter a valid value in the start Range textbox"); //show error message
                    txtBoxStartRange.Focus(); //focus on the txtbox start range
                }
                //if the textbox end range is not integer
                else if (!int.TryParse(txtBoxEndRange.Text, out endRange))
                {
                    MessageBox.Show("Please enter a valid value in the end Range textbox"); //show error message
                    txtBoxEndRange.Focus(); //focus on the txtbox end range
                }
                //if the txtBoxQuantityOfNumbers is not integer
                else if (!int.TryParse(txtBoxQuantityOfNumbers.Text, out quantityOfNumbers))
                {
                    MessageBox.Show("Please enter a valid value in the quantity of numbers textbox"); //show error message
                    txtBoxQuantityOfNumbers.Focus(); //focus on the txtBoxQuantityOfNumbers
                }
                //if all textboxes entries are valid then 
                else if (int.TryParse(txtBoxStartRange.Text, out startRange) && int.TryParse(txtBoxEndRange.Text, out endRange) && int.TryParse(txtBoxQuantityOfNumbers.Text, out quantityOfNumbers))
                {
                    //if the user enter a start range greater than the end range
                    if (startRange > endRange)
                    {
                        MessageBox.Show("The Start Range can not be greater than the End Range"); //show an error message
                        txtBoxStartRange.Focus(); //focus on the start range
                    }
                    else
                    {
                        //declare my variables
                        int randomNumber; //the random variable i am going to use for the random numbers
                        Random ran = new Random(); //using Random()


                        //set the default path for saving the file
                        String UN = Environment.UserName; //variable for the username
                        String FilePath = @"C:\Users\" + UN + @"\Documents\"; //concatinating the username with the path
                        saveFile.InitialDirectory = FilePath;
                        //add default extension
                        saveFile.DefaultExt = ".txt";
                        //show the dialogbox for saving the file
                       // saveFile.ShowDialog();
                        

                        // Declare a StreamWriter variable. 
                        StreamWriter outputFile;

                        if (saveFile.ShowDialog() == DialogResult.OK) //if the user click on save button
                        {
                            for (int i = 1; i <= quantityOfNumbers; i++)
                            {
                                // Create and append the selected file.
                                outputFile = File.AppendText(saveFile.FileName);
                                randomNumber = ran.Next(startRange, endRange); //use the random number between the start range and the end range
                                outputFile.WriteLine("Number " + i.ToString() + " and the random number is: " + randomNumber.ToString()); //write the lines in the file
                                // Close the file
                                outputFile.Close(); //
                            }
                            MessageBox.Show("Data generated and File saved successfully!");
                        }
                        else //if the user click on cancel button and didn't save any file
                        {
                            MessageBox.Show("Operation cancelled!");
                        }


                    }
                }
            }
            catch (Exception ex)
            { // Display an error message.
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxEndRange.Text = "";
            txtBoxQuantityOfNumbers.Text = "";
            txtBoxStartRange.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}