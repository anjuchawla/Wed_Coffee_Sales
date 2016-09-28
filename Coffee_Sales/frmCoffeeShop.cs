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
        private decimal subTotalAmount = 0, totalAmount;
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
            decimal price=0, tax, itemAmount;

            chkTakeout.Enabled = false;

            if (txtQuantity.Text != String.Empty)
            {
                quantity = int.Parse(txtQuantity.Text);
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
                }//if quantity is provided
                else
                {
                    MessageBox.Show("Please enter the number of coffees needed", "Input Missing",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQuantity.Focus();

                }

            }

        private void frmCoffeeShop_Load(object sender, EventArgs e)
        {


        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            //assign selectedRadioButton a value depending on the radio button selected
            selectedRadioButton =(RadioButton) sender;
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
            //Application.Restart();
            ClearInput();
            txtSubtotal.Clear();
            txtTax.Clear();
            txtTotalDue.Clear();
            subTotalAmount = 0;
            totalAmount = 0;
            if(chkTakeout.Checked)
                chkTakeout.Checked = false;
            chkTakeout.Enabled = true;
            txtQuantity.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
    }
}
