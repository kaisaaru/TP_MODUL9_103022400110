using System;

class Program
{
    static void Main(string[] args)
    {
        // Load konfigurasi
        CovidConfig config = new CovidConfig().LoadConfig();

        // Input suhu
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        // Input hari demam
        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        // Validasi suhu berdasarkan satuan yang digunakan
        if (config.satuan_suhu == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5)
                suhuValid = true;
        }
        else // fahrenheit
        {
            if (suhu >= 97.7 && suhu <= 99.5)
                suhuValid = true;
        }

        bool hariValid = hari < config.batas_hari_demam;

        // Output hasil validasi
        if (suhuValid && hariValid)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // TEST METHOD UbahSatuan
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu sekarang: {config.satuan_suhu}");
    }
}