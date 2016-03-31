using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace GradePerformancePredictorApplication
{
    public partial class MainForm : Form
    {
        String List = Directory.GetCurrentDirectory(); //Getting directory of database

        //Global Variable Declarations
        double totalFour;
        double markFour;
        double total;

        double markOne;
        double totalOne;

        double markTwo;
        double totalTwo;

        double markThree;
        double totalThree;
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //Code for Start page tab below 
        private void button1_Click(object sender, EventArgs e)
        {
            //Start Page
            String GetText = CourseTextBox.Text; //Get text from textbox

            //IF statemement to check if value is entered in the textbox
            if(GetText.Equals("")){

                MessageBox.Show("Please enter a Course");
            }

            else{
            //Else statement to redirect to Level 4/5/6 depending on selected radio button
            if (RedirectToLV4.Checked == true)
            {  
                tabControl1.SelectedTab = tabPage2;
            }

            if (RedirectToLV5.Checked == true)
            {
                tabControl1.SelectedTab = tabPage3;
            }

            if (RedirectToLV6.Checked == true)
            {
                tabControl1.SelectedTab = tabPage4;
            }
            
            //Setting text of label to text entered in textbox
            CourseNameLevel4.Text = "Your Course is " + GetText; 
            CourseNameLevel5.Text = "Your Course is " + GetText;
            CourseNameLevel6.Text = "Your Course is " + GetText;

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Setting Visibility
            OverallPerfomSum.Visible = false;
            OverallPerfomSumAuto.Visible = false;
            OverallGradeSumAuto.Visible = false;

            //Checking radio buttons by default
            SumLV4.Checked = true;
            RedirectToLV4.Checked = true;
           
            //LEVEL 4 Form Load

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation where Level = '4'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            //LEVEL 4 While Loop to extract Credit value and storing it in a total.
            //Also adding modules to listbox
            int getTotalCredit = 0;
            
            while (reader.Read())
            {
                ListOfModulesAdded.Items.Add(reader[0]);
                int getCredit = Convert.ToInt32(reader[2]);
                getTotalCredit = getTotalCredit + getCredit;
             
            }

            //Disabling buttons
            LevelFourSaveButton.Enabled = false;
            LevelFourVPG.Enabled = false;
            LevelFourVPG.Visible = false;

            ActualGrade.Checked = true; //Checking radio button by default

            //Showing total credits so far
            getCreditValue.Text = "You have entered modules worth " + getTotalCredit.ToString() + " credits so far";
            myconnection.Close(); // closing connection

            //Disabling buttons
            FailingLevel4.Enabled = false;
            AverageLevel4.Enabled = false;
            HighMarkLevel4.Enabled = false;

            //***********************************************************************//
            //LEVEL 5 Form Load
            //Connecting to the database
            SqlCeConnection myconnectionLV5 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV5.Open();

            //Query to execute in database
            String queryLV5 = "SELECT * FROM ModuleInformation where Level = '5'";
            //Query execution command
            SqlCeCommand createCommandLV5 = new SqlCeCommand(queryLV5, myconnectionLV5);
            //Reading from database
            SqlCeDataReader readerLV5 = createCommandLV5.ExecuteReader();

            //LEVEL 5 While Loop to extract Credit value and storing it in a total.
            //Also adding modules to listbox
            int getTotalCreditLV5 = 0;

            while (readerLV5.Read())
            {
                ListOfModulesAddedLevel5.Items.Add(readerLV5[0]);
                int getCreditlv5 = Convert.ToInt32(readerLV5[2]);
                getTotalCreditLV5 = getTotalCreditLV5 + getCreditlv5;

            }

            //Disabling buttons
            LevelFiveSaveButton.Enabled = false;
            LevelFiveVPG.Enabled = false;
            LevelFiveVPG.Visible = false;

            ActualGradeLV5.Checked = true; //Checking radio button by default

            //Showing total credits so far
            getCreditValueLV5.Text = "You have entered modules worth " + getTotalCreditLV5.ToString() + " credits so far";
            myconnectionLV5.Close(); //Closing Connection

            //Disabling buttons
            FailingLevel5.Enabled = false;
            AverageLevel5.Enabled = false;
            HighMarkLevel5.Enabled = false;

            //***********************************************************************//
            //LEVEL 6 Form Load
            //Connecting to the database
            SqlCeConnection myconnectionLV6 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV6.Open();

            //Query to execute in database
            String queryLV6 = "SELECT * FROM ModuleInformation where Level = '6'";
            //Query execution command
            SqlCeCommand createCommandLV6 = new SqlCeCommand(queryLV6, myconnectionLV6);
            //Reading from database
            SqlCeDataReader readerLV6 = createCommandLV6.ExecuteReader();

            //LEVEL 5 While Loop to extract Credit value and storing it in a total.
            //Also adding modules to listbox
            int getTotalCreditLV6 = 0;
            while (readerLV6.Read())
            {
                ListOfModulesAddedLevel6.Items.Add(readerLV6[0]);
                int getCreditlv6 = Convert.ToInt32(readerLV6[2]);
                getTotalCreditLV6 = getTotalCreditLV6 + getCreditlv6;

            }

            //Disabling buttons
            LevelSixSaveButton.Enabled = false;
            LevelSixVPG.Enabled = false;
            LevelSixVPG.Visible = false;
            DelButtonLevel4.Enabled = false;
            Level5DeleteButton.Enabled = false;

            ActualGradeLV6.Checked = true; //Checking radio button by default

            //Showing total credits so far
            getCreditValueLV6.Text = "You have entered modules worth " + getTotalCreditLV6.ToString() + " credits so far";
            myconnectionLV6.Close(); //Closing Connection

            //Disabling button
            FailingLevel6.Enabled = false;
            AverageLevel6.Enabled = false;
            HighMarkLevel6.Enabled = false; 
        }

        //Code for Level 4 tab below 
        private void AddButton_Click(object sender, EventArgs e)
        {
            //Level 4 Add Module Button

            //Connecting to the database
            SqlCeConnection myconnectionfour = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionfour.Open();

            //Query to execute in database
            String queryfour = "SELECT * FROM ModuleInformation where Level = '4'";

            //Query execution command
            SqlCeCommand createCommandthree = new SqlCeCommand(queryfour, myconnectionfour);

            //Reading from database
            SqlCeDataReader readerfour = createCommandthree.ExecuteReader();

            int getTotalCredit = 0;

            //LEVEL 4 While Loop to extract Credit value and storing it in a total.
            while (readerfour.Read())
            {
                int getCredit = Convert.ToInt32(readerfour[2]);
                getTotalCredit = getTotalCredit + getCredit;
            }

            //IF statement to check if the total credits is = 120
            if (getTotalCredit == 120)
            {

                AddButton.Enabled = false; //Disable button
                MessageBox.Show("You Have Already added modules worth 120 credits"); //Pop up message
                myconnectionfour.Close(); //Closing connection

            }
            else
            {
                //Open Add Module Form
                AddModuleForm AddModule = new AddModuleForm();
                AddModule.Activate();
                AddModule.ShowDialog();
                myconnectionfour.Close(); //Closing connection
            }

        }

        private void ListOfModulesAdded_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LEVEL 4 ListBox Method

            //Enabling buttons
            LevelFourSaveButton.Enabled = true;
            LevelFourVPG.Enabled = true;
            DelButtonLevel4.Enabled = true;

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation where Level = '4'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from the database
            SqlCeDataReader reader = createCommand.ExecuteReader();
            
            String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

            //LEVEL 4 While Loop to set assessment textbox values to null.
            //Also used to set number of assesssment textboxes to display.
            //Also used to set how many weighting labels to display.
            //Also used to set how many Fail/Average/High mark label to display.
            //Also used to set how many % labels to display.
                   while (reader.Read())
                   {
                       String checkModule = reader[0].ToString();

                       if (Moduleselected.Equals(checkModule))
                       {
                           AssessOneTextBox.Text = "";
                           AssessTwoTextBox.Text = "";
                           AssessThreeTextBox.Text = "";
                           AssessFourTextBox.Text = "";

                           //Reading from Column in database
                           ModuleAutoText.Text = reader[0].ToString();
                           ModuleCodeAutoText.Text = reader[1].ToString();
                           CreditAutoText.Text = reader[2].ToString();
                           NumAssessmentsAutoText.Text = reader[4].ToString();
                     
                           String CheckNum = NumAssessmentsAutoText.Text;

                           if (CheckNum.Equals("1"))
                           {
                               AssessmentOneAutoText.Text = reader[5].ToString();
                               WeightingOneAutoText.Text = "Weighting " + reader[9].ToString() + "%";
                               AssessOneTextBox.Visible = true;

                               AssessmentTwoAutoText.Text = "";
                               WeightingTwoAutoText.Text = "";
                               AssessTwoTextBox.Visible = false;

                               AssessmentThreeAutoText.Text = "";
                               WeightingThreeAutoText.Text = "";
                               AssessThreeTextBox.Visible = false;

                               AssessmentFourAutoText.Text = "";
                               WeightingFourAutoText.Text = "";
                               AssessFourTextBox.Visible = false;

                               label6.Text = "";
                               label7.Text = "";
                               label8.Text = "";

                               FAHAssess1L4.Visible = true;
                               FAHAssess2L4.Visible = false;
                               FAHAssess3L4.Visible = false;
                               FAHAssess4L4.Visible = false;
                           }


                           if (CheckNum.Equals("2"))
                           {
                               AssessmentOneAutoText.Text = reader[5].ToString();
                               WeightingOneAutoText.Text = "Weighting " + reader[9].ToString() + "%";
                               AssessOneTextBox.Visible = true;

                               AssessmentTwoAutoText.Text = reader[6].ToString();
                               WeightingTwoAutoText.Text = "Weighting " + reader[10].ToString() + "%";
                               AssessTwoTextBox.Visible = true;

                               AssessmentThreeAutoText.Text = "";
                               WeightingThreeAutoText.Text = "";
                               AssessThreeTextBox.Visible = false;

                               AssessmentFourAutoText.Text = "";
                               WeightingFourAutoText.Text = "";
                               AssessFourTextBox.Visible = false;

                               label6.Text = "%";
                               label7.Text = "";
                               label8.Text = "";

                               FAHAssess1L4.Visible = true;
                               FAHAssess2L4.Visible = true;
                               FAHAssess3L4.Visible = false;
                               FAHAssess4L4.Visible = false;
                           }

                           if (CheckNum.Equals("3"))
                           {
                               AssessmentOneAutoText.Text = reader[5].ToString();
                               WeightingOneAutoText.Text = "Weighting " + reader[9].ToString() + "%";
                               AssessOneTextBox.Visible = true;

                               AssessmentTwoAutoText.Text = reader[6].ToString();
                               WeightingTwoAutoText.Text = "Weighting " + reader[10].ToString() + "%";
                               AssessTwoTextBox.Visible = true;

                               AssessmentThreeAutoText.Text = reader[7].ToString();
                               WeightingThreeAutoText.Text = "Weighting " + reader[11].ToString() + "%";
                               AssessThreeTextBox.Visible = true;

                               AssessmentFourAutoText.Text = "";
                               WeightingFourAutoText.Text = "";
                               AssessFourTextBox.Visible = false;

                               label6.Text = "%";
                               label7.Text = "%";
                               label8.Text = "";

                               FAHAssess1L4.Visible = true;
                               FAHAssess2L4.Visible = true;
                               FAHAssess3L4.Visible = true;
                               FAHAssess4L4.Visible = false;
                           }

                           if (CheckNum.Equals("4"))
                           {
                               AssessmentOneAutoText.Text = reader[5].ToString();
                               WeightingOneAutoText.Text = "Weighting " +  reader[9].ToString() + "%";
                               AssessOneTextBox.Visible = true;

                               AssessmentTwoAutoText.Text = reader[6].ToString();
                               WeightingTwoAutoText.Text = "Weighting " + reader[10].ToString() + "%";
                               AssessTwoTextBox.Visible = true;

                               AssessmentThreeAutoText.Text = reader[7].ToString();
                               WeightingThreeAutoText.Text = "Weighting " +reader[11].ToString() + "%";
                               AssessThreeTextBox.Visible = true;

                               AssessmentFourAutoText.Text = reader[8].ToString();
                               WeightingFourAutoText.Text = "Weighting " + reader[12].ToString() + "%";
                               AssessFourTextBox.Visible = true;

                               label6.Text = "%";
                               label7.Text = "%";
                               label8.Text = "%";

                               FAHAssess1L4.Visible = true;
                               FAHAssess2L4.Visible = true;
                               FAHAssess3L4.Visible = true;
                               FAHAssess4L4.Visible = true;
                           }
                      
                       }
                  }

                   //Setting Fail/Average/High Mark labels to null everytime u click on another module.
                   FAHAssess1L4.Text = "";
                   FAHAssess2L4.Text = "";
                   FAHAssess3L4.Text = "";
                   FAHAssess4L4.Text = "";
                    
                   myconnection.Close(); //Closing Connection
        }

        private void LevelFourSaveButton_Click(object sender, EventArgs e)
        {
            //Level 4 Save grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from the database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also saves overall mark into database.
                //Also makes sure marks are not over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBox.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBox.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBox.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));

                        }

                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            //Validation to make sure marks are not over 100%
                            MessageBox.Show("Please enter a valid mark");
                        }
                        else
                        {
                            //Calculating Overall Mark
                            total = (totalOne + totalTwo + totalThree + totalFour);

                            String getModule = ModuleAutoText.Text.ToString();
                            String getModuleCode = ModuleCodeAutoText.Text.ToString();
                            String getMarkOne = totalOne.ToString();
                            String getMarkTwo = totalTwo.ToString();
                            String getMarkThree = totalThree.ToString();
                            String getMarkFour = totalFour.ToString();
                            String getAverage = total.ToString();
                            String CreditValue = CreditAutoText.Text.ToString();

                            SqlCeConnection myconnectiontwo = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                            myconnectiontwo.Open();
                            String querythree = "SELECT * FROM StudentGrades where Level = '4'";
                            SqlCeCommand createCommandthree = new SqlCeCommand(querythree, myconnectiontwo);
                            SqlCeDataReader readertwo = createCommandthree.ExecuteReader();

                            //While loop to check if mark isn't already entered for a specific module
                            bool checking = true;
                            while (readertwo.Read())
                            {

                                String checkModuleTwo = readertwo[0].ToString();
                                if (getModule.Equals(checkModuleTwo))
                                {

                                    MessageBox.Show(" You have already entered a mark for this module ");
                                    checking = false;
                                }
                            }

                            if (checking == true)
                            {
                                //Inserting into the database
                                String querytwo = "INSERT INTO StudentGrades (Module, ModuleCode, Level, MarkOne, MarkTwo, MarkThree, MarkFour, Average, Credit)"
                             + "VALUES (@Module, @ModuleCode, @Level, @MarkOne, @MarkTwo, @MarkThree, @MarkFour, @Average, @Credit)";

                                SqlCeCommand createCommandtwo = new SqlCeCommand(querytwo, myconnectiontwo);

                                createCommandtwo.Parameters.AddWithValue("@Module", getModule);
                                createCommandtwo.Parameters.AddWithValue("@ModuleCode", getModuleCode);
                                createCommandtwo.Parameters.AddWithValue("@Level", "4");
                                createCommandtwo.Parameters.AddWithValue("@MarkOne", getMarkOne);
                                createCommandtwo.Parameters.AddWithValue("@MarkTwo", getMarkTwo);
                                createCommandtwo.Parameters.AddWithValue("@MarkThree", getMarkThree);
                                createCommandtwo.Parameters.AddWithValue("@MarkFour", getMarkFour);
                                createCommandtwo.Parameters.AddWithValue("@Average", getAverage);
                                createCommandtwo.Parameters.AddWithValue("@Credit", CreditValue);

                                createCommandtwo.ExecuteNonQuery();

                                MessageBox.Show("Grades Saved!" + Environment.NewLine + "Your Average for this Module is " + total + " %");
                            }
                            myconnectiontwo.Close();
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); } 
        }

        private void LevelFourVPG_Click_1(object sender, EventArgs e)
        {
            //Level 4 View Predicted Grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from the database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check that marks aren't over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {
                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBox.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBox.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBox.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));
                        }


                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            //Validation to make sure marks are not over 100%
                            MessageBox.Show("Please enter a valid mark");
                        }
                        else
                        {
                            //Calculate Module Overall
                            total = (totalOne + totalTwo + totalThree + totalFour);
                            MessageBox.Show("Your Predicted Average for this Module is " + total + " %");
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); }
        }

        private void ActualGrade_CheckedChanged_1(object sender, EventArgs e)
        {
            //Level 4 Actual Grade Radio Button Method

            //Making labels visible    
            AFM.Visible = true;
            AFM2.Visible = true;
            LevelFourSaveButton.Visible = true; //Making button visible
            LevelFourVPG.Visible = false; //Making Button invisible
        }

        private void PredictedGrade_CheckedChanged_1(object sender, EventArgs e)
        {
            //Level 4 Predicted Grade Radio Button Method

            //Making labels invisible   
            AFM.Visible = false;
            AFM2.Visible = false;
            LevelFourSaveButton.Visible = false; //Making button invisible
            LevelFourVPG.Visible = true; //Making button visible
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Level 4 Delete Module Button

            String DeleteModule = ListOfModulesAdded.SelectedItem.ToString(); //Getting Selected Module from listbox

            //Connecting to the database
            SqlCeConnection myconnection7 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection7.Open();
            //Query to execute in database
            String query7 = @"DELETE FROM ModuleInformation where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand7 = new SqlCeCommand(query7, myconnection7);

            //Module to delete
            createCommand7.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand7.ExecuteNonQuery(); //Excecute Query
            myconnection7.Close(); //Close connection

            //Connecting to the database
            SqlCeConnection myconnection8 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection8.Open();
            //Query to execute in database
            String query8 = @"DELETE FROM StudentGrades where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand8 = new SqlCeCommand(query8, myconnection8);
            
            //Grades to delete according to Module
            createCommand8.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand8.ExecuteNonQuery(); //Excecute Query
            myconnection8.Close(); //Close connection

            MessageBox.Show("Module Deleted"); //Message shown to user when module is deleted
        }

        private void AssessOneTextBox_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment One Text Box

            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox
                
                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBox.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBox.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBox.Text = "";
                            AssessTwoTextBox.Text = "";
                            AssessThreeTextBox.Text = "";
                            AssessFourTextBox.Text = "";
                            FailingLevel4.Checked = false;
                            AverageLevel4.Checked = false;
                            HighMarkLevel4.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel4.Checked = true;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = true;
                                HighMarkLevel4.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = true;
                            }

                            if(markOne < 30){
                                FAHAssess1L4.Text = "Fail";
                                FAHAssess1L4.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkOne >= 30 && MarkOne < 40)
                            {

                                FAHAssess1L4.Text = "Referal";
                                FAHAssess1L4.ForeColor = System.Drawing.Color.Orange;
                            }

                           else if (MarkOne >= 40)
                            {
                                FAHAssess1L4.Text = "Passed";
                                FAHAssess1L4.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessTwoTextBox_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Two Text Box

            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBox.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBox.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }                   
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBox.Text = "";
                            AssessTwoTextBox.Text = "";
                            AssessThreeTextBox.Text = "";
                            AssessFourTextBox.Text = "";
                            FailingLevel4.Checked = false;
                            AverageLevel4.Checked = false;
                            HighMarkLevel4.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel4.Checked = true;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = true;
                                HighMarkLevel4.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = true;
                            }

                            if (markTwo < 30)
                            {
                                FAHAssess2L4.Text = "Fail";
                                FAHAssess2L4.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkTwo >= 30 && MarkTwo < 40)
                            {

                                FAHAssess2L4.Text = "Referal";
                                FAHAssess2L4.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkTwo >= 40)
                            {
                                FAHAssess2L4.Text = "Passed";
                                FAHAssess2L4.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessThreeTextBox_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Three Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.

                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBox.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBox.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }                          
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBox.Text = "";
                            AssessTwoTextBox.Text = "";
                            AssessThreeTextBox.Text = "";
                            AssessFourTextBox.Text = "";
                            FailingLevel4.Checked = false;
                            AverageLevel4.Checked = false;
                            HighMarkLevel4.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel4.Checked = true;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = true;
                                HighMarkLevel4.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = true;
                            }

                            if (markThree < 30)
                            {
                                FAHAssess3L4.Text = "Fail";
                                FAHAssess3L4.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkThree >= 30 && MarkThree < 40)
                            {

                                FAHAssess3L4.Text = "Referal";
                                FAHAssess3L4.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkThree >= 40)
                            {
                                FAHAssess3L4.Text = "Passed";
                                FAHAssess3L4.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessFourTextBox_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Four Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '4'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAdded.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 4 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoText.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoText.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBox.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBox.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBox.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBox.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBox.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBox.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBox.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBox.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBox.Text = "";
                            AssessTwoTextBox.Text = "";
                            AssessThreeTextBox.Text = "";
                            AssessFourTextBox.Text = "";
                            FailingLevel4.Checked = false;
                            AverageLevel4.Checked = false;
                            HighMarkLevel4.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel4.Checked = true;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = true;
                                HighMarkLevel4.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel4.Checked = false;
                                AverageLevel4.Checked = false;
                                HighMarkLevel4.Checked = true;
                            }

                            if (markFour < 30)
                            {
                                FAHAssess4L4.Text = "Fail";
                                FAHAssess4L4.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkFour >= 30 && MarkFour < 40)
                            {

                                FAHAssess4L4.Text = "Referal";
                                FAHAssess4L4.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkFour >= 40)
                            {
                                FAHAssess4L4.Text = "Passed";
                                FAHAssess4L4.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void RefreshLV4_Click(object sender, EventArgs e)
        {
            //Method for refreshing listbox in Level 4 tab

            ListOfModulesAdded.Items.Clear(); //Clearing ListBox

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation where Level = '4'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            //LEVEL 4 While Loop to add back modules to listbox
            while (reader.Read())
            {
                ListOfModulesAdded.Items.Add(reader[0]);
            }
        }

        //Code for Level 5 tab below 

        private void ListOfModulesAddedLevel5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LEVEL 5 ListBox Method

            //Enabling Buttons
            LevelFiveSaveButton.Enabled = true;
            LevelFiveVPG.Enabled = true;
            Level5DeleteButton.Enabled = true;

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();
            //Query execution command
            String query = "SELECT * FROM ModuleInformation where Level = '5'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

            //LEVEL 5 While Loop to set assessment textbox values to null.
            //Also used to set number of assesssment textboxes to display.
            //Also used to set how many weighting labels to display.
            //Also used to set how many Fail/Average/High mark label to display.
            //Also used to set how many % labels to display.

            while (reader.Read())
            {
                String checkModule = reader[0].ToString();

                if (Moduleselected.Equals(checkModule))
                {

                    AssessOneTextBoxLV5.Text = "";
                    AssessTwoTextBoxLV5.Text = "";
                    AssessThreeTextBoxLV5.Text = "";
                    AssessFourTextBoxLV5.Text = "";

                    ModuleAutoTextLV5.Text = reader[0].ToString();
                    ModuleCodeAutoTextLV5.Text = reader[1].ToString();
                    CreditAutoTextLV5.Text = reader[2].ToString();
                    NumAssessmentsAutoTextLV5.Text = reader[4].ToString();

                    String CheckNum = NumAssessmentsAutoTextLV5.Text;

                    if (CheckNum.Equals("1"))
                    {
                        AssessmentOneAutoTextLV5.Text = reader[5].ToString();
                        WeightingOneAutoTextLV5.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV5.Visible = true;

                        AssessmentTwoAutoTextLV5.Text = "";
                        WeightingTwoAutoTextLV5.Text = "";
                        AssessTwoTextBoxLV5.Visible = false;

                        AssessmentThreeAutoTextLV5.Text = "";
                        WeightingThreeAutoTextLV5.Text = "";
                        AssessThreeTextBoxLV5.Visible = false;

                        AssessmentFourAutoTextLV5.Text = "";
                        WeightingFourAutoTextLV5.Text = "";
                        AssessFourTextBoxLV5.Visible = false;

                        label18.Text = "";
                        label17.Text = "";
                        label16.Text = "";

                        FAHAssess1L5.Visible = true;
                        FAHAssess2L5.Visible = false;
                        FAHAssess3L5.Visible = false;
                        FAHAssess4L5.Visible = false;
                    }


                    if (CheckNum.Equals("2"))
                    {
                        AssessmentOneAutoTextLV5.Text = reader[5].ToString();
                        WeightingOneAutoTextLV5.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV5.Visible = true;

                        AssessmentTwoAutoTextLV5.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV5.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV5.Visible = true;

                        AssessmentThreeAutoTextLV5.Text = "";
                        WeightingThreeAutoTextLV5.Text = "";
                        AssessThreeTextBoxLV5.Visible = false;

                        AssessmentFourAutoTextLV5.Text = "";
                        WeightingFourAutoTextLV5.Text = "";
                        AssessFourTextBoxLV5.Visible = false;

                        label18.Text = "%";
                        label17.Text = "";
                        label16.Text = "";

                        FAHAssess1L5.Visible = true;
                        FAHAssess2L5.Visible = true;
                        FAHAssess3L5.Visible = false;
                        FAHAssess4L5.Visible = false;
                    }

                    if (CheckNum.Equals("3"))
                    {
                        AssessmentOneAutoTextLV5.Text = reader[5].ToString();
                        WeightingOneAutoTextLV5.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV5.Visible = true;

                        AssessmentTwoAutoTextLV5.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV5.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV5.Visible = true;

                        AssessmentThreeAutoTextLV5.Text = reader[7].ToString();
                        WeightingThreeAutoTextLV5.Text = "Weighting " + reader[11].ToString() + "%";
                        AssessThreeTextBoxLV5.Visible = true;

                        AssessmentFourAutoTextLV5.Text = "";
                        WeightingFourAutoTextLV5.Text = "";
                        AssessFourTextBoxLV5.Visible = false;

                        label18.Text = "%";
                        label17.Text = "%";
                        label16.Text = "";

                        FAHAssess1L5.Visible = true;
                        FAHAssess2L5.Visible = true;
                        FAHAssess3L5.Visible = true;
                        FAHAssess4L5.Visible = false;
                    }

                    if (CheckNum.Equals("4"))
                    {
                        AssessmentOneAutoTextLV5.Text = reader[5].ToString();
                        WeightingOneAutoTextLV5.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV5.Visible = true;

                        AssessmentTwoAutoTextLV5.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV5.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV5.Visible = true;

                        AssessmentThreeAutoTextLV5.Text = reader[7].ToString();
                        WeightingThreeAutoTextLV5.Text = "Weighting " + reader[11].ToString() + "%";
                        AssessThreeTextBoxLV5.Visible = true;

                        AssessmentFourAutoTextLV5.Text = reader[8].ToString();
                        WeightingFourAutoTextLV5.Text = "Weighting " + reader[12].ToString() + "%";
                        AssessFourTextBoxLV5.Visible = true;

                        label18.Text = "%";
                        label17.Text = "%";
                        label16.Text = "%";

                        FAHAssess1L5.Visible = true;
                        FAHAssess2L5.Visible = true;
                        FAHAssess3L5.Visible = true;
                        FAHAssess4L5.Visible = true;
                    }

                }
            }

            //Setting Fail/Average/High Mark labels to null everytime u click on another module.
            FAHAssess1L5.Text = "";
            FAHAssess2L5.Text = "";
            FAHAssess3L5.Text = "";
            FAHAssess4L5.Text = "";

            myconnection.Close(); //Closing connection.
        }

        private void AddButtonLevel5_Click(object sender, EventArgs e)
        {
            //Level 5 Add Module Button

            //Connecting to the database
            SqlCeConnection myconnectionfour = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionfour.Open();
            //Query to execute in database
            String queryfour = "SELECT * FROM ModuleInformation where Level = '5'";
            //Query execution command
            SqlCeCommand createCommandthree = new SqlCeCommand(queryfour, myconnectionfour);
            //Reading from database
            SqlCeDataReader readerfour = createCommandthree.ExecuteReader();

            int getTotalCredit = 0;

            //LEVEL 5 While Loop to extract Credit value and storing it in a total.
            while (readerfour.Read())
            {
                int getCredit = Convert.ToInt32(readerfour[2]);
                getTotalCredit = getTotalCredit + getCredit;
            }

            //IF statement to check if the total credits is = 120
            if (getTotalCredit == 120)
            {

                AddButtonLevel5.Enabled = false; //Disable button
                MessageBox.Show("You Have Already added modules worth 120 credits"); //Pop up message
                myconnectionfour.Close(); //Closing connection

            }
            else
            {
                //Open Add Module Form
                AddModuleFormLevel5 AddModuleLV5 = new AddModuleFormLevel5();
                AddModuleLV5.Activate();
                AddModuleLV5.ShowDialog();
                myconnectionfour.Close(); //Closing Connection
            }
        }

        private void ActualGradeLV5_CheckedChanged(object sender, EventArgs e)
        {
            //Level 5 Actual Grade Radio Button Method

            //Making labels visible    
            AFMLV5.Visible = true;
            AFM2LV5.Visible = true;
            LevelFiveSaveButton.Visible = true; //Making button visible
            LevelFiveVPG.Visible = false; //Making button invisible
        }

        private void PredictedGradelv5_CheckedChanged(object sender, EventArgs e)
        {
            //Level 5 Predicted Grade Radio Button Method

            //Making labels invisible   
            AFMLV5.Visible = false;
            AFM2LV5.Visible = false;
            LevelFiveSaveButton.Visible = false; //Making button invisible
            LevelFiveVPG.Visible = true; //Making button visible

        }

        private void LevelFiveVPG_Click(object sender, EventArgs e)
        {
            //Level 5 View Predicted Grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from the database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check that marks aren't over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));

                        }


                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            //Validation to make sure marks are not over 100%
                            MessageBox.Show("Please enter a valid mark");

                        }

                        else
                        {
                            //Calculating overall module mark
                            total = (totalOne + totalTwo + totalThree + totalFour);
                            MessageBox.Show("Your Predicted Average for this Module is " + total + " %");
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); }
        }

        private void LevelFiveSaveButton_Click(object sender, EventArgs e)
        {
            //Level 5 Save grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from the database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also saves overall mark into database.
                //Also makes sure marks are not over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));

                        }

                        //Validation to make sure marks are not over 100%
                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            MessageBox.Show("Please enter a valid mark");
                        }

                        else
                        {
                            //Calculate module overall mark
                            total = (totalOne + totalTwo + totalThree + totalFour);

                            String getModule = ModuleAutoTextLV5.Text.ToString();
                            String getModuleCode = ModuleCodeAutoTextLV5.Text.ToString();
                            String getMarkOne = totalOne.ToString();
                            String getMarkTwo = totalTwo.ToString();
                            String getMarkThree = totalThree.ToString();
                            String getMarkFour = totalFour.ToString();
                            String getAverage = total.ToString();
                            String CreditValue = CreditAutoTextLV5.Text.ToString();

                            SqlCeConnection myconnectiontwo = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                            myconnectiontwo.Open();

                            String querythree = "SELECT * FROM StudentGrades where Level = '5'";
                            SqlCeCommand createCommandthree = new SqlCeCommand(querythree, myconnectiontwo);
                            SqlCeDataReader readertwo = createCommandthree.ExecuteReader();

                            //While loop to check if mark isn't already entered for a specific module
                            bool checking = true;
                            while (readertwo.Read())
                            {

                                String checkModuleTwo = readertwo[0].ToString();
                                if (getModule.Equals(checkModuleTwo))
                                {

                                    MessageBox.Show(" You have already entered a mark for this module ");
                                    checking = false;
                                }
                            }

                            if (checking == true)
                            {
                                //Inserting into the database
                                String querytwo = "INSERT INTO StudentGrades (Module, ModuleCode, Level, MarkOne, MarkTwo, MarkThree, MarkFour, Average, Credit)"
                                 + "VALUES (@Module, @ModuleCode, @Level, @MarkOne, @MarkTwo, @MarkThree, @MarkFour, @Average, @Credit)";

                                SqlCeCommand createCommandtwo = new SqlCeCommand(querytwo, myconnectiontwo);

                                createCommandtwo.Parameters.AddWithValue("@Module", getModule);
                                createCommandtwo.Parameters.AddWithValue("@ModuleCode", getModuleCode);
                                createCommandtwo.Parameters.AddWithValue("@Level", "5");
                                createCommandtwo.Parameters.AddWithValue("@MarkOne", getMarkOne);
                                createCommandtwo.Parameters.AddWithValue("@MarkTwo", getMarkTwo);
                                createCommandtwo.Parameters.AddWithValue("@MarkThree", getMarkThree);
                                createCommandtwo.Parameters.AddWithValue("@MarkFour", getMarkFour);
                                createCommandtwo.Parameters.AddWithValue("@Average", getAverage);
                                createCommandtwo.Parameters.AddWithValue("@Credit", CreditValue);

                                createCommandtwo.ExecuteNonQuery();

                                MessageBox.Show("Grades Saved!" + Environment.NewLine + "Your Average for this Module is " + total + " %");
                            }
                            myconnectiontwo.Close();
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); }
        }

        private void Level5DeleteButton_Click(object sender, EventArgs e)
        {
            //Level 5 Delete Module Button

            String DeleteModule = ListOfModulesAddedLevel5.SelectedItem.ToString();  //Getting Selected Module from listbox

            //Connecting to the database
            SqlCeConnection myconnection7 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection7.Open();

            //Query to execute in database
            String query7 = @"DELETE FROM ModuleInformation where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand7 = new SqlCeCommand(query7, myconnection7);

            //Module to delete
            createCommand7.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand7.ExecuteNonQuery();
            myconnection7.Close(); //Closing Connection

            //Connecting to the database
            SqlCeConnection myconnection8 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection8.Open();

            //Query to execute in database
            String query8 = @"DELETE FROM StudentGrades where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand8 = new SqlCeCommand(query8, myconnection8);

            //Grades to delete according to Module
            createCommand8.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand8.ExecuteNonQuery(); //Executing Query
            myconnection8.Close(); //Closing Connection

            MessageBox.Show("Module Deleted"); //Message shown to user when module is deleted
        }

        private void AssessOneTextBoxLV5_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment One Text Box

            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV5.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV5.Text = "";
                            AssessTwoTextBoxLV5.Text = "";
                            AssessThreeTextBoxLV5.Text = "";
                            AssessFourTextBoxLV5.Text = "";
                            FailingLevel5.Checked = false;
                            AverageLevel5.Checked = false;
                            HighMarkLevel5.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel5.Checked = true;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = true;
                                HighMarkLevel5.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = true;
                            }

                            if (markOne < 30)
                            {
                                FAHAssess1L5.Text = "Fail";
                                FAHAssess1L5.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkOne >= 30 && MarkOne < 40)
                            {

                                FAHAssess1L5.Text = "Referal";
                                FAHAssess1L5.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkOne >= 40)
                            {
                                FAHAssess1L5.Text = "Passed";
                                FAHAssess1L5.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessTwoTextBoxLV5_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Two Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV5.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV5.Text = "";
                            AssessTwoTextBoxLV5.Text = "";
                            AssessThreeTextBoxLV5.Text = "";
                            AssessFourTextBoxLV5.Text = "";
                            FailingLevel5.Checked = false;
                            AverageLevel5.Checked = false;
                            HighMarkLevel5.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel5.Checked = true;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = true;
                                HighMarkLevel5.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = true;
                            }

                            if (markTwo < 30)
                            {
                                FAHAssess2L5.Text = "Fail";
                                FAHAssess2L5.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkTwo >= 30 && MarkTwo < 40)
                            {

                                FAHAssess2L5.Text = "Referal";
                                FAHAssess2L5.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkTwo >= 40)
                            {
                                FAHAssess2L5.Text = "Passed";
                                FAHAssess2L5.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessThreeTextBoxLV5_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Three Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV5.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV5.Text = "";
                            AssessTwoTextBoxLV5.Text = "";
                            AssessThreeTextBoxLV5.Text = "";
                            AssessFourTextBoxLV5.Text = "";
                            FailingLevel5.Checked = false;
                            AverageLevel5.Checked = false;
                            HighMarkLevel5.Checked = false;

                        }
                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel5.Checked = true;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = true;
                                HighMarkLevel5.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = true;
                            }

                            if (markThree < 30)
                            {
                                FAHAssess3L5.Text = "Fail";
                                FAHAssess3L5.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkThree >= 30 && MarkThree < 40)
                            {

                                FAHAssess3L5.Text = "Referal";
                                FAHAssess3L5.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkThree >= 40)
                            {
                                FAHAssess3L5.Text = "Passed";
                                FAHAssess3L5.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessFourTextBoxLV5_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Four Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel5.Text;  //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 5 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV5.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV5.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV5.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV5.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV5.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV5.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV5.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV5.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV5.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV5.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV5.Text = "";
                            AssessTwoTextBoxLV5.Text = "";
                            AssessThreeTextBoxLV5.Text = "";
                            AssessFourTextBoxLV5.Text = "";
                            FailingLevel5.Checked = false;
                            AverageLevel5.Checked = false;
                            HighMarkLevel5.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel5.Checked = true;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = true;
                                HighMarkLevel5.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel5.Checked = false;
                                AverageLevel5.Checked = false;
                                HighMarkLevel5.Checked = true;
                            }

                            if (markFour < 30)
                            {
                                FAHAssess4L5.Text = "Fail";
                                FAHAssess4L5.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkFour >= 30 && MarkFour < 40)
                            {

                                FAHAssess4L5.Text = "Referal";
                                FAHAssess4L5.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkFour >= 40)
                            {
                                FAHAssess4L5.Text = "Passed";
                                FAHAssess4L5.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void RefreshLV5_Click(object sender, EventArgs e)
        {
            //Method for refreshing listbox in Level 5 tab

            ListOfModulesAddedLevel5.Items.Clear(); //Clearing ListBox

            //Connecting to the database
            SqlCeConnection myconnectionLV5 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV5.Open();

            //Query to execute in database
            String queryLV5 = "SELECT * FROM ModuleInformation where Level = '5'";
            //Query execution command
            SqlCeCommand createCommandLV5 = new SqlCeCommand(queryLV5, myconnectionLV5);
            //Reading from database
            SqlCeDataReader readerLV5 = createCommandLV5.ExecuteReader();

            //LEVEL 5 While Loop to add back modules to listbox
            while (readerLV5.Read())
            {
                ListOfModulesAddedLevel5.Items.Add(readerLV5[0]);
            }
        }

        //Code for Level 6 tab below 

        private void ListOfModulesAddedLevel6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LEVEL 6 ListBox Method

            //Enabling Buttons
            LevelSixSaveButton.Enabled = true;
            LevelSixVPG.Enabled = true;
            Level6DeleteButton.Enabled = true;

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation where Level = '6'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

            //LEVEL 6 While Loop to set assessment textbox values to null.
            //Also used to set number of assesssment textboxes to display.
            //Also used to set how many weighting labels to display.
            //Also used to set how many Fail/Average/High mark label to display.
            //Also used to set how many % labels to display.
            while (reader.Read())
            {
                String checkModule = reader[0].ToString();

                if (Moduleselected.Equals(checkModule))
                {

                    AssessOneTextBoxLV6.Text = "";
                    AssessTwoTextBoxLV6.Text = "";
                    AssessThreeTextBoxLV6.Text = "";
                    AssessFourTextBoxLV6.Text = "";

                    ModuleAutoTextLV6.Text = reader[0].ToString();
                    ModuleCodeAutoTextLV6.Text = reader[1].ToString();
                    CreditAutoTextLV6.Text = reader[2].ToString();
                    NumAssessmentsAutoTextLV6.Text = reader[4].ToString();

                    String CheckNum = NumAssessmentsAutoTextLV6.Text;

                    if (CheckNum.Equals("1"))
                    {
                        AssessmentOneAutoTextLV6.Text = reader[5].ToString();
                        WeightingOneAutoTextLV6.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV6.Visible = true;

                        AssessmentTwoAutoTextLV6.Text = "";
                        WeightingTwoAutoTextLV6.Text = "";
                        AssessTwoTextBoxLV6.Visible = false;

                        AssessmentThreeAutoTextLV6.Text = "";
                        WeightingThreeAutoTextLV6.Text = "";
                        AssessThreeTextBoxLV6.Visible = false;

                        AssessmentFourAutoTextLV6.Text = "";
                        WeightingFourAutoTextLV6.Text = "";
                        AssessFourTextBoxLV6.Visible = false;

                        label23.Text = "";
                        label22.Text = "";
                        label21.Text = "";
                    }


                    if (CheckNum.Equals("2"))
                    {
                        AssessmentOneAutoTextLV6.Text = reader[5].ToString();
                        WeightingOneAutoTextLV6.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV6.Visible = true;

                        AssessmentTwoAutoTextLV6.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV6.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV6.Visible = true;

                        AssessmentThreeAutoTextLV6.Text = "";
                        WeightingThreeAutoTextLV6.Text = "";
                        AssessThreeTextBoxLV6.Visible = false;

                        AssessmentFourAutoTextLV6.Text = "";
                        WeightingFourAutoTextLV6.Text = "";
                        AssessFourTextBoxLV6.Visible = false;

                        label23.Text = "%";
                        label22.Text = "";
                        label21.Text = "";
                    }

                    if (CheckNum.Equals("3"))
                    {
                        AssessmentOneAutoTextLV6.Text = reader[5].ToString();
                        WeightingOneAutoTextLV6.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV6.Visible = true;

                        AssessmentTwoAutoTextLV6.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV6.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV6.Visible = true;

                        AssessmentThreeAutoTextLV6.Text = reader[7].ToString();
                        WeightingThreeAutoTextLV6.Text = "Weighting " + reader[11].ToString() + "%";
                        AssessThreeTextBoxLV6.Visible = true;

                        AssessmentFourAutoTextLV6.Text = "";
                        WeightingFourAutoTextLV6.Text = "";
                        AssessFourTextBoxLV6.Visible = false;

                        label23.Text = "%";
                        label22.Text = "%";
                        label21.Text = "";
                    }

                    if (CheckNum.Equals("4"))
                    {
                        AssessmentOneAutoTextLV6.Text = reader[5].ToString();
                        WeightingOneAutoTextLV6.Text = "Weighting " + reader[9].ToString() + "%";
                        AssessOneTextBoxLV6.Visible = true;

                        AssessmentTwoAutoTextLV6.Text = reader[6].ToString();
                        WeightingTwoAutoTextLV6.Text = "Weighting " + reader[10].ToString() + "%";
                        AssessTwoTextBoxLV6.Visible = true;

                        AssessmentThreeAutoTextLV6.Text = reader[7].ToString();
                        WeightingThreeAutoTextLV6.Text = "Weighting " + reader[11].ToString() + "%";
                        AssessThreeTextBoxLV6.Visible = true;

                        AssessmentFourAutoTextLV6.Text = reader[8].ToString();
                        WeightingFourAutoTextLV6.Text = "Weighting " + reader[12].ToString() + "%";
                        AssessFourTextBoxLV6.Visible = true;

                        label23.Text = "%";
                        label22.Text = "%";
                        label21.Text = "%";
                    }

                }
            }

            //Setting Fail/Average/High Mark labels to null everytime u click on another module.
            FAHAssess1L6.Text = "";
            FAHAssess2L6.Text = "";
            FAHAssess3L6.Text = "";
            FAHAssess4L6.Text = "";

            myconnection.Close(); //Closing connection
        }

        private void AddButtonLevel6_Click(object sender, EventArgs e)
        {
            //Level 6 Add Module Button

            //Connecting to the database
            SqlCeConnection myconnectionfour = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionfour.Open();

            //Query to execute in database
            String queryfour = "SELECT * FROM ModuleInformation where Level = '6'";
            //Query execution command
            SqlCeCommand createCommandthree = new SqlCeCommand(queryfour, myconnectionfour);
            //Reading from database
            SqlCeDataReader readerfour = createCommandthree.ExecuteReader();

            int getTotalCredit = 0;

            //LEVEL 5 While Loop to extract Credit value and storing it in a total.
            while (readerfour.Read())
            {
                int getCredit = Convert.ToInt32(readerfour[2]);
                getTotalCredit = getTotalCredit + getCredit;
            }

            //IF statement to check if the total credits is = 120
            if (getTotalCredit == 120)
            {

                AddButtonLevel6.Enabled = false; //Disable button
                MessageBox.Show("You Have Already added modules worth 120 credits"); //Pop up message
                myconnectionfour.Close(); //Closing connection

            }
            else
            {
                //Open Add Module Form
                AddModuleFormLevel6 AddModuleLV6 = new AddModuleFormLevel6();
                AddModuleLV6.Activate();
                AddModuleLV6.ShowDialog();
                myconnectionfour.Close(); //Closing connection
            }
        }

        private void ActualGradeLV6_CheckedChanged(object sender, EventArgs e)
        {
            //Level 6 Actual Grade Radio Button Method

            //Making labels visible   
            AFMLV6.Visible = true;
            AFMV6.Visible = true;
            LevelSixSaveButton.Visible = true;  //Making button visible
            LevelSixVPG.Visible = false;  //Making button invisible
        }

        private void PredictedGradelv6_CheckedChanged(object sender, EventArgs e)
        {
            //Level 6 Predicted Grade Radio Button Method

            //Making labels visible  
            AFMLV6.Visible = false;
            AFMV6.Visible = false;
            LevelSixSaveButton.Visible = false; //Making button invisible
            LevelSixVPG.Visible = true; //Making button visible
        }

        private void LevelSixVPG_Click(object sender, EventArgs e)
        {
            //Level 6 View Predicted Grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {

                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check that marks aren't over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));

                        }

                        //Validation to make sure marks are not over 100%
                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            MessageBox.Show("Please enter a valid mark");
                        }

                        else
                        {
                            //Calculating overall module mark
                            total = (totalOne + totalTwo + totalThree + totalFour);
                            MessageBox.Show("Your Predicted Average for this Module is " + total + " %");
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); }
        }

        private void LevelSixSaveButton_Click(object sender, EventArgs e)
        {
            //Level 6 Save grades Method

            //Try used so if appropriate module grades are not entered then a popup window is shown when catched.
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also saves overall mark into database.
                //Also makes sure marks are not over 100%
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            //Calculations to do if number of assessments equals 1
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = 0;
                            totalTwo = 0;

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;

                        }

                        if (CheckNum.Equals("2"))
                        {
                            //Calculations to do if number of assessments equals 2
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = 0;
                            totalThree = 0;

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("3"))
                        {
                            //Calculations to do if number of assessments equals 3
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = 0;
                            totalFour = 0;
                        }

                        if (CheckNum.Equals("4"))
                        {
                            //Calculations to do if number of assessments equals 4
                            markOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            totalOne = (markOne * (WeightingOne / 100));

                            markTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                            double WeightingTwo = Convert.ToDouble(reader[10]);
                            totalTwo = (markTwo * (WeightingTwo / 100));

                            markThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                            double WeightingThree = Convert.ToDouble(reader[11]);
                            totalThree = (markThree * (WeightingThree / 100));

                            markFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                            double WeightingFour = Convert.ToDouble(reader[12]);
                            totalFour = (markFour * (WeightingFour / 100));

                        }

                        //Validation to make sure marks are not over 100%
                        if (markOne > 100.0 || markTwo > 100.0 || markThree > 100 || markFour > 100)
                        {
                            MessageBox.Show("Please enter a valid mark");
                        }

                        else
                        {
                            //Calculating module overall mark
                            total = (totalOne + totalTwo + totalThree + totalFour);

                            String getModule = ModuleAutoTextLV6.Text.ToString();
                            String getModuleCode = ModuleCodeAutoTextLV6.Text.ToString();
                            String getMarkOne = totalOne.ToString();
                            String getMarkTwo = totalTwo.ToString();
                            String getMarkThree = totalThree.ToString();
                            String getMarkFour = totalFour.ToString();
                            String getAverage = total.ToString();
                            String CreditValue = CreditAutoTextLV6.Text.ToString();

                            SqlCeConnection myconnectiontwo = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                            myconnectiontwo.Open();

                            String querythree = "SELECT * FROM StudentGrades where Level = '6'";
                            SqlCeCommand createCommandthree = new SqlCeCommand(querythree, myconnectiontwo);
                            SqlCeDataReader readertwo = createCommandthree.ExecuteReader();

                            //While loop to check if mark isn't already entered for a specific module
                            bool checking = true;
                            while (readertwo.Read())
                            {

                                String checkModuleTwo = readertwo[0].ToString();
                                if (getModule.Equals(checkModuleTwo))
                                {

                                    MessageBox.Show(" You have already entered a mark for this module ");
                                    checking = false;
                                }
                            }

                            if (checking == true)
                            {
                                //Inserting into the database
                                String querytwo = "INSERT INTO StudentGrades (Module, ModuleCode, Level, MarkOne, MarkTwo, MarkThree, MarkFour, Average, Credit)"
                                 + "VALUES (@Module, @ModuleCode, @Level, @MarkOne, @MarkTwo, @MarkThree, @MarkFour, @Average, @Credit)";

                                SqlCeCommand createCommandtwo = new SqlCeCommand(querytwo, myconnectiontwo);

                                createCommandtwo.Parameters.AddWithValue("@Module", getModule);
                                createCommandtwo.Parameters.AddWithValue("@ModuleCode", getModuleCode);
                                createCommandtwo.Parameters.AddWithValue("@Level", "6");
                                createCommandtwo.Parameters.AddWithValue("@MarkOne", getMarkOne);
                                createCommandtwo.Parameters.AddWithValue("@MarkTwo", getMarkTwo);
                                createCommandtwo.Parameters.AddWithValue("@MarkThree", getMarkThree);
                                createCommandtwo.Parameters.AddWithValue("@MarkFour", getMarkFour);
                                createCommandtwo.Parameters.AddWithValue("@Average", getAverage);
                                createCommandtwo.Parameters.AddWithValue("@Credit", CreditValue);

                                createCommandtwo.ExecuteNonQuery();

                                MessageBox.Show("Grades Saved!" + Environment.NewLine + "Your Average for this Module is " + total + " %");

                            }
                            myconnectiontwo.Close(); //Closing connection
                        }
                    }
                }
            }
            // If insufficient marks are provided then message is shown when catched.
            catch { MessageBox.Show("Enter all marks"); }
        }

        private void Level6DeleteButton_Click(object sender, EventArgs e)
        {
            //Level 6 Delete Module Button

            String DeleteModule = ListOfModulesAddedLevel6.SelectedItem.ToString(); //Getting Selected Module from listbox

            //Connecting to the database
            SqlCeConnection myconnection7 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection7.Open();

            //Query to execute in database
            String query7 = @"DELETE FROM ModuleInformation where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand7 = new SqlCeCommand(query7, myconnection7);

            //Module to delete
            createCommand7.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand7.ExecuteNonQuery();
            myconnection7.Close(); //Closing Connection

            //Connecting to the database
            SqlCeConnection myconnection8 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection8.Open();

            //Query to execute in database
            String query8 = @"DELETE FROM StudentGrades where Module = @DeleteModule";
            //Query execution command
            SqlCeCommand createCommand8 = new SqlCeCommand(query8, myconnection8);

            //Grades to delete according to Module
            createCommand8.Parameters.AddWithValue("@DeleteModule", DeleteModule);
            createCommand8.ExecuteNonQuery(); //Executing Query
            myconnection8.Close(); //Closing Connection

            MessageBox.Show("Module Deleted"); //Message shown to user when module is deleted
        }  

        private void AssessOneTextBoxLV6_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment One Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV6.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV6.Text = "";
                            AssessTwoTextBoxLV6.Text = "";
                            AssessThreeTextBoxLV6.Text = "";
                            AssessFourTextBoxLV6.Text = "";
                            FailingLevel6.Checked = false;
                            AverageLevel6.Checked = false;
                            HighMarkLevel6.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel6.Checked = true;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = true;
                                HighMarkLevel6.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = true;
                            }

                            if (markOne < 30)
                            {
                                FAHAssess1L6.Text = "Fail";
                                FAHAssess1L6.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkOne >= 30 && MarkOne < 40)
                            {

                                FAHAssess1L6.Text = "Referal";
                                FAHAssess1L6.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkOne >= 40)
                            {
                                FAHAssess1L6.Text = "Passed";
                                FAHAssess1L6.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessTwoTextBoxLV6_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Two Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading From database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV6.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV6.Text = "";
                            AssessTwoTextBoxLV6.Text = "";
                            AssessThreeTextBoxLV6.Text = "";
                            AssessFourTextBoxLV6.Text = "";
                            FailingLevel6.Checked = false;
                            AverageLevel6.Checked = false;
                            HighMarkLevel6.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel6.Checked = true;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = true;
                                HighMarkLevel6.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = true;
                            }

                            if (markTwo < 30)
                            {
                                FAHAssess2L6.Text = "Fail";
                                FAHAssess2L6.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkTwo >= 30 && MarkTwo < 40)
                            {

                                FAHAssess2L6.Text = "Referal";
                                FAHAssess2L6.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkTwo >= 40)
                            {
                                FAHAssess2L6.Text = "Passed";
                                FAHAssess2L6.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessThreeTextBoxLV6_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Three Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV6.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV6.Text = "";
                            AssessTwoTextBoxLV6.Text = "";
                            AssessThreeTextBoxLV6.Text = "";
                            AssessFourTextBoxLV6.Text = "";
                            FailingLevel6.Checked = false;
                            AverageLevel6.Checked = false;
                            HighMarkLevel6.Checked = false;

                        }
                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel6.Checked = true;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = true;
                                HighMarkLevel6.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = true;
                            }

                            if (markThree < 30)
                            {
                                FAHAssess3L6.Text = "Fail";
                                FAHAssess3L6.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkThree >= 30 && MarkThree < 40)
                            {

                                FAHAssess3L6.Text = "Referal";
                                FAHAssess3L6.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkThree >= 40)
                            {
                                FAHAssess3L6.Text = "Passed";
                                FAHAssess3L6.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void AssessFourTextBoxLV6_TextChanged(object sender, EventArgs e)
        {
            //Method for Assessment Four Text Box
            try
            {
                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM ModuleInformation where Level = '6'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                String Moduleselected = ListOfModulesAddedLevel6.Text; //Getting Selected Module from listbox

                //Declaring Variables
                double MarkOne = 0;
                double TotalOne = 0;
                double MarkTwo = 0;
                double TotalTwo = 0;
                double MarkThree = 0;
                double TotalThree = 0;
                double MarkFour = 0;
                double TotalFour = 0;

                //LEVEL 6 While Loop to check how many assessments are in the module.
                //Checks by comparing module selected with module in database.
                //Also used to calculate Marks according to the weighting.
                //Also used to calculate Overall mark of module.
                //Also used to make sure a overall mark isn't already added.
                //Also used to check if marks aren't over 100%
                //Also checks whether the user is failing/Passing a test/cw or exam.
                //Also checks if user needs to be reffered in a test/cw or exam.
                //Also checks if the user is obtaining a Average/High mark or if they are failing a module.
                while (reader.Read())
                {
                    String checkModule = reader[0].ToString();

                    if (Moduleselected.Equals(checkModule))
                    {

                        NumAssessmentsAutoTextLV6.Text = reader[4].ToString();
                        String CheckNum = NumAssessmentsAutoTextLV6.Text;

                        if (CheckNum.Equals("1"))
                        {
                            MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                            double WeightingOne = Convert.ToDouble(reader[9]);
                            TotalOne = (MarkOne * (WeightingOne / 100));
                        }

                        if (CheckNum.Equals("2"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {

                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }
                        }

                        if (CheckNum.Equals("3"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }
                        }
                        if (CheckNum.Equals("4"))
                        {
                            if (!(AssessOneTextBoxLV6.Text.Equals("")))
                            {
                                MarkOne = Convert.ToDouble(AssessOneTextBoxLV6.Text);
                                double WeightingOne = Convert.ToDouble(reader[9]);
                                TotalOne = (MarkOne * (WeightingOne / 100));
                            }

                            if (!(AssessTwoTextBoxLV6.Text.Equals("")))
                            {
                                MarkTwo = Convert.ToDouble(AssessTwoTextBoxLV6.Text);
                                double WeightingTwo = Convert.ToDouble(reader[10]);
                                TotalTwo = (MarkTwo * (WeightingTwo / 100));
                            }

                            if (!(AssessThreeTextBoxLV6.Text.Equals("")))
                            {
                                MarkThree = Convert.ToDouble(AssessThreeTextBoxLV6.Text);
                                double WeightingThree = Convert.ToDouble(reader[11]);
                                TotalThree = (MarkThree * (WeightingThree / 100));
                            }

                            if (!(AssessFourTextBoxLV6.Text.Equals("")))
                            {
                                MarkFour = Convert.ToDouble(AssessFourTextBoxLV6.Text);
                                double WeightingFour = Convert.ToDouble(reader[12]);
                                TotalFour = (MarkFour * (WeightingFour / 100));
                            }
                        }

                        if (MarkOne > 100.0 || MarkTwo > 100.0 || MarkThree > 100.0 || MarkFour > 100.0)
                        {

                            MessageBox.Show("Please enter a valid mark");
                            AssessOneTextBoxLV6.Text = "";
                            AssessTwoTextBoxLV6.Text = "";
                            AssessThreeTextBoxLV6.Text = "";
                            AssessFourTextBoxLV6.Text = "";
                            FailingLevel6.Checked = false;
                            AverageLevel6.Checked = false;
                            HighMarkLevel6.Checked = false;

                        }

                        else
                        {

                            double PassFailAverageOne = TotalOne + TotalTwo + TotalThree + TotalFour;
                            double PassFailAverage = PassFailAverageOne;

                            if (PassFailAverage < 40)
                            {
                                FailingLevel6.Checked = true;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = false;
                            }
                            if (PassFailAverage >= 40)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = true;
                                HighMarkLevel6.Checked = false;
                            }

                            if (PassFailAverage >= 70)
                            {
                                FailingLevel6.Checked = false;
                                AverageLevel6.Checked = false;
                                HighMarkLevel6.Checked = true;
                            }

                            if (markFour < 30)
                            {
                                FAHAssess4L6.Text = "Fail";
                                FAHAssess4L6.ForeColor = System.Drawing.Color.Red;
                            }

                            if (MarkFour >= 30 && MarkFour < 40)
                            {

                                FAHAssess4L6.Text = "Referal";
                                FAHAssess4L6.ForeColor = System.Drawing.Color.Orange;
                            }

                            else if (MarkFour >= 40)
                            {
                                FAHAssess4L6.Text = "Passed";
                                FAHAssess4L6.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception ee) { }
        }

        private void RefreshLV6_Click(object sender, EventArgs e)
        {
            //Method for refreshing listbox in Level 5 tab

            ListOfModulesAddedLevel6.Items.Clear();  //Clearing ListBox 

            //Connecting to the database
            SqlCeConnection myconnectionLV6 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV6.Open();

            //Query to execute in database
            String queryLV6 = "SELECT * FROM ModuleInformation where Level = '6'";
            //Query execution command
            SqlCeCommand createCommandLV6 = new SqlCeCommand(queryLV6, myconnectionLV6);
            //Reading from database
            SqlCeDataReader readerLV6 = createCommandLV6.ExecuteReader();

            //LEVEL 6 While Loop to add back modules to listbox
            while (readerLV6.Read())
            {
                ListOfModulesAddedLevel6.Items.Add(readerLV6[0]);
                
            }
        }

        //Code for Summary tab below 

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Summary ListBox Method

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            String Moduleselected = SumListBox.Text; //Getting Selected Module from listbox

            //Summary While Loop to set Module label values according to module selected in listbox.
            //Also used to set Module code label value according to module selected in listbox.
            //Also used to set Credit value label according to module selected in listbox.
            while (reader.Read())
            {
                String checkModule = reader[0].ToString();

                if (Moduleselected.Equals(checkModule))
                {
                    ModuleAutoSum.Text = reader[0].ToString();
                    ModuleCodeAutoSum.Text = reader[1].ToString();
                    CreditAutoSum.Text = reader[2].ToString();
                } 
             }

            //********************************************//

            //Connecting to the database
            SqlCeConnection myconnection2 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection2.Open();

            //Query to execute in database
            String query2 = "SELECT * FROM StudentGrades";
            //Query execution command
            SqlCeCommand createCommand2 = new SqlCeCommand(query2, myconnection2);
            //Reading from database
            SqlCeDataReader reader2 = createCommand2.ExecuteReader();

            String Moduleselected2 = SumListBox.Text; //Getting Selected Module from listbox

            //Summary While Loop to set overall module marks to the label
            bool checkmark = false;
            while (reader2.Read())
            {
                String checkModule2 = reader2[0].ToString();

                if (Moduleselected2.Equals(checkModule2))
                {
                    ModuleOverallAuto.Text = reader2[7].ToString() + " %";
                    checkmark = true;
                }
            }

            if (checkmark == false) {
                //IF no marks entered then label is set to text below
                ModuleOverallAuto.Text = "N/A - No marks have been entered";
            }
        }

        private void SumLV4_CheckedChanged(object sender, EventArgs e)
        { 
            //Summary Level 4 Radio Button Method

            //Setting Text to null
            OverallPerfomSumAuto.Text = "";
            OverallGradeSumAuto.Text = "";

            //Setting label to invisible
            OverallPerfomSum.Visible = false;

            int getTotalCredit = 0;
            SumListBox.Items.Clear(); //Clearing ListBox

            //Connecting to the database
            SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnection.Open();

            //Query to execute in database
            String query = "SELECT * FROM ModuleInformation where Level = '4'";
            //Query execution command
            SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
            //Reading from database
            SqlCeDataReader reader = createCommand.ExecuteReader();

            //While loop to add Level 4 Modules and to get total credits.
            while (reader.Read())
            {
                SumListBox.Items.Add(reader[0]);
                int getCredit = Convert.ToInt32(reader[2]);
                getTotalCredit = getTotalCredit + getCredit;

            }

            TotalCreditAutoSum.Text = getTotalCredit.ToString(); //Setting credit label to total credits
        }

        private void SumLV5_CheckedChanged(object sender, EventArgs e)
        {
            //Summary Level 5 Radio Button Method

            //Setting Text to null
            OverallPerfomSumAuto.Text = "";
            OverallGradeSumAuto.Text = "";

            //Setting label to invisible
            OverallPerfomSum.Visible = false;

            int getTotalCreditLV5 = 0;
            SumListBox.Items.Clear(); //Clearing ListBox

            //Connecting to the database
            SqlCeConnection myconnectionLV5 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV5.Open();

            //Query to execute in database
            String queryLV5 = "SELECT * FROM ModuleInformation where Level = '5'";
            //Query execution command
            SqlCeCommand createCommandLV5 = new SqlCeCommand(queryLV5, myconnectionLV5);
            //Reading from database
            SqlCeDataReader readerLV5 = createCommandLV5.ExecuteReader();

            //While loop to add Level 5 Modules and to get total credits.
            while (readerLV5.Read())
            {
                SumListBox.Items.Add(readerLV5[0]);
                int getCreditlv5 = Convert.ToInt32(readerLV5[2]);
                getTotalCreditLV5 = getTotalCreditLV5 + getCreditlv5;

            }

            TotalCreditAutoSum.Text = getTotalCreditLV5.ToString(); //Setting credit label to total credits
        }

        private void SumLV6_CheckedChanged(object sender, EventArgs e)
        {
            //Summary Level 5 Radio Button Method

            //Setting Text to null
            OverallPerfomSumAuto.Text = "";
            OverallGradeSumAuto.Text = "";

            //Setting label to invisible
            OverallPerfomSum.Visible = false;

            int getTotalCreditLV6 = 0;
            SumListBox.Items.Clear(); //Clearing ListBox

            //Connecting to the database
            SqlCeConnection myconnectionLV6 = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectionLV6.Open();

            //Query to execute in database
            String queryLV6 = "SELECT * FROM ModuleInformation where Level = '6'";
            //Query execution command
            SqlCeCommand createCommandLV6 = new SqlCeCommand(queryLV6, myconnectionLV6);
            //Reading from database
            SqlCeDataReader readerLV6 = createCommandLV6.ExecuteReader();

            //While loop to add Level 5 Modules and to get total credits.
            while (readerLV6.Read())
            {
                SumListBox.Items.Add(readerLV6[0]);
                int getCreditlv6 = Convert.ToInt32(readerLV6[2]);
                getTotalCreditLV6 = getTotalCreditLV6 + getCreditlv6;

            }

            TotalCreditAutoSum.Text = getTotalCreditLV6.ToString(); //Setting credit label to total credits
        }

        private void VOPSum_Click(object sender, EventArgs e)
        {
            //View Overall Performance Button method

            //Level 4 Calculations

            //Setting label to visible
            OverallPerfomSum.Visible = true;

            //IF Statement to calculate Level 4 Overall Performance percentage
            if (SumLV4.Checked == true) {

                OverallPerfomSumAuto.Text = "";
                OverallGradeSumAuto.Text = "";

                OverallPerfomSum.Visible = true;
                OverallPerfomSumAuto.Visible = true;
                String TotalCreditAuto = TotalCreditAutoSum.Text.ToString();

                //Retrieving marks from StudentGrades table where level equals 4 
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();
                String query = "SELECT * FROM StudentGrades where Level = '4'";
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);

                SqlCeDataReader reader = createCommand.ExecuteReader();

                double OverallPercentage = 0;
                int CountModules = 0;
                double FinalOverall = 0;

                //While loop to Add Level 4 marks together
                while (reader.Read())
                {
                    double getOverall = Convert.ToDouble(reader[7]);
                    OverallPercentage = OverallPercentage + getOverall;
                    CountModules++;
                }

                //Calculating Level 4 Overall Percentage to two decimal places
                FinalOverall =  Math.Round(OverallPercentage / CountModules * 100) / 100;

                //Setting Text
                OverallPerfomSumAuto.Text = FinalOverall + " %" + " (" + TotalCreditAuto + " out of 120 Credits)";
                myconnection.Close(); //Closing Connection
            }
            //****************************************************************//

            //LEVEL 5 Summary Calcutions which are done if the Level 5 radio button is ticked.
            //When the button is pressed.
            if (SumLV5.Checked == true)
            { 
                //Setting Text to nothing
                OverallPerfomSumAuto.Text = "";
                OverallGradeSumAuto.Text = "";

                //Setting Text Visibility
                OverallPerfomSum.Visible = true;
                OverallPerfomSumAuto.Visible = true;
                OverallGradeSumAuto.Visible = true;
                String TotalCreditAuto = TotalCreditAutoSum.Text.ToString(); //Getting Text from label

                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM StudentGrades where Level = '5'";
                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();

                //Variable Declarations
                int CountModules = 0;
                double FinalOverall = 0;
                double[] grades = new double[10];
                double getOverall = 0;

                String Credit = "";

                    //LEVEL 5 While Loop to extract overall marks according to credit and storing it into an array.
                    while (reader.Read())
                    {
                        Credit = Convert.ToString(reader[8]);

                        if (Credit.Equals("15"))
                        {
                            getOverall = Convert.ToDouble(reader[7]);
                            grades[CountModules] = getOverall;
                            CountModules++;
                        }

                        else if (Credit.Equals("30"))
                        {

                            getOverall = Convert.ToDouble(reader[7]);

                            grades[CountModules] = getOverall;
                            CountModules++;
                            grades[CountModules] = getOverall;
                            CountModules++;
                        }
                        else if (Credit.Equals("45"))
                        {

                            getOverall = Convert.ToDouble(reader[7]);

                            grades[CountModules] = getOverall;
                            CountModules++;
                            grades[CountModules] = getOverall;
                            CountModules++;
                            grades[CountModules] = getOverall;
                            CountModules++;
                        } 
                    }

                    Array.Sort(grades);            // sort array
                    Array.Reverse(grades);         // reverse so in sorted descending order
                
                //Extracting individual grades from the array
                double OM1 = Convert.ToDouble(grades[0]);
                double OM2 = Convert.ToDouble(grades[1]);
                double OM3 = Convert.ToDouble(grades[2]);
                double OM4 = Convert.ToDouble(grades[3]);
                double OM5 = Convert.ToDouble(grades[4]);
                double OM6 = Convert.ToDouble(grades[5]);
                double OM7 = Convert.ToDouble(grades[6]);

                //Calculating Level 5 Overall Percentage to two decimal places
                FinalOverall = Math.Round((OM1 + OM2 + OM3 + OM4 + OM5 + OM6 + OM7) / 7 * 100) / 100;
                //Displaying Overall to user
                OverallPerfomSumAuto.Text = FinalOverall + " %" + " (" + TotalCreditAuto + " out of 120 Credits)";

                //IF statements to calculate Overall Outcome for the year
                if (!(FinalOverall >= 40)) {

                    OverallGradeSumAuto.Text = "You have achieved a third class degree for Level 5";
                }

                if (FinalOverall >= 40)
                {
                    OverallGradeSumAuto.Text = "You have achieved a lower second class degree for Level 5";
                }

                if (FinalOverall >= 50)
                {
                    OverallGradeSumAuto.Text = "You have achieved a upper second class degree for Level 5";
                }

                if (FinalOverall >= 60)
                {
                    OverallGradeSumAuto.Text = "You have achieved a 1st class degree for Level 5";
                }

                myconnection.Close(); //Closing connection
            }
            //****************************************************************//

            //LEVEL 6 Summary Calcutions which are done if the Level 6 radio button is ticked.
            //When the button is pressed.
            if (SumLV6.Checked == true)
            {
                //Setting Text to nothing
                OverallPerfomSumAuto.Text = "";
                OverallGradeSumAuto.Text = "";

                //Setting Text Visibility
                OverallPerfomSum.Visible = true;
                OverallPerfomSumAuto.Visible = true;
                OverallGradeSumAuto.Visible = true;

                String TotalCreditAuto = TotalCreditAutoSum.Text.ToString(); //Getting Text from label

                //Connecting to the database
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                //Query to execute in database
                String query = "SELECT * FROM StudentGrades where Level = '6'";
                String query3 = "SELECT * FROM StudentGrades where Level = '5'";

                //Query execution command
                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);
                SqlCeCommand createCommand3 = new SqlCeCommand(query3, myconnection);

                //Reading from database
                SqlCeDataReader reader = createCommand.ExecuteReader();
                SqlCeDataReader reader3 = createCommand3.ExecuteReader();

                //Variable declarations
                int CountModules = 0;
                double[] grades = new double[10];
                double getOverall = 0;
                String Credit = "";
                double FinalOverallLV6 = 0;
                double FinalOverallLV5 = 0;

                //LEVEL 6 While Loop to extract overall marks according to credit and storing it into an array.
                while (reader.Read())
                {
                    Credit = Convert.ToString(reader[8]);

                    if (Credit.Equals("15"))
                    {
                        getOverall = Convert.ToDouble(reader[7]);

                        grades[CountModules] = getOverall;
                        CountModules++;
                    }

                    else if (Credit.Equals("30"))
                    {

                        getOverall = Convert.ToDouble(reader[7]);

                        grades[CountModules] = getOverall;
                        CountModules++;
                        grades[CountModules] = getOverall;
                        CountModules++;
                    }
                    else if (Credit.Equals("45"))
                    {

                        getOverall = Convert.ToDouble(reader[7]);

                        grades[CountModules] = getOverall;
                        CountModules++;
                        grades[CountModules] = getOverall;
                        CountModules++;
                        grades[CountModules] = getOverall;
                        CountModules++;
                    }
                }

                Array.Sort(grades);            // sorting the array
                Array.Reverse(grades);         // reversing the array so it sorts in descending order

                //Extracting individual grades from the array
                double OM1 = Convert.ToDouble(grades[0]);
                double OM2 = Convert.ToDouble(grades[1]);
                double OM3 = Convert.ToDouble(grades[2]);
                double OM4 = Convert.ToDouble(grades[3]);
                double OM5 = Convert.ToDouble(grades[4]);
                double OM6 = Convert.ToDouble(grades[5]);
                double OM7 = Convert.ToDouble(grades[6]);  //Lowest Level 6 mark used to below to calculate overall for level 5

                //Variable Declarations
                int CountModulesLV5 = 0;
                double getOverallLV5 = 0;
                String CreditLV5 = "";
                double[] gradesLV5 = new double[8];

                //LEVEL 5 While Loop to extract the lowest overall marks according to credit. 
                //And once again storing it into an array.
                while (reader3.Read())
                {
                    CreditLV5 = Convert.ToString(reader3[8]);

                    if (CreditLV5.Equals("15"))
                    {
                        getOverallLV5 = Convert.ToDouble(reader3[7]);
                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                    }

                    else if (CreditLV5.Equals("30"))
                    {

                        getOverallLV5 = Convert.ToDouble(reader3[7]);

                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                    }
                    else if (CreditLV5.Equals("45"))
                    {

                        getOverallLV5 = Convert.ToDouble(reader3[7]);

                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                        gradesLV5[CountModulesLV5] = getOverallLV5;
                        CountModulesLV5++;
                    }
                }

                Array.Sort(gradesLV5);            // sorting the array
                Array.Reverse(gradesLV5);         // reversing the array so it sorts in descending order

                //Extracting individual grades from the array
                double OM1LV5 = Convert.ToDouble(gradesLV5[0]);
                double OM2LV5 = Convert.ToDouble(gradesLV5[1]);
                double OM3LV5 = Convert.ToDouble(gradesLV5[2]);
                double OM4LV5 = Convert.ToDouble(gradesLV5[3]);
                double OM5LV5 = Convert.ToDouble(gradesLV5[4]);
                double OM6LV5 = Convert.ToDouble(gradesLV5[5]);
                double OM7LV5 = Convert.ToDouble(gradesLV5[6]);
                double OM8LV5 = Convert.ToDouble(gradesLV5[7]);
                double OM9LV5 = OM7;
                gradesLV5[7] = OM9LV5;

                if (CountModulesLV5 == 0 || CountModules == 0)
                {
                    MessageBox.Show("INSUFFICENT DATA");
                }
                else
                {   //Calculating Level 6 Overall Percentage to two decimal places
                    FinalOverallLV6 = Math.Round((OM1 + OM2 + OM3 + OM4 + OM5 + OM6 + OM7) / 7 * 100) / 100;
                    //Calculating Level 5 Overall Percentage to two decimal places
                    FinalOverallLV5 = Math.Round((OM1LV5 + OM2LV5 + OM3LV5 + OM4LV5 + OM5LV5 + OM6LV5 + OM7LV5) / 7 * 100) / 100;
                    //Displaying Overall to user
                    OverallPerfomSumAuto.Text = FinalOverallLV6 + " %" + " (" + TotalCreditAuto + " out of 120 Credits)";

                    //IF statements to calculate Overall Outcome for the year
                    if (((FinalOverallLV5 >= 40) && (FinalOverallLV6 >= 40)))
                    {

                        OverallGradeSumAuto.Text = "You have achieved a third class degree for Level 6";
                    }

                    if (((FinalOverallLV5 >= 40) && (FinalOverallLV6 >= 50)))
                    {

                        OverallGradeSumAuto.Text = "You have achieved a lower second class degree for Level 6";
                    }

                    if (((FinalOverallLV5 >= 50) && (FinalOverallLV6 >= 60)))
                    {

                        OverallGradeSumAuto.Text = "You have achieved a upper second class degree for Level 6";
                    }

                    if (((FinalOverallLV5 >= 60) && (FinalOverallLV6 >= 70)))
                    {

                        OverallGradeSumAuto.Text = "You have achieved a 1st class degree for Level 6";
                    }

                    myconnection.Close(); //Closing connection
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Called when closing form

            base.OnFormClosing(e);
            if (ClosingFormDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true); // Used so pop up doesn't show twice
                Application.Exit(); //Closes application
            }
            else
            {
                e.Cancel = true; //Cancels form closing
            }
        }

        private DialogResult ClosingFormDialog()
        {
            //Showing option and returning what user selects (either yes or no)
            DialogResult result = System.Windows.Forms.MessageBox.Show(" Are you sure you want to quit? ", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            return result;
        }
    }
}
