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
        private RadioButton selectedRadioButton;
        private decimal subTotalAmount = 0, totalAmount;
        private int customerCount;

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
            int quantity;
            decimal price, tax, itemAmount;

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
                        else if (rdoIcedLatte.Checked)
                            price = LattePrice;
                        else    //if(rdoIcedLatte.Checked || rdoIcedCappuccino.Checked)-no need of an if here since no other option
                            price = IcedPrice;
                        
                        */


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
    }
}
