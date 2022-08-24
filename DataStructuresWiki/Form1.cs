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
// Patrick Wheatley
// 11/08/2022
namespace DataStructuresWiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //9.1	Create a global 2D string array, use static variables for the dimensions (row, column)
        static int dsRows = 12;
        static int dsCols = 4;
        string[,] DataStructures = new string[dsRows, dsCols];

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataStructuresInformation();
            displayData();
        }

        private void LoadDataStructuresInformation()
        {
            DataStructures[0, 0] = "Array";
            DataStructures[0, 1] = "Array";
            DataStructures[0, 2] = "Linear";
            DataStructures[0, 3] = "An Array is a type of data structure that allows the application to hold entire sets of values at once. Arrays can also have multiple dimensions, 1D, 2D, 3D, etc. Arrays have set sizes on initialization which means the size cannot be changed. ";

            DataStructures[1, 0] = "Two Dimensional Array";
            DataStructures[1, 1] = "Array";
            DataStructures[1, 2] = "Linear";
            DataStructures[1, 3] = "A 2D Array is basically having multiple arrays in one array. It is best to think of it like a table with X many rows and Y many columns. These are mostly used in databases and saves time creating multiple 1D Arrays. ";

            DataStructures[2, 0] = "List";
            DataStructures[2, 1] = "List";
            DataStructures[2, 2] = "Linear";
            DataStructures[2, 3] = "A list is like an array, but the size can be changed at any time. Lists can also be multidimensional. Lists can be unordered.";

            DataStructures[3, 0] = "Linked list";
            DataStructures[3, 1] = "List";
            DataStructures[3, 2] = "Linear";
            DataStructures[3, 3] = "A linked list is a list, but it is ordered. ";

            DataStructures[4, 0] = "Self-Balance Tree";
            DataStructures[4, 1] = "Tree";
            DataStructures[4, 2] = "Non-Linear";
            DataStructures[4, 3] = "A Self-Balance Tree is a node-based binary search tree that automatically keeps it height small in the face of arbitrary item insertions and deletions. ";

            DataStructures[5, 0] = "Heap";
            DataStructures[5, 1] = "Tree";
            DataStructures[5, 2] = "Non-Linear";
            DataStructures[5, 3] = "A heap is a specialized tree-based data structure which is essentially and almost complete tree that satisfies the heap property. These heap trees follow a specific order. ";

            DataStructures[6, 0] = "Binary Search Tree";
            DataStructures[6, 1] = "Tree";
            DataStructures[6, 2] = "Non-Linear";
            DataStructures[6, 3] = "A Binary Search Tree is a rooted binary tree data structure with the key of each internal node being greater than all the keys in the respective node’s left sub tree and less than the ones in the right sub tree. ";

            DataStructures[7, 0] = "Graph";
            DataStructures[7, 1] = "Graphs";
            DataStructures[7, 2] = "Non-Linear";
            DataStructures[7, 3] = "A graph is a data structure that consists of nodes and edges. Nodes are referred to as vertices and the edges are lines or arcs that connect any two nodes in the graph. These are mainly used to solve real life problems and represent networks. ";

            DataStructures[8, 0] = "Set";
            DataStructures[8, 1] = "Abstract";
            DataStructures[8, 2] = "Non-Linear";
            DataStructures[8, 3] = "A set is an abstract data type that can store unique values without any particular order. ";

            DataStructures[9, 0] = "Queue";
            DataStructures[9, 1] = "Abstract";
            DataStructures[9, 2] = "Linear";
            DataStructures[9, 3] = "A queue is a data type that stores items in an ordered and linear sequence.";

            DataStructures[10, 0] = "Stack";
            DataStructures[10, 1] = "Abstract";
            DataStructures[10, 2] = "Linear";
            DataStructures[10, 3] = "A stack is an abstract data type that holds items with two main principals: Push and Pop. The push puts a new item on to the top of the stack. The push takes the top item off the stack. ";

            DataStructures[11, 0] = "Hash Tabe";
            DataStructures[11, 1] = "Hash";
            DataStructures[11, 2] = "Non-Linear";
            DataStructures[11, 3] = "A hash function is a function that can be used to map data of arbitrary size to fixed-size values. The values returned by a hash function are called hash values, hash codes, digests or just hashes. ";
        }

        private void btnDisplayInformation_Click(object sender, EventArgs e)
        {
            // 9.8	Create a display method that will show the following information in a ListView: Name and Category,
            displayData();
        }

        private void Sort()
        {
            // 9.6	Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods),
            for (int i = 1; i < dsRows; i++)
            {
                for (int j = 0; j < dsRows - 1; j++)
                {
                    if (!(string.IsNullOrEmpty(DataStructures[j + 1, 0])))
                    {
                        if (string.Compare(DataStructures[j,0], DataStructures[j + 1, 0]) == 1)
                        {
                            swap(j); // swaps the data.
                        }
                    }
                }
            }
        }

        private void swap(int index)
        {
            // 9.6	Write the code for a Bubble Sort method to sort the 2D array by Name ascending, ensure you use a separate swap method that passes the array element to be swapped (do not use any built-in array methods),
            string temp;
            for (int i = 0; i < dsCols; i++)
            {
                temp = DataStructures[index, i];
                DataStructures[index, i] = DataStructures[index + 1, i];
                DataStructures[index + 1, i] = temp;
            }
        }

        private void displayData()
        {
            // 9.8	Create a display method that will show the following information in a ListView: Name and Category
            lvDataStructures.Items.Clear();
            Sort();
            for (int i = 0; i < dsRows; i++)
            {
                ListViewItem lv1 = new ListViewItem(DataStructures[i, 0], 0);
                lv1.SubItems.Add(DataStructures[i, 1]);
                lvDataStructures.Items.Add(lv1);
            }
        }

        private void displayTBXInformation(int slIndex)
        {
            // 9.9	Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes,
            tbxName.Text = DataStructures[slIndex,0];
            tbxCategory.Text = DataStructures[slIndex,1];
            tbxStructure.Text = DataStructures[slIndex,2];
            tbxDefinition.Text = DataStructures[slIndex,3];
        }

        private void lvDataStructures_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 9.9	Create a method so the user can select a definition (Name) from the ListView and all the information is displayed in the appropriate Textboxes.
            try
            {
                displayTBXInformation(lvDataStructures.SelectedIndices[0]);
            }
            catch (Exception)
            {
                updateSS("Nothing selected to display.");
            }          
        }

        private void updateSS(string input)
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(input);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 9.7	Write the code for a Binary Search for the Name in the 2D array and display the information in the other textboxes when found, add suitable feedback if the search in not successful and clear the search textbox (do not use any built-in array methods),
            string userText = tbxSearchBar.Text;
            bool wasFound = false;
            int left = 0;
            int right = dsRows - 1;
            while (left <= right) 
            {
                int mid = left + (right - left) / 2;
                int result = userText.CompareTo(DataStructures[mid,0]);

                if (result == 0)
                {
                    displayTBXInformation(mid);
                    lvDataStructures.Items[mid].Focused = true;
                    lvDataStructures.Items[mid].Selected = true;
                    updateSS(userText + " was found!");
                    wasFound = true;
                }
                if (result > 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            if (wasFound == false)
            {
                MessageBox.Show(userText + " was not found!");
                updateSS(userText + " was not found!");
            }
            tbxSearchBar.Clear();
            tbxSearchBar.Focus();
        }

        private void clearButtons()
        {
            // 9.5	Create a CLEAR method to clear the four text boxes so a new definition can be added
            tbxName.Clear();
            tbxCategory.Clear();
            tbxStructure.Clear();
            tbxDefinition.Clear();
            tbxName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearButtons();            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 9.3	Create an EDIT button that will allow the user to modify any information from the 4 text boxes into the 2D array,
            try
            {
                int index = lvDataStructures.SelectedIndices[0];
                if (index >= 0 && index < dsRows)
                {
                    try
                    {
                        DataStructures[index, 0] = tbxName.Text;
                        DataStructures[index, 1] = tbxCategory.Text;
                        DataStructures[index, 2] = tbxStructure.Text;
                        DataStructures[index, 3] = tbxDefinition.Text;
                        updateSS("Data successfully edited.");
                        displayData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Data unsuccessfully edited\nError Message: " + ex);
                        updateSS("Data unsuccessfully edited\nError Message: " + ex);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to edit.");
                updateSS("Error, nothing selected to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 9.4	Create a DELETE button that removes all the information from a single entry of the array; the user must be prompted before the final deletion occurs, 
            try
            {
                int index = lvDataStructures.SelectedIndices[0];
                string text = DataStructures[index, 0];

                DialogResult dr = MessageBox.Show("Are you sure you want to delete " + DataStructures[index, 0] + "?", "Are you sure you want to delete?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DataStructures[index, 0] = null;
                    DataStructures[index, 1] = null;
                    DataStructures[index, 2] = null;
                    DataStructures[index, 3] = null;
                    updateSS(text + " was deleted.");
                    displayData();
                }
                else if (dr == DialogResult.No)
                {
                    updateSS(text + " wasn't deleted.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, nothing selected to delete.");
                updateSS("Error, nothing selected to delete.");
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 9.2	Create an ADD button that will store the information from the 4 text boxes into the 2D array,
            bool canContinute = false;
            bool isFull = true;
            string txtName = tbxName.Text;
            string txtCat = tbxCategory.Text;
            string txtStruct = tbxStructure.Text;
            string txtDef = tbxDefinition.Text;
            if (!string.IsNullOrEmpty(txtName) && !string.IsNullOrEmpty(txtCat) && !string.IsNullOrEmpty(txtStruct) && !string.IsNullOrEmpty(txtDef))
            {
                canContinute = true;
            }
            else
            {
                MessageBox.Show("ERROR: One of the textboxes; Name, Category, Structure or Definition have no text inside.");
            }
            if (canContinute)
            {
                for (int i = 0; i < dsRows; i++)
                {
                    if (DataStructures[i, 0] == null)
                    {
                        DataStructures[i, 0] = txtName;
                        DataStructures[i, 1] = txtCat;
                        DataStructures[i, 2] = txtStruct;
                        DataStructures[i, 3] = txtDef;
                        updateSS(txtName + " successfully added!");
                        canContinute = false;
                        isFull = false;
                        displayData();
                        break;
                    }
                }
                if (isFull)
                {
                    MessageBox.Show("ERROR: The list is currently full and can't add anymore definitions to it!");
                    updateSS("ERROR: The list is currently full and can't add anymore definitions to it!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 9.10	Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file.
            Sort();
            string dfName = "definitions.dat";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bin file|*.bin";
            saveFileDialog.Title = "Save A BIN file";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "bin";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (saveFileDialog.FileName != "")
            {
                SaveRecord(fileName);
            }
            else
            {
                SaveRecord(dfName);
            }
        }

        private void SaveRecord(string saveFileName)
        {
            // 9.10	Create a SAVE button so the information from the 2D array can be written into a binary file called definitions.dat which is sorted by Name, ensure the user has the option to select an alternative file. Use a file stream and BinaryWriter to create the file.
            try
            {
                using (Stream stream = File.Open(saveFileName, FileMode.Create))
                {;
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        for (int x = 0; x < dsRows; x++)
                        {
                            for (int y = 0; y < dsCols; y++)
                            {
                                writer.Write(DataStructures[x, y]);
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // 9.11	Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "BIN FILES|*.bin";
            openFileDialog.Title = "Open a BIN file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenRecord(openFileDialog.FileName);
            }
        }

        private void OpenRecord(string openFileName)
        {
            // 9.11	Create a LOAD button that will read the information from a binary file called definitions.dat into the 2D array, ensure the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task.
            try
            {
                using (Stream stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {
                        {
                            int x = 0;
                            Array.Clear(DataStructures, 0, DataStructures.Length);
                            while (stream.Position < stream.Length)
                            {
                                for (int y = 0; y < dsCols; y++)
                                {
                                    DataStructures[x, y] = reader.ReadString();
                                }
                                x++;
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
            displayData();
        }

        private void lvDataStructures_DoubleClick(object sender, EventArgs e)
        {
            clearButtons();
        }
    }
}
