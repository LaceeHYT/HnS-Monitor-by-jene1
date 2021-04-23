using System;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Management;


namespace H_n_S_Monitor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetInstalledApps();
        }

        private void info_button(object sender, RoutedEventArgs e)
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                os.Text = ("Operációs rendszer  -  " + obj["Caption"]);
                win.Text = ("Windows mappa  -  " + obj["WindowsDirectory"]);
                sys.Text = ("Rendszer mappa  -  " + obj["SystemDirectory"]);
                country.Text = ("Országhívószám  -  " + obj["CountryCode"]);
                time.Text = ("Jelenlegi időzóna  -  " + obj["CurrentTimeZone"]);
                encryption.Text = ("Titkosítás szintje  -  " + obj["EncryptionLevel"]);
                type.Text = ("Operációs rendszer típusa  -  " + obj["OSType"]);
                ver.Text = ("Verzió  -  " + obj["Version"]);
            }
        }

        private void gpu_button(object sender, RoutedEventArgs e)
        {
            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                modell.Text = ("Modell  -  " + obj["Name"]);
                id.Text = ("EszközID  -  " + obj["DeviceID"]);
                vram.Text = ("Videomemória (Byte)  -  " + obj["AdapterRAM"]);
                monokrom.Text = ("Monokróm  -  " + obj["Monochrome"]);
                driver.Text = ("Illesztőprogram verzió  -  " + obj["DriverVersion"]);
                proci.Text = ("Video-Processzor  -  " + obj["VideoProcessor"]);
                arch.Text = ("Architektúra  -  " + obj["VideoArchitecture"]);
                memoria.Text = ("Memória típusa  -  " + obj["VideoMemoryType"]);
            }
        }

        private void cpu_button(object sender, RoutedEventArgs e)
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                modelll.Text = ("Modell  -  " + obj["Name"]);
                idd.Text = ("EszközID  -  " + obj["DeviceID"]);
                manu.Text = ("Gyártó  -  " + obj["Manufacturer"]);
                clock.Text = ("Jelenlegi órajel sebesség (MHz)  -  " + obj["CurrentClockSpeed"]);
                core1.Text = ("Magok száma  -  " + obj["NumberOfCores"]);
                core2.Text = ("Engedélyezett magok száma  -  " + obj["NumberOfEnabledCore"]);
                core3.Text = ("Logikai magok száma  -  " + obj["NumberOfLogicalProcessors"]);
                archh.Text = ("Architektúra  -  " + obj["Architecture"]);
            }
        }

        public void GetInstalledApps()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())

                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))

                    {
                        try

                        {
                            listBox.Items.Add(sk.GetValue("DisplayName"));
                        }

                        catch (Exception)

                        { }
                    }
                }
                label.Content = listBox.Items.Count.ToString();
            }
        } 
    }
}
