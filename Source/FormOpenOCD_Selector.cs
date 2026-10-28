using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MCUCapture
{
    // This code is AI-generated!
    public partial class FormOpenOCD_Selector : Form
    {
        private List<string> openOCDPaths = new List<string>();
        private List<string> openOCDCommands = new List<string>();
        private string configFilePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "openocd_config.json");
        private int selectedPathIndex = -1;
        private int selectedCommandIndex = -1;

        public FormOpenOCD_Selector()
        {
            InitializeComponent();
        }

        private void FormOpenOCD_Selector_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
            RefreshPathsGrid();
            RefreshCommandsGrid();
        }

        private void LoadConfiguration()
        {
            if (File.Exists(configFilePath))
            {
                try
                {
                    string json = File.ReadAllText(configFilePath);
                    var config = DeserializeFromJson(json);
                    openOCDPaths = config.Paths ?? new List<string>();
                    openOCDCommands = config.Commands ?? new List<string>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    openOCDPaths = new List<string>();
                    openOCDCommands = new List<string>();
                }
            }
        }

        private void SaveConfiguration()
        {
            try
            {
                var config = new OpenOCDConfig
                {
                    Paths = openOCDPaths,
                    Commands = openOCDCommands
                };
                string json = SerializeToJson(config);
                File.WriteAllText(configFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshPathsGrid()
        {
            dataGridViewPaths.Rows.Clear();
            for (int i = 0; i < openOCDPaths.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewPaths.Rows[dataGridViewPaths.Rows.Add()];
                row.Cells["pathDataGridViewTextBoxColumn"].Value = openOCDPaths[i];
                row.Cells["deletePathDataGridViewTextBoxColumn"].Value = "Delete";

                // Set the checkbox state
                if (i == selectedPathIndex)
                {
                    row.Cells["radioButtonPath"].Value = true;
                }
                else
                {
                    row.Cells["radioButtonPath"].Value = false;
                }
            }
        }

        private void RefreshCommandsGrid()
        {
            dataGridViewCommands.Rows.Clear();
            for (int i = 0; i < openOCDCommands.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewCommands.Rows[dataGridViewCommands.Rows.Add()];
                row.Cells["commandDataGridViewTextBoxColumn"].Value = openOCDCommands[i];
                row.Cells["deleteCommandDataGridViewTextBoxColumn"].Value = "Delete";

                // Set the checkbox state
                if (i == selectedCommandIndex)
                {
                    row.Cells["radioButtonCommand"].Value = true;
                }
                else
                {
                    row.Cells["radioButtonCommand"].Value = false;
                }
            }
        }

        private void btnAddPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            openFileDialog.Title = "Select OpenOCD Executable";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog.FileName;
                if (!openOCDPaths.Contains(selectedPath))
                {
                    openOCDPaths.Add(selectedPath);
                    SaveConfiguration();
                    RefreshPathsGrid();
                }
            }
        }

        private void btnAddCommand_Click(object sender, EventArgs e)
        {
            string newCommand = txtNewCommand.Text.Trim();
            if (!string.IsNullOrEmpty(newCommand))
            {
                if (!openOCDCommands.Contains(newCommand))
                {
                    openOCDCommands.Add(newCommand);
                    SaveConfiguration();
                    RefreshCommandsGrid();
                    txtNewCommand.Text = "";
                }
            }
        }

        private void dataGridViewPaths_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewPaths.Columns["deletePathDataGridViewTextBoxColumn"].Index)
                {
                    // Handle delete button click
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this path?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        openOCDPaths.RemoveAt(e.RowIndex);
                        SaveConfiguration();
                        RefreshPathsGrid();
                    }
                }
                else if (e.ColumnIndex == dataGridViewPaths.Columns["radioButtonPath"].Index)
                {
                    // Handle checkbox selection - ensure only one is selected (radio button behavior)
                    for (int i = 0; i < dataGridViewPaths.Rows.Count; i++)
                    {
                        if (i == e.RowIndex)
                        {
                            dataGridViewPaths.Rows[i].Cells["radioButtonPath"].Value = true;
                            selectedPathIndex = i;
                        }
                        else
                        {
                            dataGridViewPaths.Rows[i].Cells["radioButtonPath"].Value = false;
                        }
                    }
                }
            }
        }

        private void dataGridViewCommands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewCommands.Columns["deleteCommandDataGridViewTextBoxColumn"].Index)
                {
                    // Handle delete button click
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this command?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        openOCDCommands.RemoveAt(e.RowIndex);
                        SaveConfiguration();
                        RefreshCommandsGrid();
                    }
                }
                else if (e.ColumnIndex == dataGridViewCommands.Columns["radioButtonCommand"].Index)
                {
                    // Handle checkbox selection - ensure only one is selected (radio button behavior)
                    for (int i = 0; i < dataGridViewCommands.Rows.Count; i++)
                    {
                        if (i == e.RowIndex)
                        {
                            dataGridViewCommands.Rows[i].Cells["radioButtonCommand"].Value = true;
                            selectedCommandIndex = i;
                        }
                        else
                        {
                            dataGridViewCommands.Rows[i].Cells["radioButtonCommand"].Value = false;
                        }
                    }
                }
            }
        }

        private void btnRunOpenOCD_Click(object sender, EventArgs e)
        {
            if (selectedPathIndex < 0 || selectedPathIndex >= openOCDPaths.Count)
            {
                MessageBox.Show("Please select a path to OpenOCD executable.", "No Path Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedCommandIndex < 0 || selectedCommandIndex >= openOCDCommands.Count)
            {
                MessageBox.Show("Please select a command.", "No Command Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string openOCDPath = openOCDPaths[selectedPathIndex];
            string commandLine = openOCDCommands[selectedCommandIndex];

            // Extract the executable name from the command line
            string[] commandParts = commandLine.Split(' ');
            string executableName = commandParts[0];

            // Combine the path with the executable name
            string fullPath = Path.GetDirectoryName(openOCDPath);
            string executablePath = Path.Combine(fullPath, executableName);

            // Check if the executable exists
            if (!File.Exists(executablePath))
            {
                MessageBox.Show($"Executable not found: {executablePath}", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Build the command line arguments (excluding the executable name)
                string arguments = string.Join(" ", commandParts.Skip(1));

                // Run OpenOCD in a separate console window
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/k cd /d \"{fullPath}\" & \"{executablePath}\" {arguments}",
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting OpenOCD: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region JSON Serialization Helpers

        private string SerializeToJson(OpenOCDConfig config)
        {
            // Simple JSON serialization without external libraries
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");

            // Serialize Paths
            sb.AppendLine("  \"Paths\": [");
            for (int i = 0; i < config.Paths.Count; i++)
            {
                sb.Append("    \"" + EscapeJsonString(config.Paths[i]) + "\"");
                if (i < config.Paths.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            sb.AppendLine("  ],");

            // Serialize Commands
            sb.AppendLine("  \"Commands\": [");
            for (int i = 0; i < config.Commands.Count; i++)
            {
                sb.Append("    \"" + EscapeJsonString(config.Commands[i]) + "\"");
                if (i < config.Commands.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }
            sb.AppendLine("  ]");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private OpenOCDConfig DeserializeFromJson(string json)
        {
            // Simple JSON deserialization without external libraries
            OpenOCDConfig config = new OpenOCDConfig
            {
                Paths = new List<string>(),
                Commands = new List<string>()
            };

            // Extract Paths array
            Match pathsMatch = Regex.Match(json, "\"Paths\"\\s*:\\s*\\[(.*?)\\]", RegexOptions.Singleline);
            if (pathsMatch.Success)
            {
                string pathsContent = pathsMatch.Groups[1].Value;
                MatchCollection pathMatches = Regex.Matches(pathsContent, "\"(.*?)\"");
                foreach (Match match in pathMatches)
                {
                    config.Paths.Add(UnescapeJsonString(match.Groups[1].Value));
                }
            }

            // Extract Commands array
            Match commandsMatch = Regex.Match(json, "\"Commands\"\\s*:\\s*\\[(.*?)\\]", RegexOptions.Singleline);
            if (commandsMatch.Success)
            {
                string commandsContent = commandsMatch.Groups[1].Value;
                MatchCollection commandMatches = Regex.Matches(commandsContent, "\"(.*?)\"");
                foreach (Match match in commandMatches)
                {
                    config.Commands.Add(UnescapeJsonString(match.Groups[1].Value));
                }
            }

            return config;
        }

        private string EscapeJsonString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return str.Replace("\\", "\\\\")
                     .Replace("\"", "\\\"")
                     .Replace("\n", "\\n")
                     .Replace("\r", "\\r")
                     .Replace("\t", "\\t");
        }

        private string UnescapeJsonString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return str.Replace("\\\"", "\"")
                     .Replace("\\n", "\n")
                     .Replace("\\r", "\r")
                     .Replace("\\t", "\t")
                     .Replace("\\\\", "\\");
        }

        #endregion
    }

    public class OpenOCDConfig
    {
        public List<string> Paths { get; set; }
        public List<string> Commands { get; set; }
    }
}
