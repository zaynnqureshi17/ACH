﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddBank : Form
    {
        private string bankName;
        private int banktype;

        public AddBank(string Bankname, int banktypeindex)
        {
            this.banktype = banktypeindex;
            this.bankName = Bankname;
            InitializeComponent();
        }

        private DataSet dataSet2 = new DataSet();
        private DataSet dataSet1 = new DataSet();
        private int counter;

        private void AddBank_Load(object sender, EventArgs e)
        {
            if (File.Exists("Bank.xml"))
            {
                dataSet1.ReadXml("Bank.xml");
                counter = dataSet1.Tables["Banks"].Rows.Count;
            }
            else
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable();
                dataTable.TableName = "Banks";
                dataTable.Columns.Add("CompanyName");
                dataTable.Columns.Add("CompanyBankNumber");
                dataTable.Columns.Add("CompanyBranchNumber");
                dataTable.Columns.Add("CompanyAccountNumber");
                dataTable.Columns.Add("DestinationDataCenter");
                dataTable.Columns.Add("OriginatorID");
                dataTable.Columns.Add("Credit");
                dataTable.Columns.Add("Debit");
                dataTable.Columns.Add("Header");
                dataTable.Columns.Add("FileNumber");
                dataTable.Columns.Add("Password", typeof(String)).SetOrdinal(10);
                dataSet.Tables.Add(dataTable);
                DataRow row0 = dataSet.Tables["Banks"].NewRow();
                dataSet.Tables["Banks"].Rows.Add(row0);
                row0["CompanyName"] = "";
                row0["CompanyBankNumber"] = "";
                row0["CompanyBranchNumber"] = "";
                row0["CompanyAccountNumber"] = "";
                row0["DestinationDataCenter"] = "";
                row0["OriginatorID"] = "";
                row0["Credit"] = "";
                row0["Debit"] = "";
                row0["Header"] = "";
                row0["FileNumber"] = "";
                row0["Password"] = "6hGvVnbkaGpo8mUHOX8EHQ==";
                counter = dataSet.Tables["Banks"].Rows.Count;

                dataSet.WriteXml("Bank.xml");
            }

            MessageBox.Show("Click on Proceed button to go to next step");
            if (banktype == 0)
            {
                lblBankType.Text = "Bank Type is : RBC";
                lblDebit.Visible = false;
                lblCredit.Visible = false;
                txtDebit.Visible = false;
                txtCredit.Visible = false;
            }
            else
            {
                lblBankType.Text = "Bank Type is : BMO";
                lblOrID.Visible = false;
                lblHeader.Visible = false;
                txtOrID.Visible = false;
                txtHeader.Visible = false;
            }

            lblBank.Text = "Bank Name is : " + bankName;
        }

        private void btnAddNewBank_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            //cboBankType.Items.Add("RBC");
            //cboBankType.Items.Add("BMO");
            dataSet2.ReadXml("Bank.xml");
            lblBank.Text = "Bank Name is : " + bankName;
            DialogResult result = MessageBox.Show("Are you sure you want to add a new bank?", "Add New Bank", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                if (dataSet2.Tables["Banks"].Rows[0][0].ToString() == "")
                {
                    counter = counter - 1;
                    dataSet2.Tables["Banks"].Rows[counter][0] = Eramake.eCryptography.Encrypt(txtCName.Text);
                    dataSet2.Tables["Banks"].Rows[counter][1] = Eramake.eCryptography.Encrypt(txtCBNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][2] = Eramake.eCryptography.Encrypt(txtCBrNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][3] = Eramake.eCryptography.Encrypt(txtAcc.Text);
                    dataSet2.Tables["Banks"].Rows[counter][4] = Eramake.eCryptography.Encrypt(txtlDesDataCenter.Text);
                    dataSet2.Tables["Banks"].Rows[counter][5] = Eramake.eCryptography.Encrypt(txtOrID.Text);
                    dataSet2.Tables["Banks"].Rows[counter][6] = Eramake.eCryptography.Encrypt(txtHeader.Text);
                    dataSet2.Tables["Banks"].Rows[counter][9] = "";
                    dataSet2.Tables["Banks"].Rows[counter][10] = "6hGvVnbkaGpo8mUHOX8EHQ==";
                }
                else
                {
                    DataRow x = dataSet2.Tables["Banks"].NewRow();
                    dataSet2.Tables["Banks"].Rows.Add(x);
                }
                //counter++;
                if (banktype == 0)
                {
                    //counter = counter - 1;
                    dataSet2.Tables["Banks"].Rows[counter][0] = Eramake.eCryptography.Encrypt(txtCName.Text);
                    dataSet2.Tables["Banks"].Rows[counter][1] = Eramake.eCryptography.Encrypt(txtCBNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][2] = Eramake.eCryptography.Encrypt(txtCBrNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][3] = Eramake.eCryptography.Encrypt(txtAcc.Text);
                    dataSet2.Tables["Banks"].Rows[counter][4] = Eramake.eCryptography.Encrypt(txtlDesDataCenter.Text);
                    dataSet2.Tables["Banks"].Rows[counter][5] = Eramake.eCryptography.Encrypt(txtOrID.Text);
                    dataSet2.Tables["Banks"].Rows[counter][6] = Eramake.eCryptography.Encrypt(txtHeader.Text);
                    dataSet2.Tables["Banks"].Rows[counter][9] = "";

                    dataSet2.WriteXml("Bank.xml");
                }
                else if (banktype == 1)
                {
                    //counter = counter - 1;
                    dataSet2.Tables["Banks"].Rows[counter][0] = Eramake.eCryptography.Encrypt(txtCName.Text);
                    dataSet2.Tables["Banks"].Rows[counter][1] = Eramake.eCryptography.Encrypt(txtCBNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][2] = Eramake.eCryptography.Encrypt(txtCBrNo.Text);
                    dataSet2.Tables["Banks"].Rows[counter][3] = Eramake.eCryptography.Encrypt(txtAcc.Text);
                    dataSet2.Tables["Banks"].Rows[counter][4] = Eramake.eCryptography.Encrypt(txtlDesDataCenter.Text);
                    dataSet2.Tables["Banks"].Rows[counter][7] = Eramake.eCryptography.Encrypt(txtCredit.Text);
                    dataSet2.Tables["Banks"].Rows[counter][8] = Eramake.eCryptography.Encrypt(txtDebit.Text);
                    dataSet2.Tables["Banks"].Rows[counter][9] = "";

                    dataSet2.WriteXml("Bank.xml");
                }
                MessageBox.Show("Bank has been added successfully");
                this.Close();
                Start start = new Start();
                start.Show();
            }
        }
    }
}