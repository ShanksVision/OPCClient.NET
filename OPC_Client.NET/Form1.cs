using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCAutomation;

namespace OPC_Client.NET
{
    public partial class frmOPCClient : Form
    {
        private OPCTag[] tags;
        private bool updateOPC = false;
        private int tagCount = Properties.Settings.Default.TagCount;
        private OPCServer mServer;
        private OPCGroups mGroups;
        private OPCGroup mGroup;
        private OPCBrowser mBrowser;
        
        private bool mServerConnected;

        private const int DEFAULT_GROUP_UPDATE_RATE = 50;
        private const int DEFAULT_GROUP_DEAD_BAND = 0;
        private const bool DEFAULT_GROUP_IS_ACTIVE = true;       

        public frmOPCClient()
        {
            InitializeComponent();
            tags = new OPCTag[tagCount];
            for (int i = 0; i < tagCount; i++)
            {
                tags[i] = new OPCTag();
                tags[i].sensorName = Properties.Settings.Default.SensorName;
                tags[i].tagName = Properties.Settings.Default.TagName;
            }

            GetOPCServerList();
            
        }

        private void GetOPCServerList()
        {            
            try
            {
                this.mServer = new OPCServer();
                object opcServerList = mServer.GetOPCServers(string.Empty);                
                if(opcServerList != null && opcServerList is Array)
                {
                    Array opcServers = (Array)opcServerList;
                    for(int i = opcServers.GetLowerBound(0); i <= opcServers.GetUpperBound(0); i++)
                    {
                        this.lBoxOPCServers.Items.Add(opcServers.GetValue(i).ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRefreshServer_Click(object sender, EventArgs e)
        {
            this.lBoxOPCServers.Items.Clear();
            this.GetOPCServerList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (lBoxOPCServers.Items == null || lBoxOPCServers.Items.Count == 0 || lBoxOPCServers.SelectedItem == null)
                {
                    MessageBox.Show("No OPC Servers Found or selected!!");
                    return;
                }

                if (!mServerConnected)
                {
                    this.mServer = new OPCServer();
                    this.mServer.Connect(lBoxOPCServers.SelectedItem.ToString(), string.Empty);
                    this.mServerConnected = true;
                    this.mGroups = mServer.OPCGroups;
                    this.btnConnect.Text = "Disconnect";
                    this.mServer.ClientName = "OPC_Client.NET";
                    this.mServer.ServerShutDown += new DIOPCServerEvent_ServerShutDownEventHandler(mServerShutdown);
                    MessageBox.Show("Connection Succesfull!!");
                    this.PopulateTags();
                }
                else
                {
                    this.mServer.Disconnect();
                    this.btnConnect.Text = "Connect";
                    this.mServer.ServerShutDown -= new DIOPCServerEvent_ServerShutDownEventHandler(mServerShutdown);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed!!");
            }
           
        }

        private void PopulateTags()
        {
            try
            {
                if (this.tags == null)
                    return;

            string sSensor;

            //Clear any current groups
            if (this.mGroups != null)
            {
                this.mGroups.RemoveAll();
            }

            if (this.mGroup != null)
                this.mGroup.DataChange -= new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(this.mGroupDataChange);

            this.mGroups.DefaultGroupUpdateRate = DEFAULT_GROUP_UPDATE_RATE;
            this.mGroups.DefaultGroupDeadband = DEFAULT_GROUP_DEAD_BAND;
            this.mGroups.DefaultGroupIsActive = DEFAULT_GROUP_IS_ACTIVE;

            //Create a new group for the tags to be selected
            this.mGroup = this.mGroups.Add("default");
            this.mGroup.UpdateRate = 50;
            this.mGroup.IsSubscribed = true;
            this.mGroup.DataChange += new OPCAutomation.DIOPCGroupEvent_DataChangeEventHandler(this.mGroupDataChange);
            
            if (this.mServerConnected)
            {
                //create a new instance of a browser (view)
                this.mBrowser = mServer.CreateBrowser();
                //Set up the browser with basic/default values.
                this.mBrowser.AccessRights = System.Convert.ToInt32(OPCAutomation.OPCAccessRights.OPCReadable); //view all tags
                //Data type filter (0 for none)
                this.mBrowser.DataType = 0;
                //only sensors in the browser view
                this.mBrowser.ShowBranches();

                try
                {
                    int clienthandle = 1;
                    foreach (OPCTag tempTag in this.tags)
                    {

                        sSensor = tempTag.sensorName;
                        this.mBrowser.MoveToRoot();
                        if(!string.IsNullOrWhiteSpace(sSensor))
                        {
                            try
                            {
                                this.mBrowser.MoveDown(sSensor);
                            }
                            catch
                            {
                                continue;
                            }
                        }
                       
                        // get the flat list of tags
                        this.mBrowser.ShowLeafs(true);

                        //Traverse through each tag of the selected sensor, storing it to the OPC Group
                        for (int i = 1; i <= this.mBrowser.Count; i++)
                        {
                            string sValue = string.Empty;
                            object vItemID = this.mBrowser.Item(i).ToString();
                            string sItemID = vItemID.ToString();
                            this.lBoxTags.Items.Add(sItemID);
                            //ListViewItem oListViewItem = lstTags.Items.Add(sItemID);

                            //Adding the new tag to the OPC Group.
                            //if (sItemID.Contains(tempTag.tagName))
                            //{
                            //    this.mGroup.OPCItems.AddItem(sItemID, clienthandle);                                
                            //    clienthandle++;
                            //    break;
                            //}
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Exception in Refresh the data on OPC server. Please make sure the OPC Server service is started.");
                    updateOPC = true;
                }
            }

            }
            catch (Exception)
            {

                MessageBox.Show("Exception when populating tags from the selected OPC Server.");
            }
        }

        private void frmOPCClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.Disconnect();
            mServer.ServerShutDown -= new DIOPCServerEvent_ServerShutDownEventHandler(mServerShutdown);
        }

        private void mServerShutdown(string Reason)
        {
            this.Cursor = Cursors.WaitCursor;           

            //Removes all current OPCGroup and OPCItem objects to prepare for server shutdown.
            if (mGroups != null)
            {
                mGroups.RemoveAll();
                mServerConnected = false;
                lBoxTags.Items.Clear();
            }

            this.Cursor = Cursors.Default;
        }

        private void mGroupDataChange(int TransactionID, int NumItems, ref System.Array ClientHandles, ref System.Array ItemValues, ref System.Array Qualities, ref System.Array TimeStamps)
        {
            //MessageBox.Show(ItemValues.GetValue(1).ToString() + " " + Convert.ToDateTime(TimeStamps.GetValue(1).ToString()).ToLocalTime().ToString());
            for (int i = 1; i <= NumItems; i++)
            {
                string sensor = "";
                string tag = "";
                DateTime auditdate = Convert.ToDateTime(TimeStamps.GetValue(i).ToString()).ToLocalTime();
                string data = ItemValues.GetValue(i).ToString();

                string item = mGroup.OPCItems.Item(ClientHandles.GetValue(i)).ItemID;
                string[] items = item.Split('.');
                if (items.Length > 1)
                {
                    sensor = items[0];
                    tag = items[1];
                }

                if (data != "")
                {
                    this.lblTagName.Text = tag;
                    this.lblTagValue.Text = data;                    
                }
            }
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            try
            {
                if(lBoxTags.Items == null || lBoxTags.Items.Count == 0 || lBoxTags.SelectedItem == null)
                {
                    MessageBox.Show("No tags found or selected!!");
                    return;
                }

                
                this.mGroup.OPCItems.AddItem(lBoxTags.SelectedItem.ToString(), 1);
                string[] items = lBoxTags.SelectedItem.ToString().Split('.');
                Properties.Settings.Default.SensorName = items[0];
                Properties.Settings.Default.TagName = items[1];
                Properties.Settings.Default.Save();
                MessageBox.Show("Tag Added succesfully");
            }
            catch (Exception)
            {

                MessageBox.Show("Exception while adding tags");
            }
        }




    }

    public class OPCTag
    {
        public string sensorName;
        public string tagName;
    }
}
