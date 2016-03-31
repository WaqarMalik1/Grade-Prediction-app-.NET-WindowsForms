using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Data.SqlServerCe;

namespace GradePerformancePredictorApplication
{
    public partial class AddModuleFormLevel5 : Form
    {
        String List = Directory.GetCurrentDirectory(); //Getting directory of database

        //Declaring Variables
        ArrayList AssessmentTexBox = new ArrayList();
        ArrayList labels = new ArrayList();
        ArrayList labels2 = new ArrayList();
        ArrayList WeightingTexBox = new ArrayList();
        String getAssessmentOne;
        String getAssessmentTwo;
        String getAssessmentThree;
        String getAssessmentFour;
        String getWeightingOne;
        String getWeightingTwo;
        String getWeightingThree;
        String getWeightingFour;

        public AddModuleFormLevel5()
        {
            InitializeComponent();
        }

        private void AddModuleFormLevel5_Load(object sender, EventArgs e)
        {
            //Form Load Method

            //Setting Label and Button to be invisible
            AssessmentsLabel.Visible = false;
            SubmitButton.Visible = false;

            //Setting minimum and maximum numbers that can be selected on numericUpDown
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 4;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //Next Button Method

            NextButton.Enabled = false;//Disabling button once clicked

            //Connecting to the database
            SqlCeConnection myconnectiontwo = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
            myconnectiontwo.Open();

            //Query to execute in database
            String querythree = "SELECT * FROM ModuleInformation";
            //Query execution command
            SqlCeCommand createCommandthree = new SqlCeCommand(querythree, myconnectiontwo);
            //Reading from database
            SqlCeDataReader readertwo = createCommandthree.ExecuteReader();

            String getModule = ModuleTextBox.Text.ToString();

            //While loop to check if same module already exists in the database.
            bool checking = true;
            while (readertwo.Read())
            {
                String checkModuleTwo = readertwo[0].ToString();
                if (getModule.Equals(checkModuleTwo))
                {

                    MessageBox.Show(" You have already entered this module ");
                    checking = false;
                }
            }

            //IF the module doesn't exist then it checks if the credit entered in the credit text box is either 15/30/45.
            //IF it isn't then it displays a message to the user.
            //IF it is then it shows the assessment pattern. (Which is dynamic)
            if (checking == true)
            {
                String Credit = CreditTextBox.Text.ToString();

                if (!(Credit.Equals("15") || Credit.Equals("30") || Credit.Equals("45")))
                {

                    MessageBox.Show("Please Enter a appropriate Credit Value");
                    NextButton.Enabled = true; //enable next button

                }
                else
                {
                    //Show Label and Button
                    AssessmentsLabel.Visible = true;
                    SubmitButton.Visible = true;

                    int length = (int)this.numericUpDown1.Value;
                    for (int i = 0; i < length; i++)
                    {
                        //Instantiating and configuring Assessment TextBoxes
                        AssessmentTexBox.Add(new TextBox());
                        System.Drawing.Point p = new System.Drawing.Point(420, 114 + i * 25);
                        (AssessmentTexBox[i] as TextBox).Location = p;
                        (AssessmentTexBox[i] as TextBox).Size = new System.Drawing.Size(100, 20);
                        this.Controls.Add(AssessmentTexBox[i] as TextBox);

                        //Instantiating and configuring Assessment labels
                        this.labels.Add(new Label());
                        System.Drawing.Point pLabel = new System.Drawing.Point(330, 114 + i * 25);
                        (labels[i] as Label).Location = pLabel;
                        (labels[i] as Label).Size = new System.Drawing.Size(80, 13);
                        (labels[i] as Label).Text = @"Assessment " + (i + 1).ToString() + ":";
                        this.Controls.Add((labels[i] as Label));

                        //Mouse events
                        (AssessmentTexBox[i] as TextBox).MouseEnter += new System.EventHandler(this.textBox_mouseEnter);
                        (AssessmentTexBox[i] as TextBox).MouseLeave += new System.EventHandler(this.textBox_mouseLeave);
                        //Instantiating and configuring Weighting TextBoxes
                        WeightingTexBox.Add(new TextBox());
                        (WeightingTexBox[i] as TextBox).Location = new System.Drawing.Point(620, 110 + i * 25);

                        //Instantiating and configuring Weighting labels
                        this.labels2.Add(new Label());
                        (labels2[i] as Label).Location = new System.Drawing.Point(535, 114 + i * 25);
                        (labels2[i] as Label).Size = new System.Drawing.Size(80, 13);
                        (labels2[i] as Label).Text = @"Weighting % : ";
                        this.Controls.Add((labels2[i] as Label));
                        this.Controls.Add(WeightingTexBox[i] as TextBox);

                    }

                }
            }
        }

        private void textBox_mouseEnter(object sender, EventArgs e)
        {
            TextBox tempBox = (TextBox)sender;
            tempBox.BackColor = Color.PaleGoldenrod;
        }

        private void textBox_mouseLeave(object sender, EventArgs e)
        {
            TextBox tempBox = (TextBox)sender;
            tempBox.BackColor = Color.White;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            //Getting text from TextBoxes
            String getModule = ModuleTextBox.Text.ToString();
            String getModuleCode = ModuleCodeTextBox.Text.ToString();
            String getCreditValue = CreditTextBox.Text.ToString();

            //Getting Text from numericUpDown
            String getNumOfAssessments = Convert.ToString(((UpDownBase)numericUpDown1).Text);
           
            //Getting Text from dynamic TextBox
            String One = (AssessmentTexBox[0] as TextBox).Text;
            
            bool CheckingWeighting = true;

            //IF statemnts to check how many textboxes to show according to the number of assessments
            //Also used to calculate total weighting
            //Also used so if total weighting is not 100 then it won't submit.
            if (getNumOfAssessments.Equals("1"))
            {
                getAssessmentOne = (AssessmentTexBox[0] as TextBox).Text.ToString();
                getAssessmentTwo = "";
                getAssessmentThree = "";
                getAssessmentFour = "";

                getWeightingOne = (WeightingTexBox[0] as TextBox).Text.ToString();
                getWeightingTwo = "";
                getWeightingThree = "";
                getWeightingFour = "";

                int Weight1Int = Convert.ToInt32(getWeightingOne);

                int totalweighting = Weight1Int;
                if (!(totalweighting == 100))
                {
                    CheckingWeighting = false;
                    MessageBox.Show("Please make sure weighting equals 100");
                } 
            }

            if (getNumOfAssessments.Equals("2"))
            {
                getAssessmentOne = (AssessmentTexBox[0] as TextBox).Text.ToString();
                getAssessmentTwo = (AssessmentTexBox[1] as TextBox).Text.ToString();
                getAssessmentThree = "";
                getAssessmentFour = "";

                getWeightingOne = (WeightingTexBox[0] as TextBox).Text.ToString();
                getWeightingTwo = (WeightingTexBox[1] as TextBox).Text.ToString();
                getWeightingThree = "";
                getWeightingFour = "";

                int Weight1Int = Convert.ToInt32(getWeightingOne);
                int Weight2Int = Convert.ToInt32(getWeightingTwo);

                int totalweighting = Weight1Int + Weight2Int;
                if (!(totalweighting == 100))
                {
                    CheckingWeighting = false;
                    MessageBox.Show("Please make sure weighting equals 100");
                }           
            }

            if (getNumOfAssessments.Equals("3"))
            {
                 getAssessmentOne = (AssessmentTexBox[0] as TextBox).Text.ToString();
                 getAssessmentTwo = (AssessmentTexBox[1] as TextBox).Text.ToString();
                 getAssessmentThree = (AssessmentTexBox[2] as TextBox).Text.ToString();
                 getAssessmentFour = "";

                 getWeightingOne = (WeightingTexBox[0] as TextBox).Text.ToString();
                 getWeightingTwo = (WeightingTexBox[1] as TextBox).Text.ToString();
                 getWeightingThree = (WeightingTexBox[2] as TextBox).Text.ToString();
                 getWeightingFour = "";

                 int Weight1Int = Convert.ToInt32(getWeightingOne);
                 int Weight2Int = Convert.ToInt32(getWeightingTwo);
                 int Weight3Int = Convert.ToInt32(getWeightingThree);

                 int totalweighting = Weight1Int + Weight2Int + Weight3Int;
                 if (!(totalweighting == 100))
                 {
                     CheckingWeighting = false;
                     MessageBox.Show("Please make sure weighting equals 100");
                 } 
            }

            if (getNumOfAssessments.Equals("4"))
            {
                 getAssessmentOne = (AssessmentTexBox[0] as TextBox).Text.ToString();
                 getAssessmentTwo = (AssessmentTexBox[1] as TextBox).Text.ToString();
                 getAssessmentThree = (AssessmentTexBox[2] as TextBox).Text.ToString();
                 getAssessmentFour = (AssessmentTexBox[3] as TextBox).Text.ToString();

                 getWeightingOne = (WeightingTexBox[0] as TextBox).Text.ToString();
                 getWeightingTwo = (WeightingTexBox[1] as TextBox).Text.ToString();
                 getWeightingThree = (WeightingTexBox[2] as TextBox).Text.ToString();
                 getWeightingFour = (WeightingTexBox[3] as TextBox).Text.ToString();

                 int Weight1Int = Convert.ToInt32(getWeightingOne);
                 int Weight2Int = Convert.ToInt32(getWeightingTwo);
                 int Weight3Int = Convert.ToInt32(getWeightingThree);
                 int Weight4Int = Convert.ToInt32(getWeightingFour);

                 int totalweighting = Weight1Int + Weight2Int + Weight3Int + Weight4Int;
                 if (!(totalweighting == 100))
                 {
                     CheckingWeighting = false;
                     MessageBox.Show("Please make sure weighting equals 100");
                 } 
            }

            //IF checkingWeighting is true (would be false if the weighting didn't equal 100) then it saves the Module into the database.
            //It also makes sure the Level saved is 5
            //It also shows a message to the user
            //It also closes the form once it has saved into the database.
            if (CheckingWeighting == true)
            {
                SqlCeConnection myconnection = new SqlCeConnection("Data Source=" + List + @"\Database1.sdf;");
                myconnection.Open();

                String query = "INSERT INTO ModuleInformation (Module, ModuleCode, CreditValue, Level, NumberOfAssessments, AssessmentOne, AssessmentTwo, AssessmentThree, AssessmentFour, WeightingOne, WeightingTwo, WeightingThree, WeightingFour)"
                 + "VALUES (@Module, @ModuleCode, @CreditValue, @Level, @NumberOfAssessments, @AssessmentOne, @AssessmentTwo, @AssessmentThree, @AssessmentFour, @WeightingOne, @WeightingTwo, @WeightingThree, @WeightingFour)";

                SqlCeCommand createCommand = new SqlCeCommand(query, myconnection);


                createCommand.Parameters.AddWithValue("@Module", getModule);
                createCommand.Parameters.AddWithValue("@ModuleCode", getModuleCode);
                createCommand.Parameters.AddWithValue("@CreditValue", getCreditValue);
                createCommand.Parameters.AddWithValue("@Level", "5");
                createCommand.Parameters.AddWithValue("@NumberOfAssessments", getNumOfAssessments);
                createCommand.Parameters.AddWithValue("@AssessmentOne", getAssessmentOne);
                createCommand.Parameters.AddWithValue("@AssessmentTwo", getAssessmentTwo);
                createCommand.Parameters.AddWithValue("@AssessmentThree", getAssessmentThree);
                createCommand.Parameters.AddWithValue("@AssessmentFour", getAssessmentFour);
                createCommand.Parameters.AddWithValue("@WeightingOne", getWeightingOne);
                createCommand.Parameters.AddWithValue("@WeightingTwo", getWeightingTwo);
                createCommand.Parameters.AddWithValue("@WeightingThree", getWeightingThree);
                createCommand.Parameters.AddWithValue("@WeightingFour", getWeightingFour);


                createCommand.ExecuteNonQuery();
                myconnection.Close();
                MessageBox.Show("Module Added");
                Form.ActiveForm.Close();

            }
        }
    }
}
