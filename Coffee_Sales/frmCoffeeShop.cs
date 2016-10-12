/*
 * Name : Anju Chawla
 * Date: Sep. 28, 2016
 * Purpose:This application allows the user to select multiple coffee type
 * in various quantities.
 * The amount due is displayed.
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Sales
{
    public partial class frmCoffeeShop : Form
    {
        //module level variables
        //objects are initialised to null, numbers to 0
        private decimal subTotalAmount = 0, totalAmount, grandTotal;
        private int customerCount;
        private RadioButton selectedRadioButton;

        // private int customerCount;

        //module level constants
        const decimal TaxRate = 0.13m;
        const decimal CappuccinoPrice = 2m;
        const decimal EspressoPrice = 2.25m;
        const decimal LattePrice = 1.75m;
        const decimal IcedPrice = 2.50m;




        public frmCoffeeShop()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //calculates the amount for a selected coffee and accumulates
            //the subtotal too since customer can order more than 
            //one coffee in different quantities

            //local variables-do not have a default value
            int quantity = 0;
            decimal price = 0, tax, itemAmount;

            //settings
            chkTakeout.Enabled = false;
            btnNewOrder.Enabled = true;
            btnClear.Enabled = true;
            tsmiClearItem.Enabled = true;
            tsmiNewOrder.Enabled = true;

            //  if (txtQuantity.Text != String.Empty)
            //   {
            try
            {
                quantity = int.Parse(txtQuantity.Text);
                //quantity= Convert.ToInt32(txtQuantity.Text);
                if (quantity > 0)
                {
                    if (selectedRadioButton != null) //coffee is selected
                    {
                        switch (selectedRadioButton.Name)
                        {
                            case "rdoCappuccino":
                                price = CappuccinoPrice;
                                break;
                            case "rdoEspresso":
                                price = EspressoPrice;
                                break;
                            case "rdoIcedCappuccino":
                            case "rdoIcedLatte":
                                price = IcedPrice;
                                break;
                            case "rdoLatte":
                                price = LattePrice;
                                break;
                                //   default:
                                //     price = 0;
                                //     break;

                        }//switch

                        /*
                         //You can replace the switch with a nested if/else
                        if (rdoCappuccino.Checked)
                            price = CappuccinoPrice;
                        else if (rdoEspresso.Checked)
                            price = EspressoPrice;
                        else if (rdoLatte.Checked)
                            price = LattePrice;
                        else   //if(rdoIcedLatte.Checked || rdoIcedCappuccino.Checked)-no need of an if here since no other option
                            price = IcedPrice;


                        */
                        //calculations
                        itemAmount = price * quantity;
                        // subTotalAmount = subTotalAmount + itemAmount;
                        subTotalAmount += itemAmount;

                        if (chkTakeout.Checked)
                        {
                            tax = TaxRate * subTotalAmount;

                        }
                        else
                        {
                            tax = 0;
                        }

                        totalAmount = subTotalAmount + tax;

                        //display these output values 
                        txtItemAmount.Text = itemAmount.ToString("c");
                        txtSubtotal.Text = subTotalAmount.ToString("c");
                        txtTax.Text = tax.ToString("c");
                        txtTotalDue.Text = totalAmount.ToString("c");






                    }// if coffee selected

                    else
                    {
                        MessageBox.Show("Please select a coffee type", "Input Missing",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                }//quantity > 0
                else
                {
                    MessageBox.Show("Please enter a value greater than 0 for the quantity of coffees needed", "Input Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtQuantity.SelectAll();
                    txtQuantity.Focus();
                }
                // }//if quantity is provided

            }//try
            catch (FormatException quantityFE)
            {
                if (txtQuantity.Text == String.Empty)
                {
                    MessageBox.Show("Quantity cannot be left blank, MUST be whole number.", "Quantity Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //MessageBox.Show(quantityFE.Message);
                    MessageBox.Show("Quantity provided MUST be a whole number", "Quantity Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtQuantity.SelectAll(); //txtQuantity.Clear();
                txtQuantity.Focus();

            }
            catch (OverflowException quantityOE)
            {
                MessageBox.Show("Quantity provided out of range", "Quantity Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtQuantity.SelectAll(); //txtQuantity.Clear();
                txtQuantity.Focus();
            }
            catch (Exception quantityEx)
            {
                MessageBox.Show(quantityEx.Message, "Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
                txtQuantity.SelectAll(); //txtQuantity.Clear();
                txtQuantity.Focus();

        }

            /* else
             {
                 MessageBox.Show("Please enter the number of coffees needed", "Input Missing",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                 txtQuantity.Focus();

             }*/

        }

        private void frmCoffeeShop_Load(object sender, EventArgs e)
        {
            //default setting when form is loaded
            btnClear.Enabled = false;
            btnNewOrder.Enabled = false;
            tsmiClearItem.Enabled = false;
            tsmiNewOrder.Enabled = false;
            //rdoCappuccino.Checked = false;
           //rdoCappuccino.AutoCheck = true;

        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //assign selectedRadioButton a value depending on the radio button selected
            selectedRadioButton = (RadioButton)sender;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clear the user input and get back to start default state
            ClearInput();

        }

        private void ClearInput()
        {
            txtQuantity.Clear();
            txtItemAmount.Clear();
            if (selectedRadioButton != null)
            {
                selectedRadioButton.Checked = false;
                selectedRadioButton = null;
            }
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            //clear for next order
            DialogResult confirm;

            confirm = MessageBox.Show("Are you sure you want to place a new order?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (confirm == DialogResult.Yes)
            {
                //clearing the controls
                ClearInput();
                btnClear.Enabled = false;
                btnNewOrder.Enabled = false;
                tsmiNewOrder.Enabled = false;
                tsmiClearItem.Enabled = false;
                txtSubtotal.Clear();
                txtTax.Clear();
                txtTotalDue.Clear();              
                if (chkTakeout.Checked)
                    chkTakeout.Checked = false;
                chkTakeout.Enabled = true;
                txtQuantity.Focus();

                //add the totals to summary totals
                if(subTotalAmount > 0)
                {
                    grandTotal += totalAmount;
                    customerCount++;
                }
                //reset the order totals
                subTotalAmount = 0;
                totalAmount = 0;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //display the about information
            AboutBox1 information = new Coffee_Sales.AboutBox1();
            information.ShowDialog(); 
        }

        private void tsmiFont_Click(object sender, EventArgs e)
        {
            //allow the user to select a font for the output values
            Font currentFont;

            //save the current font
            //currentFont = txtSubtotal.Font;
            //show the dialog box
           // DialogResult response = 
            fontDialog1.ShowDialog();
           // if(response == DialogResult.OK)
            currentFont = fontDialog1.Font;
            txtSubtotal.Font = currentFont;
            txtTax.Font = currentFont;
            txtTotalDue.Font = currentFont;



        }

        private void tsmiColor_Click(object sender, EventArgs e)
        {
            //allow the user to select the for color of the output

            Color currentColor;
            //display the color dialog box
            colorDialog1.ShowDialog();
            //save the selected color
            currentColor = colorDialog1.Color;
            //backcolor changes when text boxes are made read-only
            //hence color of output does not change
            //irrelevant assignments to make it work
            txtSubtotal.BackColor = txtSubtotal.BackColor;
            txtTax.BackColor = txtTax.BackColor;
            txtTotalDue.BackColor = txtTotalDue.BackColor;
            //set the color of the output text
            txtSubtotal.ForeColor = currentColor;
            txtTax.ForeColor = currentColor;
            txtTotalDue.ForeColor = currentColor;

        }

        private void tsmiSummary_Click(object sender, EventArgs e)
        {
            //show the summary information
            decimal average;
            string message;

            //customer is in the middle of an order
            if(totalAmount != 0)
            {
                btnNewOrder_Click(sender, e);
            }
            if(customerCount > 0)//customers have been served
            {
                average = grandTotal / customerCount;
                message = "Number of Orders: " + customerCount.ToString() +
                    "\n" + "Total Sales: " + grandTotal.ToString("c") +
                    Environment.NewLine + "Average Sales: " + average.ToString("c");

                MessageBox.Show(message, "Coffee Sales Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No sales made yet...no summary information to display",
                    "Coffee Sales Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}
