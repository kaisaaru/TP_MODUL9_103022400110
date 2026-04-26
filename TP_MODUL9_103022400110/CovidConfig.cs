using System;
using System.IO;
using System.Text.Json;

class CovidConfig
{
    // Properti sesuai dengan soal
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    // Method untuk load konfigurasi dari file JSON
    public CovidConfig LoadConfig()
    {
        string path = "covid_config.json";

        if (!File.Exists(path))
        {
            // Default value sesuai soal
            return new CovidConfig
            {
                satuan_suhu = "celcius",
                batas_hari_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<CovidConfig>(json);
    }

    // Method untuk mengubah satuan suhu
    public void UbahSatuan()
    {
        if (satuan_suhu == "celcius")
        {
            satuan_suhu = "fahrenheit";
        }
        else
        {
            satuan_suhu = "celcius";
        }
    }
}