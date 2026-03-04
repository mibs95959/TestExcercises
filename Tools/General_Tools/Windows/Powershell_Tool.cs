using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Tools.General_Tools.Windows
{
    public class Powershell_Tool
    {

        /// <summary>
        /// Runs a PowerShell command and returns the standard output.
        /// Throws an exception if the PowerShell script returns an error.
        /// </summary>
        /// <param name="command">The PowerShell command or script to execute.</param>
        /// <returns>The output string from the console.</returns>
        public static async Task<string> RunPsCommandAsync(string command)
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                // Arguments breakdown:
                // -NoProfile: Prevents loading user profile (faster/safer for automation).
                // -ExecutionPolicy Bypass: Allows running scripts without security prompts.
                // -Command: The actual command to run.
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                // Capture output and errors asynchronously
                process.OutputDataReceived += (sender, args) =>
                {
                    if (args.Data != null) outputBuilder.AppendLine(args.Data);
                };
                process.ErrorDataReceived += (sender, args) =>
                {
                    if (args.Data != null) errorBuilder.AppendLine(args.Data);
                };

                process.Start();

                // Begin reading the streams
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                // Wait for the process to finish
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"PowerShell Error (Exit Code {process.ExitCode}): {errorBuilder}");
                }

                return outputBuilder.ToString().Trim();
            }
        }

        /// <summary>
        /// Runs multiple PowerShell commands sequentially as a single script block.
        /// Uses Base64 encoding to avoid escaping issues with quotes or special characters.
        /// </summary>
        /// <param name="commands">List of commands to run.</param>
        /// <returns>The combined standard output.</returns>
        public static async Task<string> RunPsCommandsAsync(params string[] commands)
        {
            // 1. Join commands with a newline to simulate a script file
            string fullScript = string.Join(Environment.NewLine, commands);

            // 2. Encode the script to Base64 (PowerShell expects Unicode/UTF-16LE)
            // This is crucial to prevent syntax errors if your commands contain quotes " or '
            byte[] scriptBytes = Encoding.Unicode.GetBytes(fullScript);
            string encodedCommand = Convert.ToBase64String(scriptBytes);

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                // -EncodedCommand accepts the Base64 string directly
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedCommand}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                var outputBuilder = new StringBuilder();
                var errorBuilder = new StringBuilder();

                process.OutputDataReceived += (s, e) => { if (e.Data != null) outputBuilder.AppendLine(e.Data); };
                process.ErrorDataReceived += (s, e) => { if (e.Data != null) errorBuilder.AppendLine(e.Data); };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"PowerShell Script Failed (Code {process.ExitCode}):\n{errorBuilder}");
                }

                return outputBuilder.ToString().Trim();
            }
        }

    }
}
