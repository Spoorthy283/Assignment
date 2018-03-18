using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoreItem_NutidAB.Client;
using StoreItem_NutidAB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreItem_NutidAB
{
    public partial class Form1 : Form
    {
        public HttpStatusCode statusCode;
        public String url = String.Empty;
        public String httpMethod = "GET"; //Default GET Method
        public bool isDataFomGrid = true;
        public bool isValidGridData = false;

        public Form1()
        {
            InitializeComponent();
            MethodComboBox.SelectedIndex = 0;
        }

        //Method identifies the type of request made i.e GET or POST
        //Display or Hide controls based on type of request
        //GET selected : Hide the DataGrid and JsonData TextBox
        //POST selected : Display the DataGrid and JsonData TextBox and enable DataGrid, disable Json TextBox bydefault
        //Clear DataGrid and Response Message of previous request    
        private void MethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResponseMessage.Text = String.Empty;
            DataGridView.Rows.Clear();
            DataGridView.Refresh();
            httpMethod = MethodComboBox.SelectedItem.ToString();

            if(httpMethod.Equals("GET"))
            {
                SelectPostMethodLabel.Visible = false;
                PostMethodComboBox.Visible = false;
                DataGridLabel.Visible = false;
                DataGridView.Visible = false;
                AddRow.Visible = false;
                JsonInputlabel.Visible = false;
                JsonDataTextBox.Visible = false;                              
            }            
            else if (httpMethod.Equals("POST"))
            {
                SelectPostMethodLabel.Visible = true;
                PostMethodComboBox.Visible = true;
                PostMethodComboBox.SelectedIndex = 0;  //set default input for Post as DataGrid
                DataGridLabel.Visible = true;
                DataGridView.Visible = true;
                DataGridView.Enabled = true;
                AddRow.Enabled = true;
                AddRow.Visible = true;
                GenerateColumns();
                JsonInputlabel.Visible = true;
                JsonDataTextBox.Visible = true;
                JsonDataTextBox.Enabled = false;
            }
           
        }

        //Trigger client request based on GET or POST
        //GET request: Get list of StoreItems and display data and response status
        //POST request: Check input type for Post request i.e Using DataGrid or Using JsonData 
        //            : Fetch data from DataGrid or JsonData TextBox
        //            : Make POST request to server and display response 
        private void Send_Click(object sender, EventArgs e)
        {
            ResponseMessage.Text = String.Empty;            
            List<StoreItem> storeItems;
            url = RestUrl.Text;
            try
            {
                StoreItemClient client = new StoreItemClient();
                if (httpMethod.Equals("GET"))
                {
                    DisplayResponseMessage("Request: " + httpMethod);
                    DisplayResponseMessage("Requested Url: " + url);

                    DataGridView.Rows.Clear();
                    DataGridView.Refresh();
                    storeItems = client.GetData(ref url, ref statusCode);                    
                    DisplayResponseMessage("Response StatusCode: " + (int)statusCode +" "+ statusCode);

                    if (storeItems.Any())
                    {
                        DisplayData(storeItems);
                        storeItems.Clear();
                        DisplayResponseMessage("Recieved data from server");
                    }                    
                }
                else if (httpMethod.Equals("POST"))
                {
                    DisplayResponseMessage("Request: " + httpMethod);
                    DisplayResponseMessage("Requested Url: " + url);
                    if (isDataFomGrid && CheckAllCells() )  //If Using DataGrid and has valid data
                    {                         
                        storeItems = GetDataFromGrid();
                        DataGridView.Rows.Clear();
                        DataGridView.Refresh();
                        client.UpdateData(ref url, storeItems, ref statusCode);
                        storeItems.Clear();                        
                        DisplayResponseMessage("Response StatusCode: " + (int)statusCode +" "+ statusCode);                       
                    }                    
                    else if(!isDataFomGrid)     //If Using JsonData TextBox
                    {
                        String postJsonData = JsonDataTextBox.Text;
                        if (IsValidJson(postJsonData)) 
                        {
                            JsonDataTextBox.Clear();
                            client.UpdateData(ref url, ref postJsonData, ref statusCode);                            
                            DisplayResponseMessage("Response StatusCode: " + (int)statusCode +" "+ statusCode);
                        }
                        else
                        {
                            DisplayResponseMessage("Empty or Invalid Json String");
                        }                        
                    }
                }
            }
            catch(Exception ex)
            {
                DisplayResponseMessage(ex.Message);
            }          

        }

        //Display data recieved from server in DataGrid
        private void DisplayData(List<StoreItem> storeItems)
        {
            try
            {
                GenerateColumns();  
                foreach (var storeItem in storeItems)
                {
                    DataGridView.Rows.Add(storeItem.Id, storeItem.Barcode, storeItem.ItemId, storeItem.ItemNumber, storeItem.CatalogNumber,
                        storeItem.StoreItemDescriptions[0].Id,storeItem.StoreItemDescriptions[0].ItemId, storeItem.StoreItemDescriptions[0].LandId, storeItem.StoreItemDescriptions[0].Description,
                        storeItem.StoreItemPrices[0].Id,storeItem.StoreItemPrices[0].LandId, storeItem.StoreItemPrices[0].BuyPrice, storeItem.StoreItemPrices[0].SellPrice,
                        storeItem.StoreDepartment.Id,storeItem.StoreDepartment.GroupId, storeItem.StoreDepartment.storeId, storeItem.StoreDepartment.account,
                        storeItem.StoreItemStorageAmounts[0].Id, storeItem.StoreItemStorageAmounts[0].Amount,
                        storeItem.Unit.Id, storeItem.Unit.Type);
                }
            }
            catch(Exception e)
            {
                DisplayResponseMessage("Problem:" + e.Message);
            }
        }

        //Generate Columns for Data Grid and set its ValueType
        private void GenerateColumns()
        {
            DataGridView.Rows.Clear();
            DataGridView.Refresh();
            DataGridView.ColumnCount = 21;
            try
            {
                Dictionary<string, Type> columnMap = new Dictionary<string, Type>();
                columnMap.Add("StoreItem Id", typeof(Int32));
                columnMap.Add("Barcode", typeof(String));
                columnMap.Add("ItemId", typeof(Int32));
                columnMap.Add("ItemNumber", typeof(String));
                columnMap.Add("CatalogNumber", typeof(String));
                columnMap.Add("StoreItemDesc Id", typeof(Int32));
                columnMap.Add("StoreItemDesc Item Id", typeof(Int32));
                columnMap.Add("StoreItemDesc LandId", typeof(Int32));
                columnMap.Add("StoreItemDesc Description", typeof(String));
                columnMap.Add("StoreItemPrices Id", typeof(Int32));
                columnMap.Add("StoreItemPrices LandId", typeof(Int32));
                columnMap.Add("StoreItemPrices BuyPrice", typeof(Decimal));
                columnMap.Add("StoreItemPrices SellPrice", typeof(Decimal));
                columnMap.Add("StoreDepartment Id", typeof(Int32));
                columnMap.Add("StoreDepartment GroupId", typeof(Int32));
                columnMap.Add("StoreDepartment StoreId", typeof(Int32));
                columnMap.Add("StoreDepartment Account", typeof(String));
                columnMap.Add("StoreItemStorageAmount Id", typeof(Int32));
                columnMap.Add("StoreItemStorageAmount Amount", typeof(Decimal));
                columnMap.Add("Unit Id", typeof(Int32));
                columnMap.Add("Unit Type", typeof(String));

                List<String> colNames = new List<string>(columnMap.Keys);
                List<Type> colType = new List<Type>(columnMap.Values);
                int i = 0;
                while (i < columnMap.Count)
                {
                    DataGridView.Columns[i].Name = colNames[i];
                    DataGridView.Columns[i].ValueType = colType[i];
                    i++;
                }

                columnMap.Clear();
                colNames.Clear();
                colType.Clear();
            }
            catch (Exception e)
            {
                DisplayResponseMessage(e.Message);
            }

            DataGridView.ScrollBars = ScrollBars.Both;
            DataGridView.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            DataGridView.Visible = true;
            DataGridLabel.Visible = true;
        }

        //Get data from grid and load it to list of StoreItem
        private List<StoreItem> GetDataFromGrid()
        {           
            List<StoreItem> storeItems = new List<StoreItem>();
            StoreItem storeItem;
            StoreItemDescription storeItemDescription;
            StoreItemPrice storeItemPrice;
            StoreItemStorageAmount storeItemStorageAmount;            

            try
            {
                foreach (DataGridViewRow row in DataGridView.Rows) 
                {                    
                    storeItem = new StoreItem();
                    storeItem.Id = Int32.Parse(row.Cells["StoreItem Id"].Value.ToString());
                    storeItem.Barcode = row.Cells["Barcode"].Value.ToString();
                    storeItem.ItemId = Int32.Parse(row.Cells["ItemId"].Value.ToString());
                    storeItem.ItemNumber = row.Cells["ItemNumber"].Value.ToString();
                    storeItem.CatalogNumber = row.Cells["CatalogNumber"].Value.ToString();

                    storeItemDescription = new StoreItemDescription();                
                    storeItemDescription.Id = Int32.Parse(row.Cells["StoreItemDesc Id"].Value.ToString());
                    storeItemDescription.ItemId = Int32.Parse(row.Cells["StoreItemDesc Item Id"].Value.ToString());
                    storeItemDescription.LandId = Int32.Parse(row.Cells["StoreItemDesc LandId"].Value.ToString());
                    storeItemDescription.Description = row.Cells["StoreItemDesc Description"].Value.ToString();                    
                    storeItem.StoreItemDescriptions.Add(storeItemDescription);
                   
                    storeItemPrice = new StoreItemPrice();
                    storeItemPrice.Id = Int32.Parse(row.Cells["StoreItemPrices Id"].Value.ToString());
                    storeItemPrice.LandId = Int32.Parse(row.Cells["StoreItemPrices LandId"].Value.ToString());
                    storeItemPrice.BuyPrice = Decimal.Parse(row.Cells["StoreItemPrices BuyPrice"].Value.ToString());
                    storeItemPrice.SellPrice = Decimal.Parse(row.Cells["StoreItemPrices SellPrice"].Value.ToString());                    
                    storeItem.StoreItemPrices.Add(storeItemPrice);

                    storeItem.StoreDepartment.Id = Int32.Parse(row.Cells["StoreDepartment Id"].Value.ToString());
                    storeItem.StoreDepartment.GroupId = Int32.Parse(row.Cells["StoreDepartment GroupId"].Value.ToString());
                    storeItem.StoreDepartment.storeId = Int32.Parse(row.Cells["StoreDepartment StoreId"].Value.ToString());                   
                    storeItem.StoreDepartment.account = row.Cells["StoreDepartment Account"].Value.ToString();

                    storeItemStorageAmount = new StoreItemStorageAmount();
                    storeItemStorageAmount.Id = Int32.Parse(row.Cells["StoreItemStorageAmount Id"].Value.ToString());
                    storeItemStorageAmount.Amount = Decimal.Parse(row.Cells["StoreItemStorageAmount Amount"].Value.ToString());
                    storeItem.StoreItemStorageAmounts.Add(storeItemStorageAmount);

                    storeItem.Unit.Id = Int32.Parse(row.Cells["Unit Id"].Value.ToString());
                    storeItem.Unit.Type = row.Cells["Unit Type"].Value.ToString();
                    storeItems.Add(storeItem);
                }                
            }            
            catch(Exception e)
            {               
                DisplayResponseMessage(e.Message);
            }
           
            return storeItems;
        }
       
        //Check if Input string is valid json string or not
        private bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Display all Response Messages to User
        private void DisplayResponseMessage(String msg)
        {           
            ResponseMessage.Text = ResponseMessage.Text + msg +Environment.NewLine;                       
        }

        //Add Rows to Grid
        private void AddRow_Click(object sender, EventArgs e)
        {            
            DataGridView.Rows.Add(1);                            
        }

        //Check all fields in DataGrid have value, and has atleast 1 item
        public bool CheckAllCells()
        {
            bool check = false;
            if (DataGridView.RowCount != 0)
            {
                for (int i = 0; i < DataGridView.RowCount; i++)
                {
                    for (int j = 0; j < DataGridView.ColumnCount; j++)
                    {
                        var value = DataGridView.Rows[i].Cells[j].Value;
                        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                        {
                            check = false;
                            DisplayResponseMessage("Please enter all the fields before sending the request");
                            return check;
                        }
                    }
                }
                check = true;
            }
            else
            {
                DisplayResponseMessage("Please add data before sending the request");
            }
            return check;
        }
        
        //Check data entered in fields of DataGrid has valid value
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Enter Valid Data", "alert");
        }

        //Identify if DataGrid or through JsonData Textbox
        //DataGrid: Enable DataGrid, Disable JsonData Textbox
        //JsonData: Enable JsonData TextBox, Disable DataGrid
        private void PostMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String postMethod = PostMethodComboBox.SelectedItem.ToString();
            if(postMethod.Equals("Using DataGrid"))
            {
                DataGridView.Enabled = true;
                AddRow.Enabled = true;
                isDataFomGrid = true;
                JsonDataTextBox.Clear();
                JsonDataTextBox.Enabled = false;               
            }
            else
            {
                JsonDataTextBox.Enabled = true;
                DataGridView.Rows.Clear();
                DataGridView.Refresh();
                DataGridView.Enabled = false;
                AddRow.Enabled = false;
                isDataFomGrid = false;
            }           
        }
    }
}
