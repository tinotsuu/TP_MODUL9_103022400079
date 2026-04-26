using System;

namespace TP_MODUL9_103022400079
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig covidConfig = new CovidConfig();
            covidConfig.UbahSatuan();
            
            do
            {
                Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");

                string? inputSuhu = Console.ReadLine();
                if (string.IsNullOrEmpty(inputSuhu)) break;
                double suhu = double.Parse(inputSuhu);
                Console.Write("Berapa hari yang lalu anda terakhir memiliki gejala deman? ");
                string? inputHari = Console.ReadLine();
                if (string.IsNullOrEmpty(inputHari)) break; 
                int hari = int.Parse(inputHari);
                bool kondisiSuhu = false;
                if (covidConfig.config.satuan_suhu == "celcius")
                {
                    kondisiSuhu = (suhu >= 36.5 && suhu <= 37.5);
                }
                else if (covidConfig.config.satuan_suhu == "fahrenheit")
                {
                    kondisiSuhu = (suhu >= 97.7 && suhu <= 99.5);
                }

                bool kondisiDemam = (hari < covidConfig.config.batas_hari_deman);

                if (kondisiSuhu && kondisiDemam)
                {
                    Console.WriteLine("\n " + covidConfig.config.pesan_diterima);
                }
                else
                {
                    Console.WriteLine("\n " + covidConfig.config.pesan_ditolak);
                }

                Console.WriteLine("----------------------------");

            } while (true) ;

            Console.WriteLine("Program selesai. Sampai jumpa!");
        }
    }
}