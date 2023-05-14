using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using textBox1_TextChanged_1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Scientific_Caculator
{
    public partial class Form1 : Form
    {
        double results = 0;
        string operation = "";
        bool enter_value = false;
        double memory = 0;
        string math_expression = "";
        int count = 0;
        int operator_count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        void changed_Box()
        {
            textBox1.Text = textBox2.Text;
            textBox2.Text = Answer_Display.Text;
        }
        private int factorial_Function(int n)
        {
            if (n >= 1)
            {
                return n * factorial_Function(n - 1);
            }
            else if (n == 0)
            {
                return 1;
            }
            else
            {
                Answer_Display.Text = "Invalid Value";
            }
            return 0;
        }
        private void Angle_Unit_Click(object sender, EventArgs e)
        {
            if(Angle_Unit.Text == "Deg")
            {
                Angle_Unit.Text = "Rad";
            }
            else
            {
                Angle_Unit.Text = "Deg";
            }

        }
        
        private void Fixed_Exponent_Click(object sender, EventArgs e)
        {
            if (Fixed_Exponent.BackColor == Color.White)
            {
                string temp = Answer_Display.Text;
                Fixed_Exponent.BackColor = Color.Cyan;
                int index = Answer_Display.Text.IndexOf(".");
                if (Double.Parse(Answer_Display.Text) > -1 && Double.Parse(Answer_Display.Text) < 1)
                {
                    for(int i = 0; i < Answer_Display.Text.Length; i++)
                    {
                        if ((int)Char.GetNumericValue(temp[i]) > 0)
                        {
                            index = i;
                        }
                    }
                    Answer_Display.Text = (Double.Parse(Answer_Display.Text) * Math.Pow(10, index)).ToString() + ".e" + ( - index).ToString();
                }
                else
                {
                    if (index == -1)
                    {
                        index = Answer_Display.Text.Length;
                        Answer_Display.Text = (Double.Parse(Answer_Display.Text) / Math.Pow(10, index - 1)).ToString() + ".e" + (index - 1).ToString();
                    }
                    else
                    {
                        Answer_Display.Text = (Double.Parse(Answer_Display.Text) / Math.Pow(10, index - 1)).ToString() + ".e" + (index - 1).ToString();
                    }
                }
                
            }
            else
            {
                Fixed_Exponent.BackColor = Color.White;
                string temp = Answer_Display.Text;
                int index = temp.IndexOf("e");
                int length = temp.Length;
                Answer_Display.Text = (Double.Parse(temp.Substring(0,index-1)) * Math.Pow(10, Double.Parse(temp.Substring(index + 1, temp.Length- index - 1)))).ToString();
            }
        }

        private void Superscript_Shift_Click(object sender, EventArgs e)
        {
            if(Superscript_Shift.BackColor == Color.White)
            {
                Superscript_Shift.BackColor = Color.Cyan;
                Square_Cube.Text = "x^3";
                Square_Cube_Root.Text = "3√x";
                Superscript_Root.Text = "y√x";
                Power_Ten_Two.Text = "2^x";
                Logarit_Function.Text = "logy(x)";
                Nebe_Power_Logarit.Text = "e^x";
            }
            else
            {
                Superscript_Shift.BackColor = Color.White;
                Square_Cube.Text = "x^2";
                Square_Cube_Root.Text = "2√x";
                Superscript_Root.Text = "x^y";
                Power_Ten_Two.Text = "10^x";
                Logarit_Function.Text = "log(x)";
                Nebe_Power_Logarit.Text = "ln(x)";
            }
        }

        private void Square_Cube_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Trigonometry_Shift_Click(object sender, EventArgs e)
        {
            if(Trigonometry_Shift.BackColor == Color.White && Hyperbolic_Function.BackColor == Color.White)
            {
                Trigonometry_Shift.BackColor = Color.Cyan;
                Sin_Function.Text = "arcsin(x)";
                Cos_Function.Text = "arccos(x)";
                Tan_Function.Text = "arctan(x)";
                Cot_Function.Text = "arccot(x)";
                Sec_Function.Text = "arcsec(x)";
                Csc_Function.Text = "arccsc(x)";
            } 
            else if (Trigonometry_Shift.BackColor == Color.White && Hyperbolic_Function.BackColor == Color.Cyan)
            {
                Trigonometry_Shift.BackColor = Color.Cyan;
                Sin_Function.Text = "arcsinh(x)";
                Cos_Function.Text = "arccosh(x)";
                Tan_Function.Text = "arctanh(x)";
                Cot_Function.Text = "arccoth(x)";
                Sec_Function.Text = "arcsech(x)";
                Csc_Function.Text = "arccsch(x)";
            }
            else if (Trigonometry_Shift.BackColor == Color.Cyan && Hyperbolic_Function.BackColor == Color.Cyan)
            {
                Trigonometry_Shift.BackColor = Color.White;
                Sin_Function.Text = "sinh(x)";
                Cos_Function.Text = "cosh(x)";
                Tan_Function.Text = "tanh(x)";
                Cot_Function.Text = "coth(x)";
                Sec_Function.Text = "sech(x)";
                Csc_Function.Text = "csch(x)";
            }
            else
            {
                Trigonometry_Shift.BackColor = Color.White;
                Sin_Function.Text = "sin(x)";
                Cos_Function.Text = "cos(x)";
                Tan_Function.Text = "tan(x)";
                Cot_Function.Text = "cot(x)";
                Sec_Function.Text = "sec(x)";
                Csc_Function.Text = "csc(x)";
            }
        }

        private void Hyperbolic_Function_Click(object sender, EventArgs e)
        {
            if(Trigonometry_Shift.BackColor == Color.White && Hyperbolic_Function.BackColor == Color.White)
            {
                Hyperbolic_Function.BackColor = Color.Cyan;
                Sin_Function.Text = "sinh(x)";
                Cos_Function.Text = "cosh(x)";
                Tan_Function.Text = "tanh(x)";
                Cot_Function.Text = "coth(x)";
                Sec_Function.Text = "sech(x)";
                Csc_Function.Text = "csch(x)";
            }
            else if (Trigonometry_Shift.BackColor == Color.White && Hyperbolic_Function.BackColor == Color.Cyan)
            {
                Hyperbolic_Function.BackColor = Color.White;
                Sin_Function.Text = "sin(x)";
                Cos_Function.Text = "cos(x)";
                Tan_Function.Text = "tan(x)";
                Cot_Function.Text = "cot(x)";
                Sec_Function.Text = "sec(x)";
                Csc_Function.Text = "csc(x)";
            }
            else if (Trigonometry_Shift.BackColor == Color.Cyan && Hyperbolic_Function.BackColor == Color.Cyan)
            {
                Hyperbolic_Function.BackColor = Color.White;
                Sin_Function.Text = "arcsin(x)";
                Cos_Function.Text = "arccos(x)";
                Tan_Function.Text = "arctan(x)";
                Cot_Function.Text = "arccot(x)";
                Sec_Function.Text = "arcsec(x)";
                Csc_Function.Text = "arccsc(x)";
            }
            else
            {
                Hyperbolic_Function.BackColor = Color.Cyan;
                Sin_Function.Text = "arcsinh(x)";
                Cos_Function.Text = "arccosh(x)";
                Tan_Function.Text = "arctanh(x)";
                Cot_Function.Text = "arccoth(x)";
                Sec_Function.Text = "arcsech(x)";
                Csc_Function.Text = "arccsch(x)";
            }
        }

       private void textBox1_TextChanged_1(object sender, EventArgs e){}

        private void One_Number_Click(object sender, EventArgs e)
        {
            textBox2.Text = One_Number.Text;
        }

        private void Answer_Display_TextChanged(object sender, EventArgs e)
        {

        }

        private void Two_Number_Click(object sender, EventArgs e)
        {

        }

        private void Pi_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = Math.PI.ToString();
            math_expression += Answer_Display.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e){ }

        private void Equal_Click(object sender, EventArgs e)
        {
            changed_Box();
            Operator_Display.Text = "";
            switch (operation)
            {
                case "x^y":
                    Answer_Display.Text = ((Math.Pow(results, Double.Parse(Answer_Display.Text)).ToString()));
                    break;
                case "y√x":
                    Answer_Display.Text = ((Math.Pow(results, 1 / Double.Parse(Answer_Display.Text)).ToString()));
                    break;
                case "logy(x)":
                    Answer_Display.Text = ((Math.Log(results, Double.Parse(Answer_Display.Text)).ToString()));
                    break;
                case "exp(x)":
                    Answer_Display.Text = (results * Math.Pow(10, Double.Parse(Answer_Display.Text))).ToString();
                    break;
                case "+":
                    textBox1.Text = math_expression;
                    double add_result = Convert.ToDouble(new DataTable().Compute(math_expression, null));
                    textBox1.Text = math_expression;
                    textBox2.Text = "";
                    Answer_Display.Text = add_result.ToString();
                    break;
                case "-":
                    textBox1.Text = math_expression;
                    double sub_result = Convert.ToDouble(new DataTable().Compute(math_expression, null));
                    textBox1.Text = math_expression;
                    textBox2.Text = "";
                    Answer_Display.Text = sub_result.ToString();
                    break;
                case "x":
                    textBox1.Text = math_expression;
                    double mul_result = Convert.ToDouble(new DataTable().Compute(math_expression, null));
                    textBox1.Text = math_expression;
                    textBox2.Text = "";
                    Answer_Display.Text = mul_result.ToString();
                    break;
                case ":":
                    textBox1.Text = math_expression;
                    double div_result = Convert.ToDouble(new DataTable().Compute(math_expression, null));
                    textBox1.Text = math_expression;
                    textBox2.Text = "";
                    Answer_Display.Text = div_result.ToString();
                    break;
                case "mod":
                    textBox1.Text = math_expression;
                    double mod_result = Convert.ToDouble(new DataTable().Compute(math_expression, null));
                    textBox1.Text = math_expression;
                    textBox2.Text = "";
                    Answer_Display.Text = mod_result.ToString();
                    break;
            }
            math_expression = Answer_Display.Text;
            results = 0;
        }

        private void Group_Number(object sender, EventArgs e)
        {
            if (Answer_Display.Text == "0" || (enter_value))
                Answer_Display.Text = "";
            enter_value = false;
            Console.WriteLine(Answer_Display.Text);
            Button num = (Button)sender;
            if(num.Text == ".")
            {
                
                    if (!Answer_Display.Text.Contains('.'))
                    Answer_Display.Text = Answer_Display.Text + num.Text;
                    math_expression += num.Text;
            }
            else
                Answer_Display.Text = Answer_Display.Text + num.Text;
                math_expression += num.Text;
        }

        private void Clear_Entry_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = "0";
            textBox1.Text = "";
            textBox2.Text = "";
            Operator_Display.Text = "";
            count = 0;
            Counter_Box.Text = "";
            math_expression = "";
            operator_count = 0;

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(Answer_Display.Text.Length > 0)
            {
                Answer_Display.Text = Answer_Display.Text.Remove(Answer_Display.Text.Length - 1, 1);
            }
            else if (Answer_Display.Text == "")
            {
                Answer_Display.Text = "0";
            }
        }

        private void Arithmetic_Operator(object sender, EventArgs e)
        {
            Button num = (Button)(sender);
            operation = num.Text;
            Operator_Display.Text = operation;
            results = Double.Parse(Answer_Display.Text);
            switch (operation)
                {
                    case "+":
                        math_expression += num.Text;
                        break;
                    case "-":
                        math_expression += num.Text;
                        break;
                    case "x":
                        math_expression += "*";
                        break;
                    case ":":
                        math_expression += "/";
                        break;
                    case "mod":
                        math_expression += "%";
                        break;
                }
            operator_count++;
            changed_Box();
            Answer_Display.Text = "";
        }

        private void Operator_Display_TextChanged(object sender, EventArgs e){}

        private void Factorial_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = (factorial_Function(int.Parse(Answer_Display.Text))).ToString();
            math_expression = Answer_Display.Text;
        }

        private void Absolute_Number_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = (Math.Abs(int.Parse(Answer_Display.Text)).ToString());
            math_expression = Answer_Display.Text;
        }

        private void Sign_Number_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = ( - int.Parse(Answer_Display.Text)).ToString();
            math_expression = Answer_Display.Text;
        }

        private void Euler_Number_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = Math.E.ToString();
            math_expression += Answer_Display.Text;
        }

        private void Inversion_Click(object sender, EventArgs e)
        {
            Answer_Display.Text = (1 / Double.Parse(Answer_Display.Text)).ToString();
            math_expression = Answer_Display.Text;
        }

        private void Exponential_Function_Click(object sender, EventArgs e)
        {
            
        }

        private void Superscript_Group(object sender, EventArgs e)
        {
            changed_Box();
            Button num = (Button)(sender);
            operation = num.Text;
            Operator_Display.Text = operation;
            results = Double.Parse(Answer_Display.Text);
            switch (operation)
            {
                case "x^2":
                    Answer_Display.Text = ((Math.Pow(results, 2).ToString()));
                    break;
                case "x^3":
                    Answer_Display.Text = ((Math.Pow(results, 3).ToString()));
                    break;
                case "2√x":
                    Answer_Display.Text = ((Math.Sqrt(results).ToString()));
                    break;
                case "3√x":
                    Answer_Display.Text = ((Math.Cbrt(results).ToString()));
                    break;
                case "10^x":
                    Answer_Display.Text = ((Math.Pow(10, results).ToString()));
                    break;
                case "2^x":
                    Answer_Display.Text = ((Math.Pow(2, results).ToString()));
                    break;
                case "log(x)":
                    Answer_Display.Text = ((Math.Log10(results).ToString()));
                    break;
                case "logy(x)":
                    Answer_Display.Text = "";
                    break;
                case "ln(x)":
                    Answer_Display.Text = ((Math.Log(results).ToString()));
                    break;
                case "e^x":
                    Answer_Display.Text = Math.Exp(results).ToString();
                    break;
            }
            math_expression = Answer_Display.Text;
        }

        private void Trigonometry_Group(object sender, EventArgs e)
        {
            //changed_Box();
            Button num = (Button)(sender);
            operation = num.Text;
            Operator_Display.Text = operation;
            results = Double.Parse(Answer_Display.Text);
            if (Angle_Unit.Text == "Deg")
            {
                switch (operation)
                {
                    case "sin(x)":
                        Answer_Display.Text = (Math.Sin(results * Math.PI / 180)).ToString();
                        break;
                    case "cos(x)":
                        Answer_Display.Text = (Math.Cos(results * Math.PI / 180)).ToString();
                        break;
                    case "tan(x)":
                        Answer_Display.Text = (Math.Tan(results * Math.PI / 180)).ToString();
                        break;
                    case "cot(x)":
                        Answer_Display.Text = (1 / Math.Tan(results * Math.PI / 180)).ToString();
                        break;
                    case "sec(x)":
                        Answer_Display.Text = (1 / Math.Cos(results * Math.PI / 180)).ToString();
                        break;
                    case "csc(x)":
                        Answer_Display.Text = (1 / Math.Sin(results * Math.PI / 180)).ToString();
                        break;
                    case "arcsin(x)":
                        Answer_Display.Text = (Math.Asin(results) * 180 / Math.PI).ToString();
                        break;
                    case "arccos(x)":
                        Answer_Display.Text = (Math.Acos(results) * 180 / Math.PI).ToString();
                        break;
                    case "arctan(x)":
                        Answer_Display.Text = (Math.Atan(results) * 180 / Math.PI).ToString();
                        break;
                    case "arccot(x)":
                        Answer_Display.Text = (Math.Atan(1 / results) * 180 / Math.PI).ToString();
                        break;
                    case "arcsec(x)":
                        Answer_Display.Text = (Math.Acos(1 / results) * 180 / Math.PI).ToString();
                        break;
                    case "arccsc(x)":
                        Answer_Display.Text = (Math.Asin(1 / results) * 180 / Math.PI).ToString();
                        break;
                    case "sinh(x)":
                        Answer_Display.Text = Math.Sinh(results * Math.PI / 180).ToString();
                        break;
                    case "cosh(x)":
                        Answer_Display.Text = Math.Cosh(results * Math.PI / 180).ToString();
                        break;
                    case "tanh(x)":
                        Answer_Display.Text = Math.Tanh(results * Math.PI / 180).ToString();
                        break;
                    case "coth(x)":
                        Answer_Display.Text = (1 / Math.Tanh(results * Math.PI / 180)).ToString();
                        break;
                    case "sech(x)":
                        Answer_Display.Text = (1 / Math.Cosh(results * Math.PI / 180)).ToString();
                        break;
                    case "csch(x)":
                        Answer_Display.Text = (1 / Math.Sinh(results * Math.PI / 180)).ToString();
                        break;
                    case "arcsinh(x)":
                        Answer_Display.Text = Math.Asinh(results * Math.PI / 180).ToString();
                        break;
                    case "arccosh(x)":
                        Answer_Display.Text = Math.Acosh(results * Math.PI / 180).ToString();
                        break;
                    case "arctanh(x)":
                        Answer_Display.Text = Math.Atanh(results * Math.PI / 180).ToString();
                        break;
                    case "arccoth(x)":
                        Answer_Display.Text = Math.Atanh((1 / results) * Math.PI / 180).ToString();
                        break;
                    case "arcsech(x)":
                        Answer_Display.Text = Math.Acosh((1 / results) * Math.PI / 180).ToString();
                        break;
                    case "arccsch(x)":
                        Answer_Display.Text = Math.Asinh((1 / results) * Math.PI / 180).ToString();
                        break;
                }
            }
            else if (Angle_Unit.Text == "Rad")
            {
                switch (operation)
                {
                    case "sin(x)":
                        Answer_Display.Text = (Math.Sin(results)).ToString();
                        break;
                    case "cos(x)":
                        Answer_Display.Text = (Math.Cos(results)).ToString();
                        break;
                    case "tan(x)":
                        Answer_Display.Text = (Math.Tan(results)).ToString();
                        break;
                    case "cot(x)":
                        Answer_Display.Text = (1 / Math.Tan(results)).ToString();
                        break;
                    case "sec(x)":
                        Answer_Display.Text = (1 / Math.Cos(results)).ToString();
                        break;
                    case "csc(x)":
                        Answer_Display.Text = (1 / Math.Sin(results)).ToString();
                        break;
                    case "arcsin(x)":
                        Answer_Display.Text = (Math.Asin(results)).ToString();
                        break;
                    case "arccos(x)":
                        Answer_Display.Text = (Math.Acos(results)).ToString();
                        break;
                    case "arctan(x)":
                        Answer_Display.Text = (Math.Atan(results)).ToString();
                        break;
                    case "arccot(x)":
                        Answer_Display.Text = (Math.Atan(1 / results)).ToString();
                        break;
                    case "arcsec(x)":
                        Answer_Display.Text = (Math.Acos(1 / results)).ToString();
                        break;
                    case "arccsc(x)":
                        Answer_Display.Text = (Math.Asin(1 / results)).ToString();
                        break;
                    case "sinh(x)":
                        Answer_Display.Text = (Math.Sinh(results)).ToString();
                        break;
                    case "cosh(x)":
                        Answer_Display.Text = (Math.Cosh(results)).ToString();
                        break;
                    case "tanh(x)":
                        Answer_Display.Text = (Math.Tanh(results)).ToString();
                        break;
                    case "coth(x)":
                        Answer_Display.Text = (1 / Math.Tanh(results)).ToString();
                        break;
                    case "sech(x)":
                        Answer_Display.Text = (1 / Math.Cosh(results)).ToString();
                        break;
                    case "csch(x)":
                        Answer_Display.Text = (1 / Math.Sinh(results)).ToString();
                        break;
                    case "arcsinh(x)":
                        Answer_Display.Text = (Math.Asinh(results)).ToString();
                        break;
                    case "arccosh(x)":
                        Answer_Display.Text = (Math.Acosh(results)).ToString();
                        break;
                    case "arctanh(x)":
                        Answer_Display.Text = (Math.Atanh(results)).ToString();
                        break;
                    case "arccoth(x)":
                        Answer_Display.Text = (Math.Atanh(1 / results)).ToString();
                        break;
                    case "arcsech(x)":
                        Answer_Display.Text = (Math.Acosh(1 / results)).ToString();
                        break;
                    case "arccsch(x)":
                        Answer_Display.Text = (Math.Asinh(1 / results)).ToString();
                        break;
                }
            }
            math_expression = Answer_Display.Text;
        }

        private void Rand_Ceil_Floor(object sender, EventArgs e)
        {
            Random n = new Random();
            double randomNum = n.Next();
            Button num = (Button)(sender);
            operation = num.Text;
            Operator_Display.Text = operation;
            results = Double.Parse(Answer_Display.Text);
            switch (operation)
            {
                case "⌈x⌉":
                    Answer_Display.Text = (Math.Ceiling(results)).ToString();
                    break;
                case "⌊x⌋":
                    Answer_Display.Text = (Math.Floor(results)).ToString();
                    break;
                case "rand":
                    Answer_Display.Text = (randomNum).ToString();
                    break;
            }
            math_expression = Answer_Display.Text;
        }
        private void Parenthesis(object sender, EventArgs e)
        {
            Button num = (Button)(sender);
            string parent_Sign = num.Text;
            Operator_Display.Text = parent_Sign;
            //results = Double.Parse(Answer_Display.Text);
            Fixed_Exponent.BackColor = Color.White;
            math_expression += num.Text;
            switch (parent_Sign)
            {
                case "(":
                    count ++;
                    break;
                case ")":
                    count --;
                    break;
            }
            if (count == 0) {
                Counter_Box.Text = "";
            }
            else if(count > 0)
            {
                Counter_Box.Text = count.ToString();
            }

        }

        private void Memory_Group(object sender, EventArgs e)
        {

            Button num = (Button)(sender);
            operation = num.Text;
            Operator_Display.Text = operation;
            results = Double.Parse(Answer_Display.Text);
            switch (operation)
            {
                case "M+":
                    memory += Double.Parse(Answer_Display.Text);
                    break;
                case "M-":
                    memory -= Double.Parse(Answer_Display.Text);
                    break;
                case "MS":
                    memory = Double.Parse(Answer_Display.Text);
                    break;
                case "MR":
                    Answer_Display.Text = memory.ToString();
                    break;
                case "MC":
                    memory = 0;
                    break;
            }

        }
        private void Deg_Shift(object sender, EventArgs e)
        {
            Button num = (Button)(sender);
            string Deg_op = num.Text;
            Operator_Display.Text = Deg_op;
            if (Angle_Unit.Text == "Deg")
            {
                if(Deg_op == "->dms")
                {
                    results = Double.Parse(Answer_Display.Text);
                    string temp_degrees = Answer_Display.Text;
                    int degrees_index = Answer_Display.Text.IndexOf(".");
                    double degrees = Double.Parse(temp_degrees.Substring(0, degrees_index));
                    double temp_minutes = (results - degrees)*60;
                    int minutes_index = (temp_minutes.ToString()).IndexOf(".");
                    double minutes = Double.Parse((temp_minutes.ToString()).Substring(0, minutes_index));
                    double seconds = (temp_minutes - minutes) * 60;
                    Answer_Display.Text = degrees.ToString() + "°" + minutes.ToString() + "'" + seconds.ToString() + '"';
                }
                else
                {
                    string temp_degrees = Answer_Display.Text;
                    int degrees_index = Answer_Display.Text.IndexOf("°");
                    int minutes_index = Answer_Display.Text.IndexOf("'");
                    int seconds_index = Answer_Display.Text.IndexOf('"');
                    Answer_Display.Text = (Double.Parse(temp_degrees.Substring(0, degrees_index)) + (Double.Parse(temp_degrees.Substring(degrees_index + 1, minutes_index-degrees_index-1))/60) + (Double.Parse(temp_degrees.Substring(minutes_index+1, seconds_index - minutes_index-1)))/3600).ToString();
                }
            }
        }
    }
}
