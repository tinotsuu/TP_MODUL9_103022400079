using System;
using System.IO;
using System.Text.Json;

namespace TP_MODUL9_103022400079
{
    public class ConfigData
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "";
        public string pesan_diterima { get; set; } = "";
    }

    public class CovidConfig
    {
        public ConfigData config = new ConfigData();
        private const string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    config = JsonSerializer.Deserialize<ConfigData>(jsonString) ?? new ConfigData();
                }
                else
                {
                    SetDefault();
                }
            }
            catch (Exception)
            {
                SetDefault();
            }
        }
        private void SetDefault()
        {
            config.satuan_suhu = "celcius";
            config.batas_hari_deman = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }
        public void UbahSatuan()
        {
            config.satuan_suhu = config.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
        }
    }
}